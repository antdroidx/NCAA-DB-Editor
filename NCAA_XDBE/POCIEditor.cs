// using System.Runtime.Remoting.Metadata.W3cXsd2001;
namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

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
            for (int i = 0; i < GetTableRecCount("POCI"); i++)
            {
                int ppos = GetDBValueInt("POCI", "PPOS", i);
                POCIGridView.Rows[ppos].Cells[0].Value = Positions[ppos];

                for (int j = 0; j < TDB.FieldCount(dbIndex, "POCI"); j++)
                {

                    var fieldProps = new TdbFieldProperties();
                    fieldProps.Name = new string((char)0, 5);
                    TDB.TDBFieldGetProperties(dbSelected, "POCI", j, ref fieldProps);
                    int col = -1;
                    for (int x = 0; x < POCIGridView.ColumnCount; x++)
                    {
                        if (fieldProps.Name == POCIGridView.Columns[x].Name)
                        {
                            col = x;
                            break;
                        }
                    }


                    if (col > 0) POCIGridView.Rows[ppos].Cells[col].Value = GetDBValueInt("POCI", fieldProps.Name, i);

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

        private void POCIGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DoNotTrigger) return;
            CalculatePOCISums();
        }

        private void POCIUpdate_Click(object sender, EventArgs e)
        {
            //Clear RCAT table
            for (int i = 0; i < GetTableRecCount("POCI"); i++)
            {
                DeleteRecord("POCI", i, true);
            }
            CompactDB();

            for (int i = 0; i < POCIGridView.RowCount; i++)
            {
                AddTableRecord("POCI", false);

                for (int j = 0; j < POCIGridView.ColumnCount - 1; j++)
                {

                    string fieldName = POCIGridView.Columns[j].Name;

                    if (j != 0)
                    {
                        ChangeDBInt("POCI", fieldName, i, Convert.ToInt32(POCIGridView.Rows[i].Cells[j].Value));
                    }
                    else
                    {
                        string pos = Convert.ToString(POCIGridView.Rows[i].Cells[j].Value);
                        ChangeDBInt("POCI", fieldName, i, PositionsX[pos]);
                    }
                }

            }

            CreatePOCItable();

            MessageBox.Show("POCI Updated! Save to complete the process.");

        }

    }

}
