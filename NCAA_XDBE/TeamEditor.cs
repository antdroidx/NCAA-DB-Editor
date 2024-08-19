using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        /*
        * PLAYER & TEAM EDITOR (work from elguapo - not used currently)
        */
        #region TEAM EDITOR - STARTUP


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

        public void StartTeamEditor(int tmpDB)
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

        public void GetEditorConfList()
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
                string tmpVal = GetDBValue("CONF", "CNAM", CGID.Key);

                CGIDcomboBox.Items.Add(tmpVal);
            }
            tmpManagement.Clear();
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

            EditorIndex = TGIDlist[TGIDlistBox.SelectedIndex];

            TGIDplayerBox.SelectedIndex = TGIDlistBox.SelectedIndex;

            GetTeamEditorData(EditorIndex);

        }

        #endregion

        //GET DATA
        #region Load Team Data

        public void GetTeamEditorData(int EditorIndex)
        {
            DoNotTrigger = true;

            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 11;
            progressBar1.Step = 1;

            progressBar1.PerformStep();

            //User Coach
            if (GetDBValue("COCH", "CFUC", GetCOCHrecFromTeamRec(EditorIndex)) == "1") UserCoachCheckBox.Checked = true;
            else UserCoachCheckBox.Checked = false;

            //Affiliation Info
            LeagueBox.Text = GetLeaguefromTTYP(GetDBValueInt("TEAM", "TTYP", EditorIndex));
            TeamConferenceBox.Text = GetConfNameFromCGID(GetDBValueInt("TEAM", "CGID", EditorIndex));
            TeamDivisionBox.Text = GetDivisionNamefromDGID(GetDBValueInt("TEAM", "DGID", EditorIndex));

            progressBar1.PerformStep();

            //Team Name
            TGIDtextBox.Text = GetDBValue("TEAM", "TGID", EditorIndex);
            TDNAtextBox.Text = GetDBValue("TEAM", "TDNA", EditorIndex);
            TMNAtextBox.Text = GetDBValue("TEAM", "TMNA", EditorIndex);
            TSNAtextBox.Text = GetDBValue("TEAM", "TSNA", EditorIndex);

            progressBar1.PerformStep();

            //Team Ratings
            TeamOVRtextbox.Text = GetDBValue("TEAM", "TROV", EditorIndex);
            TMPRNumBox.Value = GetDBValueInt("TEAM", "TMPR", EditorIndex);
            TMARNumBox.Value = GetDBValueInt("TEAM", "TMAR", EditorIndex);

            progressBar1.PerformStep();

            //Season Records
            APPollBox.Text = GetDBValue("TEAM", "TMRK", EditorIndex);
            CoachPollBox.Text = GetDBValue("TEAM", "TCRK", EditorIndex);
            SeasonRecordBox.Text = GetDBValue("TEAM", "tsdw", EditorIndex) + " - " + GetDBValue("TEAM", "tsdl", EditorIndex);
            ConfRecordBox.Text = GetDBValue("TEAM", "tscw", EditorIndex) + " - " + GetDBValue("TEAM", "tscl", EditorIndex);

            progressBar1.PerformStep();

            //NCAA Investigation
            INPOnumbox.Value = GetDBValueInt("TEAM", "INPO", EditorIndex);
            NCDPnumbox.Value = GetDBValueInt("TEAM", "NCDP", EditorIndex);
            SDURnumbox.Value = GetDBValueInt("TEAM", "SDUR", EditorIndex);
            SNCTnumbox.Value = GetDBValueInt("TEAM", "SNCT", EditorIndex);
            
            progressBar1.PerformStep();

            //Head Coach Info
            HCFirstNameBox.Text = GetCoachFirstNamefromRec(GetCOCHrecFromTeamRec(EditorIndex));
            HCLastNameBox.Text = GetCoachLastNamefromRec(GetCOCHrecFromTeamRec(EditorIndex));
            TeamHCPrestigeNumBox.Value = GetDBValueInt("COCH", "CPRE", GetCOCHrecFromTeamRec(EditorIndex));
            TeamCCPONumBox.Value = GetDBValueInt("COCH", "CCPO", GetCOCHrecFromTeamRec(EditorIndex));
            GetCCPOboxColor();

            progressBar1.PerformStep();

            //Off-Season Budgets
            TeamCDPCBox.Text = GetDBValue("COCH", "CDPC", GetCOCHrecFromTeamRec(EditorIndex));
            TeamCTPCNumber.Value = GetDBValueInt("COCH", "CTPC", GetCOCHrecFromTeamRec(EditorIndex));
            TeamCRPCNumber.Value = GetDBValueInt("COCH", "CRPC", GetCOCHrecFromTeamRec(EditorIndex));

            progressBar1.PerformStep();

            //Playbook & Strategies
            GetPlaybookItems();
            PlaybookSelectBox.SelectedIndex = GetPlaybookSelectedIndex();


            GetOffTypeItems();
            OffTypeSelectBox.SelectedIndex = GetDBValueInt("COCH", "COST", GetCOCHrecFromTeamRec(EditorIndex));

            GetDefTypeItems();
            DefTypeSelectBox.SelectedIndex = GetDBValueInt("COCH", "CDST", GetCOCHrecFromTeamRec(EditorIndex));

            //OffTypeBox.Text = GetOffTypeName(GetDBValueInt("COCH", "COST", GetCOCHrecFromTeamRec(EditorIndex)));
            //BaseDefBox.Text = GetDefTypeName(GetDBValueInt("COCH", "CDST", GetCOCHrecFromTeamRec(EditorIndex)));
            
            TeamCOTRbox.Value = GetDBValueInt("COCH", "COTR", GetCOCHrecFromTeamRec(EditorIndex));
            TeamCOTAbox.Value = GetDBValueInt("COCH", "COTA", GetCOCHrecFromTeamRec(EditorIndex));
            TeamCOTSbox.Value = GetDBValueInt("COCH", "COTS", GetCOCHrecFromTeamRec(EditorIndex));
            TeamCDTRbox.Value = GetDBValueInt("COCH", "CDTR", GetCOCHrecFromTeamRec(EditorIndex));
            TeamCDTAbox.Value = GetDBValueInt("COCH", "CDTA", GetCOCHrecFromTeamRec(EditorIndex));
            TeamCDTSbox.Value = GetDBValueInt("COCH", "CDTS", GetCOCHrecFromTeamRec(EditorIndex));

            progressBar1.PerformStep();

            //Team Captains & Impact Players
            TeamCaptain1box.Text = GetTeamImpactPlayer(EditorIndex, "OCAP");
            TeamCaptain2box.Text = GetTeamImpactPlayer(EditorIndex, "DCAP");
            TPIOtextbox.Text = GetTeamImpactPlayer(EditorIndex, "TPIO");
            TPIDtextbox.Text = GetTeamImpactPlayer(EditorIndex, "TPID");
            TSI1textbox.Text = GetTeamImpactPlayer(EditorIndex, "TSI1");
            TSI2textbox.Text = GetTeamImpactPlayer(EditorIndex, "TSI2");

            progressBar1.PerformStep();

            //Team Colors
            TeamColor1Button.BackColor = Color.FromArgb(GetDBValueInt("TEAM", "TFRD", EditorIndex), GetDBValueInt("TEAM", "TFFG", EditorIndex), GetDBValueInt("TEAM", "TFFB", EditorIndex));
            TeamColor2Button.BackColor = Color.FromArgb(GetDBValueInt("TEAM", "TFOR", EditorIndex), GetDBValueInt("TEAM", "TFOG", EditorIndex), GetDBValueInt("TEAM", "TFOB", EditorIndex));
            primary = TeamColor1Button.BackColor;
            secondary = TeamColor2Button.BackColor;

            progressBar1.PerformStep();

            //City, State, Stadium Info
            stadiumNameBox.Text = GetDBValue("STAD", "SNAM", FindSTADrecFromTEAMrec(EditorIndex));
            CityNameBox.Text = GetDBValue("STAD", "SCIT", FindSTADrecFromTEAMrec(EditorIndex));
            GetStateBoxItems();
            StateBox.SelectedIndex = GetDBValueInt("STAD", "STID", FindSTADrecFromTEAMrec(EditorIndex));

            AttendanceNumBox.Value = GetDBValueInt("TEAM", "TMAA", EditorIndex);
            CapacityNumbox.Value = GetDBValueInt("STAD", "SCAP", FindSTADrecFromTEAMrec(EditorIndex));



            DoNotTrigger = false;
            progressBar1.Value = 0;
        }

        private void GetStateBoxItems()
        {
            StateBox.Items.Clear();
            List<string> states = CreateStringListfromCSV(@"resources\RCST.csv", true);

            foreach (string state in states)
            {
                StateBox.Items.Add(state);
            }
        }

        private void GetPlaybookItems()
        {
            List<List<string>> pb = CreatePlaybookNames();
            //136-158 next ||  124 and below is vanilla

            if (GetDBValueInt("COCH", "CPID", GetCOCHrecFromTeamRec(EditorIndex)) > 135)
            {
                for(int i = 136; i <= 158; i++)
                {
                    PlaybookSelectBox.Items.Add(pb[i][1]);
                }
            }
            else
            {
                for (int i = 0; i <= 124; i++)
                {
                    PlaybookSelectBox.Items.Add(pb[i][1]);
                }
            }

        }

        private int GetPlaybookSelectedIndex()
        {
            int pbVal = GetDBValueInt("COCH", "CPID", GetCOCHrecFromTeamRec(EditorIndex));

            //136-158 next ||  124 and below is vanilla
            if (pbVal > 135) pbVal = pbVal - 136;
           
            return pbVal;
        }

        private void GetOffTypeItems()
        {
            OffTypeSelectBox.Items.Clear();
            List<string> OffTypes = CreateOffTypes();


            foreach (string name in OffTypes)
            {
                OffTypeSelectBox.Items.Add(name);
            }
        }

        private void GetDefTypeItems()
        {
            DefTypeSelectBox.Items.Clear();
            List<string> DefTypes = CreateBaseDef();


            foreach (string name in DefTypes)
            {
                DefTypeSelectBox.Items.Add(name);
            }
        }

        #endregion

        //Text Change Triggers
        #region Text Box Changes

        //User Coach
        private void UserCoachCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            if (UserCoachCheckBox.Checked) ChangeDBInt("COCH", "CFUC", GetCOCHrecFromTeamRec(EditorIndex), 1);
            else if (!UserCoachCheckBox.Checked) ChangeDBInt("COCH", "CFUC", GetCOCHrecFromTeamRec(EditorIndex), 0);

        }

        //Team Name
        public void TDNAtextBox_TextChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;



            ChangeDBString("TEAM", "TDNA", EditorIndex, TDNAtextBox.Text);
            TGIDlistBox.Items[TGIDlistBox.SelectedIndex] = TDNAtextBox.Text + " " + TMNAtextBox.Text;

        }
        public void TMNAtextBox_TextChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;



            ChangeDBString("TEAM", "TMNA", EditorIndex, TMNAtextBox.Text);
            TGIDlistBox.Items[TGIDlistBox.SelectedIndex] = TDNAtextBox.Text + " " + TMNAtextBox.Text;

        }


        //Team Prestige
        private void TMPRNumBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("TEAM", "TMPR", EditorIndex, Convert.ToString(TMPRNumBox.Value));
        }
        //Team Academics
        private void TMARNumBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("TEAM", "TMAR", EditorIndex, Convert.ToString(TMARNumBox.Value));
        }

        //NCAA Investigation
        private void INPOnumbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("TEAM", "INPO", EditorIndex, Convert.ToString(INPOnumbox.Value));
        }

        //Discipline Points

        private void NCDPnumbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("TEAM", "NCDP", EditorIndex, Convert.ToString(NCDPnumbox.Value));
        }

        //NCAA Sanction

        private void SNCTnumbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("TEAM", "SNCT", EditorIndex, Convert.ToString(SNCTnumbox.Value));
        }

        //Sanction Duration

        private void SDURnumbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("TEAM", "SDUR", EditorIndex, Convert.ToString(SDURnumbox.Value));
        }

        //Head Coach First Name
        private void HCFirstNameBox_TextChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("COCH", "CLFN", GetCOCHrecFromTeamRec(EditorIndex), HCFirstNameBox.Text);
        }

        //Head Coach Last Name
        private void HCLastNameBox_TextChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("COCH", "CLLN", GetCOCHrecFromTeamRec(EditorIndex), HCLastNameBox.Text);
        }

        //Head Coach Prestige
        private void TeamHCPrestigeNumBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("COCH", "CPRE", GetCOCHrecFromTeamRec(EditorIndex), Convert.ToString(TeamHCPrestigeNumBox.Value));
        }

        //Coach Performance
        private void TeamCCPONumBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBString("COCH", "CCPO", GetCOCHrecFromTeamRec(EditorIndex), Convert.ToString(TeamCCPONumBox.Value));
            GetCCPOboxColor();
        }

        //Training
        private void TeamCTPCNumber_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            if (TeamCRPCNumber.Value + TeamCTPCNumber.Value < 100)
            {
                ChangeDBString("COCH", "CTPC", GetCOCHrecFromTeamRec(EditorIndex), Convert.ToString(TeamCTPCNumber.Value));
                int discpts = 100 - (GetDBValueInt("COCH", "CTPC", GetCOCHrecFromTeamRec(EditorIndex)) + GetDBValueInt("COCH", "CRPC", GetCOCHrecFromTeamRec(EditorIndex)));
                ChangeDBString("COCH", "CDPC", GetCOCHrecFromTeamRec(EditorIndex), Convert.ToString(discpts));

                TeamCDPCBox.Text = GetDBValue("COCH", "CDPC", GetCOCHrecFromTeamRec(EditorIndex));
            }
            else
            {
                TeamCTPCNumber.Value = GetDBValueInt("COCH", "CTPC", GetCOCHrecFromTeamRec(EditorIndex));
            }
        }

        //Recruiting
        private void TeamCRPCNumber_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            if (TeamCRPCNumber.Value + TeamCTPCNumber.Value < 100)
            {
                ChangeDBString("COCH", "CRPC", GetCOCHrecFromTeamRec(EditorIndex), Convert.ToString(TeamCRPCNumber.Value));
                int discpts = 100 - (GetDBValueInt("COCH", "CTPC", GetCOCHrecFromTeamRec(EditorIndex)) + GetDBValueInt("COCH", "CRPC", GetCOCHrecFromTeamRec(EditorIndex)));
                ChangeDBString("COCH", "CDPC", GetCOCHrecFromTeamRec(EditorIndex), Convert.ToString(discpts));

                TeamCDPCBox.Text = GetDBValue("COCH", "CDPC", GetCOCHrecFromTeamRec(EditorIndex));
            }

            else
            {
                TeamCRPCNumber.Value = GetDBValueInt("COCH", "CRPC", GetCOCHrecFromTeamRec(EditorIndex));
            }
        }


        //Strategy

        //Playbook Selection
        private void PlaybookSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            int pbVal = 0;

            List<List<string>> pb = CreatePlaybookNames();
            //136-158 next ||  124 and below is vanilla

            if (GetDBValueInt("COCH", "CPID", GetCOCHrecFromTeamRec(EditorIndex)) > 135)
            {
                pbVal = PlaybookSelectBox.SelectedIndex + 136;
            }
            else
            {
                pbVal = PlaybookSelectBox.SelectedIndex;
            }


            ChangeDBInt("COCH", "CPID", GetCOCHrecFromTeamRec(EditorIndex), pbVal);
        }

        //Off Type Selection
        private void OffTypeSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "COST", GetCOCHrecFromTeamRec(EditorIndex), OffTypeSelectBox.SelectedIndex);
        }
        //Def Type Selection

        private void DefTypeSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "CDST", GetCOCHrecFromTeamRec(EditorIndex), DefTypeSelectBox.SelectedIndex);
        }

        //Off Passing Strategy 
        private void TeamCOTRbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "COTR", GetCOCHrecFromTeamRec(EditorIndex), Convert.ToInt32(TeamCOTRbox.Value));
        }

        //Off Aggressiveness
        private void TeamCOTAbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "COTA", GetCOCHrecFromTeamRec(EditorIndex), Convert.ToInt32(TeamCOTAbox.Value));
        }

        //Off Subs
        private void TeamCOTSbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "COTS", GetCOCHrecFromTeamRec(EditorIndex), Convert.ToInt32(TeamCOTSbox.Value));
        }

        //Def Passing Strategy
        private void TeamCDTRbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "CDTR", GetCOCHrecFromTeamRec(EditorIndex), Convert.ToInt32(TeamCDTRbox.Value));
        }

        //Def Aggessiveness
        private void TeamCDTAbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "CDTA", GetCOCHrecFromTeamRec(EditorIndex), Convert.ToInt32(TeamCDTAbox.Value));
        }

        //Def Subs
        private void TeamCDTSbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "CDTS", GetCOCHrecFromTeamRec(EditorIndex), Convert.ToInt32(TeamCDTSbox.Value));
        }





        //Avg Attendance
        private void AttendanceNumBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("TEAM", "TMAA", EditorIndex, Convert.ToInt32(AttendanceNumBox.Value));
            if( AttendanceNumBox.Value > CapacityNumbox.Value)
            {
                CapacityNumbox.Value = AttendanceNumBox.Value;
                ChangeDBInt("STAD", "SCAP", FindSTADrecFromTEAMrec(EditorIndex), Convert.ToInt32(CapacityNumbox.Value));

            }

        }

        //Stadium Capacity
        private void CapacityNumbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("STAD", "SCAP", FindSTADrecFromTEAMrec(EditorIndex), Convert.ToInt32(CapacityNumbox.Value));
        }

        private void StateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("STAD", "STID", FindSTADrecFromTEAMrec(EditorIndex), StateBox.SelectedIndex);
        }

        #endregion

        //Team Primary Color
        private void TeamColor1Button_Click(object sender, EventArgs e)
        {
            colorDialog1.CustomColors = new int[] { ColorTranslator.ToOle(primary), ColorTranslator.ToOle(secondary), };
            colorDialog1.ShowDialog();
            TeamColor1Button.BackColor = colorDialog1.Color;

            ChangeDBString("TEAM", "TFRD", EditorIndex, Convert.ToString(Convert.ToDecimal(TeamColor1Button.BackColor.R)));
            ChangeDBString("TEAM", "TFFG", EditorIndex, Convert.ToString(Convert.ToDecimal(TeamColor1Button.BackColor.G)));
            ChangeDBString("TEAM", "TFFB", EditorIndex, Convert.ToString(Convert.ToDecimal(TeamColor1Button.BackColor.B)));

        }

        //Team Secondary Color
        private void TeamColor2Button_Click(object sender, EventArgs e)
        {
            colorDialog1.CustomColors = new int[] { ColorTranslator.ToOle(primary), ColorTranslator.ToOle(secondary), };
            colorDialog1.ShowDialog();
            TeamColor2Button.BackColor = colorDialog1.Color;

            ChangeDBString("TEAM", "TFOR", EditorIndex, Convert.ToString(Convert.ToDecimal(TeamColor2Button.BackColor.R)));
            ChangeDBString("TEAM", "TFOG", EditorIndex, Convert.ToString(Convert.ToDecimal(TeamColor2Button.BackColor.G)));
            ChangeDBString("TEAM", "TFOB", EditorIndex, Convert.ToString(Convert.ToDecimal(TeamColor2Button.BackColor.B)));
        }

        //Reset Primary Color
        private void ResetPrimaryColorButton_Click(object sender, EventArgs e)
        {
            TeamColor1Button.BackColor = primary;

            ChangeDBString("TEAM", "TFRD", EditorIndex, Convert.ToString(Convert.ToDecimal(TeamColor1Button.BackColor.R)));
            ChangeDBString("TEAM", "TFFG", EditorIndex, Convert.ToString(Convert.ToDecimal(TeamColor1Button.BackColor.G)));
            ChangeDBString("TEAM", "TFFB", EditorIndex, Convert.ToString(Convert.ToDecimal(TeamColor1Button.BackColor.B)));
        }

        //Reset Secondary Color
        private void ResetSecondaryColorButton_Click(object sender, EventArgs e)
        {
            TeamColor2Button.BackColor = secondary;

            ChangeDBString("TEAM", "TFOR", EditorIndex, Convert.ToString(Convert.ToDecimal(TeamColor2Button.BackColor.R)));
            ChangeDBString("TEAM", "TFOG", EditorIndex, Convert.ToString(Convert.ToDecimal(TeamColor2Button.BackColor.G)));
            ChangeDBString("TEAM", "TFOB", EditorIndex, Convert.ToString(Convert.ToDecimal(TeamColor2Button.BackColor.B)));
        }


        private void GetCCPOboxColor()
        {
            if(TeamCCPONumBox.Value <= 5) TeamCCPONumBox.BackColor = Color.FromArgb(255, 199, 206);
            else if(TeamCCPONumBox.Value <= 25) TeamCCPONumBox.BackColor = Color.Orange;
            else if (TeamCCPONumBox.Value <= 49) TeamCCPONumBox.BackColor = Color.LightGoldenrodYellow;
            else if (TeamCCPONumBox.Value < 75) TeamCCPONumBox.BackColor = Color.LightGreen;
            else TeamCCPONumBox.BackColor = Color.LightBlue;
        }


        //Fire Single Head Coach

        private void FireHeadCoach()
        {
            if (UserCoachCheckBox.Checked)
            {
                MessageBox.Show("User Coach cannot be fired.");
                return;
            }

            var result = MessageBox.Show("Are you sure?", "Fire Head Coach", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                int tgid = GetDBValueInt("TEAM", "TGID", EditorIndex);

                bool hired = false;

                while (!hired)
                {
                    int applicant = rand.Next(0, TDB.TableRecordCount(dbIndex, "COCH"));
                    if (GetDBValueInt("COCH", "TGID", applicant) == 511)
                    {
                        ChangeDBInt("COCH", "TGID", GetCOCHrecFromTeamRec(EditorIndex), 511);
                        ChangeDBInt("COCH", "CCPO", GetCOCHrecFromTeamRec(EditorIndex), 65);

                        ChangeDBInt("COCH", "TGID", applicant, tgid);
                        ChangeDBInt("COCH", "CCPO", applicant, 65);

                        GetTeamEditorData(EditorIndex);

                        hired = true;
                        MessageBox.Show(GetDBValue("COCH", "CLFN", applicant) + " " + GetDBValue("COCH", "CLLN", applicant) + " was hired!");

                    }
                }
            }

        }



    }
}
