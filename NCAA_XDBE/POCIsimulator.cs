using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace DB_EDITOR
{
    public partial class POCIsimulator : Form
    {
        bool DoNotTrigger = false;
        MainEditor main;
        RosterViz rosterViz;
        List<string> POCIHeaders = new List<string>()
        {
            //PLDH	PLDL	PPOS	CAWT	KAWT	TAWT	PBWT	RBWT	ACWT	AGWT	TKWT	INWT	KPWT	SPWT	TPWT	BTWT	CTWT	STWT	JUWT	AWWT


            "PLDH", "PLDL", "PPOS", "CAWT", "KAWT", "TAWT", "PBWT", "RBWT", "ACWT", "AGWT", "TKWT", "INWT", "KPWT", "SPWT", "TPWT", "BTWT", "CTWT", "STWT", "JUWT", "AWWT"
        };


        public POCIsimulator(MainEditor parent, RosterViz parent2)
        {
            main = parent;
            rosterViz = parent2;
            InitializeComponent();
            StartPOCIEditor();
        }


        private void StartPOCIEditor()
        {

            DoNotTrigger = true;

            POCIGridView.Rows.Clear();

            //Create POCI Table
            POCIGridView.Rows.Add(21); //Add 21 rows initially

            LoadPOCIGridData();

            DoNotTrigger = false;
        }

        private void LoadPOCIGridData()
        {
            int length = 21;
            for (int i = 0; i < length; i++)
            {
                int ppos = Convert.ToInt32(main.POCI[i, 2]);
                POCIGridView.Rows[ppos].Cells[0].Value = main.Positions[ppos];
                int cols = 20;

                for (int j = 0; j < cols; j++)
                {

                    string fieldName = POCIHeaders[j];
                    int col = -1;

                    for (int x = 0; x < POCIGridView.ColumnCount; x++)
                    {
                        if (fieldName == POCIGridView.Columns[x].Name)
                        {
                            col = x;
                            break;
                        }
                    }

                    if (col > 0) POCIGridView.Rows[ppos].Cells[col].Value = main.POCI[i, j];

                }
            }

            CalculatePOCISums();
        }

        private void CalculatePOCISums()
        {
            for (int i = 0; i < POCIGridView.RowCount; i++)
            {
                int sum = 0;
                for (int col = 3; col <= 18; col++)
                {
                    sum += Convert.ToInt32(POCIGridView.Rows[i].Cells[col].Value);
                }
                POCIGridView.Rows[i].Cells[19].Value = sum;
            }
        }

        private void POCIGridView_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (DoNotTrigger) return;
            CalculatePOCISums();
        }



        private void POCIsimUpdatebtn_Click(object sender, EventArgs e)
        {
            //Clear POCISim table
            rosterViz.POCIsimValues = new double[22, 23];


            for (int i = 0; i < POCIGridView.RowCount; i++)
            {
                double sum = 0;

                for (int j = 0; j < POCIGridView.ColumnCount - 1; j++)
                {

                    string fieldName = POCIGridView.Columns[j].Name;

                    if (j != 0)
                    {
                        for(int x = 0; x < POCIHeaders.Count; x++)
                        {
                            if (fieldName == POCIHeaders[x])
                            {
                                rosterViz.POCIsimValues[i, x] = Convert.ToInt32(POCIGridView.Rows[i].Cells[j].Value);
                                if(x >= 3) sum += Convert.ToInt32(POCIGridView.Rows[i].Cells[j].Value);
                                break;
                            }
                        }
                    }
                    else
                    {
                        string pos = Convert.ToString(POCIGridView.Rows[i].Cells[j].Value);
                        rosterViz.POCIsimValues[i, 2] = main.PositionsX[pos];
                    }
                }

                //Add Average of High/Low Rating
                rosterViz.POCIsimValues[i, 20] = (Convert.ToDouble(POCIGridView.Rows[i].Cells[1].Value) + Convert.ToDouble(POCIGridView.Rows[i].Cells[2].Value)) / 2.00;

                rosterViz.POCIsimValues[i, 21] = sum;

                //Add 99 - (High - Low)
                rosterViz.POCIsimValues[i, 22] = 98.0 / (Convert.ToDouble(POCIGridView.Rows[i].Cells[1].Value) - Convert.ToDouble(POCIGridView.Rows[i].Cells[2].Value));

                //injury
                rosterViz.POCIsimValues[i, 11] = 0;

            }

            rosterViz.BuildRosterChart(true);

            //MessageBox.Show("POCI Simulation Updated! Save to complete the process.");
        }
    }
}

