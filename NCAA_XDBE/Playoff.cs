// using System.Runtime.Remoting.Metadata.W3cXsd2001;
namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        /* Playoff Viewer
         * This is a playoff viewer
         */

        private void StartPlayoffViewer()
        {
            
            // Load Playoff Viewer
            LoadRound1();
            //PlayoffYearLabel.Text = "YEAR " + (GetDBValueInt("SEAI", "SEYR", 0) + 1);
            PlayoffYearLabel.Text = "" + (GetDBValueInt("SEAI", "SEYR", 0) + DynStartYear.Value);
        }


        private void LoadRound1()
        {
            int sewn = GetDBValueInt("SEAI", "SEWN", 0);
            if (sewn < 8)
            {
                return;
            }

            if (sewn >= 8 && sewn <= 16)
            {
                List<List<int>> playoffTeams = GetPlayoffTeams();

                Round2_1 = GetPlayoffLabel(Round2_1, playoffTeams[0][1], playoffTeams[0][0]);
                Round2_2 = GetPlayoffLabel(Round2_2, playoffTeams[1][1], playoffTeams[1][0]);
                Round2_3 = GetPlayoffLabel(Round2_3, playoffTeams[2][1], playoffTeams[2][0]);
                Round2_4 = GetPlayoffLabel(Round2_4, playoffTeams[3][1], playoffTeams[3][0]);
                Round1_5 = GetPlayoffLabel(Round1_5, playoffTeams[4][1], playoffTeams[4][0]);
                Round1_6 = GetPlayoffLabel(Round1_6, playoffTeams[5][1], playoffTeams[5][0]);
                Round1_7 = GetPlayoffLabel(Round1_7, playoffTeams[6][1], playoffTeams[6][0]);
                Round1_8 = GetPlayoffLabel(Round1_8, playoffTeams[7][1], playoffTeams[7][0]);
                Round1_9 = GetPlayoffLabel(Round1_9, playoffTeams[8][1], playoffTeams[8][0]);
                Round1_10 = GetPlayoffLabel(Round1_10, playoffTeams[9][1], playoffTeams[9][0]);
                Round1_11 = GetPlayoffLabel(Round1_11, playoffTeams[10][1], playoffTeams[10][0]);
                Round1_12 = GetPlayoffLabel(Round1_12, playoffTeams[11][1], playoffTeams[11][0]);

            }
            else
            {
                GetRound1Matchups();

                GetQuarterFinalMatchups();

                GetSemiFinalMatchups();

                GetNatTitleMatchup();

                GetChamp();
            }
        }

        private void GetRound1Matchups()
        {
            // BIDX 17-20

            //Add Labels to Group
            List<Label> roundLabel = new List<Label>();

            roundLabel.Add(Round1_8);
            roundLabel.Add(Round1_9);
            roundLabel.Add(Round1_8SC);
            roundLabel.Add(Round1_9SC);

            roundLabel.Add(Round1_7);
            roundLabel.Add(Round1_10);
            roundLabel.Add(Round1_7SC);
            roundLabel.Add(Round1_10SC);

            roundLabel.Add(Round1_6);
            roundLabel.Add(Round1_11);
            roundLabel.Add(Round1_6SC);
            roundLabel.Add(Round1_11SC);

            roundLabel.Add(Round1_5);
            roundLabel.Add(Round1_12);
            roundLabel.Add(Round1_5SC);
            roundLabel.Add(Round1_12SC);

            //Find BIDX for each label and rename box

            AssignPlayoffLabels(17, 20, roundLabel);

        }

        private void GetQuarterFinalMatchups()
        {
            //BIDX 21-24

            //Add Labels to Group
            List<Label> roundLabel = new List<Label>();



            roundLabel.Add(Round2_4);
            roundLabel.Add(Round2_512);
            roundLabel.Add(Round2_4SC);
            roundLabel.Add(Round2_512SC);

            roundLabel.Add(Round2_3);
            roundLabel.Add(Round2_611);
            roundLabel.Add(Round2_3SC);
            roundLabel.Add(Round2_611SC);

            roundLabel.Add(Round2_2);
            roundLabel.Add(Round2_710);
            roundLabel.Add(Round2_2SC);
            roundLabel.Add(Round2_710SC);

            roundLabel.Add(Round2_1);
            roundLabel.Add(Round2_89);
            roundLabel.Add(Round2_1SC);
            roundLabel.Add(Round2_89SC);

            //Find BIDX for each label and rename box

            AssignPlayoffLabels(21, 24, roundLabel);

        }

        private void GetSemiFinalMatchups()
        {
            //BIDX 25-26

            //Add Labels to Group
            List<Label> roundLabel = new List<Label>();
            roundLabel.Add(Semi2_2);
            roundLabel.Add(Semi2_3);
            roundLabel.Add(Semi2_2SC);
            roundLabel.Add(Semi2_3SC);

            roundLabel.Add(Semi1_1);
            roundLabel.Add(Semi1_4);
            roundLabel.Add(Semi1_1SC);
            roundLabel.Add(Semi1_4SC);


            //Find BIDX for each label and rename box

            AssignPlayoffLabels(25, 26, roundLabel);
        }

        private void GetNatTitleMatchup()
        {
            //BIDX 27

            //Add Labels to Group
            List<Label> roundLabel = new List<Label>();

            roundLabel.Add(Final2);
            roundLabel.Add(Final1);
            roundLabel.Add(Final2SC);
            roundLabel.Add(Final1SC);

            //Find BIDX for each label and rename box

            AssignPlayoffLabels(27, 27, roundLabel);

        }

        private void GetChamp()
        {
            //BIDX 27

            //Add Labels to Group
            List<Label> roundLabel = new List<Label>();

            roundLabel.Add(Champ);


            //Find BIDX for each label and rename box

            AssignPlayoffLabels(27, 27, roundLabel, true);
        }

        private List<List<int>> GetPlayoffTeams()
        {
            List<List<int>> playoffTeams = new List<List<int>>();

            //Need to determine the best Group of 5 champ too

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    int count = playoffTeams.Count;
                    playoffTeams.Add(new List<int>());

                    playoffTeams[count].Add(i);
                    playoffTeams[count].Add(GetDBValueInt("TEAM", "TGID", i));
                    playoffTeams[count].Add(GetDBValueInt("TEAM", "TBRK", i));
                    playoffTeams[count].Add(GetDBValueInt("TEAM", "CGID", i));

                }
            }

            playoffTeams.Sort((team1, team2) => team1[2].CompareTo(team2[2]));

            List<List<int>> tmpList = new List<List<int>>();

            List<int> confs = new List<int>();
            for (int i = 0; i < 15; i++)
            {
                confs.Add(0);
            }

            for (int i = 0; i < 12; i++)
            {
                tmpList.Add(playoffTeams[i]);
                if (confs[playoffTeams[i][3]] < 1) confs[playoffTeams[i][3]] = 1;
            }

            int confCount = 0;
            foreach (int conf in confs)
            {
                if (conf == 1) confCount++;
            }

            if (confCount < 5)
            {
                for (int i = 12; i < playoffTeams.Count; i++)
                {
                    int conf = playoffTeams[i][3];
                    if (confs[conf] == 0)
                    {
                        tmpList.Insert(11, playoffTeams[i]);
                        break;
                    }

                }
            }

            return tmpList;
        }


        private void AssignPlayoffLabels(int bidxStart, int bidxEnd, List<Label> roundLabel, bool champ = false)
        {
            int count = 0;
            for (int bidx = bidxStart; bidx <= bidxEnd; bidx++)
            {
                int bowlRec = FindBowlRecFromBIDX(bidx);

                int sgnm = GetDBValueInt("BOWL", "SGNM", bowlRec);
                int sewn = GetDBValueInt("BOWL", "SEWN", bowlRec);

                int schdRec = FindSchdRecFromSGNM(sgnm, sewn);

                int TGIDAway = GetDBValueInt("SCHD", "GATG", schdRec);
                int TGIDAwayRec = FindTeamRecfromTGID(TGIDAway);
                int AwayScore = GetDBValueInt("SCHD", "GASC", schdRec);

                int TGIDHome = GetDBValueInt("SCHD", "GHTG", schdRec);
                int TGIDHomeRec = FindTeamRecfromTGID(TGIDHome);
                int HomeScore = GetDBValueInt("SCHD", "GHSC", schdRec);

                if (champ)
                {
                    int TGID = 511;
                    int rec = -1;

                    if(AwayScore == HomeScore)
                    {
                        TGID = 511;
                        rec = -1;
                    }
                    else if (AwayScore > HomeScore)
                    {
                        TGID = TGIDAway;
                        rec = TGIDAwayRec;
                    }
                    else
                    {
                        TGID = TGIDHome;
                        rec = TGIDHomeRec;
                    }


                    roundLabel[0] = GetPlayoffLabel(roundLabel[0], TGID, rec);
                }
                else
                {
                    roundLabel[count * 4] = GetPlayoffLabel(roundLabel[count * 4], TGIDHome, TGIDHomeRec);
                    roundLabel[count * 4 + 1] = GetPlayoffLabel(roundLabel[count * 4 + 1], TGIDAway, TGIDAwayRec);
                    roundLabel[count * 4 + 2] = GetScoreLabel(roundLabel[count * 4 + 2], HomeScore, TGIDHome);
                    roundLabel[count * 4 + 3] = GetScoreLabel(roundLabel[count * 4 + 3], AwayScore, TGIDAway);
                }


                count++;
            }
        }

        private Label GetPlayoffLabel(Label lbl, int TGID, int teamRec)
        {
            if (TGID == 511)
            {
                lbl.Text = "";
                lbl.BackColor = Color.DimGray;
                lbl.ForeColor = Color.Snow;
                return lbl;
            }

            lbl.Text = "" + GetDBValueInt("TEAM", "TBRK", teamRec) + " " + teamNameDB[TGID];
            //lbl.ForeColor = Color.FromArgb(GetDBValueInt("TEAM", "TFOR", teamRec), GetDBValueInt("TEAM", "TFOG", teamRec), GetDBValueInt("TEAM", "TFOB", teamRec));
            lbl.ForeColor = Color.White;
            lbl.BackColor = Color.FromArgb(GetDBValueInt("TEAM", "TFRD", teamRec), GetDBValueInt("TEAM", "TFFG", teamRec), GetDBValueInt("TEAM", "TFFB", teamRec));

            return lbl;
        }

        private Label GetScoreLabel(Label lbl, int score, int TGID)
        {
            if (TGID == 511)
            {
                lbl.Text = "";
                lbl.BackColor = Color.Black;
                lbl.ForeColor = Color.LemonChiffon;
                return lbl;
            }

            lbl.Text = "" + score;
            lbl.BackColor = Color.Black;
            lbl.ForeColor = Color.LemonChiffon;

            return lbl;
        }


        private int FindBowlRecFromBIDX(int bidx)
        {
            for (int i = 0; i < GetTableRecCount("BOWL"); i++)
            {
                if (GetDBValueInt("BOWL", "BIDX", i) == bidx) return i;
            }

            return -1;
        }

        private int FindSchdRecFromSGNM(int sgnm, int sewn)
        {
            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                if (GetDBValueInt("SCHD", "SGNM", i) == sgnm && GetDBValueInt("SCHD", "SEWN", i) == sewn) return i;
            }

            return -1;
        }
    }
}
