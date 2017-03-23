using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace GFtp
{
    class FtpController
    {
        //  _ftpAddress  = @"ftp://ftp.novell.com";
        public string FtpAddress { get; set; }
        public int Port { get; set; }
        public string ID { get; private set; }
        public string Password { get; private set; }
        public System.Windows.Forms.ProgressBar _progressBar    = null;

        // When the Form1 is loaded, display directory list to directoryTreeView control.
        public string CurrentDirectory { get; set; }

        // Constructor
        public FtpController()
        {
            CurrentDirectory = @"c:\";
        }

        // constructor of FtpController
        public void Init(string ftpAddress, string id, string password, System.Windows.Forms.ProgressBar progressBar)
        {
            FtpAddress = ftpAddress;
            ID = id;
            Password = password;

            _progressBar = progressBar;
        }

        // Translate files from local to ftp or from ftp to local
        public bool TranslateFiles(string[] files, bool IsUpload)
        {
            // Set a progressbar
            if(_progressBar != null)
            {
                _progressBar.Style = ProgressBarStyle.Continuous;
                _progressBar.Minimum = 0;
                _progressBar.Maximum = files.Length;
                _progressBar.Step = 1;
                _progressBar.Value = 0;
            }
            


            // connect ftp
            WebClient wc = new WebClient { Proxy = null };
            wc.BaseAddress = FtpAddress;
            if (ID != "" && Password != "")
            {
                wc.Credentials = new NetworkCredential(ID, Password);
            }

            try
            {
                foreach (string filename in files)
                {
                    string pathName = Path.Combine(CurrentDirectory, filename);
                    string ftpPathName = FtpAddress + "/" + filename;

                    // increment progress bar
                    if(_progressBar != null)
                        _progressBar.PerformStep();

                    // upload
                    if (IsUpload)
                    {
                        wc.UploadFile(ftpPathName, pathName);
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

        // Get all files on ftp root directory
        public GridFileInfo[] GetAllGridFileInfosFromFtp()
        {
            return GetAllGridFileInfosFromFtp(FtpAddress, ID, Password);
        }

        private GridFileInfo[] GetAllGridFileInfosFromFtp(string ftpAddr, string id, string password)
        {
            try
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
            catch
            {
                MessageBox.Show("Can't access to FTP.\n1. Check the FTP address.\n2. Check ID and P/D.");

                GridFileInfo[] gridFileInfos = new GridFileInfo[0];

                return gridFileInfos;
            }

        }
    }
}
