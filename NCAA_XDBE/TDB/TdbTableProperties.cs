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
using System.Runtime.InteropServices;

namespace DB_EDITOR
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct TdbTableProperties
    {
        public String Name;
        public int FieldCount;
        public int Capacity;
        public int RecordCount;
        public int DeletedCount;
        public int NextDeletedRecord;
        public bool Flag0;
        public bool Flag1;
        public bool Flag2;
        public bool Flag3;
        public bool NonAllocated;
        public bool HasVarChar;
        public bool HasCompressedVarChar;
    }

}
