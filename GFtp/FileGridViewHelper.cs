using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GFtp
{
    // Helper class for FileGridView
    static class FileGridViewHelper
    {
        // Get file names selected in the grid view
        static public string[] GetSelectedFiles(this DataGridView gridView)
        {
            string[] files = new string[gridView.SelectedRows.Count];
            int idx = 0;
            foreach (DataGridViewRow row in gridView.SelectedRows)
            {
                files[idx++] = row.Cells[0].Value.ToString();
            }

            return files;
        }

        // Display file to grid view
        static public void DisplayFiles(this DataGridView gridView, GridFileInfo[] fileinfos)
        {
            if (fileinfos.Length == 0)
            {
                gridView.Rows.Clear();
                return;
            }

            // initialize file tree view control
            gridView.RowCount = fileinfos.Length;
            gridView.ColumnCount = 3;

            // set column's width
            gridView.Columns[0].Width = 200;
            gridView.Columns[1].Width = 100;
            gridView.Columns[2].Width = 50;

            // set header titles
            gridView.Columns[0].HeaderText = "Name";
            gridView.Columns[1].HeaderText = "Size";
            gridView.Columns[2].HeaderText = "Type";

            // Change column's sortmode to NotSortable for DataGridViewSelectionMode.FullColumnSelect
            for (int i = 0; i < gridView.ColumnCount; ++i)
            {
                gridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Set files to grid view
            int rowIndex = 0;
            foreach (GridFileInfo f in fileinfos)
            {
                try
                {
                    gridView.Rows[rowIndex].Height = 24;
                }
                catch
                {
                }

                if (f != null)
                {
                    gridView.Rows[rowIndex].Cells[0].Value = f.Name;
                    if (f.IsFolder == false)
                    {
                        gridView.Rows[rowIndex].Cells[1].Value = f.Size;
                        gridView.Rows[rowIndex].Cells[2].Value = "File";
                    }
                    else
                    {
                        gridView.Rows[rowIndex].Cells[1].Value = "";
                        gridView.Rows[rowIndex].Cells[2].Value = "Folder";
                    }
                }


                rowIndex++;
            }
        }
    }
}
