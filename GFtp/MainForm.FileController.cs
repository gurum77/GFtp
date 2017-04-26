using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using GFtp;

namespace GFtp
{
    partial class MainForm
    {
        // when deleted a file in ftpFileGridView by user, call this
        void ftpFileGridView_UserDeletingRow(object sender, System.Windows.Forms.DataGridViewRowCancelEventArgs e)
        {
            if (sender != ftpFileGridView)
                return;

            string[] files = ftpFileGridView.GetSelectedFiles();
            _ftpController.DeleteFiles(files);

            RefreshFtpFileGridView();
            e.Cancel = true;
        }

        // when started to edit cell, call this
        // Saves old file name
        void fileGridView_CellBeginEdit(object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            if (sender != fileGridView)
                return;

            string[] files = fileGridView.GetSelectedFiles();
            if (files.Length > 1)
                return;

            _beforeEditFileName = files[0];
        }


        // when changed a text in fileGridView by user, call this
        // Renames file name
        void fileGridView_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (sender != fileGridView)
                return;

            string[] files = fileGridView.GetSelectedFiles();
            if (files.Length > 1)
                return;

            string fromFilePathName = System.IO.Path.Combine(CurrentDirectory, _beforeEditFileName);
            string toFilePathName = Path.Combine(CurrentDirectory, files[0]);

            try
            {
                System.IO.File.Move(fromFilePathName, toFilePathName);
                RefreshFileGridViewOfCurrentDirectory();
                fileGridView.SelectFile(files[0]);

            }
            catch
            {
                MessageBox.Show("Can't changed a file name.");
                RefreshFileGridViewOfCurrentDirectory();
            }
        }

        // when deleted a file in fileGridView by user, call this
        void fileGridView_UserDeletingRow(object sender, System.Windows.Forms.DataGridViewRowCancelEventArgs e)
        {
            if (sender != fileGridView)
                return;

            string[] files = fileGridView.GetSelectedFiles();
            foreach (var fileName in files)
            {
                string filePath = Path.Combine(CurrentDirectory, fileName);
                System.IO.File.Delete(filePath);
            }

            RefreshFileGridViewOfCurrentDirectory();
            e.Cancel = true;
        }

        // When finish userediting ftp file grid view, call this
        private void ftpFileGridView_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (sender != ftpFileGridView)
                return;

            string[] files = ftpFileGridView.GetSelectedFiles();
            if (files.Length > 1)
                return;

            try
            {
                _ftpController.RenameFile(_beforeEditFileName, files[0]);
                RefreshFileGridViewOfCurrentDirectory();
                fileGridView.SelectFile(files[0]);

            }
            catch
            {
                MessageBox.Show("Can't changed a file name.");
            }
        }

        private void ftpFileGridView_CellBeginEdit(object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            if (sender != ftpFileGridView)
                return;

            string[] files = ftpFileGridView.GetSelectedFiles();
            if (files.Length > 1)
                return;

            _beforeEditFileName = files[0];
        }
    }
}
