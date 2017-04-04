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
    public partial class MainForm : Form
    {
        ProgressForm _progressForm;
        Favorites _favorites = new Favorites();
        FtpController _ftpController = new FtpController();
        private string CurrentDirectory
        {
            get { return _ftpController.CurrentDirectory; }
            set { _ftpController.CurrentDirectory = value; }
        }
        private string FtpAddress
        {
            get { return _ftpController.Ftp.Address; }
            set { _ftpController.Ftp.Address = value; }
        }
        private string FtpPath
        {
            get { return _ftpController.Ftp.Path; }
            set { _ftpController.Ftp.Path = value; }
        }
        private int Port
        {
            get { return _ftpController.Ftp.Port; }
            set { _ftpController.Ftp.Port = value; }
        }
        private string ID
        {
            get { return _ftpController.ID; }
        }
        private string Password
        {
            get { return _ftpController.Password; }
        }

        // Get a ProgressBar for translating files.
        ProgressBar GetProgressBar()
        {
            if (_progressForm == null)
                return null;

            bool useProgressForm = true;
            if (useProgressForm)
                return _progressForm.GetProgressBar();

            return progressBar;
        }
  
        public MainForm()
        {
            InitializeComponent();
            InitControl();

            fileGridView.DoubleClick += FileGridView_DoubleClick;
            ftpFileGridView.DoubleClick += ftpFileGridView_DoubleClick;

            favoritesTreeView.LoadFavoritesItems(_favorites);
            favoritesTreeView.RefreshFavoritesItems(_favorites);
            favoritesTreeView.AfterSelect += favoritesTreeView_AfterSelect;
        }

        // Call when select node of FavoriteTreeView
        void favoritesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            FavoritesItem item  = favoritesTreeView.GetSelectedFavoritesItem(_favorites);
            if (item == null)
                return;

            string groupName = favoritesTreeView.GetSelectedFavoritesItemGroupName(_favorites);

            groupTextBox.Text = groupName;
            nameTextBox.Text = item.Name;
            ftpAddressTextBox.Text = item.Address;
            portTextBox.Text = item.Port;
            idTextBox.Text = item.ID;
            passwordTextBox.Text = item.Password;
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
                    // if can go to super directory, make ftp path to go to super directory.
                    if(FtpPath != "")
                    {
                        int lastIdx = FtpPath.LastIndexOf('/');

                        if (lastIdx > -1)
                        {
                            FtpPath = FtpPath.Substring(0, lastIdx);
                        }
                    }
                  
                }
                else
                {
                    FtpPath = FtpPath + "/" + nextPath;
                }
                
                pathTextBox.Text = FtpPath;

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
            _ftpController.Init(@"ftp://ftp.novell.com", 21, "",  "", "", null);
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

        // Shows ProgressForm on where center of main form.
        private void ShowProgressForm(bool isUpload)
        {
            _progressForm = new ProgressForm();
            _progressForm.Canceled += _progressForm_Canceled;

            // Sets to show center position of parent
            _progressForm.StartPosition = FormStartPosition.CenterScreen;

            // Shows
            _progressForm.Show();


            
        }
        // Translate files from local to ftp
        private void UploadToFtpButton_Click(object sender, EventArgs e)
        {
            // If backgroundWorker is busy then return
            if (backgroundWorker.IsBusy == true)
                return;

            // show a progress form 
            ShowProgressForm(true);

            // Start a DoWork function of background work .
            _ftpController.Upload = true;
            backgroundWorker.RunWorkerAsync();
        }

        // Connect to ftp
        private void connectionButton_Click(object sender, EventArgs e)
        {
            // ftp address has to have ftp://
            // Add a ftp:// if ftp address has no ftp://
            if(!ftpAddressTextBox.Text.StartsWith("ftp://"))
            {
                ftpAddressTextBox.Text = "ftp://" + ftpAddressTextBox.Text;
            }

            RefreshFtpFileGridViewWithCurrentInput();
        }

        // Refresh ftp file list box with current input (ftp address, id, password)
        private void RefreshFtpFileGridViewWithCurrentInput()
        {
            int port = 0;
            try
            {
                port = Convert.ToInt32(portTextBox.Text);
            }
            catch
            {

            }
           
            _ftpController.Init(ftpAddressTextBox.Text, port, pathTextBox.Text, idTextBox.Text, passwordTextBox.Text, null);
            
            // Connet to the ftp and get all file list.
            RefreshFtpFileGridView();
        }

        // Download selected files on ftp.
        private void downloadFromFtpButton_Click(object sender, EventArgs e)
        {
            // If backgroundWorker is busy then return
           if(backgroundWorker.IsBusy == true)
               return;
           
           // show a progress form 
           ShowProgressForm(false);

            // Start a DoWork function of background work .
           _ftpController.Upload = false;
           backgroundWorker.RunWorkerAsync();
        }

        // when cancel button is clicked, call this function
        void _progressForm_Canceled(object sender, EventArgs e)
        {
            if (backgroundWorker.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker.CancelAsync();

                // Close the AlertForm
                _progressForm.Close();

                RefreshFileGridViewOfCurrentDirectory();
            }
        }

        void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            _progressForm.Close();
        }

        // When progress percent is changed, call this function
        void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            // title caption
            _progressForm.Text = "Translating " + _ftpController.CurrentTranslatingFile + "..." + " " + (e.ProgressPercentage.ToString() + "%");

            // label
            _progressForm.Message = _progressForm.Text;

            // progress bar percent.
            _progressForm.ProgressValue = e.ProgressPercentage;
        }

        // The backgroundWorker for upload and download
        void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            // Get files of ftp
            string[] files;
            if(_ftpController.Upload == false)
                files   = ftpFileGridView.GetSelectedFiles();
            else
                files = fileGridView.GetSelectedFiles();

        
            // Translates files using ftpcontroler.
            // BackgroundWorker will changed percent while translating files.
            if (_ftpController.TranslateFiles(files, worker))
            {
                if(worker.CancellationPending == true)
                    MessageBox.Show("Canceled.");
                else
                    MessageBox.Show("Completed.");
            }
            else
            {
                MessageBox.Show("Failed.");
            }

            if (_ftpController.Upload == false)
                RefreshFileGridViewOfCurrentDirectory();
            else
                RefreshFtpFileGridView();
        }

        // Called when changed path on explorerTree
        private void explorerTree_PathChanged(object sender, EventArgs e)
        {
            CurrentDirectory = explorerTree.SelectedPath;
            RefreshFileGridViewOfCurrentDirectory();
        }

        // Refresh favorites tree view from memory
        private void RefreshFavoritesTreeView()
        {
            favoritesTreeView.RefreshFavoritesItems(_favorites);
        }

        // Add current input to favorites
        private void addButton_Click(object sender, EventArgs e)
        {
            // add a new item
            FavoritesItem item = new FavoritesItem();
            item.Name = nameTextBox.Text;
            item.Address = ftpAddressTextBox.Text;
            item.Port   = portTextBox.Text;
            item.ID = idTextBox.Text;
            item.Password = passwordTextBox.Text;
            _favorites.AddItem(groupTextBox.Text, item);

            // save _favorites
            favoritesTreeView.SaveFavoritesItems(_favorites);

            // refresh favorites tree view
            RefreshFavoritesTreeView();
        }

        // When clicked a delButton, delete current favorite item.
        private void delButton_Click(object sender, EventArgs e)
        {
            favoritesTreeView.DeleteSelectedFavoritesItem(_favorites);
            
            // save _favorites
            favoritesTreeView.SaveFavoritesItems(_favorites);

            RefreshFavoritesTreeView();
        }
    }
}
