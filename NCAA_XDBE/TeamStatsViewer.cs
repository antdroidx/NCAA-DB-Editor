using System;
using System.Collections;
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
        private void StartTeamStatsViewer()
        {
            LoadTeamStatsComboBox();
        }

        private void LoadTeamStatsComboBox()
        {
            TSTeamBox.Items.Clear();

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    TSTeamBox.Items.Add(teamNameDB[GetDBValueInt("TEAM", "TGID", i)]);
                }
            }
        }


        private void TSTeamBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string teamName = TSTeamBox.Text;

            int teamRec = FindTeamRecfromTeamName(teamName);
            int tgid = GetDBValueInt("TEAM", "TGID", teamRec);

            int pgidStart = tgid * 70;
            int pgidEnd = pgidStart + 69;

            if (teamName == null)
            {
                return;
            }
            else
            {
                teamRec = FindTeamRecfromTeamName(teamName);
                tgid = GetDBValueInt("TEAM", "TGID", teamRec);

                pgidStart = tgid * 70;
                pgidEnd = pgidStart + 69;
            }

            int year = GetDBValueInt("SEAI", "SEYR", 0);

            LoadPassingStats(year, pgidStart, pgidEnd);
            LoadRushingStats(year, pgidStart, pgidEnd);
            LoadReceivingStats(year, pgidStart, pgidEnd);
            LoadDefenseStats(year, pgidStart, pgidEnd);
            LoadKickingStats(year, pgidStart, pgidEnd);
            LoadPuntingStats(year, pgidStart, pgidEnd);
            LoadReturnsStats(year, pgidStart, pgidEnd);
        }

        private void LoadPassingStats(int year, int pgidStart, int pgidEnd)
        {
            TSPassing.Rows.Clear();

            for (int i = 0; i < GetTableRecCount("PSOF"); i++)
            {
                if (GetDBValueInt("PSOF", "SEYR", i) == year && GetDBValueInt("PSOF", "PGID", i) >= pgidStart && GetDBValueInt("PSOF", "PGID", i) <= pgidEnd && GetDBValueInt("PSOF", "saat", i) > 0)
                {
                    int gp = GetDBValueInt("PSOF", "sgmp", i);


                    if (gp > 0)
                    {
                        string player = GetPlayerNamefromPGID(GetDBValueInt("PSOF", "PGID", i));

                        int cmp = GetDBValueInt("PSOF", "sacm", i);
                        int att = GetDBValueInt("PSOF", "saat", i);
                        int yds = GetDBValueInt("PSOF", "saya", i);
                        int td = GetDBValueInt("PSOF", "satd", i);
                        int ints = GetDBValueInt("PSOF", "sain", i);
                        int skd = GetDBValueInt("PSOF", "sasa", i);

                        double pct = 0;
                        if (att > 0) pct = Math.Round((Convert.ToDouble(cmp) / Convert.ToDouble(att)) * 100, 1);

                        double ypg = 0;
                        if (gp > 0) ypg = Math.Round((Convert.ToDouble(yds) / Convert.ToDouble(gp)), 1);


                        // NCAA Passer Rating Formula:
                        // (8.4 * YDS + 330 * TD + 100 * CMP - 200 * INT) / ATT
                        double qbr = 0;
                        if (att > 0)
                        {
                            qbr = Math.Round(
                                ((8.4 * yds) +
                                 (330 * td) +
                                 (100 * cmp) -
                                 (200 * ints)) / att, 1);
                        }
                        if (qbr < 0) qbr = 0;

                        int row = TSPassing.Rows.Count;
                        TSPassing.Rows.Add(1);
                        TSPassing.Rows[row].Cells[0].Value = player;
                        TSPassing.Rows[row].Cells[1].Value = gp;
                        TSPassing.Rows[row].Cells[2].Value = qbr;
                        TSPassing.Rows[row].Cells[3].Value = cmp;
                        TSPassing.Rows[row].Cells[4].Value = att;
                        TSPassing.Rows[row].Cells[5].Value = pct;
                        TSPassing.Rows[row].Cells[6].Value = yds;
                        TSPassing.Rows[row].Cells[7].Value = ypg;
                        TSPassing.Rows[row].Cells[8].Value = td;
                        TSPassing.Rows[row].Cells[9].Value = ints;
                        TSPassing.Rows[row].Cells[10].Value = skd;
                    } 
                }
            }

            TSPassing.Sort(TSPassYds, System.ComponentModel.ListSortDirection.Descending);
            TSPassing.ClearSelection();    
        }

        private void LoadRushingStats(int year, int pgidStart, int pgidEnd)
        {

            TSRushing.Rows.Clear();

            for (int i = 0; i < GetTableRecCount("PSOF"); i++)
            {
                if (GetDBValueInt("PSOF", "SEYR", i) == year && GetDBValueInt("PSOF", "PGID", i) >= pgidStart && GetDBValueInt("PSOF", "PGID", i) <= pgidEnd && GetDBValueInt("PSOF", "suat", i) > 0)
                {
                    int gp = GetDBValueInt("PSOF", "sgmp", i);


                    if (gp > 0)
                    {
                        string player = GetPlayerNamefromPGID(GetDBValueInt("PSOF", "PGID", i));

                        int att = GetDBValueInt("PSOF", "suat", i);
                        int yds = GetDBValueInt("PSOF", "suya", i);
                        int td = GetDBValueInt("PSOF", "sutd", i);
                        int fum = GetDBValueInt("PSOF", "sufu", i);
                        int yai = GetDBValueInt("PSOF", "suyh", i);
                        int btk = GetDBValueInt("PSOF", "subt", i);
                        int twenty = GetDBValueInt("PSOF", "su2y", i);

                        double ypc = 0;
                        if (att > 0) ypc = Math.Round((Convert.ToDouble(yds) / Convert.ToDouble(att)), 1);

                        double ypg = 0;
                        if (gp > 0) ypg = Math.Round((Convert.ToDouble(yds) / Convert.ToDouble(gp)), 1);

                        int row = TSRushing.Rows.Count;
                        TSRushing.Rows.Add(1);
                        TSRushing.Rows[row].Cells[0].Value = player;
                        TSRushing.Rows[row].Cells[1].Value = gp;
                        TSRushing.Rows[row].Cells[2].Value = att;
                        TSRushing.Rows[row].Cells[3].Value = yds;
                        TSRushing.Rows[row].Cells[4].Value = td;
                        TSRushing.Rows[row].Cells[5].Value = ypc;
                        TSRushing.Rows[row].Cells[6].Value = ypg;
                        TSRushing.Rows[row].Cells[7].Value = fum;
                        TSRushing.Rows[row].Cells[8].Value = yai;
                        TSRushing.Rows[row].Cells[9].Value = btk;
                        TSRushing.Rows[row].Cells[10].Value = twenty;
                    }
                }
            }

            TSRushing.Sort(TSRushYds, System.ComponentModel.ListSortDirection.Descending);
            TSRushing.ClearSelection();
        }

        private void LoadReceivingStats(int year, int pgidStart, int pgidEnd)
        {
            TSReceiving.Rows.Clear();

            for (int i = 0; i < GetTableRecCount("PSOF"); i++)
            {
                if (GetDBValueInt("PSOF", "SEYR", i) == year && GetDBValueInt("PSOF", "PGID", i) >= pgidStart && GetDBValueInt("PSOF", "PGID", i) <= pgidEnd && GetDBValueInt("PSOF", "scca", i) > 0)
                {
                    int gp = GetDBValueInt("PSOF", "sgmp", i);


                    if (gp > 0)
                    {
                        string player = GetPlayerNamefromPGID(GetDBValueInt("PSOF", "PGID", i));

                        int cat = GetDBValueInt("PSOF", "scca", i);
                        int yds = GetDBValueInt("PSOF", "scya", i);
                        int td = GetDBValueInt("PSOF", "sctd", i);
                        int fum = GetDBValueInt("PSOF", "sufu", i);
                        int rac = GetDBValueInt("PSOF", "scyc", i);
                        int drp = GetDBValueInt("PSOF", "scdr", i);

                        double ypc = 0;
                        if (cat > 0) ypc = Math.Round((Convert.ToDouble(yds) / Convert.ToDouble(cat)), 1);

                        double ypg = 0;
                        if (gp > 0) ypg = Math.Round((Convert.ToDouble(yds) / Convert.ToDouble(gp)), 1);

                        double rca = 0;
                        if (cat > 0) ypc = Math.Round((Convert.ToDouble(rac) / Convert.ToDouble(cat)), 1);

                        int row = TSReceiving.Rows.Count;
                        TSReceiving.Rows.Add(1);
                        TSReceiving.Rows[row].Cells[0].Value = player;
                        TSReceiving.Rows[row].Cells[1].Value = gp;
                        TSReceiving.Rows[row].Cells[2].Value = cat;
                        TSReceiving.Rows[row].Cells[3].Value = yds;
                        TSReceiving.Rows[row].Cells[4].Value = td;
                        TSReceiving.Rows[row].Cells[5].Value = ypc;
                        TSReceiving.Rows[row].Cells[6].Value = ypg;
                        TSReceiving.Rows[row].Cells[7].Value = fum;
                        TSReceiving.Rows[row].Cells[8].Value = rac;
                        TSReceiving.Rows[row].Cells[9].Value = rca;
                        TSReceiving.Rows[row].Cells[10].Value = drp;
                    }
                }
            }

            TSReceiving.Sort(TSCatch, System.ComponentModel.ListSortDirection.Descending);
            TSReceiving.ClearSelection();
        }


        private void LoadDefenseStats(int year, int pgidStart, int pgidEnd)
        {
            TSDefense.Rows.Clear();

            for (int i = 0; i < GetTableRecCount("PSDE"); i++)
            {
                if (GetDBValueInt("PSDE", "SEYR", i) == year && GetDBValueInt("PSDE", "PGID", i) >= pgidStart && GetDBValueInt("PSDE", "PGID", i) <= pgidEnd && GetDBValueInt("PSDE", "sgmp", i) > 0)
                {
                    int gp = GetDBValueInt("PSDE", "sgmp", i);

                    if (gp > 0)
                    {
                        string player = GetPlayerNamefromPGID(GetDBValueInt("PSDE", "PGID", i));

                        int tak = GetDBValueInt("PSDE", "sdta", i);
                        int tfl = GetDBValueInt("PSDE", "sdtl", i);
                        int sack = GetDBValueInt("PSDE", "slsk", i);
                        int ints = GetDBValueInt("PSDE", "ssin", i);
                        int pdef = GetDBValueInt("PSDE", "sdpd", i);
                        int ffum = GetDBValueInt("PSDE", "slff", i);
                        int fumr = GetDBValueInt("PSDE", "slfr", i);
                        int defTD = GetDBValueInt("PSDE", "ssdt", i);

                        int row = TSDefense.Rows.Count;
                        TSDefense.Rows.Add(1);
                        TSDefense.Rows[row].Cells[0].Value = player;
                        TSDefense.Rows[row].Cells[1].Value = gp;
                        TSDefense.Rows[row].Cells[2].Value = tak;
                        TSDefense.Rows[row].Cells[3].Value = tfl;
                        TSDefense.Rows[row].Cells[4].Value = sack;
                        TSDefense.Rows[row].Cells[5].Value = ints;
                        TSDefense.Rows[row].Cells[6].Value = pdef;
                        TSDefense.Rows[row].Cells[7].Value = ffum;
                        TSDefense.Rows[row].Cells[8].Value = fumr;
                        TSDefense.Rows[row].Cells[9].Value = defTD;
                    }
                }
            }

            TSDefense.Sort(TSTackles, System.ComponentModel.ListSortDirection.Descending);
            TSDefense.ClearSelection();
        }



        private void LoadKickingStats(int year, int pgidStart, int pgidEnd)
        {
            TSKicking.Rows.Clear();

            for (int i = 0; i < GetTableRecCount("PSKI"); i++)
            {
                if (GetDBValueInt("PSKI", "SEYR", i) == year && GetDBValueInt("PSKI", "PGID", i) >= pgidStart && GetDBValueInt("PSKI", "PGID", i) <= pgidEnd && GetDBValueInt("PSKI", "skfa", i) > 0)
                {
                    int gp = GetDBValueInt("PSKI", "sgmp", i);

                    if (gp > 0)
                    {
                        string player = GetPlayerNamefromPGID(GetDBValueInt("PSKI", "PGID", i));

                        int fgm = GetDBValueInt("PSKI", "skfm", i);
                        int fga = GetDBValueInt("PSKI", "skfa", i);
                        int longest = GetDBValueInt("PSKI", "skfL", i);
                        int xpm = GetDBValueInt("PSKI", "skem", i);
                        int xpa = GetDBValueInt("PSKI", "skea", i);
                        int fourty = GetDBValueInt("PSKI", "", i);

                        double fgpct = 0;
                        if (fga > 0) fgpct = Math.Round((Convert.ToDouble(fgm) / Convert.ToDouble(fga)) * 100, 1);

                        double xppct = 0;
                        if (xpa > 0) xppct = Math.Round((Convert.ToDouble(xpm) / Convert.ToDouble(xpa)) * 100, 1);

                        int row = TSKicking.Rows.Count;
                        TSKicking.Rows.Add(1);
                        TSKicking.Rows[row].Cells[0].Value = player;
                        TSKicking.Rows[row].Cells[1].Value = gp;
                        TSKicking.Rows[row].Cells[2].Value = fgm;
                        TSKicking.Rows[row].Cells[3].Value = fga;
                        TSKicking.Rows[row].Cells[4].Value = fgpct;
                        TSKicking.Rows[row].Cells[5].Value = longest;
                        TSKicking.Rows[row].Cells[6].Value = xpm;
                        TSKicking.Rows[row].Cells[7].Value = xpa;
                        TSKicking.Rows[row].Cells[8].Value = xppct;
                        TSKicking.Rows[row].Cells[9].Value = fourty;
                    }
                }
            }

            TSKicking.Sort(TSFGM, System.ComponentModel.ListSortDirection.Descending);
            TSKicking.ClearSelection();
        }

        private void LoadPuntingStats(int year, int pgidStart, int pgidEnd)
        {
            TSPunting.Rows.Clear();

            for (int i = 0; i < GetTableRecCount("PSKI"); i++)
            {
                if (GetDBValueInt("PSKI", "SEYR", i) == year && GetDBValueInt("PSKI", "PGID", i) >= pgidStart && GetDBValueInt("PSKI", "PGID", i) <= pgidEnd && GetDBValueInt("PSKI", "spat", i) > 0)
                {
                    int gp = GetDBValueInt("PSKI", "sgmp", i);

                    if (gp > 0)
                    {
                        string player = GetPlayerNamefromPGID(GetDBValueInt("PSKI", "PGID", i));

                        int punt = GetDBValueInt("PSKI", "spat", i);
                        int yd = GetDBValueInt("PSKI", "spya", i);
                        int longest = GetDBValueInt("PSKI", "splN", i);
                        int intwenty = GetDBValueInt("PSKI", "sppt", i);
                        int blocked = GetDBValueInt("PSKI", "spbl", i);


                        double puntavg = 0;
                        if (punt > 0) puntavg = Math.Round((Convert.ToDouble(yd) / Convert.ToDouble(punt)), 1);

                        int row = TSPunting.Rows.Count;
                        TSPunting.Rows.Add(1);
                        TSPunting.Rows[row].Cells[0].Value = player;
                        TSPunting.Rows[row].Cells[1].Value = gp;
                        TSPunting.Rows[row].Cells[2].Value = punt;
                        TSPunting.Rows[row].Cells[3].Value = yd;
                        TSPunting.Rows[row].Cells[4].Value = puntavg;
                        TSPunting.Rows[row].Cells[5].Value = longest;
                        TSPunting.Rows[row].Cells[6].Value = intwenty;
                        TSPunting.Rows[row].Cells[7].Value = blocked;
                    }
                }
            }

            TSPunting.Sort(TSPunts, System.ComponentModel.ListSortDirection.Descending);
            TSPunting.ClearSelection();
        }



        private void LoadReturnsStats(int year, int pgidStart, int pgidEnd)
        {
            TSReturn.Rows.Clear();

            for (int i = 0; i < GetTableRecCount("PSKP"); i++)
            {
                if (GetDBValueInt("PSKP", "SEYR", i) == year && GetDBValueInt("PSKP", "PGID", i) >= pgidStart && GetDBValueInt("PSKP", "PGID", i) <= pgidEnd && GetDBValueInt("PSKP", "sgmp", i) > 0)
                {
                    int gp = GetDBValueInt("PSKP", "sgmp", i);


                    if (gp > 0)
                    {
                        string player = GetPlayerNamefromPGID(GetDBValueInt("PSKP", "PGID", i));

                        int KRAtt = GetDBValueInt("PSKP", "srka", i);
                        int KRYds = GetDBValueInt("PSKP", "srky", i);
                        int KRTD = GetDBValueInt("PSKP", "srkt", i);
                        int KRLong = GetDBValueInt("PSKP", "srkL", i);
                        int PRAtt = GetDBValueInt("PSKP", "srpa", i);
                        int PRYds = GetDBValueInt("PSKP", "srpy", i);
                        int PRTD = GetDBValueInt("PSKP", "srpt", i);
                        int PRLong = GetDBValueInt("PSKP", "srpL", i);

                        int row = TSReturn.Rows.Count;
                        TSReturn.Rows.Add(1);
                        TSReturn.Rows[row].Cells[0].Value = player;
                        TSReturn.Rows[row].Cells[1].Value = gp;
                        TSReturn.Rows[row].Cells[2].Value = KRAtt;
                        TSReturn.Rows[row].Cells[3].Value = KRYds;
                        TSReturn.Rows[row].Cells[4].Value = KRTD;
                        TSReturn.Rows[row].Cells[5].Value = KRLong;
                        TSReturn.Rows[row].Cells[6].Value = PRAtt;
                        TSReturn.Rows[row].Cells[7].Value = PRYds;
                        TSReturn.Rows[row].Cells[8].Value = PRTD;
                        TSReturn.Rows[row].Cells[9].Value = PRLong;
                    }
                }
            }

            TSReturn.Sort(TSKRYd, System.ComponentModel.ListSortDirection.Descending);
            TSReturn.ClearSelection();
        }

    }

}
