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
    public partial class MainForm : Form
    {
        
        FtpController _ftpController = new FtpController();
        private string CurrentDirectory
        {
            get { return _ftpController.CurrentDirectory; }
            set { _ftpController.CurrentDirectory = value; }
        }
        private string FtpAddress
        {
            get { return _ftpController.FtpAddress; }
            set { _ftpController.FtpAddress = value; }
        }
        private string ID
        {
            get { return _ftpController.ID; }
        }
        private string Password
        {
            get { return _ftpController.Password; }
        }
  
        public MainForm()
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
                    string addressOrg = FtpAddress;
                    int lastIdx = FtpAddress.LastIndexOf('/');
                    
                    if (lastIdx > -1)
                    {
                        FtpAddress = FtpAddress.Substring(0, lastIdx);
                    }

                    // check possible convert from string to Uri
                    try
                    {
                        Uri ftpUri = new Uri(FtpAddress);
                    }
                    catch
                    {
                        // if impossible convert then return
                        FtpAddress = addressOrg;
                        return;
                    }
                }
                else
                {
                    FtpAddress = FtpAddress + "/" + nextPath;
                }
                
                ftpAddressTextBox.Text = FtpAddress;
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
                CurrentDirectory   = Path.Combine(CurrentDirectory, fileGridView.Rows[cell.RowIndex].Cells[0].Value.ToString());
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
            CurrentDirectory = Directory.GetCurrentDirectory();
            _ftpController.Init(@"ftp://ftp.novell.com", "", "", progressBar);
        }

        // Display default field value to controls.
        void DisplayDefaultFieldValue()
        {
            ftpAddressTextBox.Text = FtpAddress;
            idTextBox.Text = ID;
            passwordTextBox.Text = Password;
        }

        // Refresh FileTreeView
        // Display all file in the current directory.
        void RefreshFileGridViewOfCurrentDirectory()
        {
            // Get all file list  directory list of my pc;
            DirectoryInfo di = new DirectoryInfo(CurrentDirectory);

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
            fileGridView.DisplayFiles(gridFileInfos);
        }

      
        // When the select director button clicked, select current directory and then refresh file tree view
        private void selectDirectoyButton_Click(object sender, EventArgs e)
        {
            // select directory
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = CurrentDirectory;
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;
            CurrentDirectory = dlg.SelectedPath;

            RefreshFileGridViewOfCurrentDirectory();
        }

        private void ftpAddressTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(Keys.Enter))
                return;

            RefreshFtpFileGridViewWithCurrentInput();
        }

        // Refresh ftp file list box
        void RefreshFtpFileGridView()
        {
            // display file list into list view
            ftpFileGridView.DisplayFiles(_ftpController.GetAllGridFileInfosFromFtp());
        }

        // Translate files from local to ftp
        private void UploadToFtpButton_Click(object sender, EventArgs e)
        {
            // Get files of local
            string[] files = fileGridView.GetSelectedFiles();

            if (_ftpController.TranslateFiles(files, true))
            {
                RefreshFtpFileGridView();
                MessageBox.Show("Completed.");
            }
            else
            {
                MessageBox.Show("Failded Upload.");
            }
        }

        // Connect to ftp
        private void connectionButton_Click(object sender, EventArgs e)
        {
            RefreshFtpFileGridViewWithCurrentInput();
          
        }

        // Refresh ftp file list box with current input (ftp address, id, password)
        private void RefreshFtpFileGridViewWithCurrentInput()
        {
            _ftpController.Init(ftpAddressTextBox.Text, idTextBox.Text, passwordTextBox.Text, progressBar);

            // Connet to the ftp and get all file list.
            RefreshFtpFileGridView();
        }

        // Download selected files on ftp.
        private void fromFtpButton_Click(object sender, EventArgs e)
        {
            // Get files of ftp
            string[] files = ftpFileGridView.GetSelectedFiles();

            if (_ftpController.TranslateFiles(files, false))
            {
                RefreshFileGridViewOfCurrentDirectory();
                MessageBox.Show("Completed.");
            }
            else
            {
                MessageBox.Show("Failded Download.");
            }
        }

        // Called when changed path on explorerTree
        private void explorerTree_PathChanged(object sender, EventArgs e)
        {
            CurrentDirectory = explorerTree.SelectedPath;
            RefreshFileGridViewOfCurrentDirectory();
        }
    }
}
