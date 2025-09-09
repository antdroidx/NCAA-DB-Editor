using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
//// using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {



        //Coaching Carousel -- Must be done at end of Season
        private void ButtonCarousel_Click(object sender, EventArgs e)
        {
            CarouselDataGrid.Rows.Clear();
            CoachCarousel();
        }


        //Coaching Carousel Mod
        private void CoachCarousel()
        {
            int coachfirings = 0;
            if (!coachProgComplete && !NextMod && !Next26Mod)
            {
                MessageBox.Show("Please run Coaching Progressions first before running this module.");
                return;
            }
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount("COCH");

            List<string> CCID_FAList = new List<string>();
            List<string> CCID_FiredList = new List<string>();
            List<string> CCID_PromoteList = new List<string>();
            List<string> TGID_VacancyList = new List<string>();
            List<List<string>> coachNews = new List<List<string>>();

            //Get List of Coaches and Fire Some
            for (int i = 0; i < GetTableRecCount("COCH"); i++)
            {
                //ADD COACHING FREE AGENCY POOL TO THE LIST
                if (GetDBValue("COCH", "TGID", i) == "511")
                {
                    CCID_FAList.Add(GetDBValue("COCH", "CCID", i));
                    ChangeDBInt("COCH", "CCPO", i, 60);
                }
                else
                {
                    string TGID = GetDBValue("COCH", "TGID", i);
                    int CTOP = Convert.ToInt32(GetDBValue("COCH", "CTOP", i));
                    int TMPR = FindTeamPrestige(Convert.ToInt32(TGID));
                    int CCPO = Convert.ToInt32(GetDBValue("COCH", "CCPO", i));

                    //FIRE COACHES
                    if (CCPO <= jobSecurityValue.Value && CTOP >= TMPR && GetDBValue("COCH", "CFUC", i) != "1" && rand.Next(0, 100) < 70 && NextMod || CCPO <= jobSecurityValue.Value && CTOP >= TMPR && GetDBValue("COCH", "CFUC", i) != "1" && rand.Next(0, 100) < 70 && Next26Mod || GetDBValueInt("COCH", "CTYR", i) > 3 && TMPR < 2 && rand.Next(0, 100) < 70 || CCPO <= jobSecurityValue.Value && CTOP-2 >= TMPR && GetDBValue("COCH", "CFUC", i) != "1" && rand.Next(0, 100) < 70 && !NextMod || CCPO <= jobSecurityValue.Value && CTOP - 2 >= TMPR && GetDBValue("COCH", "CFUC", i) != "1" && rand.Next(0, 100) < 70 && !Next26Mod)
                    {
                        CCID_FiredList.Add(GetDBValue("COCH", "CCID", i));
                        TGID_VacancyList.Add(GetDBValue("COCH", "TGID", i));


                        string coachFN = GetDBValue("COCH", "CLFN", i);
                        string coachLN = GetDBValue("COCH", "CLLN", i);
                        string teamID = GetTeamName(Convert.ToInt32(GetDBValue("COCH", "TGID", i)));


                        if (checkBoxFiredTransfers.Checked) CoachTransferPortal(Convert.ToInt32(GetDBValue("COCH", "TGID", i)), false);

                        int newCounter = coachNews.Count;
                        coachNews.Add(new List<string>());
                        coachNews[newCounter].Add(coachFN + " " + coachLN);
                        coachNews[newCounter].Add("Fired");
                        coachNews[newCounter].Add(teamID);
                        coachNews[newCounter].Add(Convert.ToString(TMPR));
                        coachNews[newCounter].Add(GetDBValue("COCH", "CPRS", i));
                        coachNews[newCounter].Add(GetDBValue("COCH", "CCWI", i) + "-" + GetDBValue("COCH","CCLO", i));

                        ChangeDBString("COCH", "CCPO", i, "60");
                        ChangeDBString("COCH", "CTYR", i, "0");
                        ChangeDBString("COCH", "TGID", i, "511");

                        CCID_FAList.Add(GetDBValue("COCH", "CCID", i));
                        coachfirings++;

                    }
                    //ADD COACHES TO CANDIDATE LIST
                    else if (CCPO > 89 && CTOP < TMPR && GetDBValue("COCH", "CFUC", i) != "1")
                    {
                        CCID_PromoteList.Add(GetDBValue("COCH", "CCID", i));
                    }
                }
                progressBar1.PerformStep();
            }

            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TGID_VacancyList.Count;

            //HIRE NEW COACHES
            while (TGID_VacancyList.Count > 0)
            {
                int TGID = Convert.ToInt32(TGID_VacancyList[0]);
                int TMPR = FindTeamPrestige(TGID);
                bool hired = false;
                int downgrade = 0;
                int counter = 0;

                while (!hired)
                {
                    if (rand.Next(0, 100) > (int)poachValue.Value && CCID_FAList.Count > 0)
                    {
                        int r = rand.Next(CCID_FAList.Count);
                        int CCID = Convert.ToInt32(CCID_FAList[r]);

                        int x = FindRecNumberCCID(CCID);
                        if (x == -1) MessageBox.Show("ERROR");

                        int CPRS = Convert.ToInt32(GetDBValue("COCH", "CPRE", x));
                        if (CPRS >= TMPR - downgrade)
                        {

                            ChangeDBString("COCH", "TGID", x, Convert.ToString(TGID));
                            ChangeDBString("COCH", "CCPO", x, "60");
                            ChangeDBString("COCH", "CTYR", x, "0");


                            string coachFN = GetDBValue("COCH", "CLFN", x);
                            string coachLN = GetDBValue("COCH", "CLLN", x);
                            string teamID = GetTeamName(Convert.ToInt32(GetDBValue("COCH", "TGID", x)));

                            int newCounter = coachNews.Count;
                            coachNews.Add(new List<string>());
                            coachNews[newCounter].Add(coachFN + " " + coachLN);
                            coachNews[newCounter].Add("Hired");
                            coachNews[newCounter].Add(teamID);
                            coachNews[newCounter].Add(Convert.ToString(TMPR));
                            coachNews[newCounter].Add(Convert.ToString(CPRS));
                            coachNews[newCounter].Add(GetDBValue("COCH", "CCWI", x) + "-" + GetDBValue("COCH", "CCLO", x));

                            CCID_FAList.RemoveAt(r);
                            TGID_VacancyList.RemoveAt(0);
                            hired = true;

                        }

                    }
                    else if (CCID_PromoteList.Count > 0 && (int)poachValue.Value != 0)
                    {
                        int r = rand.Next(CCID_PromoteList.Count);
                        int CCID = Convert.ToInt32(CCID_PromoteList[r]);

                        int x = FindRecNumberCCID(CCID);
                        if (x == -1) MessageBox.Show("ERROR");


                        int currentTGID = GetDBValueInt("COCH", "TGID", x);
                        int currentTMPR = FindTeamPrestige(currentTGID);

                        if (currentTMPR < TMPR)
                        {
                            ChangeDBInt("COCH", "TGID", x, TGID);
                            ChangeDBString("COCH", "CCPO", x, "60");
                            ChangeDBString("COCH", "CTYR", x, "0");


                            string coachFN = GetDBValue("COCH", "CLFN", x);
                            string coachLN = GetDBValue("COCH", "CLLN", x);
                            string teamID = GetTeamName(GetDBValueInt("COCH", "TGID", x));
                            string oldTeamID = GetTeamName(currentTGID);

                            if (checkBoxFiredTransfers.Checked)
                            {
                                CoachTransferPortal(currentTGID, true);
                            }

                            int newCounter = coachNews.Count;
                            coachNews.Add(new List<string>());
                            coachNews[newCounter].Add(coachFN + " " + coachLN);
                            coachNews[newCounter].Add("Hired\nfrom " + oldTeamID);
                            coachNews[newCounter].Add(teamID);
                            coachNews[newCounter].Add(Convert.ToString(TMPR));
                            coachNews[newCounter].Add(GetDBValue("COCH", "CPRS", x));
                            coachNews[newCounter].Add(GetDBValue("COCH", "CCWI", x) + "-" + GetDBValue("COCH", "CCLO", x));

                            CCID_PromoteList.RemoveAt(r);
                            TGID_VacancyList.RemoveAt(0);
                            TGID_VacancyList.Add(Convert.ToString(currentTGID));
                            hired = true;
                        }
                    }

                    if (counter % 50 == 0) downgrade++;
                    counter++;
                }

                TGID_VacancyList.OrderBy(z => z).ToList();
                progressBar1.PerformStep();
            }

            DisplayCarouselNews(coachNews);
            CoachFiringsCount.Text = "Coach Firings: " + Convert.ToString(coachfirings);

            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        //Opens a Transfer Portal for Coach Firings
        private void CoachTransferPortal(int teamRec, bool poached)
        {
            /*
             *  Coach Transfer Portal
             *  Since this is done before off-season, we need to evaluate whether the player will graduate and if they will go Pro anyway. 
             *  
             */

            int maxTransfers = 1800;
            int currentRecCount = GetTableRecCount("TRAN");

            if (currentRecCount > maxTransfers) return;

            string transferNews = "";
            int xfers = (int)maxFiredTransfers.Value;


            int[,] players = GetTeamPlayersList(teamRec);

            for (int k = 0; k < xfers; k++)
            {
                if (currentRecCount >= maxTransfers) break;

                if (rand.Next(1, 100) < 66 && currentRecCount < maxTransfers)
                {
                    int xfer = rand.Next(0, 70);
                    int tgid = teamRec;

                    if (players[xfer, 0] != 0 && GetPTYPfromRecord(players[xfer, 0]) == 0)
                    {
                        TransferPlayer(players[xfer, 0], players[xfer, 1]);

                        transferNews += GetPositionName(GetPPOSfromRecord(players[xfer, 3])) + " " + GetFirstNameFromRecord(players[xfer, 0]) + " " + GetLastNameFromRecord(players[xfer, 0]) + " (" + GetTeamName(tgid) + ") OVR: " + ConvertRating(players[xfer, 2]) + "\n";

                        currentRecCount++;
                    }
                }
            }
            if (poached)
            {
                MessageBox.Show(transferNews, GetTeamName(teamRec) + "'s Coach Hired: TRANSFER PORTAL NEWS");
            }
            else
            {
                MessageBox.Show(transferNews, GetTeamName(teamRec) + "'s Coach Fired: TRANSFER PORTAL NEWS");

            }

        }

        //Get a list of Players for the Coaching Portal
        private int[,] GetTeamPlayersList(int tgid)
        {
            int[,] list = new int[70, 4];

            int pgidStart = tgid * 70;
            int j = 0;

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (GetPGIDfromRecord(i) >= pgidStart && GetPGIDfromRecord(i) < pgidStart + 70 && GetPTYPfromRecord(i) != 3 && GetPTYPfromRecord(i) != 1 && GetPYERfromRecord(i) < 3 && GetPOVRfromRecord(i) < 25)
                {
                    list[j, 0] = i;
                    list[j, 1] = GetPGIDfromRecord(i);
                    list[j, 2] = GetPOVRfromRecord(i);
                    list[j, 3] = GetPPOSfromRecord(i);
                    j++;
                }
            }

            return list;
        }

        //Get a list of Players by Team at a specific Position for Chaos Transfers
        private int[,] GetPGIDPositionList(int tgid, int pos)
        {
            int[,] list = new int[15, 3];  // record id, pgid, povr

            int pgidStart = tgid * 70;
            int j = 0;

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (GetPGIDfromRecord(i) >= pgidStart && GetPGIDfromRecord(i) < pgidStart + 70 && GetPPOSfromRecord(i) == pos && GetPTYPfromRecord(i) != 3 && GetPTYPfromRecord(i) != 1)
                {
                    list[j, 0] = i;
                    list[j, 1] = GetPGIDfromRecord(i);
                    list[j, 2] = GetPOVRfromRecord(i);
                    j++;
                }
            }

            return list;
        }

        //Transfers Players - Updates TRAN table and sets PLAY-PTYP field to 1
        private void TransferPlayer(int i, int PGID)
        {
            if (NextConfigRadio.Checked)
            {
                int row = GetTableRecCount("TRAN");
                AddTableRecord("TRAN", false);
                ChangeDBString("TRAN", "PGID", row, Convert.ToString(PGID));
                ChangeDBString("TRAN", "PTID", row, "300");
                ChangeDBString("TRAN", "TRYR", row, "0");
                ChangeDBString("PLAY", "PTYP", i, "1");
            }
            else
            {
                ChangeDBString("PLAY", "PTYP", i, "1");

            }
        }

        private void DisplayCarouselNews(List<List<string>> portalList2)
        {
            CarouselDataGrid.ClearSelection();
            CarouselDataGrid.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            for (int x = 0; x < portalList2.Count; x++)
            {
                CarouselDataGrid.Rows.Add(new DataGridViewRow());

                CarouselDataGrid.Rows[x].Cells[0].Value = portalList2[x][0];
                CarouselDataGrid.Rows[x].Cells[1].Value = portalList2[x][1];
                CarouselDataGrid.Rows[x].Cells[2].Value = portalList2[x][2];
                CarouselDataGrid.Rows[x].Cells[3].Value = portalList2[x][3];
                CarouselDataGrid.Rows[x].Cells[4].Value = portalList2[x][4];
                CarouselDataGrid.Rows[x].Cells[5].Value = portalList2[x][5];
            }
        }



    }

}
