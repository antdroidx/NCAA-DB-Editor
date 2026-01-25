using System.Reflection;
// using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        #region League Size for Fantasy Roster

        //Changed League Size
        private void DC77_CheckedChanged(object sender, EventArgs e)
        {
            if (DC77.Checked)
            {
                MaxFantasyPlayers.Maximum = 66;
                MaxFantasyPlayers.Value = 66;
            }
            else
            {
                MaxFantasyPlayers.Maximum = 70;
                MaxFantasyPlayers.Value = 70;
            }
        }

        private void DC88_CheckedChanged(object sender, EventArgs e)
        {
            if (DC77.Checked)
            {
                MaxFantasyPlayers.Maximum = 66;
                MaxFantasyPlayers.Value = 66;
            }
            else
            {
                MaxFantasyPlayers.Maximum = 70;
                MaxFantasyPlayers.Value = 70;
            }
        }

        #endregion

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
            StartProgressBar(GetTableRecCount(tableName));



            //Clear PLAY Table
            for (int i = GetTableRecCount("PLAY"); i != -1; i--)
            {
                TDB.TDBTableRecordRemove(dbIndex, "PLAY", i);
            }
            CreateRCATtable();
            CreateFirstNamesDB();
            CreateLastNamesDB();

            List<List<string>> teamData = new List<List<string>>();
            if (verNumber >= 16.0) teamData = CreateStringListsFromCSV(@"resources\FantasyGenData136.csv", true);
            else teamData = CreateStringListsFromCSV(@"resources\FantasyGenData.csv", true);

            int rec = 0;
            int leagueType = 0;
            if (tableName == "TDYN")
            {
                if (FBSroster.Checked) leagueType = 0; //FBS
                else leagueType = 1; //FCS

                for (int i = 0; i < GetTableRecCount(tableName); i++)
                {
                    DeleteRecord(tableName, i, true);
                }
                CompactDB();

                int r = 0;
                for (int i = 0; i < teamData.Count; i++)
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
                    int TOID = GetDBValueInt(tableName, "TOID", i);
                    int rating = GetFantasyTeamRating(teamData, TOID);

                    GenerateFantasyRoster(TOID, rating, true);

                    //Finish team and perform step counter
                    ProgressBarStep();
                }
            }


            EndProgressBar();
            MessageBox.Show("Fantasy Players Created!");

            RecalculateOverall(true);
            RecalculateBodyShape("PLAY", true);
            RecalculateQBTendencies(true);
            CalculateAllTeamRatings(tableName);
            DepthChartMaker(tableName);
            MessageBox.Show("Fantasy Roster Generation & Depth Charts are complete!");

        }

        //Generate Roster
        public void GenerateFantasyRoster(int tgid, int rating, bool skipPrompt = false)
        {

            if (!skipPrompt)
            {
                //Remove existing Players
                ClearTeamPlayers(tgid);
                CreateTeamDB();
            }

            //Clear Old Stats
            ClearOldTeamStats(tgid);

            //Create New Roster
            CreateRCATtable();
            CreateFirstNamesDB();
            CreateLastNamesDB();

            List<List<int>> PJEN = CreateJerseyNumberDB();
            List<int> AvailablePJEN = new List<int>();

            List<List<string>> RCATmapper = CreateStringListsFromCSV(@"resources\players\RCAT-MAPPER.csv", false);

            int rec = GetTableRecCount("PLAY");
            int PGIDbeg = tgid * 70;
            int end = 69;
            if (verNumber >= 16.0) end = 65;
            int PGIDend = PGIDbeg + end;
            int ST = 0;
            int freshmanPCT = 25;


            for (int j = 0; j < end; j++)
            {
                //Add a record
                if (GetTableRecCount("PLAY") < rec + 1)
                    AddTableRecord("PLAY", true);
                else AddTableRecord("PLAY", false);

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
                RandomizeAttribute("PLAY", rec, rating);
                rec++;
            }

            RecalculateOverall(true);
            RecalculateBodyShape("PLAY", true);
            RecalculateQBTendencies(true);
            if (verNumber >= 16.0) DepthChartMakerSingle("PLAY", tgid, 136, true);
            else DepthChartMakerSingle("PLAY", tgid, 120, true);

            if (!skipPrompt) MessageBox.Show(teamNameDB[tgid] + " Roster has been generated.");
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

                    int redshirt = 0;
                    if (rand.Next(0, 3) > 2) redshirt = 2;


                    int ht = PickRandomHometown();

                    ChangeDBInt("PLAY", "RCHD", rec, ht); //hometown
                    ChangeDBInt("PLAY", "PGID", rec, PGID); //player id
                    ChangeDBInt("PLAY", "PHPD", rec, 0); //PHPD
                    ChangeDBInt("PLAY", "PRSD", rec, redshirt); //Redshirt
                    ChangeDBInt("PLAY", "PLMG", rec, 0); //Mouthguard
                    ChangeDBInt("PLAY", "PFGM", rec, 0); //face shape (to be calculated later)
                    ChangeDBInt("PLAY", "PJEN", rec, ChooseJerseyNumber(GetPOSG2fromPPOS(ppos), PJEN)); //jersey num
                    ChangeDBInt("PLAY", "PTEN", rec, 15); //tendency (to be calculated later)
                    ChangeDBInt("PLAY", "PFMP", rec, 0); //face (to be calculated later)
                    ChangeDBInt("PLAY", "PIMP", rec, rand.Next(0, 32)); //importance (to be re-calculated later)
                    ChangeDBInt("PLAY", "POVR", rec, 0); //overall, to be calculated later
                    ChangeDBInt("PLAY", "PSLY", rec, 0); //PSLY
                    ChangeDBInt("PLAY", "PRST", rec, 0); //PRST

                    if (rand.Next(1, 101) < FreshmanPCT) ChangeDBInt("PLAY", "PYER", rec, 0); //year/class
                    else ChangeDBInt("PLAY", "PYER", rec, rand.Next(1, 4)); //year/class

                    if (GetDBValueInt("PLAY", "PYER", rec) == 3)
                        ChangeDBInt("PLAY", "PTYP", rec, 3); //player type (graduation/nfl,etc)
                    else ChangeDBInt("PLAY", "PTYP", rec, 0); //player type (graduation/nfl,etc)



                    int currentPJEN = GetDBValueInt("PLAY", "PJEN", rec);
                    if (AvailablePJEN.Contains(currentPJEN))
                    {
                        int newPJEN = ChooseAvailableJerseyNumber(GetPOSG2fromPPOS(ppos), (PGID / 70), AvailablePJEN);
                        if (newPJEN < 0 || newPJEN > 99) newPJEN = rand.Next(0, 100);

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
        private void RandomizeAttribute(string TableName, int rec, int teamRating)
        {
            int tolEXP = (int)(GetDBValueInt(TableName, "PYER", rec) * 2.5);

            int tolRAND = 3;  //half the tolerance for specific attributes

            teamRating = (int)((teamRating - 2) * 4);

            //PTHA	PSTA	PKAC	PACC	PSPD	PPOE	PCTH	PAGI	PINJ	PTAK	PPBK	PRBK	PBTK	PTHP	PJMP	PCAR	PKPR	PSTR	PAWR
            //PPOE, PINJ, PAWR

            int PBRE, PEYE, PPOE, PINJ, PAWR, PWGT, PHGT, PTHA, PSTA, PKAC, PACC, PSPD, PCTH, PAGI, PTAK, PPBK, PRBK, PBTK, PTHP, PJMP, PCAR, PKPR, PSTR, PIMP, PDIS;

            PHGT = GetDBValueInt(TableName, "PHGT", rec);
            PWGT = GetDBValueInt(TableName, "PWGT", rec);
            PAWR = GetDBValueInt(TableName, "PAWR", rec);

            PTHA = GetDBValueInt(TableName, "PTHA", rec);
            PSTA = GetDBValueInt(TableName, "PSTA", rec);
            PKAC = GetDBValueInt(TableName, "PKAC", rec);
            PACC = GetDBValueInt(TableName, "PACC", rec);
            PSPD = GetDBValueInt(TableName, "PSPD", rec);
            PCTH = GetDBValueInt(TableName, "PCTH", rec);
            PAGI = GetDBValueInt(TableName, "PAGI", rec);
            PTAK = GetDBValueInt(TableName, "PTAK", rec);
            PPBK = GetDBValueInt(TableName, "PPBK", rec);
            PRBK = GetDBValueInt(TableName, "PRBK", rec);
            PBTK = GetDBValueInt(TableName, "PBTK", rec);
            PTHP = GetDBValueInt(TableName, "PTHP", rec);
            PJMP = GetDBValueInt(TableName, "PJMP", rec);
            PCAR = GetDBValueInt(TableName, "PCAR", rec);
            PKPR = GetDBValueInt(TableName, "PKPR", rec);
            PSTR = GetDBValueInt(TableName, "PSTR", rec);
            PDIS = GetDBValueInt(TableName, "PDIS", rec);

            PBRE = rand.Next(0, 2);
            PEYE = rand.Next(0, 2);
            PHGT += rand.Next(0, 0);
            PWGT += rand.Next(-8, 9);
            if (PWGT < 0) PWGT = 0;
            if (PWGT > 340) PWGT = 340;
            if (PHGT > 82) PHGT = 82;
            if (PHGT < 0) PHGT = 0;

            PPOE = rand.Next(1, 31);
            PINJ = rand.Next(1, maxRatingVal);
            PIMP = rand.Next(1, maxRatingVal);
            PDIS = rand.Next(2, 7);

            //Thowing Hand
            int handVal = rand.Next(1, 101);
            int hand = 0;
            if (handVal <= 9) hand = 1; //left handed 9% chance
            ChangeDBInt(TableName, "PHAN", rec, hand);


            //Add team rating factor
            PAWR = GetRandomPositiveAttribute(PAWR, teamRating);
            PSTA = GetRandomPositiveAttribute(PSTA, teamRating);
            PKAC = GetRandomPositiveAttribute(PKAC, teamRating);
            PACC = GetRandomPositiveAttribute(PACC, teamRating);
            PSPD = GetRandomPositiveAttribute(PSPD, teamRating);
            PCTH = GetRandomPositiveAttribute(PCTH, teamRating);
            PAGI = GetRandomPositiveAttribute(PAGI, teamRating);
            PTAK = GetRandomPositiveAttribute(PTAK, teamRating);
            PPBK = GetRandomPositiveAttribute(PPBK, teamRating);
            PRBK = GetRandomPositiveAttribute(PRBK, teamRating);
            PBTK = GetRandomPositiveAttribute(PBTK, teamRating);

            PJMP = GetRandomPositiveAttribute(PJMP, teamRating);
            PCAR = GetRandomPositiveAttribute(PCAR, teamRating);
            PKPR = GetRandomPositiveAttribute(PKPR, teamRating);
            PSTR = GetRandomPositiveAttribute(PSTR, teamRating);

            if (GetDBValueInt(TableName, "PPOS", rec) == 0)
            {
                PTHA = GetRandomPositiveAttribute(PTHA, teamRating);
                PTHP = GetRandomPositiveAttribute(PTHP, teamRating);
            }


            //Randomizer
            PAWR = GetRandomAttribute(PAWR, tolRAND);
            PSTA = GetRandomAttribute(PSTA, tolRAND);
            PKAC = GetRandomAttribute(PKAC, tolRAND);
            PACC = GetRandomAttribute(PACC, tolRAND);
            PSPD = GetRandomAttribute(PSPD, tolRAND);
            PCTH = GetRandomAttribute(PCTH, tolRAND);
            PAGI = GetRandomAttribute(PAGI, tolRAND);
            PTAK = GetRandomAttribute(PTAK, tolRAND);
            PPBK = GetRandomAttribute(PPBK, tolRAND);
            PRBK = GetRandomAttribute(PRBK, tolRAND);
            PBTK = GetRandomAttribute(PBTK, tolRAND);

            PJMP = GetRandomAttribute(PJMP, tolRAND);
            PCAR = GetRandomAttribute(PCAR, tolRAND);
            PKPR = GetRandomAttribute(PKPR, tolRAND);
            PSTR = GetRandomAttribute(PSTR, tolRAND);


            //Add Year Experience
            PAWR = GetRandomPositiveAttribute(PAWR, tolEXP);
            PSTA = GetRandomPositiveAttribute(PSTA, tolEXP);
            PKAC = GetRandomPositiveAttribute(PKAC, tolEXP);
            PACC = GetRandomPositiveAttribute(PACC, tolEXP);
            PSPD = GetRandomPositiveAttribute(PSPD, tolEXP);
            PCTH = GetRandomPositiveAttribute(PCTH, tolEXP);
            PAGI = GetRandomPositiveAttribute(PAGI, tolEXP);
            PTAK = GetRandomPositiveAttribute(PTAK, tolEXP);
            PPBK = GetRandomPositiveAttribute(PPBK, tolEXP);
            PRBK = GetRandomPositiveAttribute(PRBK, tolEXP);
            PBTK = GetRandomPositiveAttribute(PBTK, tolEXP);

            PJMP = GetRandomPositiveAttribute(PJMP, tolEXP);
            PCAR = GetRandomPositiveAttribute(PCAR, tolEXP);
            PKPR = GetRandomPositiveAttribute(PKPR, tolEXP);
            PSTR = GetRandomPositiveAttribute(PSTR, tolEXP);

            if (GetDBValueInt(TableName, "PPOS", rec) == 0)
            {
                PTHA = GetRandomPositiveAttribute(PTHA, tolEXP);
                PTHP = GetRandomPositiveAttribute(PTHP, tolEXP);
            }


            ChangeDBInt(TableName, "PBRE", rec, PBRE);
            ChangeDBInt(TableName, "PEYE", rec, PEYE);
            ChangeDBInt(TableName, "PPOE", rec, PPOE);
            ChangeDBInt(TableName, "PINJ", rec, PINJ);
            ChangeDBInt(TableName, "PAWR", rec, PAWR);
            ChangeDBInt(TableName, "PHGT", rec, PHGT);
            ChangeDBInt(TableName, "PWGT", rec, PWGT);


            ChangeDBInt(TableName, "PTHA", rec, PTHA);
            ChangeDBInt(TableName, "PSTA", rec, PSTA);
            ChangeDBInt(TableName, "PKAC", rec, PKAC);
            ChangeDBInt(TableName, "PACC", rec, PACC);
            ChangeDBInt(TableName, "PSPD", rec, PSPD);
            ChangeDBInt(TableName, "PCTH", rec, PCTH);
            ChangeDBInt(TableName, "PAGI", rec, PAGI);
            ChangeDBInt(TableName, "PTAK", rec, PTAK);
            ChangeDBInt(TableName, "PPBK", rec, PPBK);
            ChangeDBInt(TableName, "PRBK", rec, PRBK);
            ChangeDBInt(TableName, "PBTK", rec, PBTK);
            ChangeDBInt(TableName, "PTHP", rec, PTHP);
            ChangeDBInt(TableName, "PJMP", rec, PJMP);
            ChangeDBInt(TableName, "PCAR", rec, PCAR);
            ChangeDBInt(TableName, "PKPR", rec, PKPR);
            ChangeDBInt(TableName, "PSTR", rec, PSTR);
            ChangeDBInt(TableName, "PIMP", rec, PIMP);
            ChangeDBInt(TableName, "PDIS", rec, PDIS);

            RandomizeSkinTone(TableName, rec);
            RandomizePlayerHead(TableName, rec);
            RandomizePlayerGear(TableName, rec);
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

        private int ChooseAvailableJerseyNumber(int POSG, int TGID, List<int> teamPJENList)
        {
            List<List<int>> PJEN = CreateJerseyNumberDB();
            int jersey = 0;

            for (int i = 0; i < PJEN.Count; i++)
            {
                if (PJEN[i][0] == POSG)
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

                        if (count >= 50)
                        {
                            jersey = rand.Next(PJEN[i][3], PJEN[i][4] + 1);
                            if (!teamPJENList.Contains(jersey))
                            {
                                completed = true;
                                return jersey;
                            }
                            count++;
                        }

                        if (count >= 100)
                        {
                            jersey = rand.Next(0, 99);
                            if (!teamPJENList.Contains(jersey))
                            {
                                completed = true;
                                return jersey;
                            }
                        }
                        if (count >= 200)
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

            //set age
            int age = rand.Next(0, 60);
            ChangeDBInt("COCH", "CYCD", rec, age);

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

            //set face based on age
            if (age < 20) ChangeDBInt("COCH", "CFEX", rec, rand.Next(0, 2));
            else if (age < 40) ChangeDBInt("COCH", "CFEX", rec, rand.Next(2, 4));
            else ChangeDBInt("COCH", "CFEX", rec, rand.Next(4, 6));

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
            if (verNumber == 15.0) ChangeDBInt("COCH", "CPID", rec, rand.Next(136, 159));
            else if (verNumber >= 16.0) ChangeDBInt("COCH", "CPID", rec, rand.Next(136, 163));
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
            StartProgressBar(GetTableRecCount("COCH"));

            for (int i = 0; i < GetTableRecCount("COCH"); i++)
            {
                CreateFantasyCoach(i);
                ProgressBarStep();
            }

            EndProgressBar();
            MessageBox.Show("Fantasy Coach Database Completed!");
        }

        #endregion



    }

}
