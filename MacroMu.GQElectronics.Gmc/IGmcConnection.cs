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

namespace MacroMu.GQElectronics.Gmc;

/// <summary>
/// Connection interface for communication with the GQ GMC-500
/// through 600+ geiger counters. Implementations of this interface
/// should be used as a tx/rx level interface, with higher order
/// objects constructing messages and determining which methods to
/// communicate with.
/// </summary>
public interface IGmcConnection : IDisposable
{
    /// <summary>
    /// Indicates if the object has been disposed.
    /// </summary>
    bool IsDisposed { get; }

    /// <summary>
    /// Indicates if the underlying Serial Port is available and open.
    /// </summary>
    bool IsOpen { get; }

    /// <summary>
    /// Closes the underlying serial port. Does not wait for async
    /// operations to complete.
    /// </summary>
    void Close();

    /// <summary>
    /// Closes the underlying serial port. Waits until read and write
    /// operations have completed, or the cancellation token to request
    /// cancellation.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task CloseAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Opens the underlying serial port to the GQ device.
    /// </summary>
    /// <param name="portName"></param>
    /// <param name="baudRate"></param>
    /// <param name="parity"></param>
    /// <param name="dataBits"></param>
    /// <param name="stopBits"></param>
    /// <param name="handshake"></param>
    void Open(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits, Handshake handshake);

    /// <summary>
    /// Read from the receive buffer.
    /// </summary>
    /// <returns></returns>
    byte[] Read();

    /// <summary>
    /// Read from the receive buffer into an array.
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="offset"></param>
    /// <param name="count"></param>
    void ReadIntoBuffer(byte[] buffer, int offset, int count);

    /// <summary>
    /// Reads from the recieve buffer until the requisite number of bytes
    /// has been received.
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    IEnumerable<byte> ReadUntil(int count);

    /// <summary>
    /// Reads from the device until the stop sequence has been detected.
    /// </summary>
    /// <param name="stopSequence"></param>
    /// <returns></returns>
    IEnumerable<byte> ReadUntil(string stopSequence);

    /// <summary>
    /// Reads from the recieve buffer until the requisite number of bytes
    /// has been received.
    /// </summary>
    /// <param name="count"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<byte>> ReadUntilAsync(int count, CancellationToken cancellationToken);

    /// <summary>
    /// Read from the device until the stop sequence has been detected.
    /// </summary>
    /// <param name="stopSequence"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<byte>> ReadUntilAsync(string stopSequence, CancellationToken cancellationToken);

    /// <summary>
    /// Sends a command to the device.
    /// </summary>
    /// <param name="command"></param>
    void Send(string command);
}