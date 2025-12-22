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
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        private void StartHeadlinesViewer()
        {
            if (NewsTop25View.Rows.Count > 0) return;

            int week = GetCurrentWeek(); // Assume this method retrieves the current week number
            LoadNewspaperTitle(week);
            LoadMainHeadline(week);
            LoadHeadlines();

            LoadHeadlinesRankings();
            LoadHeadlinesHeismanRace();
            LoadHeadlinesCoachHotSeat();
            NewsTop25View.ClearSelection();
            HeismanView.ClearSelection();
            CoachHotSeatView.ClearSelection();
        }

        private void LoadNewspaperTitle(int week)
        {
            DBNHeadlinesTitle.Text = "DATABASE NEWS NETWORK: Week " + week + " Headlines";
        }


        private void LoadMainHeadline(int week)
        {
            int tgid = GetDBValueInt("MCOV", "TGID", week);
            int pgid = GetDBValueInt("MCOV", "PGID", week);
            int pRec = FindPGIDRecord(pgid);
            string pos = Positions[GetDBValueInt("PLAY", "PPOS", pRec)];
            string headlineTitle = GetDBValue("MCOV", "MHTX", week);
            string headlineCaption = GetDBValue("MCOV", "MCTX", week);

            HeadlineMainHelmet.BackColor = GetTeamPrimaryColor(FindTeamRecfromTeamName(teamNameDB[tgid]));

            MainHeadlineTitle.Text = headlineTitle;
            MainHeadlineCaption.Text = headlineCaption;
            if(pgid < 65535)
            MainHeadlineKeyPlayer.Text = GetPlayerNamefromPGID(pgid) + " (" + pos + ")";
            else MainHeadlineKeyPlayer.Text = "";

        }

        private void LoadHeadlines()
        {
            List<PictureBox> helmets = GetHelmetHeadlinePics();
            List<Label> titles = GetHeadlineTitleLabels();
            List<Label> captions = GetHeadlineCaptionsLabels();
            List<Label> players = GetHeadlinePlayerLabels();

            List<List<string>> headlinesDB = CreateStringListsFromCSV(@"resources\misc\HEAD.csv", true);
            List<List<string>> captionsDB = CreateStringListsFromCSV(@"resources\misc\CAPT.csv", true);

            for (int i = 0; i < 4; i++)
            {
                int tgid = GetDBValueInt("EASP", "TGID", i);
                int pgid = GetDBValueInt("EASP", "PGID", i);
                int pRec = FindPGIDRecord(pgid);
                string pos = Positions[GetDBValueInt("PLAY", "PPOS", pRec)];

                int hid0 = GetDBValueInt("EASP", "HID0", i);
                int cid0 = GetDBValueInt("EASP", "CID0", i);

                int HDBIndex = headlinesDB.FindIndex(row => Convert.ToInt32(row[0]) == hid0);
                int CDBIndex = captionsDB.FindIndex(row => Convert.ToInt32(row[0]) == cid0);

                string[] headlineTitle = headlinesDB[HDBIndex][3].Split(" ");
                string[] headlineCaption = captionsDB[CDBIndex][4].Split(" ");

                string finalTitle = "";
                for(int x = 0; x < headlineTitle.Length; x++)
                {
                    if (headlineTitle[x].Contains("-"))
                    {
                        finalTitle += GetCaptionConversion(headlineTitle[x], pgid, pRec, tgid);
                    }
                    else
                    {
                        finalTitle += headlineTitle[x] + " ";
                    }
                }

                string finalCaption = "";
                for (int x = 0; x < headlineCaption.Length; x++)
                {
                    if (headlineCaption[x].Contains("-"))
                    {
                        finalCaption += GetCaptionConversion(headlineCaption[x], pgid, pRec, tgid) + " ";
                    }
                    else
                    {
                        finalCaption += headlineCaption[x] + " ";
                    }
                }

                helmets[i].BackColor = GetTeamPrimaryColor(FindTeamRecfromTeamName(teamNameDB[tgid]));
                titles[i].Text = finalTitle;
                captions[i].Text = finalCaption;
                players[i].Text = GetPlayerNamefromPGID(pgid) + " (" + pos + ")  from " + teamNameDB[tgid];

            }
        }

        #region Headline Conversion Helpers

        private string GetCaptionConversion(string capSymbol, int pgid, int pRec, int tgid)
        {
            if (capSymbol == "-;") return "a";

            if (capSymbol == "-b" || capSymbol == "-b.") return teamNameDB[tgid];
            if (capSymbol.Contains("-b-")) return teamNameDB[tgid] + "'s";
            if (capSymbol == "-f") return GetPlayerNamefromPGID(pgid);
            if (capSymbol.Contains("-f-")) return GetPlayerNamefromPGID(pgid) + "'s";
            if (capSymbol.Contains("-f.")) return GetPlayerNamefromPGID(pgid);


            if (capSymbol == "-J") return GetDBValue("TEAM", "TMNA", FindTeamRecfromTeamName(teamNameDB[tgid]));
            if (capSymbol.Contains("-J-")) return GetDBValue("TEAM", "TMNA", FindTeamRecfromTeamName(teamNameDB[tgid])) + "'";

            if (capSymbol.Contains("-P")) return "Year " + GetDBValueInt("SEAI", "SEYR", 0);
            if (capSymbol == "-B") return GetClassYear(GetDBValueInt("PLAY", "PYER", pRec), GetDBValueInt("PLAY", "RSHD", pRec));

            if (capSymbol == "-g") 
            {
                int cgid = GetTeamCGID(FindTeamRecfromTeamName(teamNameDB[tgid]));
                return GetConfNameFromCGID(cgid);
            }

            if(capSymbol == "-#") GetTeamRanking(FindTeamRecfromTeamName(teamNameDB[tgid]));


            if (capSymbol == "-{")
            {
                return capSymbol;
            }

            if (capSymbol.Contains("-Q"))
            {
                return "Bowl Game";
            }

            if (capSymbol.Contains("-A"))
            {
                return GetPositionName(GetDBValueInt("PLAY", "PPOS", pRec));
            }

            if (capSymbol == "-e")
            {
                return capSymbol;
            }

            //Team Conf Seed
            if (capSymbol == "-I")
            {
                int teamRec = FindTeamRecfromTeamName(teamNameDB[tgid]);

                return "" + GetDBValue("TEAM", "tscw", teamRec) + "-" + GetDBValue("TEAM", "tscl", teamRec);
            }

            //Team  Seed
            if (capSymbol == "-8")
            {
                int teamRec = FindTeamRecfromTeamName(teamNameDB[tgid]);
                return "#" + GetDBValue("TEAM", "TCRK", teamRec);
            }


            //Prv Opponent Team  Seed
            if (capSymbol == "-#" || capSymbol == "-$")
            {
                int opponent = -1;
                int sewn = GetDBValueInt("SEAI", "SEWN", 0)-1;
                for (int i = 0; i < GetTableRecCount("SCHD"); i++)
                {
                    if (tgid == GetDBValueInt("SCHD", "GATG", i) && sewn == GetDBValueInt("SCHD", "SEWN", i))
                    {
                        int oppRec = FindTeamRecfromTeamName(teamNameDB[GetDBValueInt("SCHD", "GHTG", i)]);
                        return "#" + GetDBValue("TEAM", "TCRK", oppRec);
                    }
                    if (tgid == GetDBValueInt("SCHD", "GHTG", i) && sewn == GetDBValueInt("SCHD", "SEWN", i))
                    {
                        int oppRec = FindTeamRecfromTeamName(teamNameDB[GetDBValueInt("SCHD", "GATG", i)]);
                        return "#" + GetDBValue("TEAM", "TCRK", oppRec);
                    }
                }

                return capSymbol;
                
            }

            //Stats Season Yards
            if (capSymbol == "-?")
            {
                int seyr = GetDBValueInt("SEAI", "SEYR", 0);
                int ppos = GetDBValueInt("PLAY", "PPOS", pRec);
                for (int i = 0; i < GetTableRecCount("PSOF"); i++)
                {
                    if(pgid == GetDBValueInt("PSOF", "PGID", i) && seyr == GetDBValueInt("PSOF", "SEYR", i))
                    {
                        if (ppos == 0) return GetDBValue("PSOF", "saya", i);
                        if (ppos == 1) return GetDBValue("PSOF", "suya", i);
                        if (ppos == 3) return GetDBValue("PSOF", "scya", i);

                    }
                }

                return capSymbol;
            }

            //Stats Season TDs
            if (capSymbol == "-.")
            {
                int seyr = GetDBValueInt("SEAI", "SEYR", 0);
                int ppos = GetDBValueInt("PLAY", "PPOS", pRec);
                for (int i = 0; i < GetTableRecCount("PSOF"); i++)
                {
                    if (pgid == GetDBValueInt("PSOF", "PGID", i) && seyr == GetDBValueInt("PSOF", "SEYR", i))
                    {
                        if (ppos == 0) return GetDBValue("PSOF", "satd", i);
                        if (ppos == 1) return GetDBValue("PSOF", "sutd", i);
                        if (ppos == 3) return GetDBValue("PSOF", "sctd", i);

                    }
                }
                return capSymbol;
            }


            //Stats Game Yards
            if (capSymbol == "-v")
            {
                int sewn = GetDBValueInt("SEAI", "SEWN", 0)-1;
                int ppos = GetDBValueInt("PLAY", "PPOS", pRec);

                for (int i = 0; i < GetTableRecCount("PLAC"); i++)
                {
                    if (pgid == GetDBValueInt("PLAC", "PGID", i) && sewn == GetDBValueInt("PLAC", "SEWN", i))
                    {

                        string stat0 = GetDBValue("PLAC", "PAcC", i);
                        string stat1 = GetDBValue("PLAC", "PAsC", i);
                        string stat2 = GetDBValue("PLAC", "PAcS", i);
                        string stat3 = GetDBValue("PLAC", "PAsS", i);
                        string stat4 = GetDBValue("PLAC", "PAcV", i);
                        string stat5 = GetDBValue("PLAC", "PAsV", i);
                        string stat6 = GetDBValue("PLAC", "PAas", i);
                        string stat7 = GetDBValue("PLAC", "PAat", i);


                        if (ppos == 0) return stat3;
                        if (ppos == 1) return stat2;
                        if (ppos == 3) return stat2;

                    }
                }

                return capSymbol;
            }


            //Stats Game TDs
            if (capSymbol == "-w")
            {
                int sewn = GetDBValueInt("SEAI", "SEWN", 0) - 1;
                int ppos = GetDBValueInt("PLAY", "PPOS", pRec);

                for (int i = 0; i < GetTableRecCount("PLAC"); i++)
                {
                    if (pgid == GetDBValueInt("PLAC", "PGID", i) && sewn == GetDBValueInt("PLAC", "SEWN", i))
                    {

                        string stat0 = GetDBValue("PLAC", "PAcC", i);
                        string stat1 = GetDBValue("PLAC", "PAsC", i);
                        string stat2 = GetDBValue("PLAC", "PAcS", i);
                        string stat3 = GetDBValue("PLAC", "PAsS", i);
                        string stat4 = GetDBValue("PLAC", "PAcV", i);
                        string stat5 = GetDBValue("PLAC", "PAsV", i);
                        string stat6 = GetDBValue("PLAC", "PAas", i);
                        string stat7 = GetDBValue("PLAC", "PAat", i);


                        if (ppos == 0) return stat0;
                        if (ppos == 1) return stat0;
                        if (ppos == 3) return stat4;

                    }
                }

                return capSymbol;
            }

            //Stats Game Catches
            if (capSymbol == "-u")
            {
                int sewn = GetDBValueInt("SEAI", "SEWN", 0) - 1;
                int ppos = GetDBValueInt("PLAY", "PPOS", pRec);

                for (int i = 0; i < GetTableRecCount("PLAC"); i++)
                {
                    if (pgid == GetDBValueInt("PLAC", "PGID", i) && sewn == GetDBValueInt("PLAC", "SEWN", i))
                    {

                        string stat0 = GetDBValue("PLAC", "PAcC", i);
                        string stat1 = GetDBValue("PLAC", "PAsC", i);
                        string stat2 = GetDBValue("PLAC", "PAcS", i);
                        string stat3 = GetDBValue("PLAC", "PAsS", i);
                        string stat4 = GetDBValue("PLAC", "PAcV", i);
                        string stat5 = GetDBValue("PLAC", "PAsV", i);
                        string stat6 = GetDBValue("PLAC", "PAas", i);
                        string stat7 = GetDBValue("PLAC", "PAat", i);


                        if (ppos == 0) return capSymbol;
                        if (ppos == 1) return capSymbol;
                        if (ppos == 3) return stat3;

                    }
                }

                return capSymbol;
            }

            //City
            if (capSymbol == "-:")
            {
                int sgid = GetDBValueInt("TEAM", "SGID", FindTeamRecfromTeamName(teamNameDB[tgid]));

                for (int i = 0; i < GetTableRecCount("STAD"); i++)
                {
                    if(sgid == GetDBValueInt("STAD", "SGID", i))
                    {
                        return GetDBValue("STAD", "SCIT", i);
                    }
                }

                return capSymbol;
            }

            //Opposing Team Name
            if (capSymbol.Contains("-)"))
            {
                int opponent = -1;
                int sewn = GetDBValueInt("SEAI", "SEWN", 0);
                for (int i = 0; i < GetTableRecCount("SCHD"); i++)
                {
                    if(tgid == GetDBValueInt("SCHD", "GATG", i) && sewn == GetDBValueInt("SCHD", "SEWN", i))
                    {
                        return teamNameDB[GetDBValueInt("SCHD", "GHTG", i)];
                    }
                    if(tgid == GetDBValueInt("SCHD", "GHTG", i) && sewn == GetDBValueInt("SCHD", "SEWN", i))
                    {
                        return teamNameDB[GetDBValueInt("SCHD", "GATG", i)];

                    }
                }

                return capSymbol;
            }

            //Opposing Team Nickname
            if (capSymbol == "-|")
            {
                int opponent = -1;
                int sewn = GetDBValueInt("SEAI", "SEWN", 0);
                for (int i = 0; i < GetTableRecCount("SCHD"); i++)
                {
                    if (tgid == GetDBValueInt("SCHD", "GATG", i) && sewn == GetDBValueInt("SCHD", "SEWN", i))
                    {
                        opponent = GetDBValueInt("SCHD", "GHTG", i);
                    }
                    if (tgid == GetDBValueInt("SCHD", "GHTG", i) && sewn == GetDBValueInt("SCHD", "SEWN", i))
                    {
                        opponent = GetDBValueInt("SCHD", "GATG", i);

                    }
                }

                int teamRec = FindTeamRecfromTeamName(teamNameDB[opponent]);

                if (teamRec > 0) return GetDBValue("TEAM", "TMNA", teamRec);

                return capSymbol;
            }

            //Opposing Team rank
            if (capSymbol == "-W")
            {
                int opponent = -1;
                int sewn = GetDBValueInt("SEAI", "SEWN", 0);
                for (int i = 0; i < GetTableRecCount("SCHD"); i++)
                {
                    if (tgid == GetDBValueInt("SCHD", "GATG", i) && sewn == GetDBValueInt("SCHD", "SEWN", i))
                    {
                        opponent = GetDBValueInt("SCHD", "GHTG", i);
                    }
                    if (tgid == GetDBValueInt("SCHD", "GHTG", i) && sewn == GetDBValueInt("SCHD", "SEWN", i))
                    {
                        opponent = GetDBValueInt("SCHD", "GATG", i);

                    }
                }

                int teamRec = FindTeamRecfromTeamName(teamNameDB[opponent]);

                if (teamRec > 0) return "#" + GetDBValue("TEAM", "TCRK", teamRec);

                return capSymbol;
            }

            //Previous Opposing Team 
            if (capSymbol.Contains("-d"))
            {
                int opponent = -1;
                int sewn = GetDBValueInt("SEAI", "SEWN", 0)-1;
                for (int i = 0; i < GetTableRecCount("SCHD"); i++)
                {
                    if (tgid == GetDBValueInt("SCHD", "GATG", i) && sewn == GetDBValueInt("SCHD", "SEWN", i))
                    {
                        return teamNameDB[GetDBValueInt("SCHD", "GHTG", i)];
                    }
                    if (tgid == GetDBValueInt("SCHD", "GHTG", i) && sewn == GetDBValueInt("SCHD", "SEWN", i))
                    {
                        return teamNameDB[GetDBValueInt("SCHD", "GATG", i)];

                    }
                }

                return capSymbol;
            }

            //Previous Opposing Team Nickname
            if (capSymbol.Contains("-K"))
            {
                int opponent = -1;
                int sewn = GetDBValueInt("SEAI", "SEWN", 0) - 1;
                for (int i = 0; i < GetTableRecCount("SCHD"); i++)
                {
                    if (tgid == GetDBValueInt("SCHD", "GATG", i) && sewn == GetDBValueInt("SCHD", "SEWN", i))
                    {
                        opponent = GetDBValueInt("SCHD", "GHTG", i);
                    }
                    if (tgid == GetDBValueInt("SCHD", "GHTG", i) && sewn == GetDBValueInt("SCHD", "SEWN", i))
                    {
                        opponent = GetDBValueInt("SCHD", "GATG", i);

                    }
                }

                int teamRec = FindTeamRecfromTeamName(teamNameDB[opponent]);

                if (teamRec > 0) return GetDBValue("TEAM", "TMNA", teamRec);

                return capSymbol;
            }

            //Injury
            if (capSymbol.Contains("-Z") || capSymbol.Contains("-@"))
            {
                List<string> InjuryType = CreateInjuryTypeTable();
                for (int i = 0; i < GetTableRecCount("INJY"); i++)
                {
                    if (pgid == GetDBValueInt("INJY", "PGID", i))
                    {
                        string injuryType = InjuryType[GetDBValueInt("INJY", "INJT", i)];
                        return injuryType;
                    }
                }
                    return capSymbol;
            }

            //Injury Duration
            if (capSymbol.Contains("-!"))
            {
                List<string> InjuryLength = CreateInjuryLengthTable();
                for (int i = 0; i < GetTableRecCount("INJY"); i++)
                {
                    if (pgid == GetDBValueInt("INJY", "PGID", i))
                    {
                        string injuryLength = InjuryLength[GetDBValueInt("INJY", "INJL", i)];
                        return injuryLength;
                    }
                }
                return capSymbol;
            }

            //Player's Team City
            if (capSymbol.Contains("-E"))
            {
                int sgid = GetDBValueInt("TEAM", "SGID", FindTeamRecfromTeamName(teamNameDB[tgid]));

                for (int i = 0; i < GetTableRecCount("STAD"); i++)
                {
                    if (sgid == GetDBValueInt("STAD", "SGID", i))
                    {
                        return GetDBValue("STAD", "SCIT", i);
                    }
                }

                return capSymbol;
            }


            //Team Record
            if (capSymbol.Contains("-H"))
            {
                int rec = FindTeamRecfromTeamName(teamNameDB[tgid]);
                int wins = GetDBValueInt("TEAM", "tsdw", rec);
                int losses = GetDBValueInt("TEAM", "tsdl", rec);

                return "" + wins + "-" + losses;
            }


            //Game Score Away
            if (capSymbol.Contains("-L"))
            {
                int awayScore = 0;
                int homeScore = 0;
                int sewn = GetDBValueInt("SEAI", "SEWN", 0)-1;
                for (int i = 0; i < GetTableRecCount("SCHD"); i++)
                {
                    if (tgid == GetDBValueInt("SCHD", "GATG", i) && sewn == GetDBValueInt("SCHD", "SEWN", i))
                    {
                        awayScore = GetDBValueInt("SCHD", "GASC", i);
                        homeScore = GetDBValueInt("SCHD", "GHSC", i);
                        return "" + awayScore + "-" + homeScore;

                    }
                    if (tgid == GetDBValueInt("SCHD", "GHTG", i) && sewn == GetDBValueInt("SCHD", "SEWN", i))
                    {
                        awayScore = GetDBValueInt("SCHD", "GASC", i);
                        homeScore = GetDBValueInt("SCHD", "GHSC", i);
                        return "" + awayScore + "-" + homeScore;
                    }
                }

                return capSymbol;
            }

            //Game Score Home
            if (capSymbol.Contains("-M"))
            {
                int awayScore = 0;
                int homeScore = 0;
                int sewn = GetDBValueInt("SEAI", "SEWN", 0);
                for (int i = 0; i < GetTableRecCount("SCHD"); i++)
                {
                    if (tgid == GetDBValueInt("SCHD", "GATG", i) && sewn == GetDBValueInt("SCHD", "SEWN", i))
                    {
                        awayScore = GetDBValueInt("SCHD", "GASC", i);
                        homeScore = GetDBValueInt("SCHD", "GHSC", i);
                        return "" + homeScore;

                    }
                    if (tgid == GetDBValueInt("SCHD", "GHTG", i) && sewn == GetDBValueInt("SCHD", "SEWN", i))
                    {
                        awayScore = GetDBValueInt("SCHD", "GASC", i);
                        homeScore = GetDBValueInt("SCHD", "GHSC", i);
                        return "" + homeScore;
                    }
                }

                return capSymbol;
            }



            return capSymbol;
        }



        #endregion

        #region Headline UI Elements
        private List<PictureBox> GetHelmetHeadlinePics()
        {
            List<PictureBox> pics = new List<PictureBox>();
            pics.Add(Headline1Helmet);
            pics.Add(Headline2Helmet);
            pics.Add(Headline3Helmet);
            pics.Add(Headline4Helmet);
            return pics;
        }
        private List<Label> GetHeadlineTitleLabels()
        {
            List<Label> labels = new List<Label>();

            labels.Add(Headline1Title);
            labels.Add(Headline2Title);
            labels.Add(Headline3Title);
            labels.Add(Headline4Title);
            return labels;
        }
        private List<Label> GetHeadlineCaptionsLabels()
        {
            List<Label> labels = new List<Label>();

            labels.Add(Headline1Caption);
            labels.Add(Headline2Caption);
            labels.Add(Headline3Caption);
            labels.Add(Headline4Caption);
            return labels;
        }
        private List<Label> GetHeadlinePlayerLabels()
        {
            List<Label> labels = new List<Label>();

            labels.Add(Headline1Player);
            labels.Add(Headline2Player);
            labels.Add(Headline3Player);
            labels.Add(Headline4Player);
            return labels;
        }
        #endregion

        #region Table Views
        private void LoadHeadlinesRankings()
        {
            NewsTop25View.Rows.Clear();
            List<List<string>> rankings = new List<List<string>>();

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    int num = rankings.Count;
                    string rank = GetDBValue("TEAM", "TCRK", i);
                    rankings.Add(new List<string>());
                    rankings[num].Add(rank);
                    rankings[num].Add(GetDBValue("TEAM", "TDNA", i));
                    rankings[num].Add("" + (GetDBValueInt("TEAM", "tsdw", i)) + "-" + (GetDBValueInt("TEAM", "tsdl", i)));
                    rankings[num].Add(GetDBValue("TEAM", "TCPT", i));
                }

            }

            rankings.Sort((player1, player2) => Convert.ToInt32(player1[0]).CompareTo(Convert.ToInt32(player2[0])));
            foreach (List<string> team in rankings)
            {
                int row = NewsTop25View.Rows.Count;
                NewsTop25View.Rows.Add(1);

                NewsTop25View.Rows[row].Cells[0].Value = Convert.ToInt32(team[0]);
                NewsTop25View.Rows[row].Cells[1].Value = team[1];
                NewsTop25View.Rows[row].Cells[2].Value = team[2];
                NewsTop25View.Rows[row].Cells[3].Value = Convert.ToInt32(team[3]);

                NewsTop25View.Rows[row].Cells[1].Style.BackColor = GetTeamPrimaryColor(FindTeamRecfromTeamName(team[1]));
                NewsTop25View.Rows[row].Cells[1].Style.ForeColor = ChooseForeground(NewsTop25View.Rows[row].Cells[1].Style.BackColor);
            }
        }

        private void LoadHeadlinesHeismanRace()
        {
            HeismanView.Rows.Clear();
            List<List<string>> rankings = new List<List<string>>();

            for (int i = 0; i < GetTableRecCount("HEIS"); i++)
            {

                int num = rankings.Count;
                string rank = Convert.ToString(i + 1);
                int pgid = GetDBValueInt("HEIS", "PGID", i);
                int pRec = FindPGIDRecord(pgid);
                string pos = Positions[GetDBValueInt("PLAY", "PPOS", pRec)];
                string teamName = teamNameDB[Convert.ToInt32(pgid / 70)];


                rankings.Add(new List<string>());
                rankings[num].Add(Convert.ToString(pgid));
                rankings[num].Add(rank);
                rankings[num].Add(pos);
                rankings[num].Add(GetPlayerNamefromPGID(pgid));
                rankings[num].Add(teamName);
            }

            rankings.Sort((player1, player2) => Convert.ToInt32(player1[1]).CompareTo(Convert.ToInt32(player2[1])));
            foreach (List<string> team in rankings)
            {
                int row = HeismanView.Rows.Count;
                HeismanView.Rows.Add(1);

                HeismanView.Rows[row].Cells[0].Value = Convert.ToInt32(team[0]);
                HeismanView.Rows[row].Cells[1].Value = team[1];
                HeismanView.Rows[row].Cells[2].Value = team[2];
                HeismanView.Rows[row].Cells[3].Value = team[3];
                HeismanView.Rows[row].Cells[4].Value = team[4];
                HeismanView.Rows[row].Cells[4].Style.BackColor = GetTeamPrimaryColor(FindTeamRecfromTeamName(team[4]));
                HeismanView.Rows[row].Cells[4].Style.ForeColor = ChooseForeground(HeismanView.Rows[row].Cells[4].Style.BackColor);

            }
        }

        private void LoadHeadlinesCoachHotSeat()
        {
            CoachHotSeatView.Rows.Clear();
            List<List<string>> rankings = new List<List<string>>();

            for (int i = 0; i < GetTableRecCount("COCH"); i++)
            {

                int num = rankings.Count;

                string coachName = GetCoachFirstNamefromRec(i) + " " + GetCoachLastNamefromRec(i);
                int tgid = GetDBValueInt("COCH", "TGID", i);
                string teamName = teamNameDB[tgid];
                string CCPO = GetDBValue("COCH", "CCPO", i);

                if (Convert.ToInt32(CCPO) < 50)
                {
                    rankings.Add(new List<string>());
                    rankings[num].Add(Convert.ToString(i));
                    rankings[num].Add(coachName);
                    rankings[num].Add(teamName);
                    rankings[num].Add(CCPO);
                }
            }

            rankings.Sort((player1, player2) => Convert.ToInt32(player1[3]).CompareTo(Convert.ToInt32(player2[3])));
            foreach (List<string> team in rankings)
            {
                int row = CoachHotSeatView.Rows.Count;
                CoachHotSeatView.Rows.Add(1);

                CoachHotSeatView.Rows[row].Cells[0].Value = Convert.ToInt32(team[0]);
                CoachHotSeatView.Rows[row].Cells[1].Value = team[1];
                CoachHotSeatView.Rows[row].Cells[2].Value = team[2];
                CoachHotSeatView.Rows[row].Cells[3].Value = Convert.ToInt32(team[3]);

                CoachHotSeatView.Rows[row].Cells[2].Style.BackColor = GetTeamPrimaryColor(FindTeamRecfromTeamName(team[2]));
                CoachHotSeatView.Rows[row].Cells[2].Style.ForeColor = ChooseForeground(CoachHotSeatView.Rows[row].Cells[2].Style.BackColor);
                CoachHotSeatView.Rows[row].Cells[3].Style.BackColor = GetColorValueFullRange(Convert.ToInt32(team[3]));
                CoachHotSeatView.Rows[row].Cells[3].Style.ForeColor = Color.Black;
            }
        }

        #endregion
    }

}

