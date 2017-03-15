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
            this.ftpAddressTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toFtpButton = new System.Windows.Forms.Button();
            this.connectionButton = new System.Windows.Forms.Button();
            this.fromFtpButton = new System.Windows.Forms.Button();
            this.fileGridView = new System.Windows.Forms.DataGridView();
            this.ftpFileGridView = new System.Windows.Forms.DataGridView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.explorerTree = new WindowsExplorer.ExplorerTree();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ftpFileGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ftpAddressTextBox
            // 
            this.ftpAddressTextBox.Location = new System.Drawing.Point(67, 20);
            this.ftpAddressTextBox.Name = "ftpAddressTextBox";
            this.ftpAddressTextBox.Size = new System.Drawing.Size(332, 21);
            this.ftpAddressTextBox.TabIndex = 3;
            this.ftpAddressTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ftpAddressTextBox_KeyPress);
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(67, 45);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(229, 21);
            this.idTextBox.TabIndex = 4;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(67, 71);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(229, 21);
            this.passwordTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "FTP Addr.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "P/W";
            // 
            // toFtpButton
            // 
            this.toFtpButton.BackColor = System.Drawing.Color.Red;
            this.toFtpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toFtpButton.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.toFtpButton.ForeColor = System.Drawing.Color.White;
            this.toFtpButton.Location = new System.Drawing.Point(420, 287);
            this.toFtpButton.Name = "toFtpButton";
            this.toFtpButton.Size = new System.Drawing.Size(94, 27);
            this.toFtpButton.TabIndex = 10;
            this.toFtpButton.Text = "Upload";
            this.toFtpButton.UseVisualStyleBackColor = false;
            this.toFtpButton.Click += new System.EventHandler(this.UploadToFtpButton_Click);
            // 
            // connectionButton
            // 
            this.connectionButton.BackColor = System.Drawing.Color.Green;
            this.connectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectionButton.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.connectionButton.ForeColor = System.Drawing.Color.White;
            this.connectionButton.Image = ((System.Drawing.Image)(resources.GetObject("connectionButton.Image")));
            this.connectionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.connectionButton.Location = new System.Drawing.Point(302, 69);
            this.connectionButton.Name = "connectionButton";
            this.connectionButton.Size = new System.Drawing.Size(97, 25);
            this.connectionButton.TabIndex = 12;
            this.connectionButton.Text = "Connect";
            this.connectionButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.connectionButton.UseVisualStyleBackColor = false;
            this.connectionButton.Click += new System.EventHandler(this.connectionButton_Click);
            // 
            // fromFtpButton
            // 
            this.fromFtpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fromFtpButton.BackColor = System.Drawing.Color.Blue;
            this.fromFtpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fromFtpButton.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fromFtpButton.ForeColor = System.Drawing.Color.White;
            this.fromFtpButton.Location = new System.Drawing.Point(914, 287);
            this.fromFtpButton.Name = "fromFtpButton";
            this.fromFtpButton.Size = new System.Drawing.Size(94, 27);
            this.fromFtpButton.TabIndex = 13;
            this.fromFtpButton.Text = "Download";
            this.fromFtpButton.UseVisualStyleBackColor = false;
            this.fromFtpButton.Click += new System.EventHandler(this.fromFtpButton_Click);
            // 
            // fileGridView
            // 
            this.fileGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileGridView.ColumnHeadersHeight = 24;
            this.fileGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.fileGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.fileGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.fileGridView.Location = new System.Drawing.Point(420, 320);
            this.fileGridView.Name = "fileGridView";
            this.fileGridView.RowTemplate.Height = 27;
            this.fileGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.fileGridView.ShowEditingIcon = false;
            this.fileGridView.Size = new System.Drawing.Size(588, 299);
            this.fileGridView.TabIndex = 15;
            // 
            // ftpFileGridView
            // 
            this.ftpFileGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ftpFileGridView.ColumnHeadersHeight = 24;
            this.ftpFileGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ftpFileGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ftpFileGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.ftpFileGridView.Location = new System.Drawing.Point(420, 17);
            this.ftpFileGridView.Name = "ftpFileGridView";
            this.ftpFileGridView.RowTemplate.Height = 27;
            this.ftpFileGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ftpFileGridView.ShowEditingIcon = false;
            this.ftpFileGridView.Size = new System.Drawing.Size(588, 264);
            this.ftpFileGridView.TabIndex = 16;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.ForeColor = System.Drawing.Color.Black;
            this.progressBar.Location = new System.Drawing.Point(520, 287);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(388, 27);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 17;
            // 
            // explorerTree
            // 
            this.explorerTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.explorerTree.BackColor = System.Drawing.Color.White;
            this.explorerTree.Location = new System.Drawing.Point(8, 302);
            this.explorerTree.Name = "explorerTree";
            this.explorerTree.SelectedPath = "D:\\Program Files (x86)\\Microsoft Visual Studio 11.0\\Common7\\IDE";
            this.explorerTree.ShowAddressbar = true;
            this.explorerTree.ShowMyDocuments = true;
            this.explorerTree.ShowMyFavorites = true;
            this.explorerTree.ShowMyNetwork = true;
            this.explorerTree.ShowToolbar = true;
            this.explorerTree.Size = new System.Drawing.Size(406, 317);
            this.explorerTree.TabIndex = 18;
            this.explorerTree.PathChanged += new WindowsExplorer.ExplorerTree.PathChangedEventHandler(this.explorerTree_PathChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ftpAddressTextBox);
            this.groupBox1.Controls.Add(this.idTextBox);
            this.groupBox1.Controls.Add(this.passwordTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.connectionButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 106);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Site information";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 631);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ftpFileGridView);
            this.Controls.Add(this.fileGridView);
            this.Controls.Add(this.fromFtpButton);
            this.Controls.Add(this.toFtpButton);
            this.Controls.Add(this.explorerTree);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "MainForm";
            this.Text = "GFtp v1.3";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ftpFileGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ftpAddressTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button toFtpButton;
        private System.Windows.Forms.Button connectionButton;
        private System.Windows.Forms.Button fromFtpButton;
        private System.Windows.Forms.DataGridView fileGridView;
        private System.Windows.Forms.DataGridView ftpFileGridView;
        private System.Windows.Forms.ProgressBar progressBar;
        private WindowsExplorer.ExplorerTree explorerTree;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

