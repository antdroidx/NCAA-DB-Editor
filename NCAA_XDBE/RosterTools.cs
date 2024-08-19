using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        //FORCE A GRADUATION AND TRANSFER CYCLE OFFLINE

        private void GraduateAndTransferPlayers()
        {
            /* create a list of transfers from transfers.csv
          *  transfers [x][y] = [item][player name, new team, old pgid, new pgid]
         */
            List<List<string>> transfers = CreateStringListsFromCSV(@"resources\transfers.csv", true);

            //remove graduation/nfl players
            int removed = 0;
            int transferred = 0;

            //Setup Progress bar
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "PLAY");
            progressBar1.Step = 1;
            progressBar1.Value = 0;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PLAY"); i++)
            {
                if (GetDBValueInt("PLAY", "PTYP", i) == 3)
                {
                    //remove player from database
                    TDB.TDBTableRecordChangeDeleted(dbIndex, "PLAY", i, true);
                    removed++;
                    //clear stats
                    ClearPlayerStats(GetDBValueInt("PLAY", "PGID", i));

                }
                else if (GetDBValueInt("PLAY", "PTYP", i) == 1)
                {
                    //renumber transfers PGID
                    int year = GetDBValueInt("PLAY", "PYER", i);
                    if (year > 2) year = 2;
                    ChangeDBInt("PLAY", "PYER", i, year + 1);
                    int newPGID = 30000 + transferred;
                    transfers = AddNewPGIDtoTransferList(GetDBValueInt("PLAY", "PGID", i), newPGID, transfers);
                    ChangeDBInt("PLAY", "PGID", i, newPGID);

                    transferred++;
                }
                else
                {
                    int year = GetDBValueInt("PLAY", "PYER", i);
                    if (year > 2) year = 2;
                    else if (year < 1)
                    {
                        if (rand.Next(0, 4) == 0)
                        {
                            year = -1;
                            ChangeDBInt("PLAY", "PRSD", i, 2);
                        }
                    }
                    ChangeDBInt("PLAY", "PYER", i, year + 1);
                }

                progressBar1.PerformStep();
            }

            TDB.TDBDatabaseCompact(dbIndex);


            //transfer players

            int nottransferred = 0;
            int transfersuccess = 0;
            List<string> teamList = new List<string>();

            //Setup Progress bar
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = transfers.Count;
            progressBar1.Step = 1;
            progressBar1.Value = 0;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "TDYN"); i++)
            {
                teamList.Add(GetDBValue("TDYN", "TOID", i));
            }

            for (int i = 0; i < transfers.Count; i++)
            {
                if (teamList.Contains(transfers[i][1]))
                {


                    int team = Convert.ToInt32(transfers[i][1]);
                    int tmpPGID = Convert.ToInt32(transfers[i][3]);


                    //Create a list of PGIDs in the database for team
                    List<int> rosters = new List<int>();
                    for (int j = 0; j < TDB.TableRecordCount(dbIndex, "PLAY"); j++)
                    {
                        if (GetDBValueInt("PLAY", "PGID", j) >= team * 70 && GetDBValueInt("PLAY", "PGID", j) < team * 70 + 69) rosters.Add(GetDBValueInt("PLAY", "PGID", j));
                    }

                    for (int j = team * 70; j < team * 70 + 68; j++)
                    {
                        if (!rosters.Contains(j))
                        {
                            for (int k = 0; k < TDB.TableRecordCount(dbIndex, "PLAY"); k++)
                            {
                                if (GetDBValueInt("PLAY", "PGID", k) == tmpPGID)
                                {
                                    ChangeDBInt("PLAY", "PGID", k, j);

                                    //change stat pgid
                                    ChangePlayerStatsID(tmpPGID, j);
                                    transfersuccess++;

                                    break;
                                }
                            }
                            break;
                        }
                    }
                }

                progressBar1.PerformStep();
            }


            //Setup Progress bar
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "PLAY");
            progressBar1.Step = 1;
            progressBar1.Value = 0;

            //increase ratings 
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PLAY"); i++)
            {
                if (GetDBValueInt("PLAY", "PGID", i) >= 30000)
                {
                    TDB.TDBTableRecordChangeDeleted(dbIndex, "PLAY", i, true);
                    nottransferred++;
                }
                else RandomizeAttribute("PLAY", i, 4);

                progressBar1.PerformStep();
            }


            TDB.TDBDatabaseCompact(dbIndex);

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("There were " + removed + " players graduated or went to NFL.\n\n" + "There were " + transferred + " transfer players, " + transfersuccess + " successfully transferred to FBS and " + nottransferred + " players did not transfer to FBS and were removed.");

            //RecalculateOverall();
        }

        private void ClearPlayerStats(int pgid)
        {
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PSDE"); i++)
            {
                if (GetDBValueInt("PSDE", "PGID", i) == pgid) TDB.TDBTableRecordChangeDeleted(dbIndex, "PSDE", i, true);
                break;
            }

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PSKI"); i++)
            {
                if (GetDBValueInt("PSKI", "PGID", i) == pgid) TDB.TDBTableRecordChangeDeleted(dbIndex, "PSKI", i, true);
                break;
            }

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PSKP"); i++)
            {
                if (GetDBValueInt("PSKP", "PGID", i) == pgid) TDB.TDBTableRecordChangeDeleted(dbIndex, "PSKP", i, true);
                break;
            }

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PSOF"); i++)
            {
                if (GetDBValueInt("PSOF", "PGID", i) == pgid) TDB.TDBTableRecordChangeDeleted(dbIndex, "PSOF", i, true);
                break;
            }

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PSOL"); i++)
            {
                if (GetDBValueInt("PSOL", "PGID", i) == pgid) TDB.TDBTableRecordChangeDeleted(dbIndex, "PSOL", i, true);
                break;
            }

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PSRC"); i++)
            {
                if (GetDBValueInt("PSRC", "PGID", i) == pgid) TDB.TDBTableRecordChangeDeleted(dbIndex, "PSRC", i, true);
                break;
            }

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PSRN"); i++)
            {
                if (GetDBValueInt("PSRN", "PGID", i) == pgid) TDB.TDBTableRecordChangeDeleted(dbIndex, "PSRN", i, true);
                break;
            }

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PSRT"); i++)
            {
                if (GetDBValueInt("PSRT", "PGID", i) == pgid) TDB.TDBTableRecordChangeDeleted(dbIndex, "PSRT", i, true);
                break;
            }

        }

        private void ChangePlayerStatsID(int pgid, int newpgid)
        {
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PSDE"); i++)
            {
                if (GetDBValueInt("PSDE", "PGID", i) == pgid) ChangeDBInt("PSDE", "PGID", i, newpgid);
                break;
            }

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PSKI"); i++)
            {
                if (GetDBValueInt("PSKI", "PGID", i) == pgid) ChangeDBInt("PSKI", "PGID", i, newpgid);
                break;
            }

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PSKP"); i++)
            {
                if (GetDBValueInt("PSKP", "PGID", i) == pgid) ChangeDBInt("PSKP", "PGID", i, newpgid);
                break;
            }

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PSOF"); i++)
            {
                if (GetDBValueInt("PSOF", "PGID", i) == pgid) ChangeDBInt("PSOF", "PGID", i, newpgid);
                break;
            }

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PSOL"); i++)
            {
                if (GetDBValueInt("PSOL", "PGID", i) == pgid) ChangeDBInt("PSOL", "PGID", i, newpgid);
                break;
            }

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PSRC"); i++)
            {
                if (GetDBValueInt("PSRC", "PGID", i) == pgid) ChangeDBInt("PSRC", "PGID", i, newpgid);
                break;
            }

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PSRN"); i++)
            {
                if (GetDBValueInt("PSRN", "PGID", i) == pgid) ChangeDBInt("PSRN", "PGID", i, newpgid);
                break;
            }

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PSRT"); i++)
            {
                if (GetDBValueInt("PSRT", "PGID", i) == pgid) ChangeDBInt("PSRT", "PGID", i, newpgid);
                break;
            }
        }

        private List<List<string>> AddNewPGIDtoTransferList(int oldpgid, int newpgid, List<List<string>> transferList)
        {
            for (int i = 0; i < transferList.Count; i++)
            {
                if (transferList[i][2] == Convert.ToString(oldpgid))
                {
                    transferList[i][3] = (Convert.ToString(newpgid));
                }
            }

            return transferList;
        }

        //Load and create Transfers

        private void CreateTransfersFromCSV()
        {
            CreateRCATtable();
            List<List<string>> PlayerList = CreateStringListsFromCSV(@"resources\transfers-gen.csv", true);
            List<List<int>> PJEN = CreateJerseyNumberDB();
            List<List<string>> RCATmapper = CreateStringListsFromCSV(@"resources\RCAT-MAPPER.csv", false);

            //First	 Last	POSG	TGID

            int created = 0;

            //Create a list of active teams
            List<int> teamList = new List<int>();

            //Setup Progress bar
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = PlayerList.Count;
            progressBar1.Step = 1;
            progressBar1.Value = 0;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "TDYN"); i++)
            {
                teamList.Add(GetDBValueInt("TDYN", "TOID", i));
            }

            for (int i = 0; i < PlayerList.Count; i++)
            {
                string FN = PlayerList[i][0];
                string LN = PlayerList[i][1];
                int position = Convert.ToInt32(PlayerList[i][2]);
                int team = Convert.ToInt32(PlayerList[i][3]);

                if (teamList.Contains(team))
                {
                    //Create a list of PGIDs in the database for team
                    List<int> rosters = new List<int>();
                    for (int j = 0; j < TDB.TableRecordCount(dbIndex, "PLAY"); j++)
                    {
                        if (GetDBValueInt("PLAY", "PGID", j) >= team * 70 && GetDBValueInt("PLAY", "PGID", j) < team * 70 + 70) rosters.Add(GetDBValueInt("PLAY", "PGID", j));
                    }

                    //Check for open PGID slots
                    for (int j = team * 70; j < team * 70 + 69; j++)
                    {
                        if (!rosters.Contains(j))
                        {
                            int rec = TDB.TableRecordCount(dbIndex, "PLAY");
                            TDB.TDBTableRecordAdd(dbIndex, "PLAY", false);
                            position = ChooseRandomPosFromPOSG(position);
                            CreateNamedTransfersfromRCAT(rec, position, j, RCATmapper, PJEN, 50, FN, LN);
                            created++;
                            break;
                        }
                    }
                }

                progressBar1.PerformStep();

            }


            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("There were " + created + " created from " + PlayerList.Count + " possible Transfers.");
        }

        //CSV Generated Transfers RCAT to PLAY field
        private void CreateNamedTransfersfromRCAT(int rec, int ppos, int PGID, List<List<string>> map, List<List<int>> PJEN, int FreshmanPCT, string FN, string LN)
        {
            bool x = true;
            while (x)
            {
                int r = rand.Next(0, RCAT.Count);
                if (RCAT[r][45] == ppos)
                {
                    for (int i = 0; i < map.Count; i++)
                    {
                        int RCATcol = Convert.ToInt32(map[i][0]); //finds the column number that the RCAT attribute value lives in
                        string field = map[i][1]; //finds the name of the attribute

                        ChangeDBString("PLAY", field, rec, Convert.ToString(RCAT[r][RCATcol]));
                    }

                    string redshirt = "0";
                    if (rand.Next(0, 3) > 2) redshirt = "2";

                    ChangeDBInt("PLAY", "RCHD", rec, rand.Next(0, 12864)); //hometown
                    ChangeDBString("PLAY", "PGID", rec, Convert.ToString(PGID)); //player id
                    ChangeDBString("PLAY", "PHPD", rec, "0"); //PHPD
                    ChangeDBString("PLAY", "PRSD", rec, redshirt); //Redshirt
                    ChangeDBString("PLAY", "PLMG", rec, "0"); //Mouthguard
                    ChangeDBString("PLAY", "PFGM", rec, "0"); //face shape (to be calculated later)
                    ChangeDBInt("PLAY", "PJEN", rec, ChooseJerseyNumber(ppos, PJEN)); //jersey num
                    ChangeDBString("PLAY", "PTEN", rec, "0"); //tendency (to be calculated later)
                    ChangeDBString("PLAY", "PFMP", rec, "0"); //face (to be calculated later)
                    ChangeDBInt("PLAY", "PIMP", rec, rand.Next(0, 32)); //importance (to be re-calculated later)
                    ChangeDBString("PLAY", "PTYP", rec, "0"); //player type (graduation/nfl,etc)
                    ChangeDBString("PLAY", "POVR", rec, "0"); //overall, to be calculated later
                    ChangeDBString("PLAY", "PSLY", rec, "0"); //PSLY
                    ChangeDBString("PLAY", "PRST", rec, "0"); //PRST

                    if (rand.Next(1, 101) < FreshmanPCT) ChangeDBInt("PLAY", "PYER", rec, 0); //year/class
                    else ChangeDBInt("PLAY", "PYER", rec, rand.Next(1, 3)); //year/class

                    ConvertFirstNameStringToInt(FN, rec, "PLAY");
                    ConvertLastNameStringToInt(LN, rec, "PLAY");

                    RandomizeAttribute("PLAY", rec, 4);
                    RandomizePlayerHead("PLAY", rec);

                    x = false;
                }
            }
        }

        //Load and create Recruits

        private void CreateRecruitsFromCSV()
        {
            CreateRCATtable();
            List<List<string>> RecruitsList = CreateStringListsFromCSV(@"resources\recruits.csv", true);
            List<List<int>> PJEN = CreateJerseyNumberDB();
            List<List<string>> RCATmapper = CreateStringListsFromCSV(@"resources\RCAT-MAPPER.csv", false);

            //First	Last	Position	TGID	Height	Weight

            //Create a list of Active Teams
            List<int> teamList = new List<int>();
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "TDYN"); i++)
            {
                teamList.Add(GetDBValueInt("TDYN", "TOID", i));
            }


            //Setup Progress bar
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = RecruitsList.Count;
            progressBar1.Step = 1;
            progressBar1.Value = 0;


            int recruitsCreated = 0;

            for (int i = 0; i < RecruitsList.Count; i++)
            {
                string FN = RecruitsList[i][0];
                string LN = RecruitsList[i][1];
                int position = Convert.ToInt32(RecruitsList[i][2]);
                int team = Convert.ToInt32(RecruitsList[i][3]);
                int height = Convert.ToInt32(RecruitsList[i][4]);
                int weight = Convert.ToInt32(RecruitsList[i][5]);

                if (teamList.Contains(team))
                {
                    //Create a list of PGIDs in the database for team
                    List<int> rosters = new List<int>();
                    for (int j = 0; j < TDB.TableRecordCount(dbIndex, "PLAY"); j++)
                    {
                        if (GetDBValueInt("PLAY", "PGID", j) >= team * 70 && GetDBValueInt("PLAY", "PGID", j) < team * 70 + 70) rosters.Add(GetDBValueInt("PLAY", "PGID", j));
                    }

                    //Check for open PGID slots
                    for (int j = team * 70; j < team * 70 + 69; j++)
                    {
                        if (!rosters.Contains(j))
                        {
                            int rec = TDB.TableRecordCount(dbIndex, "PLAY");
                            TDB.TDBTableRecordAdd(dbIndex, "PLAY", false);
                            CreateNamedRecruitfromRCAT(rec, position, j, RCATmapper, PJEN, 100, FN, LN, height, weight);
                            recruitsCreated++;
                            break;
                        }
                    }
                }
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("There were " + recruitsCreated + " created from " + RecruitsList.Count + " possible recruits.");
        }

        //CSV Recruits RCAT to PLAY field
        private void CreateNamedRecruitfromRCAT(int rec, int ppos, int PGID, List<List<string>> map, List<List<int>> PJEN, int FreshmanPCT, string FN, string LN, int height, int weight)
        {
            bool x = true;
            while (x)
            {
                int r = rand.Next(0, RCAT.Count);
                if (RCAT[r][45] == ppos)
                {
                    for (int i = 0; i < map.Count; i++)
                    {
                        int RCATcol = Convert.ToInt32(map[i][0]); //finds the column number that the RCAT attribute value lives in
                        string field = map[i][1]; //finds the name of the attribute

                        ChangeDBString("PLAY", field, rec, Convert.ToString(RCAT[r][RCATcol]));
                    }

                    string redshirt = "0";
                    if (rand.Next(0, 3) > 2) redshirt = "2";

                    ChangeDBInt("PLAY", "RCHD", rec, rand.Next(0, 12864)); //hometown
                    ChangeDBString("PLAY", "PGID", rec, Convert.ToString(PGID)); //player id
                    ChangeDBString("PLAY", "PHPD", rec, "0"); //PHPD
                    ChangeDBString("PLAY", "PRSD", rec, redshirt); //Redshirt
                    ChangeDBString("PLAY", "PLMG", rec, "0"); //Mouthguard
                    ChangeDBString("PLAY", "PFGM", rec, "0"); //face shape (to be calculated later)
                    ChangeDBInt("PLAY", "PJEN", rec, ChooseJerseyNumber(ppos, PJEN)); //jersey num
                    ChangeDBString("PLAY", "PTEN", rec, "0"); //tendency (to be calculated later)
                    ChangeDBString("PLAY", "PFMP", rec, "0"); //face (to be calculated later)
                    ChangeDBInt("PLAY", "PIMP", rec, rand.Next(0, 32)); //importance (to be re-calculated later)
                    ChangeDBString("PLAY", "PTYP", rec, "0"); //player type (graduation/nfl,etc)
                    ChangeDBString("PLAY", "POVR", rec, "0"); //overall, to be calculated later
                    ChangeDBString("PLAY", "PSLY", rec, "0"); //PSLY
                    ChangeDBString("PLAY", "PRST", rec, "0"); //PRST

                    if (rand.Next(1, 101) < FreshmanPCT) ChangeDBInt("PLAY", "PYER", rec, 0); //year/class
                    else ChangeDBInt("PLAY", "PYER", rec, rand.Next(1, 4)); //year/class

                    ChangeDBInt("PLAY", "PHGT", rec, height); //Height
                    ChangeDBInt("PLAY", "PWGT", rec, weight); //Weight

                    ConvertFirstNameStringToInt(FN, rec, "PLAY");
                    ConvertLastNameStringToInt(LN, rec, "PLAY");

                    RandomizeAttribute("PLAY", rec, 2);
                    RandomizePlayerHead("PLAY", rec);

                    x = false;
                }
            }
        }

    }
}
