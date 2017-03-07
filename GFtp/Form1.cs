using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace GFtp
{
   

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // When the Form1 is loaded, display directory list to directoryTreeView control.
        string _currentDirectory = @"c:\";
        string _ftpAddress = @"ftp://ftp.novell.com";
        string _id = "";
        string _password = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            DefaultFieldValue();
            DisplayDefaultFieldValue();
            RefreshFileListBoxOfCurrentDirectory();
        }

        // Set default field values.
        void DefaultFieldValue()
        {
            _currentDirectory = Directory.GetCurrentDirectory();
        }

        // Display default field value to controls.
        void DisplayDefaultFieldValue()
        {
            ftpAddressTextBox.Text = _ftpAddress;
            idTextBox.Text = _id;
            passwordTextBox.Text = _password;
        }

        // Refresh FileTreeView
        // Display all file in the current directory.
        void RefreshFileListBoxOfCurrentDirectory()
        {
            // Get all file list  directory list of my pc;
            DirectoryInfo di = new DirectoryInfo(_currentDirectory);

            // Get all sub directory
            FileInfo[] fiArray = di.GetFiles("*.*");
            GridFileInfo[] gridFileInfos = new GridFileInfo[fiArray.Length];
            int idx = 0;
            foreach(FileInfo fi in fiArray)
            {
                gridFileInfos[idx] = new GridFileInfo();
                gridFileInfos[idx].Name = fi.Name;
                gridFileInfos[idx].Size = fi.Length;
                idx++;
            }
            // Display file to grid view
            DisplayFilesToGridView(fileGridView, gridFileInfos);
        }

        // Display file to grid view
        void DisplayFilesToGridView(DataGridView gridView, GridFileInfo[] fileinfos)
        {
            if (fileinfos.Length == 0)
            {
                gridView.Rows.Clear();
                return;
            }

            // initialize file tree view control
            gridView.RowCount = fileinfos.Length;
            gridView.ColumnCount = 2;

            // set column's width
            gridView.Columns[0].Width = 200;
            gridView.Columns[1].Width = 150;

            // set header titles
            gridView.Columns[0].HeaderText = "Name";
            gridView.Columns[1].HeaderText = "Size";

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
                gridView.Rows[rowIndex].Height = 24;
                gridView.Rows[rowIndex].Cells[0].Value = f?.Name;
                gridView.Rows[rowIndex].Cells[1].Value = f?.Size;

                rowIndex++;
            }
        }
        // When the select director button clicked, select current directory and then refresh file tree view
        private void selectDirectoyButton_Click(object sender, EventArgs e)
        {
            // select directory
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = _currentDirectory;
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            _currentDirectory = dlg.SelectedPath;

            RefreshFileListBoxOfCurrentDirectory();
        }

        private void ftpFileListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ftpAddressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(Keys.Enter))
                return;

            RefreshFtpFileListBoxWithCurrentInput();
        }

        // Refresh ftp file list box
        void RefreshFtpFileGridView(string ftpAddr, string id, string password)
        {
            GridFileInfo[] gridFileInfos    = GetAllGridFileInfosFromFtp(ftpAddr, id, password);

            // display file list into list view
            DisplayFilesToGridView(ftpFileGridView, gridFileInfos);
        }

        // Get all files on ftp root directory
        private GridFileInfo[] GetAllGridFileInfosFromFtp(string ftpAddr, string id, string password)
        {
            Uri ftpUri = new Uri(ftpAddr);
            FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(ftpUri);
            ftpReq.Credentials = new NetworkCredential(id, password);
            ftpReq.Timeout = 30000; // 30 seconds timeout
            ftpReq.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();

            StreamReader reader = new StreamReader(ftpRes.GetResponseStream(), System.Text.Encoding.Default);

            string str = reader.ReadToEnd();
            string[] fileInfos = str.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);


            GridFileInfo[] gridFileInfos = new GridFileInfo[fileInfos.Length];
            int idx = 0;
            foreach(string infoString in fileInfos)
            {
                string[] infoArray = infoString.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                gridFileInfos[idx] = new GridFileInfo();
                gridFileInfos[idx].Size = long.Parse(infoArray[4]);
                gridFileInfos[idx].Name = infoArray[8];
                idx++;
            }

            ftpRes.Close();
            return gridFileInfos;
        }

        // Translate files from local to ftp
        private void UploadToFtpButton_Click(object sender, EventArgs e)
        {
            // Get files of local
            string[] files = GetSelectedFilesOfCurrentDirectory();

            if (TranslateFiles(files, true))
            {
                RefreshFtpFileGridView(_ftpAddress, _id, _password);
                MessageBox.Show("Completed.");
            }
            else
            {
                MessageBox.Show("Failded Upload.");
            }
        }

        // Translate files from local to ftp or from ftp to local
        private bool TranslateFiles(string[] files, bool IsUpload)
        {
            // connect ftp
            WebClient wc = new WebClient { Proxy = null };
            wc.BaseAddress = _ftpAddress;
            if (_id != "" && _password != "")
            {
                wc.Credentials = new NetworkCredential(_id, _password);
            }

            try
            {
                foreach (string filename in files)
                {
                    string pathName = Path.Combine(_currentDirectory, filename);
                    // upload
                    if (IsUpload)
                    {
                        wc.UploadFile(pathName, filename);
                    }
                    // download
                    else
                    {
                        wc.DownloadFile(filename, pathName);
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        // Get file list selected of current directory
        private string[] GetSelectedFilesOfCurrentDirectory()
        {
            return GetSelectedFileOfGridView(fileGridView);
        }

        // Get file names selected in the grid view
        private string[] GetSelectedFileOfGridView(DataGridView gridView)
        {
            string[] files = new string[gridView.SelectedRows.Count];
            int idx = 0;
            foreach (DataGridViewRow row in gridView.SelectedRows)
            {
                files[idx++] = row.Cells[0].Value.ToString();
            }

            return files;
        }

        // Get selected files on ftp
        private string[] GetSelectedFilenamesOfFtp()
        {
            return GetSelectedFileOfGridView(ftpFileGridView);
        }

        // Connect to ftp
        private void connectionButton_Click(object sender, EventArgs e)
        {
            RefreshFtpFileListBoxWithCurrentInput();
          
        }

        // Refresh ftp file list box with current input (ftp address, id, password)
        private void RefreshFtpFileListBoxWithCurrentInput()
        {
            // ftp 주소
            _ftpAddress = ftpAddressTextBox.Text;

            // id, password
            _id = idTextBox.Text;
            _password = passwordTextBox.Text;

            // Connet to the ftp and get all file list.
            RefreshFtpFileGridView(_ftpAddress, _id, _password);
        }

        // Download selected files on ftp.
        private void fromFtpButton_Click(object sender, EventArgs e)
        {
            // Get files of ftp
            string[] files = GetSelectedFilenamesOfFtp();

            if (TranslateFiles(files, false))
            {
                RefreshFileListBoxOfCurrentDirectory();
                MessageBox.Show("Completed.");
            }
            else
            {
                MessageBox.Show("Failded Download.");
            }
        }
    }

    public class GridFileInfo
    {
        public string Name { get; set; }
        public long Size { get; set; }
    }
}
