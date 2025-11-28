using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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

        //League Database Updater

        private void UpdateDatabase()
        {
            /* Update TEAM, CONF, DIVI*/

            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            List<TextBox> confNames = GetConfNameTextBoxes();
            List<NumericUpDown> prestigeBoxes = GetConfPrestigeBoxes();
            List<Button> leagueButtons = GetLeagueButtons();
            List<int> cgidList = GetCGIDList();

            List<int> teamsRemoved = new List<int>(); //FBS teams that were removed
            List<int> teamsAdded = new List<int>(); //FCS teams that were added

            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = confBoxes.Count;

            /* Clear Divisions */

            for (int i = 0; i < main.GetTableRecCount("DIVI"); i++)
            {
                TDB.TDBTableRecordDeleted(0, "DIVI", i);
            }
            TDB.TDBDatabaseCompact(0);


            /* League Editor Data */

            for (int i = 0; i < confBoxes.Count; i++)
            {

                /* Conferences */

                int confRec = main.GetCONFrecFromCGID(cgidList[i]);

                //Conf Name
                main.ChangeDBString("CONF", "CNAM", confRec, confNames[i].Text);

                //Conf League
                if (leagueButtons[i].Text == "FBS") main.ChangeDBInt("CONF", "LGID", confRec, 0);
                else main.ChangeDBInt("CONF", "LGID", confRec, 1);

                //Conf Prestige & Min/Max 
                int cprs = Convert.ToInt32(prestigeBoxes[i].Value);
                main.ChangeDBInt("CONF", "CPRS", confRec, cprs);
                main.ChangeDBInt("CONF", "CMXP", confRec, cprs * 2);
                if (cprs < 1) cprs = 1;
                main.ChangeDBInt("CONF", "CMNP", confRec, cprs - 1);


                /* Teams */
                var c = confBoxes[i].Items;
                for (int x = 0; x < c.Count; x++)
                {
                    if (!c[x].Equals("*"))
                    {
                        string teamName = c[x].ToString();
                        int teamRec = main.FindTeamRecfromTeamName(teamName);
                        int tgid = main.GetDBValueInt("TEAM", "TGID", teamRec);
                        int ttyp = main.GetDBValueInt("TEAM", "TTYP", teamRec);

                        //Team CGID & DGID
                        main.ChangeDBInt("TEAM", "CGID", teamRec, cgidList[i]);
                        main.ChangeDBInt("TEAM", "DGID", teamRec, 15);

                        //Team Type
                        if (leagueButtons[i].Text == "FBS")
                        {
                            if (ttyp == 1)
                            {
                                teamsAdded.Add(tgid);
                            }

                            main.ChangeDBInt("TEAM", "TTYP", teamRec, 0);
                        }
                        else
                        {
                            if (ttyp == 0)
                            {
                                teamsRemoved.Add(tgid);
                            }
                            main.ChangeDBInt("TEAM", "TTYP", teamRec, 1);
                        }

                    }
                    else
                    {
                        break;
                    }
                }

                progressBar1.PerformStep();
            }

            /* Remaining Teams */
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = AllTeamsListBox.Items.Count;

            var t = AllTeamsListBox.Items;
            for (int i = 0; i < t.Count; i++)
            {
                string teamName = t[i].ToString();
                int teamRec = main.FindTeamRecfromTeamName(teamName);

                //Team CGID & DGID
                int currentConf = main.GetDBValueInt("TEAM", "CGID", teamRec);
                if (cgidList.Contains(currentConf)) main.ChangeDBInt("TEAM", "CGID", teamRec, 17);

                main.ChangeDBInt("TEAM", "DGID", teamRec, 15);

                if (main.GetDBValueInt("TEAM", "TTYP", teamRec) == 0)
                {
                    teamsRemoved.Add(main.GetDBValueInt("TEAM", "TGID", teamRec));
                }

                //Team Type
                main.ChangeDBInt("TEAM", "TTYP", teamRec, 1);

                progressBar1.PerformStep();
            }

            CheckConfCountDB();

            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = teamsAdded.Count;

            //Checks if it is League.DAT or Dynasty
            if (main.GetTableRecCount("PLAY") > 0)
            {
                //Create & Clear teams
                for (int i = 0; i < teamsRemoved.Count; i++)
                {
                    int tgid = teamsRemoved[i];
                    main.ClearTeamPlayers(tgid);
                    main.ClearOldTeamStats(tgid);
                    main.DepthChartRemoveTeam(tgid);
                }

                //Create Rosters 
                main.CreateNameConversionTable();
                main.CreateRatingsDB();
                main.CreatePOCItable();
                main.CreateTeamDB();

                for (int i = 0; i < teamsAdded.Count; i++)
                {
                    int tgid = teamsAdded[i];
                    main.GenerateFantasyRoster(tgid, 2, true);

                    int leaguesize = 120;
                   if(verNumber >= 16.0) leaguesize = 136;
                    main.DepthChartMakerSingle("TEAM", tgid, leaguesize, true);
                    progressBar1.PerformStep();
                }


                main.TEAM = true;
                main.RecalculateOverall(true);
                main.CalculateAllTeamRatings("TEAM");
            }

            progressBar1.Visible = true;
            progressBar1.Value = 0;

            
            
            //Schedule 
            ScheduleGenerator();

            MessageBox.Show("LEAGUE UPDATE COMPLETED!");

            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        private void CheckConfCountDB() 
        {
            List<int> Conferences = new List<int>();
            for(int i = 0; i < main.GetTableRecCount("CONF"); i++)
            {
                if (main.GetDBValueInt("CONF", "CGID", i) < 15 || main.GetDBValueInt("CONF", "CGID", i) > 17 && main.GetDBValueInt("CONF", "CGID", i) != 24)
                    Conferences.Add(i);
            }

            List<int> CountTeam17 = new List<int>();
            for(int i = 0; i < main.GetTableRecCount("TEAM"); i++)
            {
                if(main.GetDBValueInt("TEAM", "CGID", i) == 17) CountTeam17.Add(i);
            }

            for(int i = 0; i < Conferences.Count; i++)
            {
                bool teams = false;
                for (int t = 0; t < main.GetTableRecCount("TEAM"); t++)
                {
                    if (main.GetDBValueInt("TEAM", "CGID", t) == Conferences[i]) 
                    {
                        teams = true;
                        break;
                    }

                }

                if (!teams)
                {
                    main.ChangeDBInt("TEAM", "CGID", CountTeam17[0], Conferences[i]);
                    CountTeam17.RemoveAt(0);
                }

            }

        }



    }
}
