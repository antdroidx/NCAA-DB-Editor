using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DB_EDITOR
{
    public partial class MainEditor : Form
    {

        //Import - Main Menu
        private void ImportDB()
        {
            bool roster = true;
            if(TDB.TableCount(dbSelected) > 3) roster = false;

            Dictionary<string, int> AvailableFields = new Dictionary<string, int>();
            Dictionary<string, int> TableFields = new Dictionary<string, int>();

            if (SelectedTableName == "TEAM" && TDB.TDBDatabaseGetTableCount(dbSelected) > 50 && !addendum)
            {
                MessageBox.Show("DO NOT USE IMPORT CSV FUNCTION FOR TEAM TABLE.\n\nPlease use Addendum instead and DO NOT IMPORT TPIP and JJNM COLUMNS!");
                return;
            }

            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            Stream myStream = null;

            if (exportAll)
            {
                string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string csvLocation = Path.Combine(executableLocation, SelectedTableName + ".csv");
                myStream = new FileStream(csvLocation, FileMode.Open, FileAccess.Read);
            }
            else if (tabDelimited)
                openFileDialog2.Filter = "TXT Files (*.txt)|*.txt|All files (*.*)|*.*";
            else 
                openFileDialog2.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";

            if (exportAll || openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                if (exportAll & myStream != null || !exportAll && (myStream = openFileDialog2.OpenFile()) != null)
                {
                    #region Setup  Existing table field names
                    //
                    TdbTableProperties TableProps = new TdbTableProperties();
                    TableProps.Name = new string((char)0, 5);

                    TDB.TDBTableGetProperties(dbSelected, SelectedTableIndex, ref TableProps);

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = TableProps.FieldCount;
                    progressBar1.Step = 1;

                    TableFields.Clear();

                    for (int i = 0; i < TableProps.FieldCount; i++)
                    {
                        TdbFieldProperties FieldProps = new TdbFieldProperties();
                        FieldProps.Name = new string((char)0, 5);

                        TDB.TDBFieldGetProperties(dbSelected, TableProps.Name, i, ref FieldProps);

                        TableFields.Add(FieldProps.Name, (int)FieldProps.FieldType);

                        ProgressBarStep();
                    }
                    progressBar1.Value = 0;
                    #endregion

                    #region Delete All Records
                    if (!addendum)
                    {
                        if (TableProps.RecordCount != 0)
                        {
                            progressBar1.Minimum = 0;
                            progressBar1.Maximum = TableProps.RecordCount;
                            progressBar1.Step = 1;

                            for (int r = TableProps.RecordCount; r != -1; r--)
                            {
                                TDB.TDBTableRecordRemove(dbSelected, SelectedTableName, r);

                                ProgressBarStep();
                            }
                            progressBar1.Value = 0;
                        }
                    }

                    // TableProps.RecordCount = 0;
                    DBModified = true;
                    #endregion

                    #region setup import table field names

                    // new streamreader based on mystream which is an open file
                    StreamReader sr = new StreamReader(myStream);
                    string headerline = sr.ReadLine();

                    // string[] csvfieldnames = headerline.Split(',');
                    string[] csvfieldnames;

                    if (tabDelimited)
                        csvfieldnames = headerline.Split('\t');
                    else csvfieldnames = headerline.Split(',');


                    AvailableFields.Clear();

                    for (int c = 0; c < csvfieldnames.Length; c++)
                    {
                        if (BigEndian)
                            csvfieldnames[c] = StrReverse(csvfieldnames[c]);

                        // if the current table fieldnames has this field, then add to our import list
                        if (TableFields.ContainsKey(csvfieldnames[c]))
                        {
                            // if available fields does not contain the fieldname from csv read
                            if (!AvailableFields.ContainsKey(csvfieldnames[c]))
                                AvailableFields.Add(csvfieldnames[c], c);
                        }
                    }


                    // Done with reading in the csv file
                    //sr.Close();
                    #endregion

                    #region Main Loop
                    // Progress bar for large table records to write.
                    StartProgressBar(TableProps.RecordCount);


                    int recnum = 0;
                    while (!sr.EndOfStream)
                    {
                        // Readline (record) as string
                        // split string

                        string recordline = sr.ReadLine();
                        string[] record;

                        if (tabDelimited)
                            record = recordline.Split('\t');
                        else record = recordline.Split(',');

                        // add new record
                        if (!addendum || importRec)
                        {
                            TDB.TDBTableRecordAdd(dbSelected, SelectedTableName, true);
                            //TDB.TDBTableGetProperties(currentDBfileIndex, SelectedTableIndex, ref TableProps);
                            // Import record's record index.
                            if (importRec)
                                recnum++;
                        }

                        int importtmpfieldindex = -1;

                        foreach (KeyValuePair<string, int> import in AvailableFields)
                        {
                            //if (TableProps.Name == "PLAY" && getFieldIndex(import.Key) > AvailableFields.Count - 2)
                            //    continue;

                            string importfieldnames = import.Key;

                            importtmpfieldindex++;

                            #region Comment code.
                            // we only want to import the fields that actually exist in the current table
                            // which have already been stored in the available fields dictionary

                            // check tablefields for the name of the importing field
                            // if it corresponds to a string data type, set it
                            // you can look at tdbfieldtype to see what values the enum is set to
                            // MessageBox.Show(import.Key, record[import.Value]);
                            #endregion

                            //TdbFieldProperties FieldProps = new TdbFieldProperties();
                            //                   FieldProps.Name = new string((char)0, 5);

                            //TDB.TDBFieldGetProperties(currentDBfileIndex, 
                            //                          SelectedTableName, 
                            //                          TDB.FieldIndex(currentDBfileIndex, SelectedTableName, import.Key), 
                            //                          ref FieldProps);

                            if (TableFields[import.Key] == (int)TdbFieldType.tdbString)
                            {
                                // ok so tableprops.name is current table
                                // import.key is the fieldname we are setting
                                // record is array with split values from the csv readline
                                // import.value is the position in the record array of the fieldname
                                // this is already a string, so we dont need to convert it



                                TDB.TDBFieldSetValueAsString(dbSelected,
                                                                   SelectedTableName,
                                                                   importfieldnames,
                                                                   recnum,
                                                                   record[import.Value]);


                                //break;
                            }
                            else if (TableFields[import.Key] == (int)TdbFieldType.tdbInt || TableFields[import.Key] == (int)TdbFieldType.tdbSInt)
                            {
                                // signed integer and integer are the same thing, unsigned is different
                                string importfieldname = import.Key;

                                //Check if import value is within parameters.
                                if (!IsIntNumber(record[import.Value]) ||
                                    !TDB.TDBFieldSetValueAsInteger(dbSelected,
                                                                   SelectedTableName,
                                                                   importfieldname,
                                                                   recnum,
                                                                   (int)Convert.ToInt32(record[import.Value])))

                                { }  // Don't need to set it to zero on error since adding a record will automatically set it to zero.
                                     // I think you can do it this way too
                                     // so if setting the value fails, set it to 0
                                     // if (!TDB.TDBFieldSetValueAsInteger(OpenIndex, TableProps.Name, importfieldnames, recnum, (int)Convert.ToInt32(record[import.Value])))
                                     //TDB.TDBFieldSetValueAsInteger(OpenIndex, TableProps.Name, importfieldnames, recnum, 0);

                            }
                            else if (TableFields[import.Key] == (int)TdbFieldType.tdbUInt)
                            {
                                // unsigned integer
                                string importfieldname = import.Key;

                                // Check if import value is within parameters.
                                if (!IsUIntNumber(record[import.Value]) || !TDB.TDBFieldSetValueAsInteger(dbSelected, SelectedTableName, importfieldname, recnum, (int)Convert.ToUInt32(record[import.Value])))
                                { }

                            }
                            else if (TableFields[import.Key] == (int)TdbFieldType.tdbFloat)
                            {
                                // float
                                string importfieldname = import.Key;

                                // Check if import value is within parameters, if not set to max parameter.
                                if (!IsFloat(record[import.Value]) || !TDB.TDBFieldSetValueAsFloat(dbSelected, SelectedTableName, importfieldname, recnum, Convert.ToSingle(record[import.Value])))
                                { }

                            }
                            else if (TableFields[import.Key] == (int)TdbFieldType.tdbBinary || TableFields[import.Key] == (int)TdbFieldType.tdbVarchar || TableFields[import.Key] == (int)TdbFieldType.tdbLongVarchar)
                            {
                                // unsupported field types
                            }

                        }

                        if (TableProps.Name == "PLAY" && TDB.FieldIndex(dbSelected, SelectedTableName, "PF10") == 0 && !roster && record.Length > 97|| TableProps.Name == "PLAY" && TDB.FieldIndex(dbSelected, SelectedTableName, "PF10") == 0 && roster && record.Length > 86)
                        {
                            ConvertFirstNameStringToInt(record[importtmpfieldindex + 1], recnum, "PLAY");
                            ConvertLastNameStringToInt(record[importtmpfieldindex + 2], recnum, "PLAY");
                        }

                        recnum++;
                        ProgressBarStep();
                    }

                    EndProgressBar();

                    myStream.Dispose();
                    myStream.Close();
                    #endregion

                    DBModified = true;
                    saveMenuItem.Enabled = true;
                    GetTableProperties();
                    if(!exportAll) LoadFields();

                }

            }
        }






    }
}
