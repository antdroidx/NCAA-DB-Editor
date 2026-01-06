using System.Collections.Generic;
using System.Net.Sockets;

namespace DB_EDITOR
{
    public partial class PortalBox : Form
    {
        MainEditor main;

        int tgid;
        int p;
        int newPGID;
        List<int> PortalInterestList;
        List<List<int>> SpringPortal;

        public PortalBox(MainEditor main, List<List<int>> SpringPortal, List<int> PortalInterestList, int p, int tgid, int newPGID)
        {
            InitializeComponent();
            this.main = main;
            this.tgid = tgid;
            this.p = p;
            this.newPGID = newPGID;
            this.PortalInterestList = PortalInterestList;
            this.SpringPortal = SpringPortal;

            LoadPortalBox();
        }

        /* Spring Portal List
         *  0: PLAY Record
         *  1: RCPT Record
         *  2: PGID / PRID
         *  3: PPOS
         *  4: POVR
         *  5: TGID
         *  6: PYER
         *  7: Adjusted OVR
         *  8: PJEN
         *  9: TRAN Status
         *  10: RS
         *  11: DISC
         *  12: Is Starter
         *  13: POE
         */

        private void LoadPortalBox()
        {
            portalDraftView.Rows.Clear();
            lblPositionName.Text = "Position: " + main.GetPOSG2Name(p);

            for (int i = 0; i < PortalInterestList.Count; i++)
            {
                int x = PortalInterestList[i];
                int pRec = SpringPortal[x][0];

                int team = SpringPortal[x][5];
                int year = SpringPortal[x][6];
                int redshirt = SpringPortal[x][10];
                int povr = main.ConvertRating(SpringPortal[x][4]);

                int height = main.GetDBValueInt("PLAY", "PHGT", pRec);
                int feet = height / 12;
                int inches = height % 12;
                string heightStr = feet + "'" + inches + "\"";
                int weight = main.GetDBValueInt("PLAY", "PWGT", pRec) + 160;
                int pos = SpringPortal[x][3];
                string posg = main.GetPOSG2Name(pos);
                int starter = SpringPortal[x][12];

                string playerName = main.GetPlayerNamefromRec(pRec);
                if (starter > 0) playerName += "*";

                portalDraftView.Rows.Add();
                portalDraftView.Rows[i].Cells[0].Value = playerName;
                portalDraftView.Rows[i].Cells[1].Value = main.GetTeamName(team);
                portalDraftView.Rows[i].Cells[2].Value = main.GetClassYearsAbbr(year, redshirt);
                portalDraftView.Rows[i].Cells[3].Value = povr;
                portalDraftView.Rows[i].Cells[4].Value = heightStr;
                portalDraftView.Rows[i].Cells[5].Value = weight;
                portalDraftView.Rows[i].Cells[6].Value = posg;

            }

            foreach (var player in main.SpringRoster[tgid])
            {
                if (main.GetPOSG2Name(player[3]) == main.GetPOSG2Name(p / 2))
                {
                    int pRec = player[0];
                    int rRec = player[1];
                    int team, year, redshirt, povr, height, feet, inches, weight, pos;
                    string heightStr = "";
                    string playerName = "";
                    string posg = "";

                    if (pRec >= 0)
                    {
                        team = player[5];
                        year = player[6];
                        redshirt = player[10];
                        povr = main.ConvertRating(player[4]);
                        height = main.GetDBValueInt("PLAY", "PHGT", pRec);
                        feet = height / 12;
                        inches = height % 12;
                        heightStr = feet + "'" + inches + "\"";
                        weight = main.GetDBValueInt("PLAY", "PWGT", pRec) + 160;
                        pos = player[3];
                        posg = main.GetPOSG2Name(pos);
                        playerName = main.GetPlayerNamefromRec(pRec);
                    }
                    else
                    {
                        team = player[5];
                        year = player[6];
                        redshirt = player[10];
                        povr = main.ConvertRating(player[4]);
                        height = main.GetDB2ValueInt("RCPT", "PHGT", rRec);
                        feet = height / 12;
                        inches = height % 12;
                        heightStr = feet + "'" + inches + "\"";
                        weight = main.GetDB2ValueInt("RCPT", "PWGT", rRec) + 160;
                        pos = player[3];
                        posg = main.GetPOSG2Name(pos);
                        playerName = main.GetDB2Value("RCPT", "PFNA", rRec) + " " + main.GetDB2Value("RCPT", "PLNA", rRec);
                    }



                    int i = currentRosterView.Rows.Count;
                    currentRosterView.Rows.Add();
                    currentRosterView.Rows[i].Cells[0].Value = playerName;
                    currentRosterView.Rows[i].Cells[1].Value = main.GetTeamName(team);
                    currentRosterView.Rows[i].Cells[2].Value = main.GetClassYearsAbbr(year, redshirt);
                    currentRosterView.Rows[i].Cells[3].Value = povr;
                    currentRosterView.Rows[i].Cells[4].Value = heightStr;
                    currentRosterView.Rows[i].Cells[5].Value = weight;
                    currentRosterView.Rows[i].Cells[6].Value = posg;

                }


            }

        }

        private void btnOffer_Click(object sender, EventArgs e)
        {
            //Send the selection data to Main
            //TransferPlayer(int tgid, int p, ref List < List<string> > portalNews, int newPGID, int portalRec);
            int selection = portalDraftView.SelectedCells[0].RowIndex;

            if (selection >= 0)
            {
                //int selection = portalDraftView.SelectedRows[0].Index;
                int portalRec = PortalInterestList[selection];
                main.TransferPlayer(tgid, p, newPGID, portalRec);
                Close();
            }
            else
            {
                MessageBox.Show("No player was selected. Please select a player.");
            }

        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
