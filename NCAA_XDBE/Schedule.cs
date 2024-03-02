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

        }

        private void ScheduleIndependents(int ConfRec)
        {

        }

        private void OutOfConferenceScheduling()
        {

        }

        private bool CheckOOCMatchup(int teamArec, int teamBrec)
        {
            if (TDB.FieldValue(dbIndex, "TEAM", "CGID", teamArec) == TDB.FieldValue(dbIndex, "TEAM", "CGID", teamBrec)) return true;
            else return false;
        }


    }
}
