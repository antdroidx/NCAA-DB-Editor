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
        /* Scheduling System */
        /*
         *   
         */

        private List<string> AddCONFTables()
        {
            List<string> tables = new List<string>();

            tables.Add("SACC");
            tables.Add("SBTN");
            tables.Add("SBTW");
            tables.Add("SBEA");
            tables.Add("SCUS");
            tables.Add("SCHD"); //indepdents - not used!
            tables.Add("SMAC");
            tables.Add("SMWS");
            tables.Add("SPTN");
            tables.Add("SSEC");
            tables.Add("SSUN");
            tables.Add("SWAC");

            return tables;
        }

        private List<List<int>> GetScheduleTemplate(int count)
        {
            List<List<int>> template = new List<List<int>>();
            if (count == 12)
            {
                if(rand.Next(0,100) > 50) template = CreateIntListsFromCSV(@"resources\schedules\" + count + "-teamB.csv", true);
                else template = CreateIntListsFromCSV(@"resources\schedules\" + count + "-team.csv", true);
            }
            else
            {
                template = CreateIntListsFromCSV(@"resources\schedules\" + count + "-team.csv", true);
            }

            return template;
        }

        private void ClearScheduleTables(string table)
        {
            for (int i = 0; i < GetTableRecCount(table); i++)
            {
                TDB.TDBTableRecordChangeDeleted(dbIndex2, table, i, true);
            }
            TDB.TDBDatabaseCompact(dbIndex2);
        }

        private void ScheduleGenerator()
        {
            GenerateConfSchedules();
            GenerateSKNW();

            if(!ArmyNavy && NextMod)
            {
                ClearAnnuals();
                TDB.TDBTableRecordAdd(dbIndex2, "SANN", false);
                ChangeDBInt("SANN", "GTOD", 0, 1200);
                ChangeDBInt("SANN", "GATG", 0, 8);
                ChangeDBInt("SANN", "GHTG", 0, 57);
                ChangeDBInt("SANN", "SESI", 0, 1);
                ChangeDBInt("SANN", "SEWN", 0, 15);
                ChangeDBInt("SANN", "GDAT", 0, 5);
                ChangeDBInt("SANN", "SEWT", 0, 15);

                TDB.TDBTableRecordAdd(dbIndex2, "SANN", false);
                ChangeDBInt("SANN", "GTOD", 1, 1200);
                ChangeDBInt("SANN", "GATG", 1, 57);
                ChangeDBInt("SANN", "GHTG", 1, 8);
                ChangeDBInt("SANN", "SESI", 1, 0);
                ChangeDBInt("SANN", "SEWN", 1, 15);
                ChangeDBInt("SANN", "GDAT", 1, 5);
                ChangeDBInt("SANN", "SEWT", 1, 15);

            }

            MessageBox.Show("Conference Schedule Generation Completed!");
        }

        private void GenerateConfSchedules()
        {
            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            List<Button> leagueButtons = GetLeagueButtons();
            List<int> cgidList = GetCGIDList();
            List<string> CONFTables = AddCONFTables();

            for (int i = 0; i < confBoxes.Count; i++)
            {
                if (i != 5)
                {
                    //Clear CONF Table
                    ClearScheduleTables(CONFTables[i]);

                    if (leagueButtons[i].Text == "FBS")
                    {
                        //Count Conf Teams and get a list of TGIDs
                        int count = 0;
                        List<int> tgids = new List<int>();
                        for (int t = 0; t < confBoxes[i].Items.Count; t++)
                        {
                            if (!confBoxes[i].Items[t].Equals("*"))
                            {
                                tgids.Add(main.GetDBValueInt("TEAM", "TGID", main.FindTeamRecfromTeamName(Convert.ToString(confBoxes[i].Items[t]))));
                                count++;
                            }
                        }

                        //Load Schedule Template
                        List<List<int>> template = GetScheduleTemplate(count);

                        /* GTOD, GATG, GHTG, SESI, SEWN,GDAT, SEWT */

                        //Fill Schedules
                        int tableRec = 0;
                        for (int g = 0; g < template.Count; g++)
                        {
                            int away = tgids[template[g][1] - 1];
                            int home = tgids[template[g][2] - 1];
                            string table = CONFTables[i];

                            //Add a record
                            TDB.TDBTableRecordAdd(dbIndex2, table, true);

                            ChangeDBInt(table, "GTOD", tableRec, template[g][0]);
                            ChangeDBInt(table, "GATG", tableRec, away);
                            ChangeDBInt(table, "GHTG", tableRec, home);
                            ChangeDBInt(table, "SESI", tableRec, template[g][3]);
                            ChangeDBInt(table, "SEWN", tableRec, template[g][4]);
                            ChangeDBInt(table, "GDAT", tableRec, template[g][5]);
                            ChangeDBInt(table, "SEWT", tableRec, template[g][6]);

                            //check for Army-Navy game
                            if(away == 57 & home == 8)
                            {
                                ChangeDBInt(table, "SEWN", tableRec, 15);
                                ChangeDBInt(table, "SEWT", tableRec, 15);
                                ArmyNavy = true;
                            }
                            else if (away == 8 && home == 57)
                            {
                                ChangeDBInt(table, "SEWN", tableRec, 15);
                                ChangeDBInt(table, "SEWT", tableRec, 15);
                                ArmyNavy = true;
                            }

                            tableRec++;
                        }
                    }
                }
            }

        }

        private void ClearAnnuals()
        {
            ClearScheduleTables("SANN");
        }

        private void GenerateSKNW()
        {
            ClearScheduleTables("SKNW");

            List<string> CONFTables = AddCONFTables();

            //Extract Season 0's from each conference
            int tableRec = 0;
            for (int i = 0; i < CONFTables.Count; i++)
            {
                string table = CONFTables[i];
                for(int g = 0; g < GetTableRecCount(table); g++)
                {
                    if(GetDBValueInt(table, "SESI", g) == 0)
                    {
                        TDB.TDBTableRecordAdd(dbIndex2, "SKNW", true);
                        ChangeDBInt("SKNW", "GTOD", tableRec, GetDBValueInt(table, "GTOD", g));
                        ChangeDBInt("SKNW", "GATG", tableRec, GetDBValueInt(table, "GATG", g));
                        ChangeDBInt("SKNW", "GHTG", tableRec, GetDBValueInt(table, "GHTG", g));
                        ChangeDBInt("SKNW", "SESI", tableRec, GetDBValueInt(table, "SESI", g));
                        ChangeDBInt("SKNW", "SEWN", tableRec, GetDBValueInt(table, "SEWN", g));
                        ChangeDBInt("SKNW", "GDAT", tableRec, GetDBValueInt(table, "GDAT", g));
                        ChangeDBInt("SKNW", "SEWT", tableRec, GetDBValueInt(table, "SEWT", g));
                        tableRec++;
                    }
                }
            }

        }


    }
}
