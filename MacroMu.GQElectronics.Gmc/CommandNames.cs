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
/// The commands documented by RFC1801
/// </summary>
public enum CommandNames
{
    /// <summary>
    /// Disable Alarm
    /// </summary>
    ALARM0,
    /// <summary>
    /// Enable Alarm
    /// </summary>
    ALARM1,
    /// <summary>
    /// AT prefix for ESP8266 WiFi module
    /// </summary>
    AT,
    /// <summary>
    /// Update configuration
    /// </summary>
    CFGUPDATE,
    /// <summary>
    /// Erase configuration
    /// </summary>
    ECFG,
    /// <summary>
    /// Turn off serial debug echo
    /// </summary>
    EchoOFF,
    /// <summary>
    /// Turn on serial debug echo
    /// </summary>
    EchoON,
    /// <summary>
    /// Restore the device to factory defaults
    /// </summary>
    FACTORYRESET,
    /// <summary>
    /// Get the current configuration
    /// </summary>
    GETCFG,
    /// <summary>
    /// Get current counts per minute
    /// </summary>
    GETCPM,
    /// <summary>
    /// Get current high tube counts per minute
    /// </summary>
    GETCPMH,
    /// <summary>
    /// Get current low tube counts per minute
    /// </summary>
    GETCPML,
    /// <summary>
    /// Get current counts per second
    /// </summary>
    GETCPS,
    /// <summary>
    /// Get the device clock's current date and time
    /// </summary>
    GETDATETIME,
    /// <summary>
    /// Get the device's current orientation
    /// </summary>
    GETGYRO,
    /// <summary>
    /// Get the max recorded counts per second
    /// </summary>
    GETMAXCPS,
    /// <summary>
    /// Get the device's serial number
    /// </summary>
    GETSERIAL,
    /// <summary>
    /// Get the temperature from the device. UNSUPPORTED AT PRESENT.
    /// </summary>
    GETTEMP,
    /// <summary>
    /// Get the model and firmware version of the device
    /// </summary>
    GETVER,
    /// <summary>
    /// Get the battery voltage
    /// </summary>
    GETVOLT,
    /// <summary>
    /// Disable the every-second heartbeat
    /// </summary>
    HEARTBEAT0,
    /// <summary>
    /// Enable the every-second heartbeat
    /// </summary>
    HEARTBEAT1,
    /// <summary>
    /// Force a key-press
    /// </summary>
    KEY,
    /// <summary>
    /// Turn the device off
    /// </summary>
    POWEROFF,
    /// <summary>
    /// Turn the device on
    /// </summary>
    POWERON,
    /// <summary>
    /// Restart the device
    /// </summary>
    REBOOT,
    /// <summary>
    /// Set the CounterID used by the remote server
    /// </summary>
    SETCOUNTERID,
    /// <summary>
    /// Set the device clock's current day
    /// </summary>
    SETDATEDAY,
    /// <summary>
    /// Set the device clock's current month
    /// </summary>
    SETDATEMONTH,
    /// <summary>
    /// Set the device clock'c current date and time
    /// </summary>
    SETDATETIME,
    /// <summary>
    /// Set the device clock's current year
    /// </summary>
    SETDATEYEAR,
    /// <summary>
    /// Set the device's period
    /// </summary>
    SETPERIOD,
    /// <summary>
    /// Set the WiFi SSID for the device to connect to
    /// </summary>
    SETSSID,
    /// <summary>
    /// Set the device clock's current hour
    /// </summary>
    SETTIMEHOUR,
    /// <summary>
    /// Set the device clock's current minute
    /// </summary>
    SETTIMEMINUTE,
    /// <summary>
    /// Set the device clock'c current second
    /// </summary>
    SETTIMESECOND,
    /// <summary>
    /// Set the URL to post measurement data to
    /// </summary>
    SETURL,
    /// <summary>
    /// Set the UserID to use when posting data to the measurement collection server
    /// </summary>
    SETUSERID,
    /// <summary>
    /// Set the website to post measurement data to
    /// </summary>
    SETWEBSITE,
    /// <summary>
    /// Set the password to use when the device connects to a WiFi network
    /// </summary>
    SETWIFIPW,
    /// <summary>
    /// Disable the speaker that chirps on count
    /// </summary>
    SPEAKER0,
    /// <summary>
    /// Enable the speaker that chirps on count
    /// </summary>
    SPEAKER1,
    /// <summary>
    /// Get historical data from flash memory
    /// </summary>
    SPIR,
    /// <summary>
    /// Write to the device's configuration
    /// </summary>
    WCFG,
    /// <summary>
    /// Get the current WiFi connection level
    /// </summary>
    WiFiLevel,
    /// <summary>
    /// Disable the WiFi module
    /// </summary>
    WiFiOFF,
    /// <summary>
    /// Enable the WiFi module
    /// </summary>
    WiFiON
}