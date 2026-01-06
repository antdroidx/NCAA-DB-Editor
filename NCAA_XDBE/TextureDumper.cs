// using System.Runtime.Remoting.Metadata.W3cXsd2001;
namespace DB_EDITOR
{
    partial class MainEditor : Form
    {
        /* This is used for Texture Dumping Roster Creation Only */

        private void TextureDumperButton_Click(object sender, EventArgs e)
        {
            DUMPER = true;


            DepthChartMaker("TDYN");


            CreateDumpRoster();

            MessageBox.Show("COMPLETE");
            DUMPER = false;
        }

        private void CreateDumpRoster()
        {
            List<List<int>> gears = new List<List<int>>();

            gears = CreateIntListsFromCSV(@"resources\rosters\texture-dumper.csv", true);

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                int pos = GetDBValueInt("PLAY", "PPOS", i);

                int faceprotector = gears[pos][1];
                ChangeDBInt("PLAY", "PLFP", i, faceprotector);

                int visor = gears[pos][2];
                ChangeDBInt("PLAY", "PVIS", i, visor);

                int mouthguard = gears[pos][3];
                ChangeDBInt("PLAY", "PLMG", i, mouthguard);

                int neckpad = gears[pos][4];
                ChangeDBInt("PLAY", "PNEK", i, neckpad);

                int sleevetype = gears[pos][5];
                ChangeDBInt("PLAY", "PSLO", i, sleevetype);

                int sleevecolor = gears[pos][6];
                ChangeDBInt("PLAY", "PSLT", i, sleevecolor);

                int turftape = gears[pos][7];
                ChangeDBInt("PLAY", "PTTO", i, turftape);

                int elbowL = gears[pos][8];
                ChangeDBInt("PLAY", "PLEB", i, elbowL);

                int elbowR = gears[pos][9];
                ChangeDBInt("PLAY", "PREB", i, elbowR);

                int wristL = gears[pos][10];
                ChangeDBInt("PLAY", "PLWS", i, wristL);

                int wristR = gears[pos][11];
                ChangeDBInt("PLAY", "PRWS", i, wristR);

                int handL = gears[pos][12];
                ChangeDBInt("PLAY", "PLHN", i, handL);

                int handR = gears[pos][13];
                ChangeDBInt("PLAY", "PRHN", i, handR);

                int shoeL = gears[pos][14];
                ChangeDBInt("PLAY", "PLSH", i, shoeL);

                int shoeR = gears[pos][15];
                ChangeDBInt("PLAY", "PRSH", i, shoeR);

            }
        }





    }

}
