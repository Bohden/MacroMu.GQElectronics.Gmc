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

namespace MacroMu.GQElectronics.Gmc;

/// <summary>
/// Control object enabling communication with a GQ brand
/// Geiger Mueller counter with RFC1801-based commands.
/// http://www.gqelectronicsllc.com/download/GQ-RFC1801.txt
/// </summary>
public interface IGmcController : IDisposable
{
    /// <summary>
    /// Indicates if the object is already disposed of
    /// </summary>
    bool Disposed { get; }

    /// <summary>
    /// Disables the alarm that sounds when the CPM
    /// surpasses the set threshold.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DisableAlarmAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Disables serial output from the device that can
    /// be used for debugging; Echo shows the current item
    /// hovered over in menu, or popup messages.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DisableEchoAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Disables the every-second update which provides
    /// CPS information. NOTE: The heartbeat is not well
    /// supported with this library. The preferred method
    /// is to call GetCPS() manually.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DisableHeartbeatAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Disables the speaker from clicking when the
    /// detector is triggered.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DisableSpeakerAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Turns off the WiFi module.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DisableWiFiAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Enables the alarm that sounds when CPM exceeds
    /// the threshold set in the device.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task EnableAlarmAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Enables debugging output on the serial port from
    /// the device. Shows things like menu item under
    /// the cursor and popup messages.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task EnableEchoAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Enables the every-second heartbeat which
    /// displays the number of counts in that second.
    /// NOTE: this library does not support the
    /// heartbeat very well, and the preferred
    /// method is to call GetCPS() directly
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task EnableHeartbeatAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Enables the speaker to click when the device
    /// registers a count.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task EnableSpeakerAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Enables the WiFi module.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task EnableWiFiAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Resets the device to factory defaults.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task FactoryResetAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Gets the configuration from the device
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>512 byte array of config data.</returns>
    Task<byte[]> GetConfigAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Returns the currently displayed counts
    /// per minute.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<uint> GetCpmAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Returns the current counts per minute
    /// from the high tube.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<uint> GetCpmHAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Returns the current counts per minute
    /// from the low tube.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<uint> GetCpmLAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Returns the current counts per second.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<uint> GetCpsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Returns the current date and time
    /// from the device's clock.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<DateTime> GetDateTimeAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Gets the current orientation of the device.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<GyroStatus> GetGyroAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Gets the Counts per Second history from
    /// the device at a given address.
    /// </summary>
    /// <param name="address"></param>
    /// <param name="count"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<byte[]> GetHistoryFromFlashAsync(byte[] address, short count, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the maximum recorded counts per
    /// second currently stored in memory.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<uint> GetMaxCpsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Gets the serial number from the device.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string> GetSerialAsync(CancellationToken cancellationToken);

    /// <summary>
    /// If supported, returns the temperature as
    /// recorded by the device.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task GetTempAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Gets the model and revision of the device.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string> GetVersionAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Get the current battery voltage.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<double> GetVoltageAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Get the WiFi signal strength.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task GetWiFiLevelAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Turn the device off.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task PowerOffAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Turn the device on.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task PowerOnAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Registers as a key-press on the device, with
    /// key 0 being BACK and key 3 being POWER.
    /// </summary>
    /// <param name="keyId">Key number, 0 through 3</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task PressKeyAsync(int keyId, CancellationToken cancellationToken);

    /// <summary>
    /// Restarts the device.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task RebootAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Sets the Counter ID that is used on the
    /// measurement tracking website.
    /// </summary>
    /// <param name="counterId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SetCounterIdAsync(string counterId, CancellationToken cancellationToken);

    /// <summary>
    /// Set the day of the month.
    /// </summary>
    /// <param name="day"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SetDateDayAsync(byte day, CancellationToken cancellationToken);

    /// <summary>
    /// Set the month of the year.
    /// </summary>
    /// <param name="month"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SetDateMonthAsync(byte month, CancellationToken cancellationToken);

    /// <summary>
    /// Set the full date and time on
    /// the device's clock.
    /// </summary>
    /// <param name="datetime"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SetDateTimeAsync(DateTime datetime, CancellationToken cancellationToken);

    /// <summary>
    /// Set the number of years since 2000.
    /// 2023 would be just 23.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SetDateYearAsync(byte year, CancellationToken cancellationToken);

    /// <summary>
    /// Set the period.
    /// </summary>
    /// <param name="period"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SetPeriodAsync(string period, CancellationToken cancellationToken);

    /// <summary>
    /// Set the SSID of the WiFi network to
    /// connect to.
    /// </summary>
    /// <param name="ssid"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SetSsidAsync(string ssid, CancellationToken cancellationToken);

    /// <summary>
    /// Set the hour on the device's clock.
    /// </summary>
    /// <param name="hour"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SetTimeHourAsync(byte hour, CancellationToken cancellationToken);

    /// <summary>
    /// Set the minute on the device's clock.
    /// </summary>
    /// <param name="minute"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SetTimeMinuteAsync(byte minute, CancellationToken cancellationToken);

    /// <summary>
    /// Set the second on the device's clock.
    /// </summary>
    /// <param name="second"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SetTimeSecondAsync(byte second, CancellationToken cancellationToken);

    /// <summary>
    /// Set the URL the device will post measurement
    /// data to.
    /// </summary>
    /// <param name="url"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SetUrlAsync(string url, CancellationToken cancellationToken);

    /// <summary>
    /// Set the UserId to use on the measurement site.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SetUserIdAsync(string userId, CancellationToken cancellationToken);

    /// <summary>
    /// Set the website
    /// </summary>
    /// <param name="website"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SetWebSiteAsync(string website, CancellationToken cancellationToken);

    /// <summary>
    /// Set the password for the WiFi network to connect
    /// to. NOTE: the WiFi password may be stored
    /// as plan-text on the device.
    /// </summary>
    /// <param name="password"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SetWifiPasswordAsync(string password, CancellationToken cancellationToken);

    /// <summary>
    /// Update any configuration changes that have been
    /// written to the device.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateConfigAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Write bytes to the device's configuration
    /// </summary>
    /// <param name="config"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task WriteConfigAsync(byte[] config, CancellationToken cancellationToken);
}