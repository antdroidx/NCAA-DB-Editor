using System;
using System.Collections.Generic;
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
            OutOfConferenceScheduling();

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


            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("SCHD");

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

                progressBar1.PerformStep();
            }


            progressBar1.Visible = false;
            progressBar1.Value = 0;

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
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("SCHD");

            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                int teamH = GetDBValueInt("SCHD", "GHTG", i);
                int teamA = GetDBValueInt("SCHD", "GATG", i);

                if (GetDBValueInt("SCHD", "SEWN", i) < 16 && !CheckOOCMatchup(FindTeamRecfromTeamName(teamNameDB[teamH]), FindTeamRecfromTeamName(teamNameDB[teamA])))
                {
                    DeleteRecordChange("SCHD", i, true);
                }

                progressBar1.PerformStep();
            }

            CompactDB();

            progressBar1.Visible = false;
            progressBar1.Value = 0;
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

        private void OutOfConferenceScheduling()
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

        private bool CheckOOCMatchup(int teamArec, int teamBrec)
        {
            if (TDB.FieldValue(dbIndex, "TEAM", "CGID", teamArec) == TDB.FieldValue(dbIndex, "TEAM", "CGID", teamBrec)) return true;
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

                for (int w = 0; w < 16; w++)
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
                for (int w = 0; w < 16; w++)
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
                if(GetDBValueInt("SCHD", "SEWN", i) == wk)
                {
                    int tmpSGNM = GetDBValueInt("SCHD", "SGNM", i);
                    if(tmpSGNM > sgnm) sgnm = tmpSGNM;
                }
            }

            ChangeDBInt("SCHD", "SGNM", rec, sgnm+1);

        }
    }
}
