using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Neural_Project
{
    class DataGridView_Helpers
    {
        const int column_width = 30;

        public bool is_grid_row_empty(DataGridViewRow dgrdv_row)
        {
            for (int i = 0; i < dgrdv_row.Cells.Count; i++)
            {
                if (dgrdv_row.Cells[i].Value == null)
                    return true;
            }
            return false;
        }

        public void add_grid_column(string name, string header, DataGridViewCell cell_template, DataGridView dgrdview)
        {
            DataGridViewColumn dgrdview_col = new DataGridViewColumn();
            dgrdview_col.Width = 70;
            dgrdview_col.Name = name;
            dgrdview_col.HeaderText = header;
            dgrdview_col.CellTemplate = cell_template;
            dgrdview.Columns.Add(dgrdview_col);
        }
    }
}
