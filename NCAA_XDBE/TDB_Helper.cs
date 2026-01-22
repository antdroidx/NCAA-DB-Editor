// using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {
        #region TDB Functions

        private string BitMax(int bitsize)
        {
            int temp = (int)Math.Pow(2, bitsize) - 1;
            return temp.ToString();
        }
        private static string StrReverse(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        private static bool IsIntNumber(String str)
        {
            Int32 a;
            if (Int32.TryParse(str, out a))
            {
                // Value is numberic
                return true;
            }
            else
            {
                //Not a valid number
                return false;
            }
        }
        private static bool IsUIntNumber(String str)
        {
            UInt32 a;
            if (UInt32.TryParse(str, out a))
            {
                // Value is numberic
                return true;
            }
            else
            {
                //Not a valid number
                return false;
            }

        }
        private static bool IsFloat(String str)
        {
            decimal a;
            if (Decimal.TryParse(str, out a))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region DB1 Helper
        public void ChangeDBString(string table, string field, int rec, string value)
        {
            TDB.NewfieldValue(dbIndex, table, field, rec, value);
        }

        public void ChangeDBInt(string table, string field, int rec, int value)
        {
            TDB.NewfieldValue(dbIndex, table, field, rec, Convert.ToString(value));

        }

        public string GetDBValue(string table, string field, int rec)
        {
            return TDB.FieldValue(dbIndex, table, field, rec);
        }

        public int GetDBValueInt(string table, string field, int rec)
        {
            return TDB.TDBFieldGetValueAsInteger(dbIndex, table, field, rec);
        }

        public int GetTableRecCount(string table)
        {
            return TDB.TableRecordCount(dbIndex, table);
        }

        public void AddTableRecord(string table, bool expand)
        {
            TDB.TDBTableRecordAdd(dbIndex, table, expand);
        }

        public void ReOrderTable(string table, string field)
        {
            List<List<string>> tmpTable = new List<List<string>>();
            int sortCol = TDB.FieldIndex(dbIndex, table, field);

            StartProgressBar(GetTableRecCount(table));


            //Copy Table
            int row = 0;
            for (int i = 0; i < GetTableRecCount(table); i++)
            {
                tmpTable.Add(new List<string>());

                for (int f = 0; f < TDB.FieldCount(dbIndex, table); f++)
                {
                    TdbFieldProperties FieldProps = new TdbFieldProperties();
                    FieldProps.Name = new string((char)0, 5);

                    TDB.TDBFieldGetProperties(dbIndex, table, f, ref FieldProps);

                    tmpTable[row].Add(GetDBValue(table, FieldProps.Name, row));
                }
                row++;
                ProgressBarStep();
            }

            //Sort
            tmpTable.Sort((player1, player2) => Convert.ToInt32(player1[sortCol]).CompareTo(Convert.ToInt32(player2[sortCol])));


            StartProgressBar(GetTableRecCount(table));
            //Clear Table
            for (int i = 0; i < GetTableRecCount(table); i++)
            {
                TDB.TDBTableRecordRemove(dbIndex, table, i);
                ProgressBarStep();
            }

            StartProgressBar(tmpTable.Count);

            //Paste Table
            int rec = 0;
            for (int i = 0; i < tmpTable.Count; i++)
            {
                AddTableRecord(table, false);
                for (int f = 0; f < TDB.FieldCount(dbIndex, table); f++)
                {
                    TdbFieldProperties FieldProps = new TdbFieldProperties();
                    FieldProps.Name = new string((char)0, 5);

                    TDB.TDBFieldGetProperties(dbIndex, table, f, ref FieldProps);
                    ChangeDBString(table, FieldProps.Name, rec, tmpTable[rec][f]);
                }
                rec++;
                ProgressBarStep();
            }

            EndProgressBar();
        }

        public void CompactDB()
        {
            TDB.TDBDatabaseCompact(dbIndex);
        }

        public void DeleteRecord(string table, int rec, bool deleted)
        {
            TDB.TDBTableRecordChangeDeleted(dbIndex, table, rec, deleted);
        }

        public int GetFieldCount(string tableName)
        {
            return TDB.FieldCount(dbIndex, tableName);
        }

        public string GetFieldName(string tableName, int fCol)
        {
            var fieldProps = new TdbFieldProperties();
            fieldProps.Name = new string((char)0, 5);
            TDB.TDBFieldGetProperties(dbSelected, tableName, fCol, ref fieldProps);

            string fieldName = fieldProps.Name;

            return fieldName;
        }

        public int GetFieldIndex(string tmpFName)
        {
            int tmpIndex = 0;

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            TDB.TDBTableGetProperties(dbIndex, SelectedTableIndex, ref TableProps);

            TdbFieldProperties FieldProps = new TdbFieldProperties();
            FieldProps.Name = new string((char)0, 5);

            for (int index = 0; index < TableProps.FieldCount; index++)
            {
                TDB.TDBFieldGetProperties(dbIndex, SelectedTableName, index, ref FieldProps);

                if (tmpFName == FieldProps.Name)
                {
                    tmpIndex = index;
                    break;
                }
            }
            // MessageBox.Show(tmpIndex + " ", tmpFName + " - " + FieldProps.Name);
            return tmpIndex;
        }

        public string GetTableName(int dbFILEindex, int tmpTABLEindex)
        {
            // TdbTableProperties class
            TdbTableProperties TableProps = new TdbTableProperties();

            // 4 character string, max value of 5
            TableProps.Name = new string((char)0, 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(dbFILEindex);

            string tmpTABLEname = "";

            if (tmpTABLEindex < tmpTableCount)
            {
                // Init the tdbtableproperties name
                TableProps.Name = new string((char)0, 5);

                // Get the tableproperties for the given table number
                TDB.TDBTableGetProperties(dbFILEindex, tmpTABLEindex, ref TableProps);

                tmpTABLEname = TableProps.Name;

            }
            // MessageBox.Show(tmpTABLEname + "  index: " + tmpTABLEindex);
            return tmpTABLEname;
        }
        public int GetTableIndex(int dbFILEindex, string tmpTABLEname)
        {
            // TdbTableProperties class
            TdbTableProperties TableProps = new TdbTableProperties();

            // 4 character string, max value of 5
            StringBuilder TableName = new StringBuilder("    ", 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(dbFILEindex);
            int tmpTABLEindex = -1;

            for (int i = 0; i < tmpTableCount; i++)
            {
                // Init the tdbtableproperties name
                TableProps.Name = TableName.ToString();

                // Get the tableproperties for the given table number
                TDB.TDBTableGetProperties(dbFILEindex, i, ref TableProps);

                if (BigEndian)
                    TableProps.Name = StrReverse(TableProps.Name);

                if (tmpTABLEname == TableProps.Name)
                {
                    tmpTABLEindex = i;
                    break;
                }

            }
            // MessageBox.Show(TableProps.Name + "  index: " + tmpTABLEindex);
            return tmpTABLEindex;
        }

        #endregion

        #region DB2 Helper
        public void ChangeDB2String(string table, string field, int rec, string value)
        {
            TDB.NewfieldValue(dbIndex2, table, field, rec, value);
        }

        public void ChangeDB2Int(string table, string field, int rec, int value)
        {
            TDB.NewfieldValue(dbIndex2, table, field, rec, Convert.ToString(value));

        }

        public string GetDB2Value(string table, string field, int rec)
        {
            return TDB.FieldValue(dbIndex2, table, field, rec);
        }

        public int GetDB2ValueInt(string table, string field, int rec)
        {
            return TDB.TDBFieldGetValueAsInteger(dbIndex2, table, field, rec);
        }

        public int GetTable2RecCount(string table)
        {
            return TDB.TableRecordCount(dbIndex2, table);
        }

        public void AddTable2Record(string table, bool expand)
        {
            TDB.TDBTableRecordAdd(dbIndex2, table, expand);
        }

        public void ReOrderTable2(string table, string field)
        {
            List<List<string>> tmpTable = new List<List<string>>();
            int sortCol = TDB.FieldIndex(dbIndex2, table, field);

            StartProgressBar(GetTableRecCount(table));


            //Copy Table
            int row = 0;
            for (int i = 0; i < GetTable2RecCount(table); i++)
            {
                tmpTable.Add(new List<string>());

                for (int f = 0; f < TDB.FieldCount(dbIndex2, table); f++)
                {
                    TdbFieldProperties FieldProps = new TdbFieldProperties();
                    FieldProps.Name = new string((char)0, 5);

                    TDB.TDBFieldGetProperties(dbIndex2, table, f, ref FieldProps);

                    tmpTable[row].Add(GetDBValue(table, FieldProps.Name, row));
                }
                row++;
                ProgressBarStep();
            }

            //Sort
            tmpTable.Sort((player1, player2) => Convert.ToInt32(player1[sortCol]).CompareTo(Convert.ToInt32(player2[sortCol])));


            StartProgressBar(GetTable2RecCount(table));
            //Clear Table
            for (int i = 0; i < GetTable2RecCount(table); i++)
            {
                TDB.TDBTableRecordRemove(dbIndex2, table, i);
                ProgressBarStep();
            }

            StartProgressBar(tmpTable.Count);

            //Paste Table
            int rec = 0;
            for (int i = 0; i < tmpTable.Count; i++)
            {
                AddTable2Record(table, false);
                for (int f = 0; f < TDB.FieldCount(dbIndex2, table); f++)
                {
                    TdbFieldProperties FieldProps = new TdbFieldProperties();
                    FieldProps.Name = new string((char)0, 5);

                    TDB.TDBFieldGetProperties(dbIndex2, table, f, ref FieldProps);
                    ChangeDBString(table, FieldProps.Name, rec, tmpTable[rec][f]);
                }
                rec++;
                ProgressBarStep();
            }

            EndProgressBar();
        }

        public void CompactDB2()
        {
            TDB.TDBDatabaseCompact(dbIndex2);
        }

        public void DeleteRecord2(string table, int rec, bool deleted)
        {
            TDB.TDBTableRecordChangeDeleted(dbIndex2, table, rec, deleted);
        }

        public int GetTableCapacity(string table)
        {
            return TDB.TableCapacity(dbIndex, table);
        }

        #endregion

    }

}
