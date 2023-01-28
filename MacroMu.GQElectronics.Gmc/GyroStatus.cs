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
/// Contains the X, Y, and Z orientation values
/// </summary>
public class GyroStatus
{
    /// <summary>
    /// Indicates the orientation of the GMC on its X axis
    /// </summary>
    public short X { get; set; }

    /// <summary>
    /// Indicates the orientation of the GMC on its Y axis
    /// </summary>
    public short Y { get; set; }

    /// <summary>
    /// Indicates the orientation of the GMC on its Z axis
    /// </summary>
    public short Z { get; set; }

    /// <summary>
    /// Initializes a new GyroStatus object
    /// </summary>
    public GyroStatus(short x, short y, short z)
    {
        X = x;
        Y = y;
        Z = z;
    }
}