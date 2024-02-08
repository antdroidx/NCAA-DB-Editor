/******************************************************************************
 * MaddenAmp
 * Copyright (C) 2005 Colin Goudie
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 *
 * http://maddenamp.sourceforge.net/
 * 
 * maddeneditor@tributech.com.au
 * 
 *****************************************************************************/
using System;
using System.Runtime.InteropServices;

namespace DB_EDITOR
{
    public enum TdbFieldType { tdbString = 0, tdbBinary = 1, tdbSInt = 2, tdbUInt = 3, tdbFloat = 4, tdbVarchar = 0xD, tdbLongVarchar = 0xE, tdbInt = 0x2CE };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TdbFieldProperties
    {
        public String Name;
        public int Size;
        public TdbFieldType FieldType;
    }
}
