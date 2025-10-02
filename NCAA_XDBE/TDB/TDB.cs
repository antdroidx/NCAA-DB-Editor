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
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DB_EDITOR
{
    /// <summary>
    /// This class contains the static methods to use the tdbaccess.dll. The instructions
    /// on how to use these function are contained in the help file that comes with the
    /// dll.
    /// </summary>
    static class TDB
    {
        #region tdbaccess original functions
        private const string TDBACCESS_DLL = @"resources\tdbaccess.dll";

        [DllImport(TDBACCESS_DLL, CharSet = CharSet.Unicode)]
        public static extern int TDBOpen(string FileName);

        [DllImport(TDBACCESS_DLL)]
        public static extern bool TDBClose(int DBIndex);

        [DllImport(TDBACCESS_DLL)]
        public static extern bool TDBSave(int DBIndex);

        [DllImport(TDBACCESS_DLL)]
        public static extern bool TDBDatabaseCompact(int DBIndex);

        [DllImport(TDBACCESS_DLL)]
        public static extern int TDBDatabaseGetTableCount(int DBIndex);

        [DllImport(TDBACCESS_DLL, CharSet = CharSet.Unicode)]
        public static extern bool TDBFieldGetProperties(int DBIndex, string TableName, int FieldIndex, ref TdbFieldProperties FieldProperties);

        [DllImport(TDBACCESS_DLL)]
        public static extern bool TDBTableGetProperties(int DBIndex, int TableIndex, ref TdbTableProperties TableProperties);

        [DllImport(TDBACCESS_DLL, CharSet = CharSet.Unicode)]
        public static extern bool TDBFieldGetValueAsBinary(int DBIndex, string TableName, string FieldName, int RecNo, ref string OutBuffer);

        [DllImport(TDBACCESS_DLL, CharSet = CharSet.Unicode)]
        public static extern float TDBFieldGetValueAsFloat(int DBIndex, string TableName, string FieldName, int RecNo);

        [DllImport(TDBACCESS_DLL, CharSet = CharSet.Unicode)]
        public static extern int TDBFieldGetValueAsInteger(int DBIndex, string TableName, string FieldName, int RecNo);

        [DllImport(TDBACCESS_DLL, CharSet = CharSet.Unicode)]
        public static extern bool TDBFieldGetValueAsString(int DBIndex, string TableName, string FieldName, int RecNo, ref string OutBuffer);

        [DllImport(TDBACCESS_DLL, CharSet = CharSet.Unicode)]
        public static extern bool TDBFieldSetValueAsFloat(int DBIndex, string TableName, string FieldName, int RecNo, float NewValue);

        [DllImport(TDBACCESS_DLL, CharSet = CharSet.Unicode)]
        public static extern bool TDBFieldSetValueAsInteger(int DBIndex, string TableName, string FieldName, int RecNo, int NewValue);

        [DllImport(TDBACCESS_DLL, CharSet = CharSet.Unicode)]
        public static extern bool TDBFieldSetValueAsString(int DBIndex, string TableName, string FieldName, int RecNo, string NewValue);

        [DllImport(TDBACCESS_DLL, CharSet = CharSet.Unicode)]
        public static extern int TDBQueryFindUnsignedInt(int DBIndex, string TableName, string FieldName, int Value);

        [DllImport(TDBACCESS_DLL)]
        public static extern int TDBQueryGetResult(int Index);

        [DllImport(TDBACCESS_DLL)]
        public static extern int TDBQueryGetResultSize();

        [DllImport(TDBACCESS_DLL, CharSet = CharSet.Unicode)]
        public static extern int TDBTableRecordAdd(int DBIndex, string TableName, bool AllowExpand);

        [DllImport(TDBACCESS_DLL, CharSet = CharSet.Unicode)]
        public static extern bool TDBTableRecordChangeDeleted(int DBIndex, string TableName, int RecNo, bool Deleted);

        [DllImport(TDBACCESS_DLL, CharSet = CharSet.Unicode)]
        public static extern bool TDBTableRecordDeleted(int DBIndex, string TableName, int RecNo);

        [DllImport(TDBACCESS_DLL, CharSet = CharSet.Unicode)]
        public static extern bool TDBTableRecordRemove(int DBIndex, string TableName, int RecNo);

        [DllImport(TDBACCESS_DLL, CharSet = CharSet.Unicode)]
        public static extern bool TDBTableChangeCapacity(int DBIndex, string TableName, int NewCapacity);


        #endregion

        #region user added functions
        public static int TableCount(int DBIndex)
        {//Get the table count of db.

            int tmpCount = TDB.TDBDatabaseGetTableCount(DBIndex);

            return tmpCount;
        }
        public static int TableIndex(int DBIndex, string TableName)
        {//Get the table index from the table name and db file..

            int tmpIndex = -1;

            #region Get TABLE Properties
            TdbTableProperties tableProps = new TdbTableProperties();
            tableProps.Name = new string((char)0, 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(DBIndex);

            for (int tmpTableIndex = 0; tmpTableIndex < tmpTableCount; tmpTableIndex++)
            {
                TDB.TDBTableGetProperties(DBIndex, tmpTableIndex, ref tableProps);

                if (tableProps.Name == TableName)
                {
                    tmpIndex = tmpTableIndex;
                    break;
                }
            }
            #endregion

            return tmpIndex;
        }
        public static int TableRecordCount(int DBIndex, string TableName)
        {//Get the table index from the table name and db file..

            int recCount = -1;

            #region Get TABLE Properties
            TdbTableProperties tableProps = new TdbTableProperties();
            tableProps.Name = new string((char)0, 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(DBIndex);

            for (int tmpTableIndex = 0; tmpTableIndex < tmpTableCount; tmpTableIndex++)
            {
                TDB.TDBTableGetProperties(DBIndex, tmpTableIndex, ref tableProps);

                if (tableProps.Name == TableName)
                    break;
            }
            #endregion

            return recCount = tableProps.RecordCount;

        }

        public static int TableCapacity(int DBIndex, string TableName)
        {//Get the table index from the table name and db file..

            int capacity = -1;

            #region Get TABLE Properties
            TdbTableProperties tableProps = new TdbTableProperties();
            tableProps.Name = new string((char)0, 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(DBIndex);

            for (int tmpTableIndex = 0; tmpTableIndex < tmpTableCount; tmpTableIndex++)
            {
                TDB.TDBTableGetProperties(DBIndex, tmpTableIndex, ref tableProps);

                if (tableProps.Name == TableName)
                    break;
            }
            #endregion

            return capacity = tableProps.Capacity;

        }

        public static int FieldCount(int DBIndex, string TableName)
        {//Get the field count from table name and db file.

            int tmpCount = -1;

            #region Get TABLE Properties
            TdbTableProperties tableProps = new TdbTableProperties();
            tableProps.Name = new string((char)0, 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(DBIndex);

            for (int tmpTableIndex = 0; tmpTableIndex < tmpTableCount; tmpTableIndex++)
            {
                TDB.TDBTableGetProperties(DBIndex, tmpTableIndex, ref tableProps);

                if (tableProps.Name == TableName)
                    break;
            }
            #endregion

            return tmpCount = tableProps.FieldCount;
        }
        public static int FieldIndex(int DBIndex, string TableName, string FieldName)
        {//Get the field index from the field name of the table name and db file.

            int tmpCount = -1;

            #region Get TABLE Properties
            TdbTableProperties tableProps = new TdbTableProperties();
            tableProps.Name = new string((char)0, 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(DBIndex);

            for (int tmpTableIndex = 0; tmpTableIndex < tmpTableCount; tmpTableIndex++)
            {
                TDB.TDBTableGetProperties(DBIndex, tmpTableIndex, ref tableProps);

                if (tableProps.Name == TableName)
                    break;
            }
            #endregion

            #region Get FIELD Properties
            TdbFieldProperties fieldProps = new TdbFieldProperties();
            fieldProps.Name = new string((char)0, 5);

            int tmpFieldCount = tableProps.FieldCount;
            for (int tmpFieldIndex = 0; tmpFieldIndex < tmpFieldCount; tmpFieldIndex++)
            {
                TDB.TDBFieldGetProperties(DBIndex, tableProps.Name, tmpFieldIndex, ref fieldProps);
                if (fieldProps.Name == FieldName)
                {
                    tmpCount = tmpFieldIndex;
                    break;
                }
            }
            #endregion

            return tmpCount;
        }
        public static string FieldValue(int DBIndex, string TableName, string FieldName, int RecNo)
        {
            string tmpValue = "";

            #region Get TABLE Properties
            TdbTableProperties tableProps = new TdbTableProperties();
            tableProps.Name = new string((char)0, 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(DBIndex);

            for (int tmpTableIndex = 0; tmpTableIndex < tmpTableCount; tmpTableIndex++)
            {
                TDB.TDBTableGetProperties(DBIndex, tmpTableIndex, ref tableProps);

                if (tableProps.Name == TableName)
                    break;
            }
            #endregion

            #region Get FIELD Properties
            TdbFieldProperties fieldProps = new TdbFieldProperties();
            fieldProps.Name = new string((char)0, 5);

            int tmpFieldCount = tableProps.FieldCount;
            for (int tmpFieldIndex = 0; tmpFieldIndex < tmpFieldCount; tmpFieldIndex++)
            {
                TDB.TDBFieldGetProperties(DBIndex, tableProps.Name, tmpFieldIndex, ref fieldProps);
                if (fieldProps.Name == FieldName)
                    break;
            }
            #endregion

            if (fieldProps.FieldType == TdbFieldType.tdbString)
            {
                // I think Values that are a string might have to be formatted to a specific length
                // it probably has something to do with the language he made the dll with
                string val = new string((char)0, (fieldProps.Size / 8) + 1);

                TDB.TDBFieldGetValueAsString(DBIndex, tableProps.Name, fieldProps.Name, RecNo, ref val);
                val = val.Replace(",", "-");
                tmpValue = val;
            }
            else if (fieldProps.FieldType == TdbFieldType.tdbUInt)
            {
                UInt32 intval;
                intval = (UInt32)TDB.TDBFieldGetValueAsInteger(DBIndex, tableProps.Name, fieldProps.Name, RecNo);
                tmpValue = Convert.ToString(intval);
            }
            else if (fieldProps.FieldType == TdbFieldType.tdbInt || fieldProps.FieldType == TdbFieldType.tdbSInt)
            {
                Int32 signedval;
                signedval = TDB.TDBFieldGetValueAsInteger(DBIndex, tableProps.Name, fieldProps.Name, RecNo);
                tmpValue = Convert.ToString(signedval);
            }
            else if (fieldProps.FieldType == TdbFieldType.tdbFloat)
            {
                float floatval;
                floatval = TDB.TDBFieldGetValueAsFloat(DBIndex, tableProps.Name, fieldProps.Name, RecNo);
                tmpValue = Convert.ToString(floatval);
            }
            else if (fieldProps.FieldType == TdbFieldType.tdbBinary || fieldProps.FieldType == TdbFieldType.tdbVarchar || fieldProps.FieldType == TdbFieldType.tdbLongVarchar)
            {
                string val = new string((char)0, (fieldProps.Size / 8) + 1);
                TDB.TDBFieldGetValueAsString(DBIndex, tableProps.Name, fieldProps.Name, RecNo, ref val);
                tmpValue = val;
            }
            else
            {
                tmpValue = "n/a";
            }

            return tmpValue;
        }
        public static string NewfieldValue(int DBIndex, string TableName, string FieldName, int RecNo, string newValue)
        {//Set the field value of a record.

            string xValue = "-1";

            #region Get TABLE Properties
            TdbTableProperties tableProps = new TdbTableProperties();
            tableProps.Name = new string((char)0, 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(DBIndex);

            for (int tmpTableIndex = 0; tmpTableIndex < tmpTableCount; tmpTableIndex++)
            {
                TDB.TDBTableGetProperties(DBIndex, tmpTableIndex, ref tableProps);

                if (tableProps.Name == TableName)
                    break;
            }
            #endregion

            #region Get FIELD Properties
            TdbFieldProperties fieldProps = new TdbFieldProperties();
            fieldProps.Name = new string((char)0, 5);

            int tmpFieldCount = tableProps.FieldCount;
            for (int tmpFieldIndex = 0; tmpFieldIndex < tmpFieldCount; tmpFieldIndex++)
            {
                TDB.TDBFieldGetProperties(DBIndex, tableProps.Name, tmpFieldIndex, ref fieldProps);
                if (fieldProps.Name == FieldName)
                    break;
            }
            #endregion

            if (fieldProps.FieldType == TdbFieldType.tdbString)
            {
                // I think Values that are a string might have to be formatted to a specific length
                // it probably has something to do with the language he made the dll with
                string val = new string((char)0, (fieldProps.Size / 8) + 1);

                if (!TDB.TDBFieldSetValueAsString(DBIndex, tableProps.Name, fieldProps.Name, RecNo, newValue))
                {
                    xValue = "xXx";
                }

            }
            else if (fieldProps.FieldType == TdbFieldType.tdbUInt)
            {
                if (!TDB.TDBFieldSetValueAsInteger(DBIndex, tableProps.Name, fieldProps.Name, RecNo, (int)Convert.ToUInt32(newValue)))
                {
                    xValue = "xXx";
                }
            }
            else if (fieldProps.FieldType == TdbFieldType.tdbInt || fieldProps.FieldType == TdbFieldType.tdbSInt)
            {
                if (!TDB.TDBFieldSetValueAsInteger(DBIndex, tableProps.Name, fieldProps.Name, RecNo, (int)Convert.ToInt32(newValue)))
                {
                    xValue = "xXx";
                }
            }
            else if (fieldProps.FieldType == TdbFieldType.tdbFloat)
            {
                if (!TDB.TDBFieldSetValueAsFloat(DBIndex, tableProps.Name, fieldProps.Name, RecNo, Convert.ToSingle(newValue)))
                {
                    xValue = "xXx";
                }
            }
            else if (fieldProps.FieldType == TdbFieldType.tdbBinary || fieldProps.FieldType == TdbFieldType.tdbVarchar || fieldProps.FieldType == TdbFieldType.tdbLongVarchar)
            {
                //string val = new string((char)0, (fieldProps.Size / 8) + 1);
                //TDB.TDBFieldGetValueAsString(dbIndex, tableProps.Name, fieldProps.Name, dbRecNo, ref val);
                //tmpValue = val;
            }
            else
            {
                //tmpValue = "n/a";
            }

            return xValue;
        }

        public static string FieldBitmax(int DBIndex, string TableName, string FieldName)
        {//Get the maximum value of the field.

            int tmpBitmax = -1;

            #region Get TABLE Properties
            TdbTableProperties tableProps = new TdbTableProperties();
            tableProps.Name = new string((char)0, 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(DBIndex);

            for (int tmpTableIndex = 0; tmpTableIndex < tmpTableCount; tmpTableIndex++)
            {
                TDB.TDBTableGetProperties(DBIndex, tmpTableIndex, ref tableProps);

                if (tableProps.Name == TableName)
                    break;
            }
            #endregion

            #region Get FIELD Properties
            TdbFieldProperties fieldProps = new TdbFieldProperties();
            fieldProps.Name = new string((char)0, 5);

            int tmpFieldCount = tableProps.FieldCount;
            for (int tmpFieldIndex = 0; tmpFieldIndex < tmpFieldCount; tmpFieldIndex++)
            {
                TDB.TDBFieldGetProperties(DBIndex, tableProps.Name, tmpFieldIndex, ref fieldProps);
                if (fieldProps.Name == FieldName)
                    break;
            }
            #endregion

            tmpBitmax = (int)Math.Pow(2, fieldProps.Size) - 1;


            return tmpBitmax.ToString();
        }


        public static void CopyRecord(int DBIndex, string TableName, int RecNo)
        {// Copy RecNo into newRecNo.

            TdbFieldProperties FieldProps = new TdbFieldProperties();
            FieldProps.Name = new string((char)0, 5);

            int newRecNo = TableRecordCount(DBIndex, TableName);
            int tmpFieldCount = FieldCount(DBIndex, TableName);

            for (int fCount = 0; fCount != tmpFieldCount; fCount++)
            {
                TDB.TDBFieldGetProperties(DBIndex, TableName, fCount, ref FieldProps);

                if (FieldProps.FieldType == TdbFieldType.tdbString)
                {
                    string val = new string((char)0, (FieldProps.Size / 8) + 1);

                    TDB.TDBFieldGetValueAsString(DBIndex, TableName, FieldProps.Name, RecNo, ref val);
                    val = val.Replace(",", "");
                    //
                    TDB.TDBFieldSetValueAsString(DBIndex, TableName, FieldProps.Name, newRecNo - 1, val);
                }
                else if (FieldProps.FieldType == TdbFieldType.tdbInt || FieldProps.FieldType == TdbFieldType.tdbSInt)
                {
                    Int32 signedval;
                    signedval = TDB.TDBFieldGetValueAsInteger(DBIndex, TableName, FieldProps.Name, RecNo);
                    //
                    TDB.TDBFieldSetValueAsInteger(DBIndex, TableName, FieldProps.Name, newRecNo - 1, (int)Convert.ToInt32(signedval));
                }
                else if (FieldProps.FieldType == TdbFieldType.tdbUInt)
                {
                    UInt32 intval;
                    intval = (UInt32)TDB.TDBFieldGetValueAsInteger(DBIndex, TableName, FieldProps.Name, RecNo);
                    //
                    TDB.TDBFieldSetValueAsInteger(DBIndex, TableName, FieldProps.Name, newRecNo - 1, (int)Convert.ToUInt32(intval));
                }
                else if (FieldProps.FieldType == TdbFieldType.tdbFloat)
                {
                    float floatval;
                    floatval = TDB.TDBFieldGetValueAsFloat(DBIndex, TableName, FieldProps.Name, RecNo);
                    //
                    TDB.TDBFieldSetValueAsFloat(DBIndex, TableName, FieldProps.Name, newRecNo - 1, Convert.ToSingle(floatval));
                }
                else if (FieldProps.FieldType == TdbFieldType.tdbBinary || FieldProps.FieldType == TdbFieldType.tdbVarchar || FieldProps.FieldType == TdbFieldType.tdbLongVarchar)
                {
                    // Can't edit these fields.
                }
            }
        }

        #endregion

    }
    static class Extensions
    {
        public static void AddSafe(this Dictionary<int, int> dictionary, int key, int value)
        {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
        }

        public static void StrInt(this Dictionary<string, int> dictionary, string key, int value)
        {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
        }

    }

}
