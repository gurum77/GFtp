namespace GFtp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toFtpButton = new System.Windows.Forms.Button();
            this.fromFtpButton = new System.Windows.Forms.Button();
            this.fileGridView = new System.Windows.Forms.DataGridView();
            this.ftpFileGridView = new System.Windows.Forms.DataGridView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.explorerTree = new WindowsExplorer.ExplorerTree();
            this.favoritesTreeView = new System.Windows.Forms.TreeView();
            this.verticalSplitContainer = new System.Windows.Forms.SplitContainer();
            this.leftSplitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.delButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.groupTextBox = new System.Windows.Forms.TextBox();
            this.groupLabel = new System.Windows.Forms.Label();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ftpAddressTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connectionButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rightSplitContainer = new System.Windows.Forms.SplitContainer();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.fileGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ftpFileGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalSplitContainer)).BeginInit();
            this.verticalSplitContainer.Panel1.SuspendLayout();
            this.verticalSplitContainer.Panel2.SuspendLayout();
            this.verticalSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftSplitContainer)).BeginInit();
            this.leftSplitContainer.Panel1.SuspendLayout();
            this.leftSplitContainer.Panel2.SuspendLayout();
            this.leftSplitContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightSplitContainer)).BeginInit();
            this.rightSplitContainer.Panel1.SuspendLayout();
            this.rightSplitContainer.Panel2.SuspendLayout();
            this.rightSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toFtpButton
            // 
            this.toFtpButton.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.toFtpButton, "toFtpButton");
            this.toFtpButton.ForeColor = System.Drawing.Color.White;
            this.toFtpButton.Name = "toFtpButton";
            this.toFtpButton.UseVisualStyleBackColor = false;
            this.toFtpButton.Click += new System.EventHandler(this.UploadToFtpButton_Click);
            // 
            // fromFtpButton
            // 
            resources.ApplyResources(this.fromFtpButton, "fromFtpButton");
            this.fromFtpButton.BackColor = System.Drawing.Color.Blue;
            this.fromFtpButton.ForeColor = System.Drawing.Color.White;
            this.fromFtpButton.Name = "fromFtpButton";
            this.fromFtpButton.UseVisualStyleBackColor = false;
            this.fromFtpButton.Click += new System.EventHandler(this.downloadFromFtpButton_Click);
            // 
            // fileGridView
            // 
            resources.ApplyResources(this.fileGridView, "fileGridView");
            this.fileGridView.BackgroundColor = System.Drawing.Color.White;
            this.fileGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.fileGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.fileGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.fileGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.fileGridView.Name = "fileGridView";
            this.fileGridView.RowTemplate.Height = 27;
            this.fileGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.fileGridView.ShowEditingIcon = false;
            // 
            // ftpFileGridView
            // 
            resources.ApplyResources(this.ftpFileGridView, "ftpFileGridView");
            this.ftpFileGridView.BackgroundColor = System.Drawing.Color.White;
            this.ftpFileGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ftpFileGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ftpFileGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ftpFileGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ftpFileGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.ftpFileGridView.Name = "ftpFileGridView";
            this.ftpFileGridView.RowTemplate.Height = 27;
            this.ftpFileGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ftpFileGridView.ShowEditingIcon = false;
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.ForeColor = System.Drawing.Color.Black;
            this.progressBar.Name = "progressBar";
            this.progressBar.Step = 1;
            // 
            // explorerTree
            // 
            resources.ApplyResources(this.explorerTree, "explorerTree");
            this.explorerTree.BackColor = System.Drawing.Color.White;
            this.explorerTree.Name = "explorerTree";
            this.explorerTree.SelectedPath = "C:\\Program Files (x86)\\Microsoft Visual Studio 14.0\\Common7\\IDE";
            this.explorerTree.ShowAddressbar = true;
            this.explorerTree.ShowMyDocuments = true;
            this.explorerTree.ShowMyFavorites = true;
            this.explorerTree.ShowMyNetwork = true;
            this.explorerTree.ShowToolbar = true;
            this.explorerTree.PathChanged += new WindowsExplorer.ExplorerTree.PathChangedEventHandler(this.explorerTree_PathChanged);
            // 
            // favoritesTreeView
            // 
            resources.ApplyResources(this.favoritesTreeView, "favoritesTreeView");
            this.favoritesTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.favoritesTreeView.Name = "favoritesTreeView";
            this.favoritesTreeView.ShowNodeToolTips = true;
            // 
            // verticalSplitContainer
            // 
            resources.ApplyResources(this.verticalSplitContainer, "verticalSplitContainer");
            this.verticalSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.verticalSplitContainer.Name = "verticalSplitContainer";
            // 
            // verticalSplitContainer.Panel1
            // 
            this.verticalSplitContainer.Panel1.Controls.Add(this.leftSplitContainer);
            // 
            // verticalSplitContainer.Panel2
            // 
            this.verticalSplitContainer.Panel2.Controls.Add(this.rightSplitContainer);
            // 
            // leftSplitContainer
            // 
            resources.ApplyResources(this.leftSplitContainer, "leftSplitContainer");
            this.leftSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftSplitContainer.Name = "leftSplitContainer";
            // 
            // leftSplitContainer.Panel1
            // 
            this.leftSplitContainer.Panel1.Controls.Add(this.favoritesTreeView);
            this.leftSplitContainer.Panel1.Controls.Add(this.groupBox1);
            // 
            // leftSplitContainer.Panel2
            // 
            this.leftSplitContainer.Panel2.Controls.Add(this.explorerTree);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.pathTextBox);
            this.groupBox1.Controls.Add(this.delButton);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.nameLabel);
            this.groupBox1.Controls.Add(this.groupTextBox);
            this.groupBox1.Controls.Add(this.groupLabel);
            this.groupBox1.Controls.Add(this.portTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ftpAddressTextBox);
            this.groupBox1.Controls.Add(this.idTextBox);
            this.groupBox1.Controls.Add(this.passwordTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.connectionButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // pathTextBox
            // 
            resources.ApplyResources(this.pathTextBox, "pathTextBox");
            this.pathTextBox.Name = "pathTextBox";
            // 
            // delButton
            // 
            this.delButton.BackColor = System.Drawing.Color.Goldenrod;
            resources.ApplyResources(this.delButton, "delButton");
            this.delButton.ForeColor = System.Drawing.Color.White;
            this.delButton.Name = "delButton";
            this.delButton.UseVisualStyleBackColor = false;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // nameTextBox
            // 
            resources.ApplyResources(this.nameTextBox, "nameTextBox");
            this.nameTextBox.Name = "nameTextBox";
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Goldenrod;
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Name = "addButton";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // nameLabel
            // 
            resources.ApplyResources(this.nameLabel, "nameLabel");
            this.nameLabel.Name = "nameLabel";
            // 
            // groupTextBox
            // 
            resources.ApplyResources(this.groupTextBox, "groupTextBox");
            this.groupTextBox.Name = "groupTextBox";
            // 
            // groupLabel
            // 
            resources.ApplyResources(this.groupLabel, "groupLabel");
            this.groupLabel.Name = "groupLabel";
            // 
            // portTextBox
            // 
            resources.ApplyResources(this.portTextBox, "portTextBox");
            this.portTextBox.Name = "portTextBox";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // ftpAddressTextBox
            // 
            resources.ApplyResources(this.ftpAddressTextBox, "ftpAddressTextBox");
            this.ftpAddressTextBox.Name = "ftpAddressTextBox";
            this.ftpAddressTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ftpAddressTextBox_KeyPress);
            // 
            // idTextBox
            // 
            resources.ApplyResources(this.idTextBox, "idTextBox");
            this.idTextBox.Name = "idTextBox";
            // 
            // passwordTextBox
            // 
            resources.ApplyResources(this.passwordTextBox, "passwordTextBox");
            this.passwordTextBox.Name = "passwordTextBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // connectionButton
            // 
            resources.ApplyResources(this.connectionButton, "connectionButton");
            this.connectionButton.BackColor = System.Drawing.Color.Green;
            this.connectionButton.ForeColor = System.Drawing.Color.White;
            this.connectionButton.Name = "connectionButton";
            this.connectionButton.UseVisualStyleBackColor = false;
            this.connectionButton.Click += new System.EventHandler(this.connectionButton_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // rightSplitContainer
            // 
            resources.ApplyResources(this.rightSplitContainer, "rightSplitContainer");
            this.rightSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightSplitContainer.Name = "rightSplitContainer";
            // 
            // rightSplitContainer.Panel1
            // 
            this.rightSplitContainer.Panel1.Controls.Add(this.ftpFileGridView);
            // 
            // rightSplitContainer.Panel2
            // 
            this.rightSplitContainer.Panel2.Controls.Add(this.fileGridView);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.fromFtpButton);
            this.Controls.Add(this.toFtpButton);
            this.Controls.Add(this.verticalSplitContainer);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ftpFileGridView)).EndInit();
            this.verticalSplitContainer.Panel1.ResumeLayout(false);
            this.verticalSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.verticalSplitContainer)).EndInit();
            this.verticalSplitContainer.ResumeLayout(false);
            this.leftSplitContainer.Panel1.ResumeLayout(false);
            this.leftSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leftSplitContainer)).EndInit();
            this.leftSplitContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.rightSplitContainer.Panel1.ResumeLayout(false);
            this.rightSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightSplitContainer)).EndInit();
            this.rightSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

     

        

        // When favorites tree view lost focus, initialize all controls state.
        private void FavoritesTreeView_LostFocus(object sender, System.EventArgs e)
        {
            InitControl();
        }

        // When favorites tree view get focus, initialize all contfrols state.
        private void FavoritesTreeView_GotFocus(object sender, System.EventArgs e)
        {
            InitControl();
        }

        // Initialize all control by current state.
        private void InitControl()
        {
            // When favorites tree view is focused, del button is enabled and add button is disabled.
            // When favorites tree view is not focused, del button is disabled.
            if(favoritesTreeView.Focused)
            {
                delButton.Enabled = true;
                addButton.Enabled = false;
            }
            else
            {
                delButton.Enabled = true;
                addButton.Enabled = true;
            } 
        }

        #endregion
        private System.Windows.Forms.Button toFtpButton;
        private System.Windows.Forms.Button fromFtpButton;
        private System.Windows.Forms.DataGridView fileGridView;
        private System.Windows.Forms.DataGridView ftpFileGridView;
        private System.Windows.Forms.ProgressBar progressBar;
        private WindowsExplorer.ExplorerTree explorerTree;
        private System.Windows.Forms.TreeView favoritesTreeView;
        private System.Windows.Forms.SplitContainer verticalSplitContainer;
        private System.Windows.Forms.SplitContainer rightSplitContainer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button connectionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox ftpAddressTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label groupLabel;
        private System.Windows.Forms.TextBox groupTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer leftSplitContainer;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}

