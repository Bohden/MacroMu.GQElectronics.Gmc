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

using System.Text;

namespace MacroMu.GQElectronics.Gmc;

/// <inheritdoc/>
public class GmcController : IGmcController
{
    /// <inheritdoc/>
    public bool Disposed { get; private set; } = false;

    private readonly SemaphoreSlim commandSemaphore;

    private readonly IGmcConnection connection;

    /// <summary>
    /// Creates a new Controller for the device on the provided connection.
    /// </summary>
    /// <param name="connection"></param>
    public GmcController(IGmcConnection connection)
    {
        this.connection = connection;
        commandSemaphore = new SemaphoreSlim(1, 1);
    }

    /// <inheritdoc/>
    public async Task DisableAlarmAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.ALARM0;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task DisableEchoAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.EchoOFF;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task DisableHeartbeatAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.HEARTBEAT0;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task DisableSpeakerAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SPEAKER0;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task DisableWiFiAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.WiFiOFF;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc/>
    public async Task EnableAlarmAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.ALARM1;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task EnableEchoAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.EchoON;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task EnableHeartbeatAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SPEAKER0;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task EnableSpeakerAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SPEAKER1;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task EnableWiFiAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.WiFiON;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task FactoryResetAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.FACTORYRESET;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task<byte[]> GetConfigAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.GETCFG;
        string commandId = commandName.ToString();
        byte[] result;

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(512, cancellationToken);

            if (response.Count() != 512)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }

            result = response.ToArray();
        }
        finally
        {
            commandSemaphore.Release();
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<uint> GetCpmAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.GETCPM;
        string commandId = commandName.ToString();
        uint result;

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a data back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(4, cancellationToken);

            if (response.Count() != 4)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }

            result = BitConverter.ToUInt32(GetAdjustedByteOrder(response.ToArray()));
        }
        finally
        {
            commandSemaphore.Release();
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<uint> GetCpmHAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.GETCPMH;
        string commandId = commandName.ToString();
        uint result;

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a data back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(4, cancellationToken);

            if (response.Count() != 4)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }

            result = BitConverter.ToUInt32(GetAdjustedByteOrder(response.ToArray()));
        }
        finally
        {
            commandSemaphore.Release();
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<uint> GetCpmLAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.GETCPML;
        string commandId = commandName.ToString();
        uint result;

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a data back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(4, cancellationToken);

            if (response.Count() != 4)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }

            result = BitConverter.ToUInt32(GetAdjustedByteOrder(response.ToArray()));
        }
        finally
        {
            commandSemaphore.Release();
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<uint> GetCpsAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.GETCPS;
        string commandId = commandName.ToString();
        uint result;

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a data back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(4, cancellationToken);

            if (response.Count() != 4)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }

            result = BitConverter.ToUInt32(GetAdjustedByteOrder(response.ToArray()));
        }
        finally
        {
            commandSemaphore.Release();
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<DateTime> GetDateTimeAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.GETDATETIME;
        string commandId = commandName.ToString();
        DateTime result;

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a data back immediately.
            connection.Send($"<{commandId}>>");
            var response = (await connection.ReadUntilAsync(7, cancellationToken)).ToArray();

            // The documentation states that the year is 2000 plus the return value. No, this won't work after 2255 :(
            int year = 2000 + response[0];
            int month = response[1];
            int day = response[2];
            int hour = response[3];
            int minute = response[4];
            int second = response[5];
            int terminator = response[6];

            if (terminator != 0xAA)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Terminator was invalid. Expected 0xAA got 0x{BitConverter.ToString(new byte[] { (byte)terminator })}");
            }

            result = new(year, month, day, hour, minute, second);
        }
        finally
        {
            commandSemaphore.Release();
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<GyroStatus> GetGyroAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.GETGYRO;
        string commandId = commandName.ToString();
        GyroStatus result;

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a data back immediately.
            connection.Send($"<{commandId}>>");
            var response = (await connection.ReadUntilAsync(7, cancellationToken)).ToArray();

            short x = BitConverter.ToInt16(GetAdjustedByteOrder(response[..2].ToArray()));
            short y = BitConverter.ToInt16(GetAdjustedByteOrder(response[2..4].ToArray()));
            short z = BitConverter.ToInt16(GetAdjustedByteOrder(response[4..6].ToArray()));
            int terminator = response[6];

            if (terminator != 0xAA)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Terminator was invalid. Expected 0xAA got 0x{BitConverter.ToString(new byte[] { (byte)terminator })}");
            }

            result = new(x, y, z);
        }
        finally
        {
            commandSemaphore.Release();
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<byte[]> GetHistoryFromFlashAsync(byte[] address, short count, CancellationToken cancellationToken)
    {
        if (address.Length != 3)
        {
            throw new ArgumentException("Address byte array should be exactly 3 bytes.", nameof(address));
        }

        CommandNames commandName = CommandNames.SPIR;
        string commandId = commandName.ToString();
        byte[] result;

        byte[] countBytes = GetAdjustedByteOrder(BitConverter.GetBytes(count));

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Construct the command string
            string command = $"<{commandId}";

            foreach (var addressByte in address)
            {
                command += (char)addressByte;
            }

            foreach (var countByte in countBytes)
            {
                command += (char)countByte;
            }

            command += ">>";

            // Send the command and expect a data back immediately.
            connection.Send(command);
            var response = await connection.ReadUntilAsync(count, cancellationToken);

            if (response.Count() != count)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }

            result = response.ToArray();
        }
        finally
        {
            commandSemaphore.Release();
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<uint> GetMaxCpsAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.GETMAXCPS;
        string commandId = commandName.ToString();
        uint result;

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a data back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(4, cancellationToken);

            if (response.Count() != 4)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }

            result = BitConverter.ToUInt32(GetAdjustedByteOrder(response.ToArray()));
        }
        finally
        {
            commandSemaphore.Release();
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<string> GetSerialAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.GETSERIAL;
        string commandId = commandName.ToString();
        string result;

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a data back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(7, cancellationToken);

            if (response.Count() != 7)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }

            result = BitConverter.ToString(response.ToArray()).Replace("-", "");
        }
        finally
        {
            commandSemaphore.Release();
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task GetTempAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException("Not currently supported by GMC500 - GMC600+ models.");
    }

    /// <inheritdoc/>
    public async Task<string> GetVersionAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.GETVER;
        string commandId = commandName.ToString();
        string result;

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a data back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(15, cancellationToken);

            result = Encoding.ASCII.GetString(response.ToArray());
        }
        finally
        {
            commandSemaphore.Release();
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<double> GetVoltageAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.GETVOLT;
        string commandId = commandName.ToString();
        double result;

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a data back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(5, cancellationToken);

            result = double.Parse(Encoding.ASCII.GetString(response.ToArray()[..4]));
        }
        finally
        {
            commandSemaphore.Release();
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task GetWiFiLevelAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.WiFiLevel;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task PowerOffAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.POWEROFF;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task PowerOnAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.POWERON;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task PressKeyAsync(int keyId, CancellationToken cancellationToken)
    {
        if (keyId < 0 || keyId > 3)
        {
            throw new ArgumentOutOfRangeException(nameof(keyId), "Valid KeyIds are 0 - 3.");
        }

        CommandNames commandName = CommandNames.POWERON;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}{keyId}>>");
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task RebootAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.REBOOT;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task SetCounterIdAsync(string counterId, CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SETCOUNTERID;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}{counterId}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task SetDateDayAsync(byte day, CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SETDATEDAY;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}{(char)day}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task SetDateMonthAsync(byte month, CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SETDATEMONTH;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}{(char)month}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task SetDateTimeAsync(DateTime datetime, CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SETDATETIME;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        char year = (char)(datetime.Year - 2000);
        char month = (char)datetime.Month;
        char day = (char)datetime.Day;
        char hour = (char)datetime.Hour;
        char minute = (char)datetime.Minute;
        char second = (char)datetime.Second;

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}{year}{month}{day}{hour}{minute}{second}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task SetDateYearAsync(byte year, CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SETDATEYEAR;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}{(char)year}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task SetPeriodAsync(string period, CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SETDATEDAY;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}{period}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task SetSsidAsync(string ssid, CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SETSSID;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}{ssid}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task SetTimeHourAsync(byte hour, CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SETTIMEHOUR;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}{(char)hour}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task SetTimeMinuteAsync(byte minute, CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SETTIMEMINUTE;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}{(char)minute}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task SetTimeSecondAsync(byte second, CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SETTIMESECOND;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}{(char)second}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task SetUrlAsync(string url, CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SETURL;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}{url}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task SetUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SETDATEDAY;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}{userId}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task SetWebSiteAsync(string website, CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SETWEBSITE;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}{website}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task SetWifiPasswordAsync(string password, CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.SETWIFIPW;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}{password}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task UpdateConfigAsync(CancellationToken cancellationToken)
    {
        CommandNames commandName = CommandNames.CFGUPDATE;
        string commandId = commandName.ToString();

        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            // Send the command and expect a byte back immediately.
            connection.Send($"<{commandId}>>");
            var response = await connection.ReadUntilAsync(1, cancellationToken);

            if (response.Count() != 1)
            {
                throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
            }
            else if (response.First() != 0xAA)
            {
                string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
                throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    public async Task WriteConfigAsync(byte[] config, CancellationToken cancellationToken)
    {
        await commandSemaphore.WaitAsync(cancellationToken);

        try
        {
            for (ushort address = 0; address < config.Length; address++)
            {
                var addressBytes = GetAdjustedByteOrder(BitConverter.GetBytes(address));
                await WriteConfigByteAsync(addressBytes, config[address], cancellationToken);
            }
        }
        finally
        {
            commandSemaphore.Release();
        }
    }

    /// <inheritdoc/>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing && !Disposed)
        {
            commandSemaphore?.Dispose();
            Disposed = true;
        }
    }

    /// <summary>
    /// The data back from the device is Big Endian. If
    /// the local processor is little endian, we will
    /// reverse the byte order for numeric parsing.
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    private static byte[] GetAdjustedByteOrder(byte[] bytes)
    {
        byte[] result = bytes;

        if (BitConverter.IsLittleEndian)
        {
            result = bytes.Reverse().ToArray();
        }

        return result;
    }

    private async Task WriteConfigByteAsync(byte[] addressBytes, byte config, CancellationToken cancellationToken)
    {
        if (addressBytes.Length != 2)
        {
            throw new ArgumentException("Address bytes must be 2 bytes in length.", nameof(addressBytes));
        }

        CommandNames commandName = CommandNames.WCFG;
        string commandId = commandName.ToString();

        // Send the command and expect a byte back immediately.
        connection.Send($"<{commandId}{(char)addressBytes[0]}{(char)addressBytes[1]}{(char)config}>>");
        var response = await connection.ReadUntilAsync(1, cancellationToken);

        if (response.Count() != 1)
        {
            throw new GmcUnexpectedResponseException(commandName, $"Invalid number of bytes returned.");
        }
        else if (response.First() != 0xAA)
        {
            string byteAsHex = BitConverter.ToString(new byte[] { response.First() });
            throw new GmcUnexpectedResponseException(commandName, $"Invalid byte value returned. Expected 0xAA but received 0x{byteAsHex}");
        }
    }
}