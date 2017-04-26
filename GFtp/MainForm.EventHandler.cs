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
    public partial class MainForm
    {
        private void InitializeEventHandler()
        {
            this.connectionButton.Click += connectionButton_Click;
            this.toFtpButton.Click += new System.EventHandler(this.UploadToFtpButton_Click);
            this.fromFtpButton.Click += new System.EventHandler(this.downloadFromFtpButton_Click);
            this.explorerTree.PathChanged += new WindowsExplorer.ExplorerTree.PathChangedEventHandler(this.explorerTree_PathChanged);
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.fileGridView.DoubleClick += FileGridView_DoubleClick;
            this.ftpFileGridView.DoubleClick += ftpFileGridView_DoubleClick;
            this.favoritesTreeView.AfterSelect += favoritesTreeView_AfterSelect;
            this.addButton.Click += addButton_Click;
            this.delButton.Click += delButton_Click;

            this.fileGridView.UserDeletingRow +=fileGridView_UserDeletingRow;
            this.fileGridView.CellBeginEdit += fileGridView_CellBeginEdit;
            this.fileGridView.CellEndEdit += fileGridView_CellEndEdit;

            this.ftpFileGridView.UserDeletingRow += ftpFileGridView_UserDeletingRow;
            this.ftpFileGridView.CellBeginEdit += ftpFileGridView_CellBeginEdit;
            this.ftpFileGridView.CellEndEdit +=ftpFileGridView_CellEndEdit;
        }

    }
}
