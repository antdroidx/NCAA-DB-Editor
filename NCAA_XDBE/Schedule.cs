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
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "CONF"); i++)
            {
                if (TDB.FieldValue(dbIndex, "CONF", "LGID", i) == "0")
                {
                    ConferenceScheduling(i);
                }
            }


        }

        private void ClearRegularSeasonSchedule()
        {
            for(int i = 0; i < TDB.TableRecordCount(dbIndex, "SCHD"); i++)
            {
                if(Convert.ToInt32(TDB.FieldValue(dbIndex,"SCHD", "SEWN", i)) > 16)
                {
                    TDB.TDBTableRecordRemove(dbIndex, "SCHD", i);
                }
            }
        }

        private void ConferenceScheduling(int ConfRec)
        {
            //Create Conf Team List
            List<string> teamList = new List<string>();
            string CGID = TDB.FieldValue(dbIndex, "CONF", "CGID", ConfRec);

            for (int x = 0; x < TDB.TableRecordCount(dbIndex, "TEAM"); x++)
            {
                if (TDB.FieldValue(dbIndex, "TEAM", "CGID", x) == CGID)
                {
                    teamList.Add(TDB.FieldValue(dbIndex, "TEAM", "TGID", x));
                }
            }

            //Schedule Weeks 5-15
            int byeWeek = rand.Next(5, 16);

            for(int i = 5; i < 16; i++)
            {

            }

        }

        private void OutOfConferenceScheduling()
        {
            //divide 120 teams into 3 parts and schedule within each one
        }

        private bool CheckOOCMatchup(int teamArec, int teamBrec)
        {
            if (TDB.FieldValue(dbIndex, "TEAM", "CGID", teamArec) == TDB.FieldValue(dbIndex, "TEAM", "CGID", teamBrec)) return true;
            else return false;
        }

        private void CheckLeagueSetupForScheduling()
        {
            if (Convert.ToInt32(TDB.TableRecordCount(dbIndex, "DIVI")) > 0)
            {
                ScheduleError();
                return;
            }

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "CONF"); i++)
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
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "TEAM"); i++)
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
            for(int x = 0; x < TDB.TableRecordCount(dbIndex, "TEAM"); x++)
            {
                if(TDB.FieldValue(dbIndex, "TEAM", "CGID", x) == CGID)
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


    }
}
