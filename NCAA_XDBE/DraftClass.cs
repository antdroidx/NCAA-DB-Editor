using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private void ExportDraft_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This feature is not yet implemented.");

            CreateDraftClass();

        }

        private void ExportDC2_Click(object sender, EventArgs e)
        {
            CreateDraftClass();

        }


        private void CreateDraftClass()
        {

            List<int> PositionReq = GetDraftClassTable();
            List<List<byte>> DraftClass = new List<List<byte>>();

            StartProgressBar(1600);
            bool fb = false;
            int classCount = 0;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "All files (*.*)|*.*";
                saveFileDialog.Title = "Save Draft Class Export";
                saveFileDialog.FileName = "BASLUS-21214LClassExport";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(new byte[] { 0x46, 0x00, 0x40, 0x06 }, 0, 4); // Write the header

                        for (int i = 0; i < PositionReq.Count; i++)
                        {
                            List<int> PlayerList = GetTopPositionProspects(i, PositionReq[i]);

                            if (i == 2) fb = true; else fb = false;

                            for (int j = 0; j < PlayerList.Count; j++)
                            {
                                fs.Write(ExportDCPlayerData(PlayerList[j], fb).ToArray(), 0, ExportDCPlayerData(PlayerList[j], fb).Count);
                                classCount++;
                                ProgressBarStep();
                            }
                            
                        }

                        /*
                        int pos = 0;
                        while(classCount < 1600)
                        {
                            List<int> PlayerList = GetSupplementalPlayers(pos, PositionReq[pos]);
                            for (int j = 0; j < PlayerList.Count; j++)
                            {
                                fs.Write(ExportDCPlayerData(PlayerList[j], fb).ToArray(), 0, ExportDCPlayerData(PlayerList[j], fb).Count);
                                classCount++;
                                ProgressBarStep();
                            }

                            pos++;
                            if (pos > 20) pos = 0;
                        }
                        */

                        // Write 0x00 bytes of length 0x27C (636 in decimal) to the end of the file
                        byte[] padding = new byte[0x27C];
                        fs.Write(padding, 0, padding.Length);
                    }
                }


                MessageBox.Show("Complete | total class: " + classCount);
                EndProgressBar();

            }
        }

        private List<int> GetDraftClassTable()
        {
            List<int> PositionReq = new List<int>();
            PositionReq.Add(95); //QB
            PositionReq.Add(120); //HB
            PositionReq.Add(50); //FB
            PositionReq.Add(185); //WR
            PositionReq.Add(80); //TE
            PositionReq.Add(65);  //LT
            PositionReq.Add(65);  //LG
            PositionReq.Add(65);  //OC
            PositionReq.Add(60);  //RT
            PositionReq.Add(60);  //RG
            PositionReq.Add(65);  //LE
            PositionReq.Add(65);  //RE
            PositionReq.Add(120);  //DT
            PositionReq.Add(55);  //LB
            PositionReq.Add(85);  //MLB
            PositionReq.Add(55);  //LB
            PositionReq.Add(120);  //CB
            PositionReq.Add(65);  //FS
            PositionReq.Add(65);  //FS
            PositionReq.Add(30);  //K
            PositionReq.Add(30);  //P

            return PositionReq;
        }


        private List<int> GetTopPositionProspects(int ppos, int count)
        {
            List<List<int>> AllPosPlayers = new List<List<int>>();
            List<int> TopPlayers = new List<int>();

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (GetDBValueInt("PLAY", "PPOS", i) == ppos && GetDBValueInt("PLAY", "PTYP", i) == 3)
                {
                    AllPosPlayers.Add(new List<int>());
                    AllPosPlayers[AllPosPlayers.Count - 1].Add(i); //Player Index
                    AllPosPlayers[AllPosPlayers.Count - 1].Add(GetDBValueInt("PLAY", "POVR", i)); //Overall
                }
            }

            AllPosPlayers.Sort((player1, player2) => player2[1].CompareTo(player1[1]));

            int added = 0;
            for (int i = 0; i < AllPosPlayers.Count; i++)
            {
                TopPlayers.Add(AllPosPlayers[i][0]);
                added++;
                if (added >= count) break;
            }

            //check FB count and convert HB/TE to FB if needed
            if (ppos == 2 && TopPlayers.Count < count)
            {
                int needed = count - TopPlayers.Count;

                List<List<int>> MoreFBPlayers = new List<List<int>>();
                for (int i = 0; i < GetTableRecCount("PLAY"); i++)
                {
                    if (GetDBValueInt("PLAY", "PPOS", i) == 1 && GetDBValueInt("PLAY", "PTYP", i) == 3)
                    {
                        MoreFBPlayers.Add(new List<int>());
                        MoreFBPlayers[MoreFBPlayers.Count - 1].Add(i); //Player Index
                        MoreFBPlayers[MoreFBPlayers.Count - 1].Add(GetDBValueInt("PLAY", "POVR", i)); //Overall
                    }
                }

                MoreFBPlayers.Sort((player1, player2) => player2[1].CompareTo(player1[1]));

                for (int i = 120; i < MoreFBPlayers.Count; i++)
                {
                    TopPlayers.Add(MoreFBPlayers[i][0]);
                    needed--;
                    if (needed <= 0) break;
                }
            }

            if (ppos == 2 && TopPlayers.Count < count)
            {
                int needed = count - TopPlayers.Count;

                List<List<int>> MoreFBPlayers = new List<List<int>>();
                for (int i = 0; i < GetTableRecCount("PLAY"); i++)
                {
                    if (GetDBValueInt("PLAY", "PPOS", i) == 4 && GetDBValueInt("PLAY", "PTYP", i) == 3)
                    {
                        MoreFBPlayers.Add(new List<int>());
                        MoreFBPlayers[MoreFBPlayers.Count - 1].Add(i); //Player Index
                        MoreFBPlayers[MoreFBPlayers.Count - 1].Add(GetDBValueInt("PLAY", "POVR", i)); //Overall
                    }
                }

                MoreFBPlayers.Sort((player1, player2) => player2[1].CompareTo(player1[1]));

                for (int i = 80; i < MoreFBPlayers.Count; i++)
                {
                    TopPlayers.Add(MoreFBPlayers[i][0]);
                    needed--;
                    if (needed <= 0) break;
                }
            }

            if (TopPlayers.Count < count)
            {
                string posName = Positions[ppos];
                int needed = count - TopPlayers.Count;

                List<List<int>> MoreFBPlayers = new List<List<int>>();
                for (int i = 0; i < GetTableRecCount("PLAY"); i++)
                {
                    if (GetDBValueInt("PLAY", "PPOS", i) == ppos && GetDBValueInt("PLAY", "PTYP", i) == 0)
                    {
                        MoreFBPlayers.Add(new List<int>());
                        MoreFBPlayers[MoreFBPlayers.Count - 1].Add(i); //Player Index
                        MoreFBPlayers[MoreFBPlayers.Count - 1].Add(GetDBValueInt("PLAY", "POVR", i)); //Overall
                    }
                }

                MoreFBPlayers.Sort((player1, player2) => player1[1].CompareTo(player2[1]));

                for (int i = 0; i < MoreFBPlayers.Count; i++)
                {
                    TopPlayers.Add(MoreFBPlayers[i][0]);
                    ChangeDBInt("PLAY", "PTYP", MoreFBPlayers[i][0], 3);
                    needed--;
                    if (needed <= 0) break;
                }

                if (needed > 0)  MessageBox.Show("Not enough " + posName + " prospects available to fill draft class requirements. It requires " + needed + " more players. Please pick players to graduate in PLAYER EDITOR.");

            }


            return TopPlayers;
        }

        private List<int> GetSupplementalPlayers(int ppos, int count)
        {
            List<List<int>> AllPosPlayers = new List<List<int>>();
            List<int> TopPlayers = new List<int>();

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (GetDBValueInt("PLAY", "PPOS", i) == ppos && GetDBValueInt("PLAY", "PTYP", i) == 3)
                {
                    AllPosPlayers.Add(new List<int>());
                    AllPosPlayers[AllPosPlayers.Count - 1].Add(i); //Player Index
                    AllPosPlayers[AllPosPlayers.Count - 1].Add(GetDBValueInt("PLAY", "POVR", i)); //Overall
                }
            }

            AllPosPlayers.Sort((player1, player2) => player2[1].CompareTo(player1[1]));


            if (TopPlayers.Count > count+1)
            {
                for (int i = count; i < AllPosPlayers.Count + 2; i++)
                {
                    TopPlayers.Add(AllPosPlayers[i][0]);
                    break;
                }
            }

            return TopPlayers;
        }

        private List<byte> ExportDCPlayerData(int rec, bool fb)
        {
            List<byte> DraftClassPlayer = new List<byte>();

            {
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PFMP", rec));
                DraftClassPlayer.Add((byte)0);
                DraftClassPlayer.Add((byte)rand.Next(0, 255)); //Random Seed Value
                DraftClassPlayer.Add((byte)10); //Team Bucket
                DraftClassPlayer.Add((byte)(int)(GetDBValueInt("PLAY", "PGID", rec) / 70));
                DraftClassPlayer.Add((byte)0);

                string FirstName = GetFirstNameFromRecord(rec);
                foreach (char c in FirstName)
                {
                    DraftClassPlayer.Add((byte)c);
                }

                int zeros = (11 - FirstName.Length);
                for (int j = 0; j < zeros; j++)
                {
                    DraftClassPlayer.Add((byte)0);
                }

                string LastName = GetLastNameFromRecord(rec);
                foreach (char c in LastName)
                {
                    DraftClassPlayer.Add((byte)c);
                }


                zeros = (14 - LastName.Length);
                for (int j = 0; j < zeros; j++)
                {
                    DraftClassPlayer.Add((byte)0);
                }

                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PYER", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PRSD", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "POVR", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PJEN", rec));

                //force HB/TE to FB position for draft export
                if (fb)
                {
                    DraftClassPlayer.Add((byte)2);
                }
                else
                {
                    DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PPOS", rec));
                }

                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PWGT", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PHGT", rec));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PSTR", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PAGI", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PSPD", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PACC", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PAWR", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PCTH", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PCAR", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PTHP", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PTHA", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PKPR", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PKAC", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PBTK", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PTAK", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PIMP", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PPBK", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PRBK", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PPOE", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PTEN", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PJMP", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PINJ", rec)));
                DraftClassPlayer.Add((byte)ConvertRating(GetDBValueInt("PLAY", "PSTA", rec)));
                DraftClassPlayer.Add((byte)0);
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PHED", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PHCL", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PSKI", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "HELM", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PFMK", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PVIS", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PEYE", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PBRE", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PNEK", rec));
                DraftClassPlayer.Add((byte)0);
                DraftClassPlayer.Add((byte)0);
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PREB", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PLEB", rec));
                DraftClassPlayer.Add((byte)0);
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PSLT", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PSLO", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PRWS", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PLWS", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PRHN", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PLHN", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PRSH", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PLSH", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PMSH", rec));
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PFSH", rec));
                DraftClassPlayer.Add((byte)0);
                DraftClassPlayer.Add((byte)GetDBValueInt("PLAY", "PSSH", rec));
            }

            return DraftClassPlayer;
        }




    }

}
