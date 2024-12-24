﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        private void StartStadiumEditor()
        {
            StadiumIndex = -1;

            LoadStadiumListBox();
        }

        private void LoadStadiumListBox()
        {
            StadiumListBox.Items.Clear();
            List<string> teamList = new List<string>();


            for (int i = 0; i < GetTableRecCount("STAD"); i++)
            {
                teamList.Add(GetDBValue("STAD", "TDNA", i));
            }


            //teamList.Sort();

            for (int i = 0; i < teamList.Count; i++)
            {
                if (teamList[i] != null) StadiumListBox.Items.Add(teamList[i]);
            }

        }


        private void StadiumListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            StadiumIndex = StadiumListBox.SelectedIndex;
            LoadStadiumData();
        }

        #region Load Stadium Data
        private void LoadStadiumData()
        {
            DoNotTrigger = true;

            //Stadium DB Info
            STADsgidBox.Text = GetDBValue("STAD", "SGID", StadiumIndex);
            STADResBox.Text = GetDBValue("STAD", "SRES", StadiumIndex);
            STADTDNA.Text = GetDBValue("STAD", "TDNA", StadiumIndex);
            STADSTDR.Text = GetDBValue("STAD", "STDR", StadiumIndex);
            STADSTDR.BackColor = GetRatingColor(STADSTDR).BackColor;



            //Stadium Info
            STADNameBox.Text = GetDBValue("STAD", "SNAM", StadiumIndex);
            STADNickBox.Text = GetDBValue("STAD", "STNN", StadiumIndex);
            STADCity.Text = GetDBValue("STAD", "SCIT", StadiumIndex);
            GetSTADStateBoxItems();
            STADState.SelectedIndex = GetDBValueInt("STAD", "STID", StadiumIndex);

            STADCap.Value = GetDBValueInt("STAD", "SCAP", StadiumIndex);

            GetFieldTypes();
            STADSFTYBox.SelectedIndex = GetDBValueInt("STAD", "SFTY", StadiumIndex);

            //Stadium Weather
            STtsBox.Value = GetDBValueInt("STAD", "STts", StadiumIndex);
            STjtBox.Value = GetDBValueInt("STAD", "STjt", StadiumIndex);

            STtvBox.Value = GetDBValueInt("STAD", "STtv", StadiumIndex);
            STfwBox.Value = GetDBValueInt("STAD", "STfw", StadiumIndex);
            STwpBox.Value = GetDBValueInt("STAD", "STwp", StadiumIndex);

            SWFPBox.Value = GetDBValueInt("STAD", "SWFP", StadiumIndex);
            SWWPBox.Value = GetDBValueInt("STAD", "SWWP", StadiumIndex);
            SWRPBox.Value = GetDBValueInt("STAD", "SWRP", StadiumIndex);
            SWSPBox.Value = GetDBValueInt("STAD", "SWSP", StadiumIndex);

            //Stadium Options
            STADVisbility.Checked = false;
            STADcat.Checked = false;
            STADCannon.Checked = false;
            STADType.Checked = false;

            if (GetDBValueInt("STAD", "SUTf", StadiumIndex) == 1) STADVisbility.Checked = true;
            if (GetDBValueInt("STAD", "SCRE", StadiumIndex) == 1) STADcat.Checked = true;
            if (GetDBValueInt("STAD", "STCA", StadiumIndex) == 1) STADCannon.Checked = true;
            if (GetDBValueInt("STAD", "STYP", StadiumIndex) == 1)
            {
                STADType.Checked = true;
                ChangeDBInt("STAD", "STYP", StadiumIndex, 1);

                ChangeDBInt("STAD", "SWFP", StadiumIndex, 0);
                ChangeDBInt("STAD", "SWWP", StadiumIndex, 0);
                ChangeDBInt("STAD", "SWSP", StadiumIndex, 0);
                ChangeDBInt("STAD", "SWRP", StadiumIndex, 0);

                ChangeDBInt("STAD", "STjt", StadiumIndex, 70);
                ChangeDBInt("STAD", "STts", StadiumIndex, 70);
                ChangeDBInt("STAD", "STtv", StadiumIndex, 0);
                ChangeDBInt("STAD", "STfw", StadiumIndex, 0);
                ChangeDBInt("STAD", "STwp", StadiumIndex, 0);
            }

            DoNotTrigger = false;

        }

        private void GetSTADStateBoxItems()
        {
            STADState.Items.Clear();
            List<string> states = CreateStringListfromCSV(@"resources\players\RCST.csv", true);

            foreach (string state in states)
            {
                STADState.Items.Add(state);
            }
        }

        private void GetFieldTypes()
        {
            STADSFTYBox.Items.Clear();

            STADSFTYBox.Items.Add("Natural - Light");
            STADSFTYBox.Items.Add("Natural - Dark");
            STADSFTYBox.Items.Add("Artificial");
            STADSFTYBox.Items.Add("Blue Turf");
            STADSFTYBox.Items.Add("Grassy Turf");
            STADSFTYBox.Items.Add("Multi-Turf");
        }

        #endregion

        #region Triggers

        //Info

        private void STADNameBox_Leave(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBString("STAD", "SNAM", StadiumIndex, STADNameBox.Text);
        }

        private void STADNickBox_Leave(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBString("STAD", "STNN", StadiumIndex, STADNickBox.Text);
        }

        private void STADCity_Leave(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBString("STAD", "SCIT", StadiumIndex, STADCity.Text);
        }

        private void STADState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBInt("STAD", "STID", StadiumIndex, STADState.SelectedIndex);
            ChangeDBString("STAD", "SSTA", StadiumIndex, Convert.ToString(STADState.SelectedItem));
        }

        private void STADCap_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBString("STAD", "SCAP", StadiumIndex, STADCap.Text);
        }

        private void STADSFTYBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBInt("STAD", "SFTY", StadiumIndex, STADSFTYBox.SelectedIndex);
        }

        //Weather

        private void STtsBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBInt("STAD", "STts", StadiumIndex, Convert.ToInt32(STtsBox.Value));
        }

        private void STjtBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBInt("STAD", "STjt", StadiumIndex, Convert.ToInt32(STjtBox.Value));
        }


        private void STtvBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBInt("STAD", "STtv", StadiumIndex, Convert.ToInt32(STtvBox.Value));

        }

        private void STfwBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBInt("STAD", "STfw", StadiumIndex, Convert.ToInt32(STfwBox.Value));
        }

        private void STwpBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBInt("STAD", "STwp", StadiumIndex, Convert.ToInt32(STwpBox.Value));
        }

        private void SWFPBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBInt("STAD", "SWFP", StadiumIndex, Convert.ToInt32(SWFPBox.Value));
        }

        private void SWWPBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBInt("STAD", "SWWP", StadiumIndex, Convert.ToInt32(SWWPBox.Value));
        }

        private void SWRPBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBInt("STAD", "SWRP", StadiumIndex, Convert.ToInt32(SWRPBox.Value));
        }

        private void SWSPBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBInt("STAD", "SWSP", StadiumIndex, Convert.ToInt32(SWSPBox.Value));
        }

        //Stadium Options
        private void STADVisbility_CheckedChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            if (STADVisbility.Checked) ChangeDBInt("STAD", "SUTf", StadiumIndex, 1);
            else ChangeDBInt("STAD", "SUTf", StadiumIndex, 0);
        }

        private void STADCannon_CheckedChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            if (STADCannon.Checked) ChangeDBInt("STAD", "STCA", StadiumIndex, 1);
            else ChangeDBInt("STAD", "STCA", StadiumIndex, 0);
        }

        private void STADType_CheckedChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            if (STADType.Checked)
            {
                ChangeDBInt("STAD", "STYP", StadiumIndex, 1);

                ChangeDBInt("STAD", "SWFP", StadiumIndex, 0);
                ChangeDBInt("STAD", "SWWP", StadiumIndex, 0);
                ChangeDBInt("STAD", "SWSP", StadiumIndex, 0);
                ChangeDBInt("STAD", "SWRP", StadiumIndex, 0);

                ChangeDBInt("STAD", "STjt", StadiumIndex, 70);
                ChangeDBInt("STAD", "STts", StadiumIndex, 70);
                ChangeDBInt("STAD", "STfw", StadiumIndex, 0);
                ChangeDBInt("STAD", "STwp", StadiumIndex, 0);
            }
            else ChangeDBInt("STAD", "STYP", StadiumIndex, 0);
        }


        #endregion


        #region Global Editor

        private void GlobalWeather_Click(object sender, EventArgs e)
        {
            List<List<string>> weather = CreateStringListsFromCSV(@"resources\misc\weather-data.csv", true);

            int[,] temperature = GetTemperatureData();



            for (int i = 0; i < GetTableRecCount("STAD"); i++)
            {
                int state = GetDBValueInt("STAD", "STID", i);

                int tgid = FindTGIDfromSGID(GetDBValueInt("STAD", "SGID", i));

                if (GetDBValueInt("STAD", "STYP", i) == 0)
                {
                    ChangeDBString("STAD", "SWFP", i, weather[state][5]);
                    ChangeDBString("STAD", "SWWP", i, weather[state][4]);
                    ChangeDBString("STAD", "SWSP", i, weather[state][3]);
                    ChangeDBString("STAD", "SWRP", i, weather[state][2]);

                    if (tgid != -1 && temperature[tgid, 0] > 0)
                    {
                        ChangeDBInt("STAD", "STts", i, temperature[tgid, 0]);
                        ChangeDBInt("STAD", "STjt", i, temperature[tgid, 1]);

                        if (GetDBValueInt("STAD", "STtv", i) < 3)
                        {
                            ChangeDBInt("STAD", "STtv", i, 3);
                        }
                    }
                }
                else
                {
                    ChangeDBInt("STAD", "SWFP", i, 0);
                    ChangeDBInt("STAD", "SWWP", i, 0);
                    ChangeDBInt("STAD", "SWSP", i, 0);
                    ChangeDBInt("STAD", "SWRP", i, 0);

                    ChangeDBInt("STAD", "STjt", i, 70);
                    ChangeDBInt("STAD", "STts", i, 70);
                    ChangeDBInt("STAD", "STtv", i, 0);
                    ChangeDBInt("STAD", "STfw", i, 0);
                    ChangeDBInt("STAD", "STwp", i, 0);
                }

            }


            MessageBox.Show("Weather Info Imported and Updated!");

        }

        private int[,] GetTemperatureData()
        {
            int[,] tempData = new int[511,2];
            string location = @"resources\misc\temp-data.csv";
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, location);

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int Row = 0;
            int skip = 0;
            bool skipFirstRow = true;

            if (skipFirstRow) skip = -1;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (skipFirstRow && Row == 0) /*do nothing*/;
                else
                {
                    for (int column = 1; column < Line.Length; column++)
                    {
                        tempData[Convert.ToInt32(Line[0]), column-1] = Convert.ToInt32(Line[column]);
                    }
                }

                Row++;
            }
            sr.Close();

            return tempData;
        }

        #endregion

    }

}
