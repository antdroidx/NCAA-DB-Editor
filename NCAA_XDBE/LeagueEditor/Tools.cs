using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Label = System.Windows.Forms.Label;

namespace DB_EDITOR
{
    partial class LeagueMain : Form
    {

        #region TDB Functions

        private void ChangeDBString(string table, string field, int rec, string value)
        {
            TDB.NewfieldValue(dbIndex2, table, field, rec, value);
        }

        private void ChangeDBInt(string table, string field, int rec, int value)
        {
            TDB.NewfieldValue(dbIndex2, table, field, rec, Convert.ToString(value));

        }

        private string GetDBValue(string table, string field, int rec)
        {
            return TDB.FieldValue(dbIndex2, table, field, rec);
        }

        private int GetDBValueInt(string table, string field, int rec)
        {
            return TDB.TDBFieldGetValueAsInteger(dbIndex2, table, field, rec);
        }

        private int GetTableRecCount(string table)
        {
            return TDB.TableRecordCount(dbIndex2, table);
        }


        #endregion

        #region CSV Tools

        private List<List<string>> CreateStringListsFromCSV(string location, bool skipFirstRow)
        {
            List<List<string>> list = new List<List<string>>();
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, location);

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int Row = 0;
            int skip = 0;
            if (skipFirstRow) skip = -1;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (skipFirstRow && Row == 0) /*do nothing*/;
                else
                {
                    list.Add(new List<string>());
                    for (int column = 0; column < Line.Length; column++)
                    {
                        list[Row + skip].Add(Line[column]);
                    }
                }

                Row++;
            }
            sr.Close();

            return list;
        }

        private List<string> CreateStringListfromCSV(string location, bool skipFirstRow)
        {
            List<string> list = new List<string>();
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, location);

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Row == 0 && skipFirstRow)
                {
                    //skip header
                }
                else
                {
                    list.Add(Line[0]);
                }

                Row++;
            }
            sr.Close();

            return list;
        }


        private List<List<int>> CreateIntListsFromCSV(string location, bool skipFirstRow)
        {
            List<List<int>> list = new List<List<int>>();
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, location);

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int Row = 0;
            int skip = 0;
            if (skipFirstRow) skip = -1;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (skipFirstRow && Row == 0) /*do nothing*/;
                else
                {
                    list.Add(new List<int>());
                    for (int column = 0; column < Line.Length; column++)
                    {
                        list[Row + skip].Add(Convert.ToInt32(Line[column]));
                    }
                }

                Row++;
            }
            sr.Close();

            return list;
        }

        private List<int> CreateIntListfromCSV(string location, bool skipFirstRow)
        {
            List<int> list = new List<int>();
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, location);

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Row == 0 && skipFirstRow)
                {
                    //skip header
                }
                else
                {
                    for (int column = 0; column < Line.Length; column++)
                    {
                        if (column == 1) list.Add(Convert.ToInt32(Line[column]));
                    }
                }

                Row++;
            }
            sr.Close();

            return list;
        }

        #endregion

    }
}
