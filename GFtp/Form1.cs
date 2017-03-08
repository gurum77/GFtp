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
        // When the Form1 is loaded, display directory list to directoryTreeView control.
        string _currentDirectory = @"c:\";
        string _ftpAddress = @"ftp://ftp.novell.com";
        string _ftpRootAddress = @"ftp://ftp.novell.com";   // The ftp address When ftp is connected, 
        string _id = "";
        string _password = "";
  
        public Form1()
        {
            InitializeComponent();

            fileGridView.DoubleClick += FileGridView_DoubleClick;
            ftpFileGridView.DoubleClick += ftpFileGridView_DoubleClick;
        }
        
        void ftpFileGridView_DoubleClick(object sender, EventArgs e)
        {
            if (sender != ftpFileGridView)
                return;

            DataGridViewCell cell = ftpFileGridView.CurrentCell;
            // Check clicked cell is file or folder
            bool isFolder = true;
            if (ftpFileGridView.Rows[cell.RowIndex].Cells[2].Value.ToString() == "File")
                isFolder = false;

            // if clicked cell is folder then move current directory to sub directory
            if (isFolder)
            {
                string nextPath = ftpFileGridView.Rows[cell.RowIndex].Cells[0].Value.ToString();
                if(nextPath == "..")
                {
                    string addressOrg = _ftpAddress;
                    int lastIdx = _ftpAddress.LastIndexOf('/');
                    
                    if (lastIdx > -1)
                    {
                        _ftpAddress = _ftpAddress.Substring(0, lastIdx);
                    }

                    // check possible convert from string to Uri
                    try
                    {
                        Uri ftpUri = new Uri(_ftpAddress);
                    }
                    catch
                    {
                        // if impossible convert then return
                        _ftpAddress = addressOrg;
                        return;
                    }
                }
                else
                {
                    _ftpAddress = _ftpAddress + "/" + nextPath;
                }
                
                ftpAddressTextBox.Text = _ftpAddress;
                RefreshFtpFileGridViewWithCurrentInput();
            }        
        }
        
        
        private void FileGridView_DoubleClick(object sender, EventArgs e)
        {
            if (sender != fileGridView)
                return;

            DataGridViewCell cell = fileGridView.CurrentCell;
            // Check clicked cell is file or folder
            bool isFolder = true;
            if (fileGridView.Rows[cell.RowIndex].Cells[2].Value.ToString() == "File")
                isFolder = false;

            // if clicked cell is folder then move current directory to sub directory
            if(isFolder)
            {
                _currentDirectory   = Path.Combine(_currentDirectory, fileGridView.Rows[cell.RowIndex].Cells[0].Value.ToString());
                RefreshFileGridViewOfCurrentDirectory();
            }         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DefaultFieldValue();
            DisplayDefaultFieldValue();
            RefreshFileGridViewOfCurrentDirectory();
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
        void RefreshFileGridViewOfCurrentDirectory()
        {
            // Get all file list  directory list of my pc;
            DirectoryInfo di = new DirectoryInfo(_currentDirectory);

            // Get all sub directory
            DirectoryInfo[] subDiArray = di.GetDirectories();
           
            // Get all files
            FileInfo[] fiArray = di.GetFiles("*.*");

            GridFileInfo[] gridFileInfos = new GridFileInfo[1 + subDiArray.Length + fiArray.Length];
            int idx = 0;

            // Add super directory
            {
                gridFileInfos[idx] = new GridFileInfo();
                gridFileInfos[idx].Name = "..";
                gridFileInfos[idx].Size = 0;
                gridFileInfos[idx].IsFolder = true;
                idx++;
            }
            
            // Add directory infos
            foreach (DirectoryInfo subDi in subDiArray)
            {
                gridFileInfos[idx] = new GridFileInfo();
                gridFileInfos[idx].Name = subDi.Name;
                gridFileInfos[idx].Size = 0;
                gridFileInfos[idx].IsFolder = true;
                idx++;
            }
         
            // Add file infos
            foreach(FileInfo fi in fiArray)
            {
                gridFileInfos[idx] = new GridFileInfo();
                gridFileInfos[idx].Name = fi.Name;
                gridFileInfos[idx].Size = fi.Length;
                gridFileInfos[idx].IsFolder = false;
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
                gridView.Rows[rowIndex].Height = 24;
                
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

        // When the select director button clicked, select current directory and then refresh file tree view
        private void selectDirectoyButton_Click(object sender, EventArgs e)
        {
            // select directory
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = _currentDirectory;
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            _currentDirectory = dlg.SelectedPath;

            RefreshFileGridViewOfCurrentDirectory();
        }

        private void ftpAddressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(Keys.Enter))
                return;

            RefreshFtpFileGridViewWithCurrentInput();
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

            GridFileInfo[] gridFileInfos = new GridFileInfo[1 + fileInfos.Length];
            int idx = 0;

            // Add super directory
            {
                gridFileInfos[idx] = new GridFileInfo();
                gridFileInfos[idx].Size = 0;
                gridFileInfos[idx].Name = "..";
                gridFileInfos[idx].IsFolder = true;
                idx++;
            }

            // Get all files and folders
            foreach (string infoString in fileInfos)
            {
                string[] infoArray = infoString.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                gridFileInfos[idx] = new GridFileInfo();
                gridFileInfos[idx].Size = long.Parse(infoArray[4]);
                gridFileInfos[idx].Name = infoArray[8];
                if (infoArray[0][0] == 'd')
                {
                    gridFileInfos[idx].IsFolder = true;
                }
                idx++;
            }

            
            // sort from folers to files
            Array.Sort(gridFileInfos);

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
            // Set a progressbar
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Minimum = 0;
            progressBar.Maximum = files.Length;
            progressBar.Step = 1;
            progressBar.Value = 0;
   

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

                    // increment progress bar
                    progressBar.PerformStep();
                    
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
            RefreshFtpFileGridViewWithCurrentInput();
          
        }

        // Refresh ftp file list box with current input (ftp address, id, password)
        private void RefreshFtpFileGridViewWithCurrentInput()
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
                RefreshFileGridViewOfCurrentDirectory();
                MessageBox.Show("Completed.");
            }
            else
            {
                MessageBox.Show("Failded Download.");
            }
        }
    }
}
