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
        private void buttonCarousel_Click(object sender, EventArgs e)
        {
            CarouselDataGrid.Rows.Clear();
            CoachPortalNews.Rows.Clear();
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

            StartProgressBar(GetTableRecCount("COCH"));

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
                    if (CCPO <= jobSecurityValue.Value && CTOP >= TMPR && GetDBValue("COCH", "CFUC", i) != "1" && rand.Next(0, 100) < 70 && NextMod || CCPO <= jobSecurityValue.Value && CTOP >= TMPR && GetDBValue("COCH", "CFUC", i) != "1" && rand.Next(0, 100) < 70 && Next26Mod || GetDBValueInt("COCH", "CTYR", i) > 3 && TMPR < 2 && rand.Next(0, 100) < 70 && GetDBValueInt("COCH", "CCPO", i) < LowPrestigeCoachValue.Value || CCPO <= jobSecurityValue.Value && CTOP-2 >= TMPR && GetDBValue("COCH", "CFUC", i) != "1" && rand.Next(0, 100) < 70 && !NextMod || CCPO <= jobSecurityValue.Value && CTOP - 2 >= TMPR && GetDBValue("COCH", "CFUC", i) != "1" && rand.Next(0, 100) < 70 && !Next26Mod)
                    {
                        CCID_FiredList.Add(GetDBValue("COCH", "CCID", i));
                        TGID_VacancyList.Add(GetDBValue("COCH", "TGID", i));


                        string coachFN = GetDBValue("COCH", "CLFN", i);
                        string coachLN = GetDBValue("COCH", "CLLN", i);
                        string teamID = GetTeamName(Convert.ToInt32(GetDBValue("COCH", "TGID", i)));


                        if (checkBoxFiredTransfers.Checked) CoachTransferPortal(Convert.ToInt32(GetDBValue("COCH", "TGID", i)));

                        int newCounter = coachNews.Count;
                        coachNews.Add(new List<string>());
                        coachNews[newCounter].Add(coachFN + " " + coachLN);
                        coachNews[newCounter].Add("Fired");
                        coachNews[newCounter].Add(teamID);
                        coachNews[newCounter].Add(Convert.ToString(TMPR));
                        coachNews[newCounter].Add(GetDBValue("COCH", "CPRE", i));
                        coachNews[newCounter].Add(GetDBValue("COCH", "CCWI", i) + "-" + GetDBValue("COCH","CCLO", i));
                        coachNews[newCounter].Add(GetDBValue("COCH", "CSWI", i) + "-" + GetDBValue("COCH", "CSLO", i));
                        coachNews[newCounter].Add(GetDBValue("COCH", "CCPO", i));


                        ChangeDBString("COCH", "CCPO", i, "60");
                        ChangeDBString("COCH", "CTYR", i, "0");
                        ChangeDBString("COCH", "TGID", i, "511");

                        CCID_FAList.Add(GetDBValue("COCH", "CCID", i));
                        coachfirings++;

                    }
                    //ADD COACHES TO CANDIDATE LIST
                    else if (CCPO > 89 && CTOP < TMPR && GetDBValueInt("COCH", "CFUC", i) != 1 && GetDBValueInt("COCH", "CSWI", i) >= 8)
                    {
                        CCID_PromoteList.Add(GetDBValue("COCH", "CCID", i));
                    }
                }
                ProgressBarStep();
            }

            StartProgressBar(TGID_VacancyList.Count);

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
                            coachNews[newCounter].Add("N/A");
                            coachNews[newCounter].Add(GetDBValue("COCH", "CCPO", x));

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
                                CoachTransferPortal(currentTGID);
                            }

                            int newCounter = coachNews.Count;
                            coachNews.Add(new List<string>());
                            coachNews[newCounter].Add(coachFN + " " + coachLN);
                            coachNews[newCounter].Add("Hired\nfrom " + oldTeamID);
                            coachNews[newCounter].Add(teamID);
                            coachNews[newCounter].Add(Convert.ToString(TMPR));
                            coachNews[newCounter].Add(GetDBValue("COCH", "CPRE", x));
                            coachNews[newCounter].Add(GetDBValue("COCH", "CCWI", x) + "-" + GetDBValue("COCH", "CCLO", x));
                            coachNews[newCounter].Add(GetDBValue("COCH", "CSWI", x) + "-" + GetDBValue("COCH", "CSLO", x));
                            coachNews[newCounter].Add(GetDBValue("COCH", "CCPO", x));

                            CCID_PromoteList.RemoveAt(r);
                            TGID_VacancyList.RemoveAt(0);
                            TGID_VacancyList.Add(Convert.ToString(currentTGID));
                            hired = true;
                        }
                    }

                    if (counter / 50 >= 1)
                    {
                        downgrade++;
                        counter = 0;
                    }
                    else
                    {
                        counter++;
                    }

                }

                TGID_VacancyList.OrderBy(z => z).ToList();
                ProgressBarStep();
            }

            DisplayCarouselNews(coachNews);
            CoachFiringsCount.Text = "Coach Firings: " + Convert.ToString(coachfirings);

            EndProgressBar();
        }

        //Opens a Transfer Portal for Coach Firings
        private void CoachTransferPortal(int TGID)
        {
            /*
             *  Coach Transfer Portal
             *  Since this is done before off-season, we need to evaluate whether the player will graduate and if they will go Pro anyway. 
             *  
             */

            List<List<string>> TransferNews = new List<List<string>>();
            int maxTransfers = 1800;
            int currentRecCount = GetTableRecCount("TRAN");

            if (currentRecCount > maxTransfers) return;

            int xfers = (int)maxFiredTransfers.Value;
            int[,] players = GetTeamPlayersList(TGID);

            for (int k = 0; k < xfers; k++)
            {
                if (currentRecCount >= maxTransfers) break;

                if (rand.Next(1, 100) < 65 && currentRecCount < maxTransfers)
                {
                    int xfer = rand.Next(0, 70);
                    int tgid = TGID;

                    if (players[xfer, 0] != 0 && GetPTYPfromRecord(players[xfer, 0]) == 0)
                    {
                        TransferPlayer(players[xfer, 0], players[xfer, 1]);

                        int row = TransferNews.Count;
                        TransferNews.Add(new List<string>());
                        TransferNews[row].Add(GetTeamName(tgid));
                        TransferNews[row].Add(GetFirstNameFromRecord(players[xfer, 0]) + " " + GetLastNameFromRecord(players[xfer, 0]));
                        TransferNews[row].Add(GetPositionName(players[xfer, 3]));
                        TransferNews[row].Add( Convert.ToString(ConvertRating(players[xfer, 2])));

                        currentRecCount++;
                    }
                }
            }

            DisplayCoachPortalNews(TransferNews);

        }

        //Get a list of Players for the Coaching Portal
        private int[,] GetTeamPlayersList(int tgid)
        {
            int[,] list = new int[70, 4];

            int pgidStart = tgid * 70;
            int j = 0;

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (GetPGIDfromRecord(i) >= pgidStart && GetPGIDfromRecord(i) < pgidStart + 70 && GetPTYPfromRecord(i) != 3 && GetPTYPfromRecord(i) != 1 && GetPYERfromRecord(i) < 3)
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

        private void DisplayCarouselNews(List<List<string>> CoachNews)
        {
            CarouselDataGrid.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            for (int x = 0; x < CoachNews.Count; x++)
            {
                CarouselDataGrid.Rows.Add(new DataGridViewRow());

                CarouselDataGrid.Rows[x].Cells[0].Value = CoachNews[x][0];
                CarouselDataGrid.Rows[x].Cells[1].Value = CoachNews[x][1];
                CarouselDataGrid.Rows[x].Cells[2].Value = CoachNews[x][2];
                CarouselDataGrid.Rows[x].Cells[3].Value = CoachNews[x][3];
                CarouselDataGrid.Rows[x].Cells[4].Value = CoachNews[x][4];
                CarouselDataGrid.Rows[x].Cells[5].Value = CoachNews[x][5];
                CarouselDataGrid.Rows[x].Cells[6].Value = CoachNews[x][6];
                CarouselDataGrid.Rows[x].Cells[7].Value = CoachNews[x][7];


            }
        }

        private void DisplayCoachPortalNews(List<List<string>> CoachNews)
        {
            CoachPortalNews.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            int prevCount = CoachPortalNews.RowCount;
            for (int x = prevCount; x < prevCount+CoachNews.Count; x++)
            {
                CoachPortalNews.Rows.Add(new DataGridViewRow());
                CoachPortalNews.Rows[x].Cells[0].Value = CoachNews[x - prevCount][0];
                CoachPortalNews.Rows[x].Cells[1].Value = CoachNews[x - prevCount][1];
                CoachPortalNews.Rows[x].Cells[2].Value = CoachNews[x - prevCount][2];
                CoachPortalNews.Rows[x].Cells[3].Value = CoachNews[x - prevCount][3];
            }
        }



        //Graduate to Coaching Mod
        #region Players to Coach Mod


        //Players to Coaches
        private void buttonPlayerCoach_Click(object sender, EventArgs e)
        {
            PlayerToCoach();
        }


        private void PlayerToCoach()
        {

            List<string> CCID_FAList = new List<string>();
            List<int> PGID_List = new List<int>();
            string news = "";

            //Create a list of Free Agent Coach's from COCH

            StartProgressBar(GetTableRecCount("COCH"));

            int minRating = 0;
            while (CCID_FAList.Count < numberPlayerCoach.Value)
            {
                for (int i = 0; i < GetTableRecCount("COCH"); i++)
                {
                    //ADD COACHING FREE AGENCY POOL TO THE LIST
                    if (GetDBValue("COCH", "TGID", i) == "511" && Convert.ToInt32(GetDBValue("COCH", "CPRE", i)) < minRating)
                    {
                        CCID_FAList.Add(GetDBValue("COCH", "CCID", i));
                    }
                    ProgressBarStep();
                }
                minRating++;
            }



            //Create a list of graduating players
            StartProgressBar(GetTableRecCount("PLAY"));

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                //Create a list of Players that are seniors and have high awareness
                if (ConvertRating(GetDBValueInt("PLAY", "PAWR", i)) >= 90 && GetDBValue("PLAY", "PYER", i) == "3")
                {
                    PGID_List.Add(i);
                }
                ProgressBarStep();
            }

            if (PGID_List.Count >= numberPlayerCoach.Value)
            {
                //Randomly pick a FA Coach and replace with Player

                for (int i = 0; i < numberPlayerCoach.Value; i++)
                {
                    int x = rand.Next(0, CCID_FAList.Count);
                    string ccid = CCID_FAList[x];
                    int rec = FindRecNumberCCID(Convert.ToInt32(ccid));


                    string coachFN = GetDBValue("COCH", "CLFN", rec);
                    string coachLN = GetDBValue("COCH", "CLLN", rec);

                    news += "Removed: " + coachFN + " " + coachLN + "\n\n";

                    CCID_FAList.RemoveAt(x);

                    int y = rand.Next(0, PGID_List.Count);
                    int recP = PGID_List[y];

                    string playFN = GetFirstNameFromRecord(recP);
                    string playLN = GetLastNameFromRecord(recP);
                    string team = GetTeamName(Convert.ToInt32(GetDBValue("PLAY", "PGID", recP)) / 70);
                    PGID_List.RemoveAt(y);

                    ChangeDBString("COCH", "CLFN", rec, playFN);
                    ChangeDBString("COCH", "CLLN", rec, playLN);

                    //SKIN COLOR, need to convert to 0, 1, 5

                    int skin = GetDBValueInt("PLAY", "PSKI", recP);
                    if (skin > 3) skin = 5;
                    else if (skin > 0) skin = 2;
                    ChangeDBInt("COCH", "CSKI", rec, skin);

                    ChangeDBInt("COCH", "CHAR", rec, GetDBValueInt("PLAY", "PHCL", recP));

                    ChangeDBInt("COCH", "CBSZ", rec, rand.Next(0, 3));

                    x = rand.Next(0, 5);
                    if (x > 0) x++;
                    ChangeDBInt("COCH", "CThg", rec, x);

                    ChangeDBInt("COCH", "CFEX", rec, rand.Next(0, 4));
                    ChangeDBInt("COCH", "CTgw", rec, rand.Next(0, 2));

                    x = rand.Next(0, 3);
                    if (x == 1) ChangeDBInt("COCH", "CThg", rec, 1);
                    else if (x == 2) ChangeDBInt("COCH", "CThg", rec, 0);

                    ChangeDBInt("COCH", "COHT", rec, x);

                    news += "Added: " + playFN + " " + playLN + " (" + team + ")\n\n";



                    //Clear COCH Stats Data
                    ClearCoachStats(rec);


                    //Calculate COCH PRESTIGE
                    int prestige = Convert.ToInt32(GetDBValue("PLAY", "POVR", recP));

                    if (prestige > 27) prestige = 4;
                    else if (prestige > 24) prestige = 3;
                    else if (prestige > 21) prestige = 2;
                    else prestige = 1;

                    ChangeDBString("COCH", "CPRE", rec, Convert.ToString(prestige));


                    //Determine Coaching Playbook and Strategies
                    int TGID = Convert.ToInt32(GetDBValue("PLAY", "PGID", recP)) / 70;
                    int recCOCH = -1;

                    for (int j = 0; j < GetTableRecCount("COCH"); j++)
                    {
                        if (GetDBValue("COCH", "TGID", j) == Convert.ToString(TGID))
                        {
                            recCOCH = j;
                        }
                    }

                    AssignPlayerCoachStrategies(recCOCH, rec);

                }

                MessageBox.Show(news, "Coaching List Changes");

            }
            else
            {
                MessageBox.Show("Please run this module with lower player settings");
            }


            EndProgressBar();


        }

        private void ClearCoachStats(int rec)
        {
            ChangeDBString("COCH", "CT05", rec, "0");
            ChangeDBString("COCH", "CT15", rec, "0");
            ChangeDBString("COCH", "CT25", rec, "0");
            ChangeDBString("COCH", "CCBB", rec, "0");
            ChangeDBString("COCH", "CFUC", rec, "0");
            ChangeDBString("COCH", "CCWI", rec, "0");
            ChangeDBString("COCH", "CSWI", rec, "0");
            ChangeDBString("COCH", "C25L", rec, "0");
            ChangeDBString("COCH", "CBLL", rec, "0");
            ChangeDBString("COCH", "CCOL", rec, "0");
            ChangeDBString("COCH", "CCRL", rec, "0");
            ChangeDBString("COCH", "CNTL", rec, "0");
            ChangeDBString("COCH", "CRVL", rec, "0");
            ChangeDBString("COCH", "CCWN", rec, "0");
            ChangeDBString("COCH", "CTWN", rec, "0");
            ChangeDBString("COCH", "CCLO", rec, "0");
            ChangeDBString("COCH", "CSLO", rec, "0");
            ChangeDBString("COCH", "CCPO", rec, "60");
            ChangeDBString("COCH", "CTOP", rec, "0");
            ChangeDBString("COCH", "CCTP", rec, "0");
            ChangeDBString("COCH", "CCYR", rec, "0");
            ChangeDBString("COCH", "CTYR", rec, "0");
            ChangeDBString("COCH", "COFS", rec, "0");
            ChangeDBString("COCH", "CCLS", rec, "0");
            ChangeDBString("COCH", "CSLS", rec, "0");
            ChangeDBString("COCH", "CTLS", rec, "0");
            ChangeDBString("COCH", "CCWS", rec, "0");
            ChangeDBString("COCH", "CRWS", rec, "0");
            ChangeDBString("COCH", "CSWS", rec, "0");
            ChangeDBString("COCH", "CCCT", rec, "0");
            ChangeDBString("COCH", "CCNT", rec, "0");
            ChangeDBString("COCH", "CWST", rec, "0");
            ChangeDBString("COCH", "C25W", rec, "0");
            ChangeDBString("COCH", "CBLW", rec, "0");
            ChangeDBString("COCH", "CCRW", rec, "0");
            ChangeDBString("COCH", "CCSW", rec, "0");
            ChangeDBString("COCH", "CCTW", rec, "0");
            ChangeDBString("COCH", "CNTW", rec, "0");
            ChangeDBString("COCH", "CRTW", rec, "0");
            ChangeDBString("COCH", "CTTW", rec, "0");
            ChangeDBString("COCH", "CNVW", rec, "0");
            ChangeDBString("COCH", "CRVW", rec, "0");
            ChangeDBString("COCH", "CCFY", rec, "0");
            ChangeDBString("COCH", "COTY", rec, "0");

        }

        private void AssignPlayerCoachStrategies(int recCOCH, int rec)
        {
            ChangeDBString("COCH", "CDTA", rec, Convert.ToString(Convert.ToInt32(GetDBValue("COCH", "CDTA", recCOCH)) + rand.Next(-3, 4)));
            ChangeDBString("COCH", "COTA", rec, Convert.ToString(Convert.ToInt32(GetDBValue("COCH", "COTA", recCOCH)) + rand.Next(-3, 4)));

            ChangeDBString("COCH", "CDST", rec, GetDBValue("COCH", "CDST", recCOCH));
            ChangeDBString("COCH", "COST", rec, GetDBValue("COCH", "COST", recCOCH));
            ChangeDBString("COCH", "CPID", rec, GetDBValue("COCH", "CPID", recCOCH));

            ChangeDBString("COCH", "CDTR", rec, Convert.ToString(Convert.ToInt32(GetDBValue("COCH", "CDTR", recCOCH)) + rand.Next(-3, 4)));
            ChangeDBString("COCH", "COTR", rec, Convert.ToString(Convert.ToInt32(GetDBValue("COCH", "COTR", recCOCH)) + rand.Next(-3, 4)));

            ChangeDBString("COCH", "CDTS", rec, Convert.ToString(Convert.ToInt32(GetDBValue("COCH", "CDTS", recCOCH)) + rand.Next(-3, 4)));
            ChangeDBString("COCH", "COTS", rec, Convert.ToString(Convert.ToInt32(GetDBValue("COCH", "COTS", recCOCH)) + rand.Next(-3, 4)));

            //CDPC, CRPC, CTPC
            int CDPC, CRPC, CTPC;
            CRPC = Convert.ToInt32(GetDBValue("COCH", "CRPC", rec));
            CTPC = Convert.ToInt32(GetDBValue("COCH", "CTPC", rec));
            CDPC = 0;

            while (CDPC < 15 || CDPC > 25)
            {
                CTPC = rand.Next(25, 46);
                CRPC = rand.Next(25, 46);
                CDPC = 100 - CTPC - CRPC;
            }

            ChangeDBString("COCH", "CDPC", rec, Convert.ToString(CDPC));
            ChangeDBString("COCH", "CRPC", rec, Convert.ToString(CRPC));
            ChangeDBString("COCH", "CTPC", rec, Convert.ToString(CTPC));

        }

        #endregion
    }

}
