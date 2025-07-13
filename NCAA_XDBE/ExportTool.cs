using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DB_EDITOR
{
    public partial class MainEditor : Form
    {

        //EXPORT - Main Menu
        private void ExportDB()
        {
            string tmpReverse = "";
            string tmpcurrentDBfile = Path.GetFileNameWithoutExtension(dbFile);

            Stream myStream = null;
            SaveFileDialog SaveDialog1 = new SaveFileDialog();


            if (!exportAll)
            {
                if (tabDelimited)
                    SaveDialog1.Filter = "TXT Files (*.txt)|*.txt|All files (*.*)|*.*";
                else SaveDialog1.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";

                if (BigEndian)
                    SaveDialog1.FileName = tmpcurrentDBfile + " - " + StrReverse(SelectedTableName);
                else SaveDialog1.FileName = tmpcurrentDBfile + " - " + SelectedTableName;
            }
            else
            {
                myStream = File.Create(SelectedTableName + ".csv");
            }

            if (exportAll || SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                // use a try-catch here
#pragma warning disable CS0168 // Variable is declared but never used
                try
                {

                    // Open the file using Stream, if it succeeds do stuff with it
                    if (exportAll || (myStream = SaveDialog1.OpenFile()) != null)
                    {
                        StreamWriter wText = new StreamWriter(myStream);    // create writer using the stream that opened the savefile earlier

                        StringBuilder hbuilder = new StringBuilder();       // hbuilder is for the header, which are the fieldnames
                        // builder.Append(Whatever string you want here, probably the field names in the table
                        // builder.Append(",");  separate each name with a comma

                        TdbTableProperties TableProps = new TdbTableProperties();
                        TableProps.Name = new string((char)0, 5);

                        TDB.TDBTableGetProperties(dbSelected, SelectedTableIndex, ref TableProps);

                        #region Write CSV Header (field names).
                        for (int i = 0; i < TableProps.FieldCount; i++)
                        {
                            TdbFieldProperties FieldProps = new TdbFieldProperties();
                            FieldProps.Name = new string((char)0, 5);



                            TDB.TDBFieldGetProperties(dbSelected, SelectedTableName, i, ref FieldProps);
                            tmpReverse = FieldProps.Name;

                            // Reverse field name if BigEndian file.
                            if (BigEndian)
                                tmpReverse = StrReverse(tmpReverse);

                            hbuilder.Append(tmpReverse);

                            // Excempt comma if there are no more field names to add.
                            if (i != TableProps.FieldCount - 1)
                            {
                                if (tabDelimited)
                                    hbuilder.Append("\t");
                                else hbuilder.Append(",");

                            }

                        }
                        if (TableProps.Name == "PLAY" && TDB.FieldIndex(dbSelected, SelectedTableName, "PF10") == 0)
                        {
                            hbuilder.Append(",");
                            hbuilder.Append("FirstName");
                            hbuilder.Append(",");
                            hbuilder.Append("LastName");
                            hbuilder.Append(",");
                            hbuilder.Append("College");
                            hbuilder.Append(",");
                            hbuilder.Append("Position");
                        }

                        wText.WriteLine(hbuilder.ToString());   // Convert the string builder to an actual string and write to the stream/file
                        #endregion

                        // Progress bar for large table records to write.
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = TableProps.RecordCount;
                        progressBar1.Step = 1;

                        #region Write CSV cells (field values).

                        for (int r = 0; r < TableProps.RecordCount; r++)
                        {
                            hbuilder.Clear();
                            int tmpTGID = -1;
                            int tmpPos = -1;
                            for (int f = 0; f < TableProps.FieldCount; f++)
                            {
                                TdbFieldProperties FieldProps = new TdbFieldProperties();
                                FieldProps.Name = new string((char)0, 5);

                                TDB.TDBFieldGetProperties(dbSelected, TableProps.Name, f, ref FieldProps);

                                if (FieldProps.FieldType == TdbFieldType.tdbString)
                                {
                                    string val = new string((char)0, (FieldProps.Size / 8) + 1);

                                    TDB.TDBFieldGetValueAsString(dbSelected, TableProps.Name, FieldProps.Name, r, ref val);

                                    if (!tabDelimited)
                                        val = val.Replace(",", "");

                                    hbuilder.Append(val.ToString());

                                }
                                else if (FieldProps.FieldType == TdbFieldType.tdbUInt)
                                {
                                    UInt32 intval;
                                    intval = (UInt32)TDB.TDBFieldGetValueAsInteger(dbSelected, TableProps.Name, FieldProps.Name, r);
                                    hbuilder.Append(intval.ToString());

                                    if (FieldProps.Name == "PGID")
                                    {
                                        tmpTGID = (int)intval / 70;
                                    }
                                    if (FieldProps.Name == "PPOS") tmpPos = (int)intval;

                                }
                                else if (FieldProps.FieldType == TdbFieldType.tdbInt || FieldProps.FieldType == TdbFieldType.tdbSInt)
                                {
                                    Int32 signedval;
                                    signedval = TDB.TDBFieldGetValueAsInteger(dbSelected, TableProps.Name, FieldProps.Name, r);
                                    hbuilder.Append(signedval.ToString());

                                }
                                else if (FieldProps.FieldType == TdbFieldType.tdbFloat)
                                {
                                    float floatval;
                                    floatval = TDB.TDBFieldGetValueAsFloat(dbSelected, TableProps.Name, FieldProps.Name, r);
                                    hbuilder.Append(floatval.ToString());

                                }
                                else if (FieldProps.FieldType == TdbFieldType.tdbBinary || FieldProps.FieldType == TdbFieldType.tdbVarchar || FieldProps.FieldType == TdbFieldType.tdbLongVarchar)
                                {
                                    string val = new string((char)0, (FieldProps.Size / 8) + 1);
                                    TDB.TDBFieldGetValueAsString(dbSelected, TableProps.Name, FieldProps.Name, r, ref val);

                                    // hbuilder.Append(val.ToString());
                                    hbuilder.Append("usft");

                                }
                                else hbuilder.Append("[na]");

                                // Excempt comma if there are no more field names to add.
                                if (f != TableProps.FieldCount - 1)
                                    if (tabDelimited)
                                        hbuilder.Append("\t");
                                    else hbuilder.Append(",");
                            }
                            if (TableProps.Name == "PLAY" && TDB.FieldIndex(dbSelected, SelectedTableName, "PF10") == 0)
                            {
                                hbuilder.Append(",");
                                hbuilder.Append(GetFirstNameFromRecord(r)); //write first name string to csv
                                hbuilder.Append(",");
                                hbuilder.Append(GetLastNameFromRecord(r)); //write last name string to csv
                                hbuilder.Append(",");
                                hbuilder.Append(GetTeamName((int)tmpTGID)); //convert and write team name to csv
                                hbuilder.Append(",");
                                hbuilder.Append(GetPositionName((int)tmpPos)); //convert and write position name to csv
                            }

                            progressBar1.PerformStep();
                            wText.WriteLine(hbuilder.ToString());   // Convert the strin builder to an actual string and write to the stream/file
                        }
                        #endregion

                        progressBar1.Value = 0;
                        wText.Flush();
                        wText.Close();

                        if (!exportAll)
                            MessageBox.Show(Path.GetFileNameWithoutExtension(SaveDialog1.FileName) + Path.GetExtension(SaveDialog1.FileName).ToLower() + " saved.", "Export");

                    }
                }
                catch (IOException err)
                {
                    MessageBox.Show("Error opening file\r\n\r\n Check that the file is not already opened", "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
#pragma warning restore CS0168 // Variable is declared but never used

                myStream.Dispose();
                myStream.Close();  // I get an error when saving the file when it is opened in excel.
            }
        }


        //EXPORT - Field Menu
        private void ExportField()
        {
            string tmpReverse = "";
            string dbFile = "";

            dbFile = Path.GetFileName(this.dbFile);

            Stream myStream = null;
            SaveFileDialog SaveDialog1 = new SaveFileDialog();

            // Reverse table for file name.
            if (BigEndian)
                SaveDialog1.FileName = "export" + dbFile + " - " + StrReverse(SelectedTableName);
            else SaveDialog1.FileName = "export" + dbFile + " - " + SelectedTableName;

            SaveDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";

            dbFile = SaveDialog1.FileName;

            if (SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                // use a try-catch here
#pragma warning disable CS0168 // Variable is declared but never used
                try
                {

                    // Open the file using Stream, if it succeeds do stuff with it
                    if ((myStream = SaveDialog1.OpenFile()) != null)
                    {
                        StreamWriter wText = new StreamWriter(myStream);    // create writer using the stream that opened the savefile earlier

                        StringBuilder hbuilder = new StringBuilder();       // hbuilder is for the header, which are the fieldnames
                        // builder.Append(Whatever string you want here, probably the field names in the table
                        // builder.Append(",");  separate each name with a comma

                        TdbTableProperties TableProps = new TdbTableProperties();
                        TableProps.Name = new string((char)0, 5);

                        TDB.TDBTableGetProperties(dbSelected, SelectedTableIndex, ref TableProps);

                        #region Write CSV Header (field names).
                        for (int i = 0; i < TableProps.FieldCount; i++)
                        {
                            TdbFieldProperties FieldProps = new TdbFieldProperties();
                            FieldProps.Name = new string((char)0, 5);

                            if (TDB.TDBFieldGetProperties(dbSelected, SelectedTableName, i, ref FieldProps))
                            {
                                tmpReverse = FieldProps.Name;

                                // Reverse field name if BigEndian file.
                                if (BigEndian)
                                    tmpReverse = StrReverse(tmpReverse);
                            }
                            hbuilder.Append(tmpReverse);

                            // Excempt comma if there are no more field names to add.
                            if (i != TableProps.FieldCount - 1)
                                hbuilder.Append(",");
                        }

                        wText.WriteLine(hbuilder.ToString());   // Convert the string builder to an actual string and write to the stream/file
                        #endregion

                        // Progress bar for large table records to write.
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = TableProps.RecordCount;
                        progressBar1.Step = 1;

                        #region Write CSV cells (field values).

                        foreach (DataGridViewRow row in fieldsGridView.SelectedRows)
                        {
                            hbuilder.Clear();
                            for (int f = 0; f < TableProps.FieldCount; f++)
                            {
                                TdbFieldProperties FieldProps = new TdbFieldProperties();
                                FieldProps.Name = new string((char)0, 5);

                                TDB.TDBFieldGetProperties(dbSelected, TableProps.Name, f, ref FieldProps);

                                if (FieldProps.FieldType == TdbFieldType.tdbString)
                                {
                                    string val = new string((char)0, (FieldProps.Size / 8) + 1);

                                    TDB.TDBFieldGetValueAsString(dbSelected, TableProps.Name, FieldProps.Name, Convert.ToInt32(row.Cells[0].Value), ref val);
                                    val = val.Replace(",", "");

                                    hbuilder.Append(val.ToString());

                                }
                                else if (FieldProps.FieldType == TdbFieldType.tdbUInt)
                                {
                                    UInt32 intval;
                                    intval = (UInt32)TDB.TDBFieldGetValueAsInteger(dbSelected, TableProps.Name, FieldProps.Name, Convert.ToInt32(row.Cells[0].Value));
                                    hbuilder.Append(intval.ToString());

                                }
                                else if (FieldProps.FieldType == TdbFieldType.tdbInt || FieldProps.FieldType == TdbFieldType.tdbSInt)
                                {
                                    Int32 signedval;
                                    signedval = TDB.TDBFieldGetValueAsInteger(dbSelected, TableProps.Name, FieldProps.Name, Convert.ToInt32(row.Cells[0].Value));
                                    hbuilder.Append(signedval.ToString());

                                }
                                else if (FieldProps.FieldType == TdbFieldType.tdbFloat)
                                {
                                    float floatval;
                                    floatval = TDB.TDBFieldGetValueAsFloat(dbSelected, TableProps.Name, FieldProps.Name, Convert.ToInt32(row.Cells[0].Value));
                                    hbuilder.Append(floatval.ToString());

                                }
                                else if (FieldProps.FieldType == TdbFieldType.tdbBinary || FieldProps.FieldType == TdbFieldType.tdbVarchar || FieldProps.FieldType == TdbFieldType.tdbLongVarchar)
                                {
                                    string val = new string((char)0, (FieldProps.Size / 8) + 1);
                                    TDB.TDBFieldGetValueAsString(dbSelected, TableProps.Name, FieldProps.Name, Convert.ToInt32(row.Cells[0].Value), ref val);

                                    // hbuilder.Append(val.ToString());
                                    hbuilder.Append("usft");

                                }
                                else hbuilder.Append("[na]");

                                // Excempt comma if there are no more field names to add.
                                if (f != TableProps.FieldCount - 1)
                                    hbuilder.Append(",");
                            }
                            progressBar1.PerformStep();
                            wText.WriteLine(hbuilder.ToString());   // Convert the strin builder to an actual string and write to the stream/file
                        }
                        #endregion

                        progressBar1.Value = 0;
                        wText.Flush();
                        wText.Close();

                        MessageBox.Show(dbFile + Path.GetExtension(SaveDialog1.FileName).ToLower() + " saved.", "Export");

                    }
                }
                catch (IOException err)
                {
                    MessageBox.Show("Error opening file\r\n\r\n Check that the file is not already opened", "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
#pragma warning restore CS0168 // Variable is declared but never used
                myStream.Close();  // I get an error when saving the file when it is opened in excel.
            }

            DBModified = true;
        }




    }
}
