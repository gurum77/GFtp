﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.ComponentModel;

namespace GFtp
{
    // ftp address class
    class FtpAddress
    {
        public FtpAddress()
        {
            Address = "";
            Port = 21;
            Path = "";
        }

        public string Address { get; set; }
        public string Path { get; set; }
        public int Port { get; set; }

        // Get full address of ftp
        public string GetFullAddress()
        {
            string fullAddress  = Address;
            if (Port != 0)
                fullAddress = fullAddress + ":" + Port.ToString();
            if (Path != "")
                fullAddress = fullAddress + "/" + Path;


            return fullAddress;
        }
        
    }

    class FtpController
    {
        //  _ftpAddress  = @"ftp://ftp.novell.com";
        public FtpAddress Ftp { get; set; }
        public string ID { get; private set; }
        public string Password { get; private set; }
        public bool UsePassive { get; set; }
        public System.Windows.Forms.ProgressBar _progressBar    = null;

        // When the Form1 is loaded, display directory list to directoryTreeView control.
        public string CurrentDirectory { get; set; }

        // This property is if current behavior is upload or download.
        public bool Upload { get; set; }

        // Current translating file.
        public string CurrentTranslatingFile { get; set; }

        // Constructor
        public FtpController()
        {
            CurrentDirectory = @"c:\";
            UsePassive = true;
            Ftp = new FtpAddress();
        }

        // constructor of FtpController
        public void Init(string ftpAddress, int port, string ftpPath, bool usePassive, string id, string password, System.Windows.Forms.ProgressBar progressBar)
        {
            Ftp.Address = ftpAddress;
            Ftp.Port = port;
            Ftp.Path = ftpPath;

            UsePassive  = usePassive;

            ID = id;
            Password = password;

            _progressBar = progressBar;
        }

        // Creates a FtpWebRequest without method like.
        private FtpWebRequest CreateFtpWebRequest(Uri ftpUri)
        {
            FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create(ftpUri);
            ftpReq.UsePassive = UsePassive;
            ftpReq.Credentials = new NetworkCredential(ID, Password);
            ftpReq.Timeout = 30000; // 30 seconds timeout

            return ftpReq;
        }
        // Renames file in ftp
        public bool RenameFile(string oldFileName, string newFileName)
        {
            try
            {
                Uri ftpUri = new Uri(Ftp.GetFullAddress() + "/" + oldFileName);
                FtpWebRequest ftpReq = CreateFtpWebRequest(ftpUri);
                ftpReq.Method = WebRequestMethods.Ftp.Rename;
                ftpReq.RenameTo = newFileName;

                FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();
                ftpRes.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

            return true;
        }

        // Deletes files in ftp
        public bool DeleteFiles(string[] files)
        {
            try
            {
                foreach (var fileName in files)
                {
                    Uri ftpUri = new Uri(Ftp.GetFullAddress() + "/" + fileName);
                    FtpWebRequest ftpReq = CreateFtpWebRequest(ftpUri);
                    ftpReq.Method = WebRequestMethods.Ftp.DeleteFile;

                    FtpWebResponse ftpRes = (FtpWebResponse)ftpReq.GetResponse();
                    ftpRes.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }

        // Translate files from local to ftp or from ftp to local
        public bool TranslateFiles(string[] files, BackgroundWorker worker)
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
            wc.BaseAddress = Ftp.GetFullAddress();
            
            if (ID != "" && Password != "")
            {
                wc.Credentials = new NetworkCredential(ID, Password);
            }

            try
            {
                int percent = 0;
                int gap = 100 / files.Length;
                foreach (string filename in files)
                {
                    string pathName = Path.Combine(CurrentDirectory, filename);
                    string ftpPathName = wc.BaseAddress + "/" + filename;

                    // Sets the CurrentTranslatingFile
                    CurrentTranslatingFile = filename;

                    // increment progress bar
                    if(_progressBar != null)
                        _progressBar.PerformStep();

                    // background work report process setting
                    if (worker != null)
                    {
                        percent += gap;
                        worker.ReportProgress(percent);

                        if (worker.CancellationPending == true)
                        {
                            break;
                        }
                    }

                    // upload
                    if (Upload)
                    {
                        wc.UploadFile(ftpPathName, pathName);
                    }
                    // download
                    else
                    {
                        wc.DownloadFile(ftpPathName, pathName);
                    }
                }
            }
            catch(System.Exception e)
            {
                MessageBox.Show(e.ToString());

                return false;
            }

            return true;
        }

        // Get all files on ftp root directory
        public GridFileInfo[] GetAllGridFileInfosFromFtp()
        {
            return GetAllGridFileInfosFromFtp(Ftp.GetFullAddress(), ID, Password);
        }

        private GridFileInfo[] GetAllGridFileInfosFromFtp(string ftpAddr, string id, string password)
        {
            try
            {
                Uri ftpUri = new Uri(ftpAddr);
                FtpWebRequest ftpReq = CreateFtpWebRequest(ftpUri);
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
