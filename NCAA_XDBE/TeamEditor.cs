using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        /*
        * PLAYER & TEAM EDITOR (work from elguapo - not used currently)
        */
        #region PLAYER/TEAM EDITOR - NOT COMPLETE


        public void SelectDBTabPage()
        {

            if (tabControl1.SelectedTab.Text == "Teams")
            {
                if (TGIDrecNo.Count < 1)
                {
                    Management(dbIndex, "TEAM", "TORD");  //Load Teams by their team order.
                    MangTGID(dbIndex);
                    //LoadTGIDlistBox(dbIndex, "TTYP", 0);  // -1 = to all teams.

                    // If table exixts in current DB.
                    if (TDB.TableIndex(dbIndex, "CONF") != -1)
                    {
                        Management(dbIndex, "CONF", "CGID");
                        MangCONF();
                    }
                }

                LoadTGIDlistBox(dbIndex, "TTYP", 0);  // -1 = to all teams.

            }
            else if (tabControl1.SelectedTab.Text == "Players")
            {
                if (PGIDrecNo.Count < 1)
                {
                    Management(dbIndex, "PLAY", "POVR");  //Load players by their overall.
                    MangPGID(dbIndex);
                }
            }

        }

        public void Management(int tmpDBindex, string tmpTName, string tmpFName)
        {
            string tmpVal = "";

            tmpManagement.Clear();

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected table index
            if (!TDB.TDBTableGetProperties(tmpDBindex, GetTableIndex(tmpDBindex, tmpTName), ref TableProps))
                return;

            for (int r = 0; r < TableProps.RecordCount; r++)
            {
                // check if record is deleted, if so, skip
                if (TDB.TDBTableRecordDeleted(tmpDBindex, TableProps.Name, r))
                    continue;


                for (int f = 0; f < TableProps.FieldCount; f++)
                {
                    TdbFieldProperties FieldProps = new TdbFieldProperties();
                    FieldProps.Name = new string((char)0, 5);

                    TDB.TDBFieldGetProperties(tmpDBindex, TableProps.Name, f, ref FieldProps);

                    #region Load recTMP by tdbFieldType.
                    if (tmpFName == FieldProps.Name)
                    {
                        //
                        if (FieldProps.FieldType == TdbFieldType.tdbString)
                        {
                            // I think Values that are a string might have to be formatted to a specific length
                            // it probably has something to do with the language he made the dll with
                            string val = new string((char)0, (FieldProps.Size / 8) + 1);

                            TDB.TDBFieldGetValueAsString(tmpDBindex, TableProps.Name, FieldProps.Name, r, ref val);
                            val = val.Replace(",", "");

                            tmpVal = val;

                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbUInt)
                        {
                            UInt32 intval;
                            intval = (UInt32)TDB.TDBFieldGetValueAsInteger(tmpDBindex, TableProps.Name, FieldProps.Name, r);

                            tmpVal = Convert.ToString(intval);
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbInt || FieldProps.FieldType == TdbFieldType.tdbSInt)
                        {
                            Int32 signedval;
                            signedval = TDB.TDBFieldGetValueAsInteger(tmpDBindex, TableProps.Name, FieldProps.Name, r);

                            tmpVal = Convert.ToString(signedval);
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbFloat)
                        {
                            float floatval;
                            floatval = TDB.TDBFieldGetValueAsFloat(tmpDBindex, TableProps.Name, FieldProps.Name, r);

                            tmpVal = Convert.ToString(floatval);
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbBinary || FieldProps.FieldType == TdbFieldType.tdbVarchar || FieldProps.FieldType == TdbFieldType.tdbLongVarchar)
                        {
                            string val = new string((char)0, (FieldProps.Size / 8) + 1);
                            TDB.TDBFieldGetValueAsString(tmpDBindex, TableProps.Name, FieldProps.Name, r, ref val);

                            // unsupportedFieltype;
                            tmpVal = val;
                        }
                        else
                        {
                            // unsupportedFieltype;
                            tmpVal = "NA";

                        }
                        tmpManagement.Add(r, Convert.ToInt32(tmpVal));
                        break;
                    }
                    #endregion
                }

            }


        }


        public void MangTGID(int tmpDB)
        {
            List<int> tmpTTYP = new List<int>();
            List<int> tmpDGID = new List<int>();
            List<int> tmpLGID = new List<int>();
            List<int> tmpCGID = new List<int>();

            var tmpList = new Dictionary<int, int>();
            tmpList.Clear();
            TGIDrecNo.Clear();

            progressBar1.Minimum = 0;
            progressBar1.Maximum = tmpManagement.Count;
            progressBar1.Step = 1;

            // TORD
            foreach (KeyValuePair<int, int> TGID in tmpManagement.OrderBy(key => key.Value))
            {
                progressBar1.PerformStep();
                TGIDrecNo.Add(TGID.Key, Convert.ToInt32(TDB.FieldValue(tmpDB, "TEAM", "TGID", TGID.Key)));

                tmpTTYP.Add(Convert.ToInt32(TDB.FieldValue(tmpDB, "TEAM", "TTYP", TGID.Key)));

                tmpDGID.Add(Convert.ToInt32(TDB.FieldValue(tmpDB, "TEAM", "DGID", TGID.Key)));

                tmpLGID.Add(Convert.ToInt32(TDB.FieldValue(tmpDB, "TEAM", "LGID", TGID.Key)));

                if (TDB.TableIndex(dbIndex, "CONF") == -1)
                    tmpCGID.Add(Convert.ToInt32(TDB.FieldValue(tmpDB, "TEAM", "CGID", TGID.Key)));

            }
            progressBar1.Value = 0;
            tmpTTYP.Sort();
            tmpDGID.Sort();
            tmpLGID.Sort();
            tmpCGID.Sort();

            if (TDB.TableIndex(dbIndex, "CONF") == -1)
            {
                CONFlist.Clear();
            }

            #region Team Type Combo Box
            // TTYP
            TTYPcomboBox.Items.Clear();
            for (int i = 0; i < tmpTTYP.Count; i++)
            {
                tmpList.AddSafe(tmpTTYP[i], 0);
            }
            foreach (KeyValuePair<int, int> TTYP in tmpList)
            {
                TTYPcomboBox.Items.Add(TTYP.Key);
            }
            if (TTYPcomboBox.Items.Count > 0)
            {
                TTYPcomboBox.Items.Add(-1);
                TTYPcomboBox.SelectedIndex = TTYPcomboBox.Items.Count - 1;
            }
            tmpList.Clear();
            tmpTTYP.Clear();
            #endregion

            #region Team Division Combo Box
            // DGID
            DGIDcomboBox.Items.Clear();
            for (int i = 0; i < tmpDGID.Count; i++)
            {

                tmpList.AddSafe(tmpDGID[i], 0);

            }
            foreach (KeyValuePair<int, int> DGID in tmpList)
            {
                DGIDcomboBox.Items.Add(DGID.Key);
            }

            tmpList.Clear();
            tmpDGID.Clear();
            #endregion

            #region Team League Combo Box
            // LGID
            LGIDcomboBox.Items.Clear();
            for (int i = 0; i < tmpLGID.Count; i++)
            {

                tmpList.AddSafe(tmpLGID[i], 0);

            }
            foreach (KeyValuePair<int, int> LGID in tmpList)
            {
                LGIDcomboBox.Items.Add(LGID.Key);
            }

            tmpList.Clear();
            tmpLGID.Clear();
            #endregion

            #region Team Conference Combo Box
            // CGID
            CGIDcomboBox.Items.Clear();
            CONFlist.Clear();
            for (int i = 0; i < tmpCGID.Count; i++)
            {
                tmpList.AddSafe(tmpCGID[i], 0);
            }

            int tmpSelectedIndex = -1;
            foreach (KeyValuePair<int, int> CGID in tmpList)
            {
                CGIDcomboBox.Items.Add(CGID.Key);

                tmpSelectedIndex = tmpSelectedIndex + 1;
                CONFlist.Add(tmpSelectedIndex, CGID.Key);
            }

            tmpList.Clear();
            tmpCGID.Clear();
            #endregion


            tmpManagement.Clear();
        }
        public void LoadTGIDlistBox(int tmpDB, string tmpBOX, int tmpVAL)
        {
 
            TGIDlistBox.Items.Clear();
            TGIDplayerBox.Items.Clear();
            TGIDlist.Clear();


            if (TGIDrecNo.Count < 1)
                return;

            int tmpIndex = -1;
            string tmpTDNA = "";
            string tmpTLNA = "";
            string tmpFULL = "";
            int tmpFIELD = -1;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = TGIDrecNo.Count;
            progressBar1.Step = 1;

            foreach (KeyValuePair<int, int> TGID in TGIDrecNo)
            {
                progressBar1.PerformStep();

                tmpTDNA = TDB.FieldValue(tmpDB, "TEAM", "TMNA", TGID.Key);
                tmpTLNA = TDB.FieldValue(tmpDB, "TEAM", "TDNA", TGID.Key) + " ";
                tmpFIELD = Convert.ToInt32(TDB.FieldValue(tmpDB, "TEAM", tmpBOX, TGID.Key));

                if (LocationcheckBox.Checked)
                {
                    tmpFULL = tmpTLNA;
                }
                else if (MascotcheckBox.Checked)
                {
                    tmpFULL = tmpTDNA;
                }
                else tmpFULL = tmpTLNA + tmpTDNA;

                if (tmpVAL == -1)
                    tmpFIELD = -1;

                if (tmpFIELD == tmpVAL)
                {
                    tmpIndex = tmpIndex + 1;
                    TGIDlistBox.Items.Add(tmpFULL);
                    TGIDplayerBox.Items.Add(tmpFULL);
                    TGIDlist.Add(tmpIndex, TGID.Key);

                }
            }
            progressBar1.Value = 0;

        }

        public void MangPGID(int tmpDBindex)
        {
            PGIDrecNo.Clear();

            var TGIDd = new Dictionary<int, string>();
            bool tmpDIC = false;
            int tmpSelectIndex = -1;


            progressBar1.Minimum = 0;
            progressBar1.Maximum = tmpManagement.Count;
            progressBar1.Step = 1;

            if (TDB.TableIndex(dbIndex, "TEAM") == -1)
            {
                tmpDIC = true;
                TGIDplayerBox.Items.Clear();
                TGIDrecNo.Clear();
            }

            foreach (KeyValuePair<int, int> PGID in tmpManagement.OrderByDescending(key => key.Value))
            {
                progressBar1.PerformStep();

                int tmpPGID = Convert.ToInt32(TDB.FieldValue(tmpDBindex, "PLAY", "PGID", PGID.Key));
                int tmpTGID = (int)tmpPGID / 70;

                PGIDrecNo.Add(PGID.Key, tmpPGID);

                #region Add team's TGID if no TEAM table
                if (tmpDIC)
                {
                    if(!TGIDd.ContainsKey(tmpTGID))
                    TGIDd.Add(tmpTGID, teamNameDB[tmpTGID]);

                }
                #endregion

            }
            progressBar1.Value = 0;

            if (tmpDIC)
            {
                foreach (KeyValuePair<int, string> TGID in TGIDd.OrderBy(key => key.Key))
                {
                    tmpSelectIndex = tmpSelectIndex + 1;
                    TGIDrecNo.Add(TGID.Key, TGID.Key);
                    TGIDplayerBox.Items.Add(TGID.Value);
                    TGIDlist.Add(tmpSelectIndex, TGID.Key);
                    TGIDlistBox.Items.Add(TGID.Value);
                }
            }

            TGIDd.Clear();

            tmpManagement.Clear();
        }
        public void LoadPGIDlistBox(int tmpDBindex, int tmpTGID)
        {
            if (PGIDrecNo.Count < 1)
                return;



            int tmpIndex = -1;
            string tmpPFNA = "";
            string tmpPLNA = "";

            PGIDlistBox.Items.Clear();
            PGIDlist.Clear();
            ROSrecNo.Clear();

            progressBar1.Minimum = 0;
            progressBar1.Maximum = PGIDrecNo.Count;
            progressBar1.Step = 1;

            foreach (KeyValuePair<int, int> PGID in PGIDrecNo)
            {
                progressBar1.PerformStep();

                int TGID = (int)PGID.Value / 70;

                if (tmpTGID == TGID)
                {
                    tmpIndex = tmpIndex + 1;

                    tmpPFNA = ConvertFN_IntToString(PGID.Key);
                    tmpPLNA = ConvertLN_IntToString(PGID.Key);

                    PGIDlistBox.Items.Add(tmpPFNA + " " + tmpPLNA);
                    PGIDlist.Add(tmpIndex, PGID.Key);
                    ROSrecNo.Add(PGID.Key, PGID.Value);
                }

            }



            label4.Text = "Roster Size: " + Convert.ToString(PGIDlistBox.Items.Count);
            progressBar1.Value = 0;

        }

        public void MangCONF()
        {
            CONFrecNo.Clear();
            CONFlist.Clear();
            CGIDcomboBox.Items.Clear();

            int tmpSelectedIndex = -1;
            foreach (KeyValuePair<int, int> CGID in tmpManagement.OrderBy(key => key.Value))
            {
                tmpSelectedIndex = tmpSelectedIndex + 1;
                CONFrecNo.Add(CGID.Key, CGID.Value);
                CONFlist.Add(tmpSelectedIndex, CGID.Value);
            }

            foreach (KeyValuePair<int, int> CGID in CONFrecNo)
            {
                string tmpVal = TDB.FieldValue(dbIndex, "CONF", "CNAM", CGID.Key);

                CGIDcomboBox.Items.Add(tmpVal);
            }
            tmpManagement.Clear();
        }



        public void Editor_ConvertFN_InttoString(int tmpRecNo)
        {
            if (DoNotTrigger)
                return;

            for (int i = 1; i <= maxNameChar; i++)
            {
                string tmpSTR = "0";

                foreach (KeyValuePair<int, string> CHAR in Alphabet)
                {

                    if (i <= PFNAtextBox.Text.Length)
                        if (CHAR.Value == PFNAtextBox.Text.Substring(i - 1, 1))
                            tmpSTR = Convert.ToString(CHAR.Key);

                    TDB.NewfieldValue(dbIndex,
                                      "PLAY",
                                      "PF" + AddLeadingZeros(Convert.ToString(i), 2),
                                      tmpRecNo,
                                      tmpSTR);

                }

            }
            if (PGIDlistBox.Items.Count > 0)
                PGIDlistBox.Items[PGIDlistBox.SelectedIndex] = PFNAtextBox.Text + " " + PLNAtextBox.Text;
        }
        public void Editor_ConvertLN_IntToString(int tmpRecNo)
        {
            if (DoNotTrigger)
                return;

            for (int i = 1; i <= maxNameChar; i++)
            {
                string tmpSTR = "0";

                foreach (KeyValuePair<int, string> CHAR in Alphabet)
                {

                    if (i <= PLNAtextBox.Text.Length)
                        if (CHAR.Value == PLNAtextBox.Text.Substring(i - 1, 1))
                            tmpSTR = Convert.ToString(CHAR.Key);

                    TDB.NewfieldValue(dbIndex,
                                      "PLAY",
                                      "PL" + AddLeadingZeros(Convert.ToString(i), 2),
                                      tmpRecNo,
                                      tmpSTR);

                }

            }
            if (PGIDlistBox.Items.Count > 0)
                PGIDlistBox.Items[PGIDlistBox.SelectedIndex] = PFNAtextBox.Text + " " + PLNAtextBox.Text;
        }



        public void PGIDlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PGIDlistBox.SelectedIndex == -1)
                return;

            int tmpRecNo = PGIDlist[PGIDlistBox.SelectedIndex];

            GetPGID(tmpRecNo);
        }

        public void GetPGID(int tmpRecNo)
        {
            DoNotTrigger = true;

            PFNAtextBox.Text = ConvertFN_IntToString(tmpRecNo); //...first name from numeric to text conversion
            PLNAtextBox.Text = ConvertLN_IntToString(tmpRecNo); //...last name from numeric to text conversion

            DoNotTrigger = false;
        }

        public void TGIDplayerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tmpTGID = TGIDrecNo[TGIDlist[TGIDplayerBox.SelectedIndex]];

            TGIDlistBox.SelectedIndex = TGIDplayerBox.SelectedIndex;

            LoadPGIDlistBox(dbIndex, tmpTGID);
        }

        public void PFNAtextBox_TextChanged(object sender, EventArgs e)
        {
            if (PGIDlistBox.Items.Count < 1)
                return;

            int tmpRecNo = PGIDlist[PGIDlistBox.SelectedIndex];

            Editor_ConvertFN_InttoString(tmpRecNo);  // ...first name from text to numeric conversion

        }
        public void PLNAtextBox_TextChanged(object sender, EventArgs e)
        {
            if (PGIDlistBox.Items.Count < 1)
                return;

            int tmpRecNo = PGIDlist[PGIDlistBox.SelectedIndex];

            Editor_ConvertLN_IntToString(tmpRecNo);  // ...last name from text to numeric conversion

        }

        public void TTYPcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TTYPcomboBox.SelectedIndex == -1 || DoNotTrigger)
                return;

            DGIDcomboBox.SelectedIndex = -1;
            LGIDcomboBox.SelectedIndex = -1;
            CGIDcomboBox.SelectedIndex = -1;

            LoadTGIDlistBox(dbIndex, "TTYP", Convert.ToInt32(TTYPcomboBox.Items[TTYPcomboBox.SelectedIndex]));
        }
        public void DGIDcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DGIDcomboBox.SelectedIndex == -1 || DoNotTrigger)
                return;

            TTYPcomboBox.SelectedIndex = -1;
            LGIDcomboBox.SelectedIndex = -1;
            CGIDcomboBox.SelectedIndex = -1;


            LoadTGIDlistBox(dbIndex, "DGID", Convert.ToInt32(DGIDcomboBox.Items[DGIDcomboBox.SelectedIndex]));
        }
        public void LGIDcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LGIDcomboBox.SelectedIndex == -1 || DoNotTrigger)
                return;

            TTYPcomboBox.SelectedIndex = -1;
            DGIDcomboBox.SelectedIndex = -1;
            CGIDcomboBox.SelectedIndex = -1;


            LoadTGIDlistBox(dbIndex, "LGID", Convert.ToInt32(LGIDcomboBox.Items[LGIDcomboBox.SelectedIndex]));
        }
        public void CGIDcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CGIDcomboBox.SelectedIndex == -1 || DoNotTrigger)
                return;

            TTYPcomboBox.SelectedIndex = -1;
            DGIDcomboBox.SelectedIndex = -1;
            LGIDcomboBox.SelectedIndex = -1;

            LoadTGIDlistBox(dbIndex, "CGID", Convert.ToInt32(CONFlist[CGIDcomboBox.SelectedIndex]));
        }

        public void MascotcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            DoNotTrigger = true;
            LocationcheckBox.Checked = false;

            int tmpSelectedIndex = TGIDlistBox.SelectedIndex;

            TTYPcomboBox_SelectedIndexChanged(null, null);

            TGIDlistBox.SelectedIndex = tmpSelectedIndex;
            DoNotTrigger = false;
        }
        public void LocationcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            DoNotTrigger = true;
            MascotcheckBox.Checked = false;

            int tmpSelectedIndex = TGIDlistBox.SelectedIndex;

            TTYPcomboBox_SelectedIndexChanged(null, null);

            TGIDlistBox.SelectedIndex = tmpSelectedIndex;
            DoNotTrigger = false;
        }

        public void TGIDlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TGIDlistBox.Items.Count < 1 || TGIDlistBox.SelectedIndex == -1)
                return;

            int tmpRecNo = TGIDlist[TGIDlistBox.SelectedIndex];

            TGIDplayerBox.SelectedIndex = TGIDlistBox.SelectedIndex;

            GetTGID(tmpRecNo);

        }
        public void GetTGID(int tmpRecNo)
        {
            DoNotTrigger = true;

            TGIDtextBox.Text = TDB.FieldValue(dbIndex, "TEAM", "TGID", tmpRecNo);
            TDNAtextBox.Text = TDB.FieldValue(dbIndex, "TEAM", "TDNA", tmpRecNo);
            TMNAtextBox.Text = TDB.FieldValue(dbIndex, "TEAM", "TMNA", tmpRecNo);

            DoNotTrigger = false;
        }


        public void TDNAtextBox_TextChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            int tmpRecNo = TGIDlist[TGIDlistBox.SelectedIndex];

            TDB.NewfieldValue(dbIndex, "TEAM", "TDNA", tmpRecNo, TDNAtextBox.Text);
            TGIDlistBox.Items[TGIDlistBox.SelectedIndex] = TDNAtextBox.Text + " " + TMNAtextBox.Text;

        }
        public void TMNAtextBox_TextChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            int tmpRecNo = TGIDlist[TGIDlistBox.SelectedIndex];

            TDB.NewfieldValue(dbIndex, "TEAM", "TMNA", tmpRecNo, TMNAtextBox.Text);
            TGIDlistBox.Items[TGIDlistBox.SelectedIndex] = TDNAtextBox.Text + " " + TMNAtextBox.Text;

        }

        #endregion
    }
}
