using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
// using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {


        #region Fantasy Roster Generator
        //Fantasy Roster Generator
        private void FantasyRosterGenerator(string tableName)
        {
            /* Creates a fantasy roster from team overall rating
             * Use RCAT, sort by position, count position players
             * randomize each raing + random from 0 to overall rating/10
             * make sure there's a mininum number of positions then randomize rest
             */


            //Setup Progress bar
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount(tableName);
            progressBar1.Step = 1;
            progressBar1.Value = 0;


            //Clear PLAY Table
            for (int i = GetTableRecCount("PLAY"); i != -1; i--)
            {
                TDB.TDBTableRecordRemove(dbIndex, "PLAY", i);
            }
            CreateRCATtable();
            CreateFirstNamesDB();
            CreateLastNamesDB();
            List<List<int>> PJEN = CreateJerseyNumberDB();

            List<List<string>> RCATmapper = CreateStringListsFromCSV(@"resources\players\RCAT-MAPPER.csv", false);

            List<List<string>> teamData = new List<List<string>>();
            teamData = CreateStringListsFromCSV(@"resources\FantasyGenData.csv", true);

            int rec = 0;
            int leagueType = 0;
            if (tableName == "TDYN")
            {
                if (FBSroster.Checked) leagueType = 0; //FBS
                else leagueType = 1; //FCS

                for(int i = 0; i < GetTableRecCount(tableName); i++)
                {
                    DeleteRecord(tableName, i, true);
                }
                CompactDB();

                int r = 0;
                for(int i = 0; i < teamData.Count; i++)
                {
                    if (Convert.ToInt32(teamData[i][3]) == leagueType)
                    {
                        AddTableRecord(tableName, true);
                        ChangeDBInt(tableName, "TOID", r, Convert.ToInt32(teamData[i][0])); //TGID
                        r++;
                    }
                }
            }

            for (int i = 0; i < GetTableRecCount(tableName); i++)
            {
                if (TDYN || GetDBValueInt(tableName, "TTYP", i) == 0)
                {
                    List<int> AvailablePJEN = new List<int>();
                    int TOID = GetDBValueInt(tableName, "TOID", i);
                    int PGIDbeg = TOID * 70;
                    int PGIDend = PGIDbeg + 69;
                    int rating = GetFantasyTeamRating(teamData, TOID);
                    int ST = 0;
                    int freshmanPCT = 25;


                    for (int j = 0; j < MaxFantasyPlayers.Value; j++)
                    {
                        //Add a record
                        AddTableRecord("PLAY", false);
                        //QB
                        if (j < 3) TransferRCATtoPLAY(rec, 0, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //RB
                        else if (j < 6) TransferRCATtoPLAY(rec, 1, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //FB
                        else if (j < 7) TransferRCATtoPLAY(rec, 2, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //WR
                        else if (j < 13) TransferRCATtoPLAY(rec, 3, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //TE
                        else if (j < 16) TransferRCATtoPLAY(rec, 4, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //LT
                        else if (j < 18) TransferRCATtoPLAY(rec, 5, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //LG
                        else if (j < 20) TransferRCATtoPLAY(rec, 6, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //C
                        else if (j < 22) TransferRCATtoPLAY(rec, 7, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //RG
                        else if (j < 24) TransferRCATtoPLAY(rec, 8, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //RT
                        else if (j < 26) TransferRCATtoPLAY(rec, 9, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //LE
                        else if (j < 28) TransferRCATtoPLAY(rec, 10, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //DT
                        else if (j < 32) TransferRCATtoPLAY(rec, 11, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //RE
                        else if (j < 34) TransferRCATtoPLAY(rec, 12, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //LOLB
                        else if (j < 36) TransferRCATtoPLAY(rec, 13, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //MLB
                        else if (j < 39) TransferRCATtoPLAY(rec, 14, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //ROLB
                        else if (j < 41) TransferRCATtoPLAY(rec, 15, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //CB
                        else if (j < 46) TransferRCATtoPLAY(rec, 16, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //SS
                        else if (j < 48) TransferRCATtoPLAY(rec, 17, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //FS
                        else if (j < 50) TransferRCATtoPLAY(rec, 18, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //K
                        else if (j < 51) TransferRCATtoPLAY(rec, 19, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        //P
                        else if (j < 52) TransferRCATtoPLAY(rec, 20, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                        else
                        {
                            if (ST < 1)
                            {
                                TransferRCATtoPLAY(rec, rand.Next(0, 21), PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);
                                ST++;
                            }
                            else TransferRCATtoPLAY(rec, rand.Next(0, 19), PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);
                        }


                        //randomizes the attributes from team overall
                        RandomizeAttribute("PLAY", rec, rating + GetDBValueInt("PLAY", "PYER", rec) - 1);


                        rec++;
                    }

                    //Finish team and perform step counter
                    progressBar1.PerformStep();
                }
            }


            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Fantasy Players Created!");

            RecalculateOverall();
            RecalculateBodyShape("PLAY");
            RecalculateQBTendencies();
            CalculateAllTeamRatings(tableName);

            MessageBox.Show("Fantasy Roster Generation is complete!\n\nRun the Depth Chart Tool to create Depth Charts!");

        }

        public void FantasyRosterGeneratorSingle(int tgid, int rating)
        {

            //Remove existing Players
            ClearTeamPlayers(tgid);


            //Clear Old Stats
            ClearOldTeamStats(tgid);

            //Create New Roster
            CreateRCATtable();
            CreateFirstNamesDB();
            CreateLastNamesDB();
            CreateTeamDB();


            List<List<int>> PJEN = CreateJerseyNumberDB();
            List<int> AvailablePJEN = new List<int>();

            List<List<string>> RCATmapper = CreateStringListsFromCSV(@"resources\players\RCAT-MAPPER.csv", false);

            int rec = GetTableRecCount("PLAY");
            int PGIDbeg = tgid * 70;
            int PGIDend = PGIDbeg + 69;
            int ST = 0;
            int freshmanPCT = 25;


            for (int j = 0; j < 68; j++)
            {
                //Add a record
                AddTableRecord("PLAY", false);

                //QB
                if (j < 3) TransferRCATtoPLAY(rec, 0, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //RB
                else if (j < 6) TransferRCATtoPLAY(rec, 1, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //FB
                else if (j < 7) TransferRCATtoPLAY(rec, 2, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //WR
                else if (j < 13) TransferRCATtoPLAY(rec, 3, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //TE
                else if (j < 16) TransferRCATtoPLAY(rec, 4, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //LT
                else if (j < 18) TransferRCATtoPLAY(rec, 5, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //LG
                else if (j < 20) TransferRCATtoPLAY(rec, 6, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //C
                else if (j < 22) TransferRCATtoPLAY(rec, 7, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //RG
                else if (j < 24) TransferRCATtoPLAY(rec, 8, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //RT
                else if (j < 26) TransferRCATtoPLAY(rec, 9, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //LE
                else if (j < 28) TransferRCATtoPLAY(rec, 10, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //DT
                else if (j < 32) TransferRCATtoPLAY(rec, 11, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //RE
                else if (j < 34) TransferRCATtoPLAY(rec, 12, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //LOLB
                else if (j < 36) TransferRCATtoPLAY(rec, 13, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //MLB
                else if (j < 39) TransferRCATtoPLAY(rec, 14, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //ROLB
                else if (j < 41) TransferRCATtoPLAY(rec, 15, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //CB
                else if (j < 46) TransferRCATtoPLAY(rec, 16, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //SS
                else if (j < 48) TransferRCATtoPLAY(rec, 17, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //FS
                else if (j < 50) TransferRCATtoPLAY(rec, 18, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //K
                else if (j < 51) TransferRCATtoPLAY(rec, 19, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                //P
                else if (j < 52) TransferRCATtoPLAY(rec, 20, PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);

                else
                {
                    if (ST < 1)
                    {
                        TransferRCATtoPLAY(rec, rand.Next(0, 21), PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);
                        ST++;
                    }
                    else TransferRCATtoPLAY(rec, rand.Next(0, 19), PGIDbeg + j, RCATmapper, PJEN, AvailablePJEN, freshmanPCT);
                }



                //randomizes the attributes from team overall
                RandomizeAttribute("PLAY", rec, rating + GetDBValueInt("PLAY", "PYER", rec) - 1);
                rec++;
            }


            MessageBox.Show(teamNameDB[tgid] + " Roster has been generated.");
        }



        private int GetFantasyTeamRating(List<List<String>> teamData, int TGID)
        {
            int value = 0;

            if (FantasyCSV.Checked)
            {
                for (int i = 0; i < teamData.Count; i++)
                {
                    if (teamData[i][0] == Convert.ToString(TGID))
                    {
                        return Convert.ToInt32(teamData[i][2]);
                    }
                }
            }
            else
            {
                value = FindTeamPrestige(TGID);
            }

            return value;
        }

        //Transfers RCAT to PLAY field
        private void TransferRCATtoPLAY(int rec, int ppos, int PGID, List<List<string>> map, List<List<int>> PJEN, List<int> AvailablePJEN, int FreshmanPCT)
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


                    int ht = PickRandomHometown();

                    ChangeDBInt("PLAY", "RCHD", rec, ht); //hometown
                    ChangeDBString("PLAY", "PGID", rec, Convert.ToString(PGID)); //player id
                    ChangeDBString("PLAY", "PHPD", rec, "0"); //PHPD
                    ChangeDBString("PLAY", "PRSD", rec, redshirt); //Redshirt
                    ChangeDBString("PLAY", "PLMG", rec, "0"); //Mouthguard
                    ChangeDBString("PLAY", "PFGM", rec, "0"); //face shape (to be calculated later)
                    ChangeDBInt("PLAY", "PJEN", rec, ChooseJerseyNumber(ppos, PJEN)); //jersey num
                    ChangeDBString("PLAY", "PTEN", rec, "0"); //tendency (to be calculated later)
                    ChangeDBString("PLAY", "PFMP", rec, "0"); //face (to be calculated later)
                    ChangeDBInt("PLAY", "PIMP", rec, rand.Next(0, 32)); //importance (to be re-calculated later)
                    ChangeDBString("PLAY", "POVR", rec, "0"); //overall, to be calculated later
                    ChangeDBString("PLAY", "PSLY", rec, "0"); //PSLY
                    ChangeDBString("PLAY", "PRST", rec, "0"); //PRST

                    if (rand.Next(1, 101) < FreshmanPCT) ChangeDBInt("PLAY", "PYER", rec, 0); //year/class
                    else ChangeDBInt("PLAY", "PYER", rec, rand.Next(1, 4)); //year/class

                    if (GetDBValueInt("PLAY", "PYER", rec) == 3)
                        ChangeDBString("PLAY", "PTYP", rec, "3"); //player type (graduation/nfl,etc)
                    else ChangeDBString("PLAY", "PTYP", rec, "0"); //player type (graduation/nfl,etc)



                    int currentPJEN = GetDBValueInt("PLAY", "PJEN", rec);
                    if (AvailablePJEN.Contains(currentPJEN))
                    {
                        int newPJEN = ChooseAvailableJerseyNumber(ppos, (PGID/70), AvailablePJEN);
                        ChangeDBInt("PLAY", "PJEN", rec, newPJEN);
                        AvailablePJEN.Add(newPJEN);
                    }
                    else
                    {
                        AvailablePJEN.Add(currentPJEN);
                    }

                    string FN, LN;

                    FN = FirstNames[rand.Next(0, FirstNames.Count)];
                    LN = LastNames[rand.Next(0, LastNames.Count)];

                    ConvertFirstNameStringToInt(FN, rec, "PLAY");
                    ConvertLastNameStringToInt(LN, rec, "PLAY");

                    x = false;
                }
            }
        }

        //Randomize the Players to give a little bit more variety and evaluation randomness
        private void RandomizeAttribute(string TableName, int rec, int tol)
        {
            tol += 3 - GetDBValueInt("PLAY", "PYER", rec);

            int tolB = tol / 2;  //half the tolerance for specific attributes

            //PTHA	PSTA	PKAC	PACC	PSPD	PPOE	PCTH	PAGI	PINJ	PTAK	PPBK	PRBK	PBTK	PTHP	PJMP	PCAR	PKPR	PSTR	PAWR
            //PPOE, PINJ, PAWR

            int PBRE, PEYE, PPOE, PINJ, PAWR, PWGT, PHGT, PTHA, PSTA, PKAC, PACC, PSPD, PCTH, PAGI, PTAK, PPBK, PRBK, PBTK, PTHP, PJMP, PCAR, PKPR, PSTR, PIMP, PDIS;

            PHGT = Convert.ToInt32(GetDBValue(TableName, "PHGT", rec));
            PWGT = Convert.ToInt32(GetDBValue(TableName, "PWGT", rec));
            PAWR = Convert.ToInt32(GetDBValue(TableName, "PAWR", rec));

            PTHA = Convert.ToInt32(GetDBValue(TableName, "PTHA", rec));
            PSTA = Convert.ToInt32(GetDBValue(TableName, "PSTA", rec));
            PKAC = Convert.ToInt32(GetDBValue(TableName, "PKAC", rec));
            PACC = Convert.ToInt32(GetDBValue(TableName, "PACC", rec));
            PSPD = Convert.ToInt32(GetDBValue(TableName, "PSPD", rec));
            PCTH = Convert.ToInt32(GetDBValue(TableName, "PCTH", rec));
            PAGI = Convert.ToInt32(GetDBValue(TableName, "PAGI", rec));
            PTAK = Convert.ToInt32(GetDBValue(TableName, "PTAK", rec));
            PPBK = Convert.ToInt32(GetDBValue(TableName, "PPBK", rec));
            PRBK = Convert.ToInt32(GetDBValue(TableName, "PRBK", rec));
            PBTK = Convert.ToInt32(GetDBValue(TableName, "PBTK", rec));
            PTHP = Convert.ToInt32(GetDBValue(TableName, "PTHP", rec));
            PJMP = Convert.ToInt32(GetDBValue(TableName, "PJMP", rec));
            PCAR = Convert.ToInt32(GetDBValue(TableName, "PCAR", rec));
            PKPR = Convert.ToInt32(GetDBValue(TableName, "PKPR", rec));
            PSTR = Convert.ToInt32(GetDBValue(TableName, "PSTR", rec));
            PDIS = Convert.ToInt32(GetDBValue(TableName, "PDIS", rec));

            PBRE = rand.Next(0, 2);
            PEYE = rand.Next(0, 2);
            PHGT += rand.Next(0, 0);
            PWGT += rand.Next(-8, 9);
            if (PWGT < 0) PWGT = 0;
            if (PWGT > 340) PWGT = 340;
            if (PHGT > 82) PHGT = 82;
            if (PHGT < 0) PHGT = 0;

            PPOE = rand.Next(1, 30);
            PINJ = rand.Next(1, maxRatingVal);
            PIMP = rand.Next(1, 30);
            PAWR = GetRandomPositiveAttribute(PAWR, tolB);
            PDIS = rand.Next(2, 7);

            PSTA = GetRandomPositiveAttribute(PSTA, tol);
            PKAC = GetRandomPositiveAttribute(PKAC, tol);
            PACC = GetRandomPositiveAttribute(PACC, tolB);
            PSPD = GetRandomPositiveAttribute(PSPD, tolB);
            PCTH = GetRandomPositiveAttribute(PCTH, tol);
            PAGI = GetRandomPositiveAttribute(PAGI, tolB);
            PTAK = GetRandomPositiveAttribute(PTAK, tol);
            PPBK = GetRandomPositiveAttribute(PPBK, tol);
            PRBK = GetRandomPositiveAttribute(PRBK, tol);
            PBTK = GetRandomPositiveAttribute(PBTK, tol);

            PJMP = GetRandomPositiveAttribute(PJMP, tol);
            PCAR = GetRandomPositiveAttribute(PCAR, tol);
            PKPR = GetRandomPositiveAttribute(PKPR, tol);
            PSTR = GetRandomPositiveAttribute(PSTR, tol);

            if (GetDBValueInt("PLAY", "PPOS", rec) == 0)
            {
                PTHA = GetRandomPositiveAttribute(PTHA, tol);
                PTHP = GetRandomPositiveAttribute(PTHP, tol);
            }


            ChangeDBString(TableName, "PBRE", rec, Convert.ToString(PBRE));
            ChangeDBString(TableName, "PEYE", rec, Convert.ToString(PEYE));
            ChangeDBString(TableName, "PPOE", rec, Convert.ToString(PPOE));
            ChangeDBString(TableName, "PINJ", rec, Convert.ToString(PINJ));
            ChangeDBString(TableName, "PAWR", rec, Convert.ToString(PAWR));
            ChangeDBString(TableName, "PHGT", rec, Convert.ToString(PHGT));
            ChangeDBString(TableName, "PWGT", rec, Convert.ToString(PWGT));


            ChangeDBString(TableName, "PTHA", rec, Convert.ToString(PTHA));
            ChangeDBString(TableName, "PSTA", rec, Convert.ToString(PSTA));
            ChangeDBString(TableName, "PKAC", rec, Convert.ToString(PKAC));
            ChangeDBString(TableName, "PACC", rec, Convert.ToString(PACC));
            ChangeDBString(TableName, "PSPD", rec, Convert.ToString(PSPD));
            ChangeDBString(TableName, "PCTH", rec, Convert.ToString(PCTH));
            ChangeDBString(TableName, "PAGI", rec, Convert.ToString(PAGI));
            ChangeDBString(TableName, "PTAK", rec, Convert.ToString(PTAK));
            ChangeDBString(TableName, "PPBK", rec, Convert.ToString(PPBK));
            ChangeDBString(TableName, "PRBK", rec, Convert.ToString(PRBK));
            ChangeDBString(TableName, "PBTK", rec, Convert.ToString(PBTK));
            ChangeDBString(TableName, "PTHP", rec, Convert.ToString(PTHP));
            ChangeDBString(TableName, "PJMP", rec, Convert.ToString(PJMP));
            ChangeDBString(TableName, "PCAR", rec, Convert.ToString(PCAR));
            ChangeDBString(TableName, "PKPR", rec, Convert.ToString(PKPR));
            ChangeDBString(TableName, "PSTR", rec, Convert.ToString(PSTR));
            ChangeDBString(TableName, "PIMP", rec, Convert.ToString(PIMP));
            ChangeDBString(TableName, "PDIS", rec, Convert.ToString(PDIS));

            RandomizePlayerHead(TableName, rec);

        }

        private int ChooseJerseyNumber(int PPOS, List<List<int>> PJEN)
        {
            int jersey = 99;

            for (int i = 0; i < PJEN.Count; i++)
            {
                if (PJEN[i][0] == PPOS)
                {
                    return rand.Next(PJEN[i][1], PJEN[i][2] + 1);
                }
            }

            return jersey;
        }

        private int ChooseAvailableJerseyNumber(int PPOS, int TGID, List<int> teamPJENList )
        {
            List<List<int>> PJEN  = CreateJerseyNumberDB();
            int jersey = 99;

            for (int i = 0; i < PJEN.Count; i++)
            {
                if (PJEN[i][0] == PPOS)
                {
                    bool completed = false;
                    int count = 0;
                    while (!completed)
                    {
                        jersey = rand.Next(PJEN[i][1], PJEN[i][2] + 1);
                        if (!teamPJENList.Contains(jersey))
                        {
                            completed = true;
                            return jersey;
                        }
                        count++;

                        if (count >= 25)
                        {
                            jersey = rand.Next(PJEN[i][3], PJEN[i][4] + 1);
                            if (!teamPJENList.Contains(jersey))
                            {
                                completed = true;
                                return jersey;
                            }
                            count++;
                        }

                        if (count >= 50)
                        {
                            jersey = rand.Next(0, 100);
                            if (!teamPJENList.Contains(jersey))
                            {
                                completed = true;
                                return jersey;
                            }
                        }
                        if (count >= 100)
                        {
                            return rand.Next(0, 99);
                        }

                    }
                }
            }

            return jersey;
        }

        private int PickRandomHometown()
        {
            int ht = 0;

            List<string> home = new List<string>();

            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\players\RCHT.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                home.Add(Line[0]);
            }
            sr.Close();

            bool realHT = false;
            while (!realHT)
            {
                ht = Convert.ToInt32(home[rand.Next(0, home.Count)]);
                if (home.Contains(Convert.ToString(ht))) realHT = true;

            }

            return ht;
        }


        #endregion


        #region Fantasy Coach Generators

        private void CreateFantasyCoach(int rec)
        {
            //collect ccid and tgid
            int ccid = GetDBValueInt("COCH", "CCID", rec);
            int tgid = GetDBValueInt("COCH", "TGID", rec);
            int cfuc = GetDBValueInt("COCH", "CFUC", rec);

            //reset stats

            TdbFieldProperties FieldProps = new TdbFieldProperties();

            for (int i = 0; i < TDB.FieldCount(dbIndex, "COCH"); i++)
            {
                TDB.TDBFieldGetProperties(dbIndex, "COCH", i, ref FieldProps);

                ChangeDBInt("COCH", FieldProps.Name, rec, 0);
            }

            //set CPID CLTF and CLTR

            ChangeDBInt("COCH", "CPID", rec, 511);
            ChangeDBInt("COCH", "CLTF", rec, 65535);
            ChangeDBInt("COCH", "CLTR", rec, 65535);

            //Set CCID & TGID
            ChangeDBInt("COCH", "CCID", rec, ccid);
            ChangeDBInt("COCH", "TGID", rec, tgid);
            ChangeDBInt("COCH", "CFUC", rec, cfuc);
            ChangeDBInt("COCH", "CFRC", rec, 1);
            ChangeDBInt("COCH", "CSAS", rec, 1);

            //set ccpo & ctop
            ChangeDBInt("COCH", "CCPO", rec, 60);
            ChangeDBInt("COCH", "CTOP", rec, FindTeamPrestige(tgid));

            //name
            CreateFirstNamesDB();
            CreateLastNamesDB();
            string FN, LN;
            FN = FirstNames[rand.Next(0, FirstNames.Count)];
            LN = LastNames[rand.Next(0, LastNames.Count)];
            ChangeDBString("COCH", "CLFN", rec, FN);
            ChangeDBString("COCH", "CLLN", rec, LN);

            //skin, body, hair color, hair style, face, glasses, headwear

            int x = rand.Next(0, 3);
            int y = 0;
            if (x == 0) y = 0;
            else if (x == 1) y = 2;
            else y = 5;
            ChangeDBInt("COCH", "CSKI", rec, y);

            ChangeDBInt("COCH", "CBSZ", rec, rand.Next(0, 3));
            ChangeDBInt("COCH", "CHAR", rec, rand.Next(0, 6));

            x = rand.Next(0, 5);
            if (x > 0) x++;
            ChangeDBInt("COCH", "CThg", rec, x);

            ChangeDBInt("COCH", "CFEX", rec, rand.Next(0, 6));
            ChangeDBInt("COCH", "CTgw", rec, rand.Next(0, 2));

            x = rand.Next(0, 3);
            if (x == 1) ChangeDBInt("COCH", "CThg", rec, 1);
            else if (x == 2) ChangeDBInt("COCH", "CThg", rec, 0);

            ChangeDBInt("COCH", "COHT", rec, x);


            //prestige 
            ChangeDBInt("COCH", "CPRE", rec, rand.Next(1, 7));

            //budget
            int disc = rand.Next(20, 30);
            int recruit = rand.Next(25, 40);
            int train = 100 - disc - recruit;

            ChangeDBInt("COCH", "CDPC", rec, disc);
            ChangeDBInt("COCH", "CTPC", rec, train);
            ChangeDBInt("COCH", "CRPC", rec, recruit);

            //playbook & strategy
            if (NextMod) ChangeDBInt("COCH", "CPID", rec, rand.Next(136, 159));
            else ChangeDBInt("COCH", "CPID", rec, rand.Next(0, 125));

            ChangeDBInt("COCH", "COST", rec, rand.Next(0, 5));
            ChangeDBInt("COCH", "CDST", rec, rand.Next(0, 5));

            ChangeDBInt("COCH", "COTR", rec, rand.Next(30, 70));
            ChangeDBInt("COCH", "COTA", rec, rand.Next(25, 75));
            ChangeDBInt("COCH", "COTS", rec, rand.Next(50, 80));
            ChangeDBInt("COCH", "CDTR", rec, rand.Next(30, 70));
            ChangeDBInt("COCH", "CDTA", rec, rand.Next(25, 75));
            ChangeDBInt("COCH", "CDTS", rec, rand.Next(50, 80));
        }

        private void CreateFantasyCoachDB()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("COCH");

            for (int i = 0; i < GetTableRecCount("COCH"); i++)
            {
                CreateFantasyCoach(i);
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Fantasy Coach Database Completed!");
        }

        #endregion



    }

}
