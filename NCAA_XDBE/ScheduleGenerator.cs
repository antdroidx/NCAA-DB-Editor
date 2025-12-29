using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private void ScheduleSeason_Click(object sender, EventArgs e)
        {
            ScheduleGenerator();
            SCHDTeamBox_SelectedIndexChanged(sender, e);

        }


        //Reschedule Out of Conference Games
        private void RescheduleOOC_Click(object sender, EventArgs e)
        {
            ClearOutOfConferenceOnly();
            CreateMasterScheduleDB();
            OutOfConferenceScheduling();

            ScheduleFinalCheck(12, 99);

            SCHDTeamBox_SelectedIndexChanged(sender, e);
        }

        private void ScheduleGenerator()
        {  
            //Check League Setup
            if(LeagueConfCheck() == false)
            {
                ScheduleError();
                return;
            }
            

            //Clear Regular Season Games
            ClearRegularSeasonSchedule();


            //Create Master Schedule DB
            CreateMasterScheduleDB();

            //Pick a Conference & Schedule Games
            StartProgressBar(GetTableRecCount("CONF"));
            for (int i = 0; i < GetTableRecCount("CONF"); i++)
            {
                int conf = GetDBValueInt("CONF", "CGID", i);
                if (GetDBValueInt("CONF", "LGID", i) == 0)
                {
                    ConferenceScheduling(i);

                    int confGames = Convert.ToInt32(ConfGames.Value);
                    int confSize = GetConfTeamCount(i);


                    if (confSize - 1 <= confGames)
                    {
                        confGames = confSize - 1;
                        if (confSize > 12) confGames = 12;
                    }
                    else if (RoundRobinSchedule.Checked)
                    {
                        confGames = confSize - 1;
                        if (confSize > 12) confGames = 12;
                    }

                    if (confSize % 2 == 1 && confGames % 2 == 1)
                    {
                        confGames -= 1; //adjust for odd sized conferences
                    }

                    ScheduleFinalCheck(confGames, conf);
                }
                ProgressBarStep();
            }
            EndProgressBar();

            //Re-Create Master Schedule DB
            CreateMasterScheduleDB();

            //Out of Conference Scheduling
            OutOfConferenceScheduling();

            //Final Check
            ScheduleFinalCheck(12, 99);

            //Ensure Week 15 is used
            Week15Check();


            MessageBox.Show("Scheduling Complete!");

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
            }
        }

        //Conference Scheduling
        private void ClearRegularSeasonSchedule()
        {
            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                if (GetDBValueInt("SCHD", "SEWN", i) < 16)
                {
                    DeleteRecord("SCHD", i, true);
                }
            }
            CompactDB();

        }


        private void ConferenceScheduling(int ConfRec)
        {
            //Create Conf Team List
            List<int> teamList = new List<int>();
            int CGID = GetDBValueInt("CONF", "CGID", ConfRec);

            for (int x = 0; x < GetTableRecCount("TEAM"); x++)
            {
                if (GetDBValueInt("TEAM", "CGID", x) == CGID)
                {
                    teamList.Add(GetDBValueInt("TEAM", "TGID", x));
                }
            }

            // Randomize the team list using Fisher-Yates shuffle
            int teamCount = teamList.Count;
            while (teamCount > 1)
            {
                teamCount--;
                int k = rand.Next(teamCount + 1);
                int temp = teamList[k];
                teamList[k] = teamList[teamCount];
                teamList[teamCount] = temp;
            }

            //Determine if Conference Size is Odd
            int BYE = 999;
            if (teamList.Count % 2 == 1)
            {
                teamList.Add(BYE); //add bye week team
            }

            // Recompute n using the (possibly) updated list
            teamCount = teamList.Count;                  // total teams incl. BYE if present
            int pivotIndex = teamCount - 1;              // fixed team/pivot (last slot)
            int maxRounds = teamCount - 1;               // circle method: always n-1 rounds

            // Determine requested number of conference games (rounds)
            int requested = Convert.ToInt32(ConfGames.Value);
            bool roundRobin = RoundRobinSchedule.Checked;

            // Limit: at most 12 conference games
            int rounds = roundRobin ? maxRounds : Math.Min(requested, maxRounds);
            rounds = Math.Min(rounds, 12);


            //Determine if Conference Size is Odd
            if (teamList.Count % 2 == 1 && rounds % 2 == 1)
            {
                rounds--; //reduce rounds by 1 for odd teams
            }


            //Schedule Weeks
            for (int r = 0; r < rounds; r++)
            {
                //Create a list of Teams and their game count
                CreateMasterScheduleDB();
                List<int> teamGames = new List<int>();
                for (int t = 0; t < teamList.Count; t++)
                {
                    int tgid = teamList[t];
                    teamGames.Add(0);
                    if(tgid == BYE)
                    {
                        continue;
                    }
                    //Count Games:
                    int games = 0;
                    for (int g = 0; g < MasterSchedule[tgid].Count; g++)
                    {
                        if (MasterSchedule[tgid][g] != 511) games++;
                    }

                    teamGames[t] = games;
                }

                // Pair i-th from the start with i-th from the end; special-case first pair vs pivot
                for (int i = 0; i < teamCount / 2; i++)
                {
                    // Indices into [0..n-2]; pivot is n-1
                    int aIndex = (r + i) % (pivotIndex);
                    int bIndex = (pivotIndex - i + r) % (pivotIndex);
                    if (i == 0) bIndex = pivotIndex; // first pair each round uses the pivot

                    int teamA = teamList[aIndex];
                    int teamB = teamList[bIndex];

                    // Skip BYE
                    if (teamA == BYE || teamB == BYE) continue;

                    // Avoid duplicates and self-games
                    if (teamA == teamB) continue;
                    if (MasterSchedule[teamA].Contains(teamB)) continue;

                    //Schedule Game
                    bool scheduled = false;
                    int attempts = 0;

                    while (scheduled == false && attempts < 10000)
                    {

                        int w = rand.Next(0, r + 16 - rounds);
                        if (w > 15) w = 15;

                        if (MasterSchedule[teamA][w] == 511 && MasterSchedule[teamB][w] == 511 && !MasterSchedule[teamA].Contains(teamB))
                        {

                            //MasterSchedule[teamA][w] = teamB;
                            //MasterSchedule[teamB][w] = teamA;
                            teamGames[aIndex]++;
                            teamGames[bIndex]++;

                            if (r % 2 == 0) ScheduleMatch(teamA, teamB, w, true);
                            else ScheduleMatch(teamB, teamA, w, true);

                            scheduled = true;
                        }
                        attempts++;
                    }

                }  
                
            }

        }


        //Out of Conference Scheduling
        private void ClearOutOfConferenceOnly()
        {
            StartProgressBar(GetTableRecCount("SCHD"));

            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                int teamH = GetDBValueInt("SCHD", "GHTG", i);
                int teamA = GetDBValueInt("SCHD", "GATG", i);

                int recH = FindTeamRecfromTGID(teamH);
                int recA = FindTeamRecfromTGID(teamA);

                int GASC = GetDBValueInt("SCHD", "GASC", i);
                int GHSC = GetDBValueInt("SCHD", "GHSC", i);

                if (GASC > 0 || GHSC > 0)
                {
                    //do nothing
                }
                else if (KeepNDACCGames.Checked)
                {
                    if (GetDBValueInt("SCHD", "SEWN", i) < 16 && CheckOOCMatchup(recH, recA) && !CheckNDACC(recH, recA) && !CheckMilitaryGames(recH, recA))
                    {
                        DeleteRecord("SCHD", i, true);
                    }
                    else
                    {
                        ChangeDBInt("SCHD", "GMFX", i, 1);
                    }
                }
                else
                {
                    if (GetDBValueInt("SCHD", "SEWN", i) < 16 && CheckOOCMatchup(recH, recA) && !CheckMilitaryGames(recH, recA))
                    {
                        DeleteRecord("SCHD", i, true);
                    }
                }

                ProgressBarStep();
            }

            CompactDB();

            EndProgressBar();
        }

        private void OutOfConferenceScheduling()
        {
            StartProgressBar(350);
            int maxCounter = 25000;

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


            //Start the Scheduling Loop
            bool complete = false;
            bool indiesDone = false;
            int counter = 0;
            while (!complete)
            {

                //Count Games:
                CreateMasterScheduleDB();

                for (int t = 0; t < teamList.Count; t++)
                {
                    int tgid = teamList[t][1];
                    int games = 0;
                    for (int g = 0; g < MasterSchedule[tgid].Count; g++)
                    {
                        if (MasterSchedule[tgid][g] != 511) games++;
                    }

                    teamList[t][3] = games;
                }

                // Randomize the team list using Fisher-Yates shuffle
                int n = teamList.Count;
                while (n > 1)
                {
                    n--;
                    int k = rand.Next(n + 1);
                    List<int> temp = teamList[k];
                    teamList[k] = teamList[n];
                    teamList[n] = temp;
                }

                //Quality Checks
                int schdCount = GetTableRecCount("SCHD");
                if (CheckSCHDCapacity())
                {
                    return;
                }
                else if (counter > maxCounter)
                {
                    for (int t = 0; t < teamList.Count; t++)
                    {
                        if (teamList[t][3] < 12)
                        {
                            while (teamList[t][3] < 12)
                            {

                                if (CheckSCHDCapacity()) return;

                                ScheduleFCSMatch(teamList[t][1], fcs);
                                teamList[t][3]++;
                            }
                        }
                    }

                    for (int t = 0; t < teamList.Count; t++)
                    {
                        if (teamList[t][3] < 12)
                        {

                            MessageBox.Show("Scheduling Failed!\n\nDid not schedule enough OOC games.\n\n Please re-run again until it works!");

                            MessageBox.Show("" + teamNameDB[teamList[t][1]]);
                            break;
                        }
                    }

                }

                /* Start the actual scheduling process
                 * Create two groups of teams that need games
                 */

                List<List<int>> groupA = new List<List<int>>();
                List<List<int>> groupB = new List<List<int>>();

                //schedule independents first to reduce errors.
                if (!indiesDone)
                {
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

                    if (groupA.Count == 0)
                    {
                        indiesDone = true;
                    }
                }
                //Schedule the rest of the teams
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
                //Schedule Games
                else
                {
                    int teamA = rand.Next(0, groupA.Count);
                    int teamB = rand.Next(0, groupB.Count);
                    int teamArec = groupA[teamA][0];
                    int teamBrec = groupB[teamB][0];
                    teamA = groupA[teamA][1];  //tgid
                    teamB = groupB[teamB][1]; //tgid
                    bool scheduled = false;

                    if (CheckOOCMatchup(teamArec, teamBrec) && !CheckScheduledMatchup(teamA, teamB))
                    {

                        int sewn = GetDBValueInt("SEAI", "SEWN", 0) + 1;

                        for (int w = sewn; w < 16; w++)
                        {
                            if (MasterSchedule[teamA][w] == 511 && MasterSchedule[teamB][w] == 511)
                            {
                                ScheduleMatch(teamA, teamB, w, true);
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

                }

                counter++;
                ProgressBarStep();
            }




            if (counter < maxCounter)
            {
                MessageBox.Show("Out of Conference Scheduling Completed Succcessfully!");
            }


            EndProgressBar();
        }


        //Quality Checks

        private bool LeagueConfCheck()
        {
            for (int i = 0; i < GetTableRecCount("CONF"); i++)
            {
                int lgid = GetDBValueInt("CONF", "LGID", i);
                int cgid = GetDBValueInt("CONF", "CGID", i);
                if (lgid == 0 && cgid != 5)
                {
                    int count = GetConfTeamCount(i);
                    if (count % 2 == 1 && count < 11)
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        private void ScheduleFinalCheck(int ExpectedGames, int conf)
        {

            CreateMasterScheduleDB();

            List<List<int>> teamList = new List<List<int>>();

            //teamList   rec | TGID | CGID | gameCount
            //Create a list of Teams and their game count
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                int ttyp = GetDBValueInt("TEAM", "TTYP", i);
                int cgid = GetDBValueInt("TEAM", "CGID", i);
                int tgid = GetDBValueInt("TEAM", "TGID", i);

                if (ttyp == 0 && cgid == conf || ttyp == 0 && conf == 99)
                {
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

            }

            for (int t = 0; t < teamList.Count; t++)
            {
                if (teamList[t][3] != ExpectedGames)
                {
                    string gamecount = " not enough ";
                    if (teamList[t][3] > ExpectedGames) gamecount = " too many ";
                    string type = "[CONF]";
                    if (conf == 99) type = "[OOC]";
                    MessageBox.Show("Scheduling Failed!\n\nThere were" + gamecount + type + " games.\n\n Please re-run again until it works!\n\n\n Example: " + teamNameDB[teamList[t][1]]);
                    break;
                }
            }


        }

        private void Week15Check()
        {
            CreateMasterScheduleDB();
            bool week15used = false;

            for (int i = 0; i < MasterSchedule.Count; i++)
            {
                if (MasterSchedule[i][15] != 511)
                {
                    week15used = true;
                    break;
                }
            }

            if (!week15used)
            {
                //reschedule a game to week 15
                for (int i = 0; i < GetTableRecCount("SCHD"); i++)
                {
                    int sewn = GetDBValueInt("SCHD", "SEWN", i);
                    if (sewn < 15)
                    {
                        //reschedule this game to week 15
                        ChangeDBInt("SCHD", "SGNM", i, 0);
                        ChangeDBInt("SCHD", "SEWN", i, 15);
                        ChangeDBInt("SCHD", "SEWT", i, 15);
                        week15used = true;
                        break;
                    }
                }
            }
        }

        private bool CheckScheduledMatchup(int teamA, int teamB)
        {
            CreateMasterScheduleDB();
            //check for matchup if it already exists
            for (int w = 0; w < 16; w++)
            {
                if (MasterSchedule[teamA][w] == teamB)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckOOCMatchup(int teamArec, int teamBrec)
        {
            if (GetDBValueInt("TEAM", "CGID", teamArec) == GetDBValueInt("TEAM", "CGID", teamBrec)) return false;
            else return true;
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

        private int GetConfTeamCount(int i)
        {
            int CGID = GetDBValueInt("CONF", "CGID", i);
            int count = 0;
            for (int x = 0; x < GetTableRecCount("TEAM"); x++)
            {
                if (GetDBValueInt("TEAM", "CGID", x) == CGID)
                {
                    count++;
                }
            }

            return count;
        }

        private bool CheckSCHDCapacity()
        {
            int capacity = TDB.TableCapacity(0, "SCHD");
            int schdCount = GetTableRecCount("SCHD");
            if (schdCount > capacity)
            {
                MessageBox.Show("Scheduling Failed!\n\nRan out of database capacity.\n\n Please re-run again until it works!");
                return true;
            }
            else
            {
                return false;
            }

        }

        private void ScheduleError()
        {
            MessageBox.Show("This Schedule Generator only works with even-sized conferences!");
        }




        //Scheduling Helpers
        private void ScheduleFCSMatch(int team, List<int> fcs)
        {
            int teamH = team;
            bool scheduled = false;
            int count = 0;
            while (!scheduled && count < 1000)
            {
                int teamA = fcs[rand.Next(0, fcs.Count)];
                int sewn = GetDBValueInt("SEAI", "SEWN", 0);
                for (int w = sewn; w < 16; w++)
                {
                    if (MasterSchedule[teamH][w] == 511 && MasterSchedule[teamA][w] == 511)
                    {
                        ScheduleMatch(teamH, teamA, w, false);

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
                        ScheduleMatch(teamH, teamA, w, false);

                        break;
                    }
                }

            }

        }

        private void ScheduleMatch(int teamH, int teamA, int wk, bool locked)
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
            int gmfx = 0;
            if (locked) gmfx = 1;
            ChangeDBInt("SCHD", "GMFX", rec, gmfx);

            if (teamA == 8 && teamH == 57 || teamH == 8 && teamA == 57)
            {
                ChangeDBInt("SCHD", "SEWN", rec, 15);
                ChangeDBInt("SCHD", "SEWT", rec, 15);
            }


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
