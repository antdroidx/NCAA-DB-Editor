using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {
        //Quick n Dirty Schedule Generator - Divisionless & Rivalryless
        private void ScheduleGenerator()
        {
            //Check League Setup
            CheckLeagueSetupForScheduling();


            //Clear Regular Season Games
            ClearRegularSeasonSchedule();


            //Out of Conference Scheduling Weeks 0 - 4
            OutOfConferenceSchedulingOLD();

            //Pick a Conference & Schedule Games (Weeks 5-15) -- 9 games
            for (int i = 0; i < GetTableRecCount("CONF"); i++)
            {
                if (TDB.FieldValue(dbIndex, "CONF", "LGID", i) == "0")
                {
                    ConferenceScheduling(i);
                }
            }


        }

        private void CreateMasterScheduleDB()
        {
            //create a list of teams and schedule

            MasterSchedule = new List<List<int>>();
            for (int i = 0; i < teamNameDB.Length; i++)
            {
                MasterSchedule.Add(new List<int>());
                for (int w = 0; w < 16; w++)
                {
                    MasterSchedule[i].Add(511);
                }
            }


            StartProgressBar(GetTableRecCount("SCHD"));

            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                if (GetDBValueInt("SCHD", "SEWN", i) < 16)
                {
                    int teamH = GetDBValueInt("SCHD", "GHTG", i);
                    int teamA = GetDBValueInt("SCHD", "GATG", i);
                    int sewn = GetDBValueInt("SCHD", "SEWN", i);
                    MasterSchedule[teamH][sewn] = teamA;
                    MasterSchedule[teamA][sewn] = teamH;
                }

                ProgressBarStep();
            }


            EndProgressBar();
        }

        private void ClearRegularSeasonSchedule()
        {
            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                if (GetDBValueInt("SCHD", "SEWN", i) < 16)
                {
                    TDB.TDBTableRecordRemove(dbIndex, "SCHD", i);
                }
            }
        }

        private void ClearOutOfConferenceOnly()
        {
            StartProgressBar(GetTableRecCount("SCHD"));

            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                int teamH = GetDBValueInt("SCHD", "GHTG", i);
                int teamA = GetDBValueInt("SCHD", "GATG", i);

                int recH = FindTeamRecfromTeamName(teamNameDB[teamH]);
                int recA = FindTeamRecfromTeamName(teamNameDB[teamA]);

                int GASC = GetDBValueInt("SCHD", "GASC", i);
                int GHSC = GetDBValueInt("SCHD", "GHSC", i);

                if(GASC > 0 || GHSC > 0)
                {
                    //do nothing
                }
                else if (KeepNDACCGames.Checked)
                {
                    if (GetDBValueInt("SCHD", "SEWN", i) < 16 && !CheckOOCMatchup(recH, recA) && !CheckNDACC(recH, recA) && !CheckMilitaryGames(recH, recA))
                    {
                        DeleteRecord("SCHD", i, true);
                    }
                }
                else
                {
                    if (GetDBValueInt("SCHD", "SEWN", i) < 16 && !CheckOOCMatchup(recH, recA) && !CheckMilitaryGames(recH, recA))
                    {
                        DeleteRecord("SCHD", i, true);
                    }
                }

                ProgressBarStep();
            }

            CompactDB();

            EndProgressBar();
        }

        private void ConferenceScheduling(int ConfRec)
        {
            //Create Conf Team List
            List<string> teamList = new List<string>();
            string CGID = TDB.FieldValue(dbIndex, "CONF", "CGID", ConfRec);

            for (int x = 0; x < GetTableRecCount("TEAM"); x++)
            {
                if (TDB.FieldValue(dbIndex, "TEAM", "CGID", x) == CGID)
                {
                    teamList.Add(TDB.FieldValue(dbIndex, "TEAM", "TGID", x));
                }
            }

            //Schedule Weeks 5-15
            int byeWeek = rand.Next(5, 16);

            for (int i = 5; i < 16; i++)
            {

            }

        }

        private void OutOfConferenceSchedulingOLD()
        {
            //divide 120 teams into 3 parts and schedule within each one
            List<int> groupA = new List<int>();
            List<int> groupB = new List<int>();
            List<int> groupC = new List<int>();
            List<int> fcs = new List<int>();

            int count = 0;
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    count++;
                    if (count % 3 == 0) groupA.Add(GetDBValueInt("TEAM", "TGID", i));
                    else if (count % 2 == 0) groupB.Add(GetDBValueInt("TEAM", "TGID", i));
                    else if (count % 1 == 0) groupC.Add(GetDBValueInt("TEAM", "TGID", i));
                }
                else if (GetDBValueInt("TEAM", "TTYP", i) == 1)
                {
                    fcs.Add(GetDBValueInt("TEAM", "TGID", i));
                }
            }

            OOCGroupScheduler(groupA, fcs);
            OOCGroupScheduler(groupB, fcs);
            OOCGroupScheduler(groupC, fcs);


            count = 0;
            groupA = new List<int>();
            groupB = new List<int>();
            groupC = new List<int>();
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    count++;
                    if (count % 3 == 0) groupA.Add(GetDBValueInt("TEAM", "TGID", i));
                    else if (count % 2 == 0) groupB.Add(GetDBValueInt("TEAM", "TGID", i));
                    else if (count % 1 == 0) groupC.Add(GetDBValueInt("TEAM", "TGID", i));
                }
                else if (GetDBValueInt("TEAM", "TTYP", i) == 1)
                {
                    fcs.Add(GetDBValueInt("TEAM", "TGID", i));
                }
            }

            OOCGroupsScheduler(groupA, groupB, fcs);

            count = 0;
            groupA = new List<int>();
            groupB = new List<int>();
            groupC = new List<int>();
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    count++;
                    if (count % 3 == 0) groupA.Add(GetDBValueInt("TEAM", "TGID", i));
                    else if (count % 2 == 0) groupB.Add(GetDBValueInt("TEAM", "TGID", i));
                    else if (count % 1 == 0) groupC.Add(GetDBValueInt("TEAM", "TGID", i));
                }
                else if (GetDBValueInt("TEAM", "TTYP", i) == 1)
                {
                    fcs.Add(GetDBValueInt("TEAM", "TGID", i));
                }
            }

            OOCGroupsScheduler(groupB, groupC, fcs);

            count = 0;
            groupA = new List<int>();
            groupB = new List<int>();
            groupC = new List<int>();
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    count++;
                    if (count % 3 == 0) groupA.Add(GetDBValueInt("TEAM", "TGID", i));
                    else if (count % 2 == 0) groupB.Add(GetDBValueInt("TEAM", "TGID", i));
                    else if (count % 1 == 0) groupC.Add(GetDBValueInt("TEAM", "TGID", i));
                }
                else if (GetDBValueInt("TEAM", "TTYP", i) == 1)
                {
                    fcs.Add(GetDBValueInt("TEAM", "TGID", i));
                }
            }

            OOCGroupsScheduler(groupC, groupA, fcs);

            MessageBox.Show("Out of Conference Scheduling Completed!");
        }

        private void OutOfConferenceSchedulingNEW()
        {
            StartProgressBar(300);
            List<List<int>> teamList = new List<List<int>>();
            List<int> fcs = new List<int>();

            //teamList   rec | TGID | CGID | gameCount
            //Create a list of Teams and their game count
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                int ttyp = GetDBValueInt("TEAM", "TTYP", i);

                if (ttyp == 0)
                {
                    int tgid = GetDBValueInt("TEAM", "TGID", i);
                    int cgid = GetDBValueInt("TEAM", "CGID", i);

                    int x = teamList.Count;
                    teamList.Add(new List<int>());
                    teamList[x].Add(i);
                    teamList[x].Add(tgid);
                    teamList[x].Add(cgid);
                    teamList[x].Add(0);

                    //Count Games:
                    int games = 0;
                    for (int g = 0; g < MasterSchedule[tgid].Count; g++)
                    {
                        if (MasterSchedule[tgid][g] != 511) games++;
                    }

                    teamList[x][3] = games;
                }
                else if (ttyp == 1)
                {
                    fcs.Add(GetDBValueInt("TEAM", "TGID", i));
                }
            }

            int capacity = TDB.TableCapacity(0, "SCHD");

            bool complete = false;
            bool indiesDone = false;
            int counter = 0;
            while (!complete)
            {
                List<List<int>> groupA = new List<List<int>>();
                List<List<int>> groupB = new List<List<int>>();

                if (!indiesDone)
                {
                    //schedule independents first to reduce errors.
                    for (int i = 0; i < teamList.Count; i++)
                    {
                        if (teamList[i][2] == 5 && teamList[i][3] < 12)
                        {
                            groupA.Add(teamList[i]);
                        }
                        else if (teamList[i][3] < 12)
                        {
                            groupB.Add(teamList[i]);
                        }
                    }

                    if (groupA.Count < 1)
                    {
                        indiesDone = true;
                    }
                }
                else
                {
                    int count = 0;
                    for (int i = 0; i < teamList.Count; i++)
                    {
                        if (count % 2 == 0 && teamList[i][3] < 12)
                        {
                            groupA.Add(teamList[i]);
                            count++;
                        }
                        else if (count % 1 == 0 && teamList[i][3] < 12)
                        {
                            groupB.Add(teamList[i]);
                            count++;
                        }
                    }
                }


                //start scheduling here, but first check if we're done.
                if (groupA.Count == 0 && groupB.Count == 0 && indiesDone)
                {
                    complete = true;
                    break;
                }
                else if (groupA.Count == 0 && groupB.Count > 0)
                {
                    ScheduleFCSMatch(groupB[0][1], fcs);
                }
                else if (groupB.Count == 0 && groupA.Count > 0)
                {
                    ScheduleFCSMatch(groupA[0][1], fcs);
                }
                else
                {
                    int teamA = rand.Next(0, groupA.Count);
                    int teamB = rand.Next(0, groupB.Count);
                    teamA = groupA[teamA][1];
                    teamB = groupB[teamB][1];
                    bool scheduled = false;
                    bool matchupcheck = false;
                    if (!CheckOOCMatchup(teamA, teamB))
                    {
                        //check for matchup if it already exists
                        int sewn = GetDBValueInt("SEAI", "SEWN", 0) + 1;
                        for (int w = sewn; w < 16; w++)
                        {
                            if (MasterSchedule[teamA][w] == teamB)
                            {
                                matchupcheck = true;
                                break;
                            }
                        }

                        if (!matchupcheck)
                        {
                            for (int w = sewn; w < 16; w++)
                            {
                                if (MasterSchedule[teamA][w] == 511 && MasterSchedule[teamB][w] == 511)
                                {
                                    ScheduleMatch(teamA, teamB, w);
                                    MasterSchedule[teamA][w] = teamB;
                                    MasterSchedule[teamB][w] = teamA;
                                    scheduled = true;
                                    break;
                                }
                            }

                            if (!scheduled)
                            {
                                ScheduleFCSMatch(teamA, fcs);
                                ScheduleFCSMatch(teamB, fcs);
                                scheduled = true;
                            }
                        }
                        else
                        {
                            ScheduleFCSMatch(teamA, fcs);
                            ScheduleFCSMatch(teamB, fcs);
                            scheduled = true;
                        }

                        //add game counters
                        if (scheduled)
                        {
                            for (int t = 0; t < teamList.Count; t++)
                            {
                                if (teamList[t][1] == teamA) teamList[t][3]++;
                                else if (teamList[t][1] == teamB) teamList[t][3]++;
                            }
                        }
                    }
                }

                ProgressBarStep();

                int schdCount = GetTableRecCount("SCHD");
                counter++;
                if(counter >= 25000 || schdCount > capacity)
                {
                    if (schdCount > capacity) MessageBox.Show("Scheduling Failed!\n\nToo many FCS games scheduled.\n\n Please re-run again until it works!");
                    else  MessageBox.Show("Scheduling Failed!\n\nDid not schedule enough games.\n\n Please re-run again until it works!");
                    break;
                }
            }
           
            if(counter < 25000)
            MessageBox.Show("Out of Conference Scheduling Completed Succcessfully!");
            EndProgressBar();
        }


        private bool CheckOOCMatchup(int teamArec, int teamBrec)
        {
            if (TDB.FieldValue(dbIndex, "TEAM", "CGID", teamArec) == TDB.FieldValue(dbIndex, "TEAM", "CGID", teamBrec)) return true;
            else return false;
        }

        private bool CheckNDACC(int teamArec, int teamBrec)
        {
            int teamA = GetDBValueInt("TEAM", "TGID", teamArec);
            int teamB = GetDBValueInt("TEAM", "TGID", teamBrec);
            int cgidA = GetDBValueInt("TEAM", "CGID", teamArec);
            int cgidB = GetDBValueInt("TEAM", "CGID", teamBrec);


            if (teamA == 68 && cgidB == 0) return true;
            else if (teamB == 68 && cgidA == 0) return true;
            else if (teamB == 68 && teamNameDB[teamA] == "USC" || teamA == 68 && teamNameDB[teamB] == "USC") return true;
            else return false;
        }

        private bool CheckMilitaryGames(int teamArec, int teamBrec)
        {
            string teamA = GetDBValue("TEAM", "TDNA", teamArec);
            string teamB = GetDBValue("TEAM", "TDNA", teamBrec);

            if (teamA == "Army" && teamB == "Navy" || teamB == "Army" && teamA == "Navy") return true;
            else if (teamA == "Army" && teamB == "Air Force" || teamB == "Army" && teamA == "Air Force") return true;
            else if (teamA == "Air Force" && teamB == "Navy" || teamB == "Air Force" && teamA == "Navy") return true;
            else return false;
        }

        private void CheckLeagueSetupForScheduling()
        {
            if (Convert.ToInt32(GetTableRecCount("DIVI")) > 0)
            {
                ScheduleError();
                return;
            }

            for (int i = 0; i < GetTableRecCount("CONF"); i++)
            {
                if (TDB.FieldValue(dbIndex, "CONF", "LGID", i) == "0")
                {
                    if (TDB.FieldValue(dbIndex, "CONF", "CGID", i) == "5")
                    {
                        ScheduleError();
                        return;
                    }
                    else if (GetConfTeamCount(i) % 2 != 0)
                    {
                        ScheduleError();
                        return;
                    }
                }
            }

            int count = 0;
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (TDB.FieldValue(dbIndex, "TEAM", "TTYP", i) == "0")
                {
                    count++;
                }
            }

            if (count != 120)
            {
                ScheduleError();
                return;
            }
        }

        private double GetConfTeamCount(int i)
        {
            string CGID = TDB.FieldValue(dbIndex, "CONF", "CGID", i);
            double count = 0;
            for (int x = 0; x < GetTableRecCount("TEAM"); x++)
            {
                if (TDB.FieldValue(dbIndex, "TEAM", "CGID", x) == CGID)
                {
                    count++;
                }
            }

            return count;
        }

        private void ScheduleError()
        {
            MessageBox.Show("This Schedule Generator only works with even, divisionless conferences and no independents!");
        }

        private void OOCGroupScheduler(List<int> group, List<int> fcs)
        {

            while (group.Count > 0)
            {
                int teamA = group[rand.Next(0, group.Count)];
                group.Remove(teamA);

                if (group.Count == 0)
                {
                    ScheduleFCSMatch(teamA, fcs);
                    break;
                }

                int teamB = group[rand.Next(0, group.Count)];
                group.Remove(teamB);

                if (!CheckOOCMatchup(FindTeamRecfromTeamName(teamNameDB[teamA]), FindTeamRecfromTeamName(teamNameDB[teamB])))
                {
                    bool scheduled = false;
                    for (int w = 1; w < 16; w++)
                    {
                        if (MasterSchedule[teamA][w] == 511 && MasterSchedule[teamB][w] == 511)
                        {
                            ScheduleMatch(teamA, teamB, w);
                            MasterSchedule[teamA][w] = teamB;
                            MasterSchedule[teamB][w] = teamA;
                            scheduled = true;
                            break;
                        }
                    }

                    if (!scheduled)
                    {
                        ScheduleFCSMatch(teamA, fcs);
                        ScheduleFCSMatch(teamB, fcs);
                    }
                }
                else
                {
                    ScheduleFCSMatch(teamA, fcs);
                    ScheduleFCSMatch(teamB, fcs);
                }

            }

        }

        private void OOCGroupsScheduler(List<int> ListA, List<int> ListB, List<int> fcs)
        {
            while (ListA.Count > 0)
            {
                if (ListA.Count == 1 && ListB.Count == 0)
                {
                    int team = ListA[rand.Next(0, ListA.Count)];
                    ScheduleFCSMatch(team, fcs);
                    break;

                }
                else if (ListA.Count == 0 && ListB.Count == 1)
                {
                    int team = ListA[rand.Next(0, ListB.Count)];
                    ScheduleFCSMatch(team, fcs);
                    break;
                }


                int teamA = ListA[rand.Next(0, ListA.Count)];
                ListA.Remove(teamA);
                int teamB = ListB[rand.Next(0, ListB.Count)];
                ListB.Remove(teamB);

                if (!CheckOOCMatchup(FindTeamRecfromTeamName(teamNameDB[teamA]), FindTeamRecfromTeamName(teamNameDB[teamB])))
                {
                    bool scheduled = false;
                    for (int w = 1; w < 16; w++)
                    {
                        if (MasterSchedule[teamA][w] == 511 && MasterSchedule[teamB][w] == 511)
                        {
                            ScheduleMatch(teamA, teamB, w);
                            MasterSchedule[teamA][w] = teamB;
                            MasterSchedule[teamB][w] = teamA;

                            scheduled = true;
                            break;
                        }
                    }
                    if (!scheduled)
                    {
                        ScheduleFCSMatch(teamA, fcs);
                        ScheduleFCSMatch(teamB, fcs);
                    }
                }
                else
                {
                    ScheduleFCSMatch(teamA, fcs);
                    ScheduleFCSMatch(teamB, fcs);
                }

            }

        }

        private void ScheduleFCSMatch(int team, List<int> fcs)
        {
            int teamH = team;
            bool scheduled = false;
            int count = 0;
            while (!scheduled && count < 50)
            {
                int teamA = fcs[rand.Next(0, fcs.Count)];
                int sewn = GetDBValueInt("SEAI", "SEWN", 0);
                for (int w = sewn; w < 16; w++)
                {
                    if (MasterSchedule[teamH][w] == 511 && MasterSchedule[teamA][w] == 511)
                    {
                        ScheduleMatch(teamH, teamA, w);
                        MasterSchedule[teamA][w] = teamH;
                        MasterSchedule[teamH][w] = teamA;

                        scheduled = true;
                        break;
                    }
                }
                count++;
            }


            if (!scheduled)
            {
                int sewn = GetDBValueInt("SEAI", "SEWN", 0);
                for (int w = sewn; w < 16; w++)
                {
                    if (MasterSchedule[teamH][w] == 511)
                    {
                        int teamA = fcs[rand.Next(0, fcs.Count)];
                        ScheduleMatch(teamH, teamA, w);
                        MasterSchedule[teamA][w] = teamH;
                        MasterSchedule[teamH][w] = teamA;

                        break;
                    }
                }

            }

        }

        private void ScheduleMatch(int teamH, int teamA, int wk)
        {
            int rec = GetTableRecCount("SCHD");
            AddTableRecord("SCHD", false);

            int tod = rand.Next(0, 4);
            if (tod == 0) tod = 630;
            else if (tod == 1) tod = 920;
            else tod = 1130;
            ChangeDBInt("SCHD", "GTOD", rec, tod);
            ChangeDBInt("SCHD", "GATG", rec, teamA);
            ChangeDBInt("SCHD", "GHTG", rec, teamH);
            ChangeDBInt("SCHD", "SEWN", rec, wk);
            ChangeDBInt("SCHD", "GDAT", rec, 5);
            ChangeDBInt("SCHD", "SEWT", rec, wk);
            int gmfx = rand.Next(0, 2);
            ChangeDBInt("SCHD", "GMFX", rec, gmfx);

            int sgnm = 0;
            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                if (GetDBValueInt("SCHD", "SEWN", i) == wk)
                {
                    int tmpSGNM = GetDBValueInt("SCHD", "SGNM", i);
                    if (tmpSGNM > sgnm) sgnm = tmpSGNM;
                }
            }

            ChangeDBInt("SCHD", "SGNM", rec, sgnm + 1);

        }
    }
}
