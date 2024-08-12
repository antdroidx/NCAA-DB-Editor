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
        #region PLAYER EDITOR - NOT COMPLETE

        public void StartPlayerEditor(int tmpDBindex)
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
                    if (!TGIDd.ContainsKey(tmpTGID))
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

                    tmpPFNA = GetFirstNameFromRecord(PGID.Key);
                    tmpPLNA = GetLastNameFromRecord(PGID.Key);

                    PGIDlistBox.Items.Add(tmpPFNA + " " + tmpPLNA);
                    PGIDlist.Add(tmpIndex, PGID.Key);
                    ROSrecNo.Add(PGID.Key, PGID.Value);
                }

            }



            label4.Text = "Roster Size: " + Convert.ToString(PGIDlistBox.Items.Count);
            progressBar1.Value = 0;

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

            PFNAtextBox.Text = GetFirstNameFromRecord(tmpRecNo); //...first name from numeric to text conversion
            PLNAtextBox.Text = GetLastNameFromRecord(tmpRecNo); //...last name from numeric to text conversion

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



        #endregion
    }
}
