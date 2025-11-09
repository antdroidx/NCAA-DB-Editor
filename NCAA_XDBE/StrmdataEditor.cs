using System;
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

        //RCAT RECRUIT
        private void buttonRCATBody_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GetTableRecCount("RCAT"); i++)
            {
                RecalculateIndividualBodyShape(i, "RCAT");
            }

            MessageBox.Show("Body Model updates are complete!");
        }

        private void RCATAppearanceRandomizerButton_Click(object sender, EventArgs e)
        {


            for (int i = 0; i < GetTableRecCount("RCAT"); i++)
            {
                int handVal = rand.Next(1, 101);
                int hand = 0;
                if (handVal <= 9) hand = 1; //left handed 9% chance
                ChangeDBInt("RCAT", "PHAN", i, hand);

                RandomizeSkinTone("RCAT", i);
                RandomizePlayerHead("RCAT", i);
            }
            MessageBox.Show("Player Appearance Randomized!");

        }

        private void RCATGearRandomizerButton_Click(object sender, EventArgs e)
        {
            RandomizeAllPlayerGears("RCAT");
            MessageBox.Show("Player Gears Randomized!");
        }
        
        private void ExportRCATButton_Click(object sender, EventArgs e)
        {
            // TdbTableProperties class
            TdbTableProperties TableProps = new TdbTableProperties();

            // 4 character string, max value of 5
            StringBuilder TableName = new StringBuilder("    ", 5);

            for (int i = 0; i < TDB.TDBDatabaseGetTableCount(dbIndex); i++)
            {
                // Get the tableproperties for the given table number
                if (GetTableName(dbIndex, i) == "RCAT")
                {
                    SelectedTableName = "RCAT";
                    SelectedTableIndex = i;
                    exportToolItem.PerformClick();
                    break;
                }
            }
        }
    }
}
