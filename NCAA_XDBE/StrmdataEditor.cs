﻿using System;
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
            for(int i = 0; i < GetTableRecCount("RCAT"); i++)
            {
                RecalculateIndividualBodyShape(i, "RCAT");
            }

            MessageBox.Show("Body Model updates are complete!");
        }


    }

}
