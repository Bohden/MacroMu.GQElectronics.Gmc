/*
    Copyright (C) 2022  MacroMu, LLC.

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
 
 */

using System.IO.Ports;
using System.Text;

namespace MacroMu.GQElectronics.Gmc;

/// <summary>
/// Default implementation of the IGqConnection object.
/// </summary>
public class GmcConnection : IGmcConnection
{
    /// <inheritdoc/>
    public bool IsDisposed { get; private set; }

    /// <inheritdoc/>
    public bool IsOpen => serialPort?.IsOpen ?? false;

    private readonly SemaphoreSlim rxSemaphore;
    private readonly SemaphoreSlim txSemaphore;

    private SerialPort? serialPort;

    /// <summary>
    /// Creates a new, uninitialized connection object.
    /// </summary>
    public GmcConnection()
    {
        IsDisposed = false;

        txSemaphore = new(1);
        rxSemaphore = new(1);
    }

    /// <summary>
    /// Creates a new connection object, and attempts to open the underlying serial port.
    /// </summary>
    /// <param name="portName"></param>
    /// <param name="baudRate"></param>
    /// <param name="parity"></param>
    /// <param name="dataBits"></param>
    /// <param name="stopBits"></param>
    /// <param name="handshake"></param>
    public GmcConnection(string portName, int baudRate = 115200, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One, Handshake handshake = Handshake.None) : this()
    {
        Open(portName, baudRate, parity, dataBits, stopBits, handshake);
    }

    /// <inheritdoc/>
    public void Close()
    {
        if (IsOpen)
        {
            serialPort!.Close();
        }
    }

    /// <inheritdoc/>
    public async Task CloseAsync(CancellationToken cancellationToken)
    {
        if (IsOpen)
        {
            await txSemaphore.WaitAsync(cancellationToken);
            await rxSemaphore.WaitAsync(cancellationToken);

            serialPort!.Close();
            rxSemaphore.Release();
            txSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc/>
    public void Open(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits, Handshake handshake)
    {
        if (serialPort?.IsOpen ?? false)
        {
            throw new InvalidOperationException("GQ connection is already open.");
        }

        if (serialPort != null)
        {
            serialPort?.Dispose();
        }

        serialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits)
        {
            Handshake = handshake
        };

        serialPort.Open();
    }

    /// <inheritdoc/>
    public byte[] Read()
    {
        rxSemaphore.Wait();

        ThrowIfNotOpen();

        byte[] receivedBytes = new byte[serialPort!.ReadBufferSize];

        try
        {
            serialPort!.Read(receivedBytes, 0, receivedBytes.Length);
        }
        finally
        {
            rxSemaphore.Release();
        }

        return receivedBytes;
    }

    /// <inheritdoc/>
    public void ReadIntoBuffer(byte[] buffer, int offset, int count)
    {
        ThrowIfNotOpen();

        rxSemaphore.Wait();

        try
        {
            serialPort!.Read(buffer, offset, count);
        }
        finally
        {
            rxSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public IEnumerable<byte> ReadUntil(string stopSequence)
    {
        List<byte> receivedBytes = new();

        string stopSequenceCheck = "";

        rxSemaphore.Wait();

        try
        {
            while (true)
            {
                ThrowIfNotOpen();

                if (serialPort!.ReadBufferSize == 0)
                {
                    Task.Delay(50).Wait();
                    continue;
                }

                try
                {
                    // Read the inbound data. If it looks like it could be the cutoff, add it to the check string.
                    // In the event it's not, writ it to the received bytes. We do NOT return the terminator to the client
                    byte nextByte = (byte)serialPort!.ReadByte();
                    string nextChar = Encoding.ASCII.GetString(new byte[1] { nextByte });

                    stopSequenceCheck += nextChar;

                    if (stopSequenceCheck == stopSequence)
                    {
                        // If we hit the stop sequence, break out
                        break;
                    }
                    if (!stopSequenceCheck.StartsWith(stopSequenceCheck))
                    {
                        // If the characters read have nothing to do with the stop sequence, flush to buffer and reset check
                        receivedBytes.AddRange(Encoding.ASCII.GetBytes(stopSequenceCheck));

                        stopSequenceCheck = "";
                    }
                }
                catch
                {
                    break;
                }
            }
        }
        finally
        {
            rxSemaphore.Release();
        }

        return receivedBytes;
    }

    /// <inheritdoc/>
    public IEnumerable<byte> ReadUntil(int count)
    {
        List<byte> receivedBytes = new();

        rxSemaphore.Wait();

        try
        {
            while (receivedBytes.Count < count)
            {
                ThrowIfNotOpen();

                if (serialPort!.ReadBufferSize == 0)
                {
                    Task.Delay(50).Wait();
                    continue;
                }

                receivedBytes.Add((byte)serialPort!.ReadByte());
            }
        }
        finally
        {
            rxSemaphore.Release();
        }

        return receivedBytes;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<byte>> ReadUntilAsync(int count, CancellationToken cancellationToken)
    {
        List<byte> receivedBytes = new();

        rxSemaphore.Wait();

        try
        {
            while (receivedBytes.Count < count)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    throw new OperationCanceledException();
                }

                ThrowIfNotOpen();

                if (serialPort!.ReadBufferSize == 0)
                {
                    await Task.Delay(50, cancellationToken);
                    continue;
                }

                receivedBytes.Add((byte)serialPort!.ReadByte());
            }
        }
        finally
        {
            rxSemaphore.Release();
        }

        return receivedBytes;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<byte>> ReadUntilAsync(string stopSequence, CancellationToken cancellationToken)
    {
        List<byte> receivedBytes = new();

        string stopSequenceCheck = "";

        rxSemaphore.Wait(cancellationToken);

        try
        {
            while (true)
            {
                ThrowIfNotOpen();

                if (cancellationToken.IsCancellationRequested)
                {
                    throw new OperationCanceledException();
                }

                if (serialPort!.ReadBufferSize == 0)
                {
                    await Task.Delay(50, cancellationToken);
                    continue;
                }

                try
                {
                    // Read the inbound data. If it looks like it could be the cutoff, add it to the check string.
                    // In the event it's not, writ it to the received bytes. We do NOT return the terminator to the client
                    byte nextByte = (byte)serialPort!.ReadByte();
                    string nextChar = Encoding.ASCII.GetString(new byte[1] { nextByte });

                    stopSequenceCheck += nextChar;

                    if (stopSequenceCheck == stopSequence)
                    {
                        // If we hit the stop sequence, break out
                        break;
                    }
                    if (!stopSequenceCheck.StartsWith(stopSequenceCheck))
                    {
                        // If the characters read have nothing to do with the stop sequence, flush to buffer and reset check
                        receivedBytes.AddRange(Encoding.ASCII.GetBytes(stopSequenceCheck));

                        stopSequenceCheck = "";
                    }
                }
                catch
                {
                    break;
                }
            }
        }
        finally
        {
            rxSemaphore.Release();
        }

        return receivedBytes;
    }

    /// <inheritdoc/>
    public void Send(string command)
    {
        txSemaphore.Wait();

        ThrowIfNotOpen();

        byte[] commandBytes = Encoding.ASCII.GetBytes(command);

        serialPort!.Write(commandBytes, 0, command.Length);

        txSemaphore.Release();
    }

    /// <summary>
    /// Disposes of the managed objects created within this object's scope.
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            serialPort?.Dispose();
            txSemaphore?.Dispose();
            rxSemaphore?.Dispose();

            IsDisposed = true;
        }
    }

    private void ThrowIfNotOpen()
    {
        if (!IsOpen)
        {
            throw new InvalidOperationException("Cannot send to GQ device when connection is not open.");
        }
    }
}