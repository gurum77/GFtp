namespace GFtp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.selectDirectoyButton = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.fileGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ftpFileGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // selectDirectoyButton
            // 
            this.selectDirectoyButton.AutoSize = true;
            this.selectDirectoyButton.Image = ((System.Drawing.Image)(resources.GetObject("selectDirectoyButton.Image")));
            this.selectDirectoyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.selectDirectoyButton.Location = new System.Drawing.Point(13, 4);
            this.selectDirectoyButton.Name = "selectDirectoyButton";
            this.selectDirectoyButton.Size = new System.Drawing.Size(156, 70);
            this.selectDirectoyButton.TabIndex = 1;
            this.selectDirectoyButton.Text = "Directory";
            this.selectDirectoyButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.selectDirectoyButton.UseVisualStyleBackColor = true;
            this.selectDirectoyButton.Click += new System.EventHandler(this.selectDirectoyButton_Click);
            // 
            // ftpAddressTextBox
            // 
            this.ftpAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ftpAddressTextBox.Location = new System.Drawing.Point(563, 70);
            this.ftpAddressTextBox.Name = "ftpAddressTextBox";
            this.ftpAddressTextBox.Size = new System.Drawing.Size(327, 21);
            this.ftpAddressTextBox.TabIndex = 3;
            this.ftpAddressTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ftpAddressTextBox_KeyPress);
            // 
            // idTextBox
            // 
            this.idTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.idTextBox.Location = new System.Drawing.Point(563, 8);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(445, 21);
            this.idTextBox.TabIndex = 4;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.Location = new System.Drawing.Point(563, 39);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(445, 21);
            this.passwordTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(471, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ftp address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(471, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(471, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Password";
            // 
            // toFtpButton
            // 
            this.toFtpButton.Image = ((System.Drawing.Image)(resources.GetObject("toFtpButton.Image")));
            this.toFtpButton.Location = new System.Drawing.Point(447, 108);
            this.toFtpButton.Name = "toFtpButton";
            this.toFtpButton.Size = new System.Drawing.Size(94, 84);
            this.toFtpButton.TabIndex = 10;
            this.toFtpButton.UseVisualStyleBackColor = true;
            this.toFtpButton.Click += new System.EventHandler(this.UploadToFtpButton_Click);
            // 
            // connectionButton
            // 
            this.connectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.connectionButton.Image = ((System.Drawing.Image)(resources.GetObject("connectionButton.Image")));
            this.connectionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.connectionButton.Location = new System.Drawing.Point(896, 69);
            this.connectionButton.Name = "connectionButton";
            this.connectionButton.Size = new System.Drawing.Size(112, 29);
            this.connectionButton.TabIndex = 12;
            this.connectionButton.Text = "Connect";
            this.connectionButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.connectionButton.UseVisualStyleBackColor = true;
            this.connectionButton.Click += new System.EventHandler(this.connectionButton_Click);
            // 
            // fromFtpButton
            // 
            this.fromFtpButton.Image = ((System.Drawing.Image)(resources.GetObject("fromFtpButton.Image")));
            this.fromFtpButton.Location = new System.Drawing.Point(447, 198);
            this.fromFtpButton.Name = "fromFtpButton";
            this.fromFtpButton.Size = new System.Drawing.Size(94, 84);
            this.fromFtpButton.TabIndex = 13;
            this.fromFtpButton.UseVisualStyleBackColor = true;
            this.fromFtpButton.Click += new System.EventHandler(this.fromFtpButton_Click);
            // 
            // fileGridView
            // 
            this.fileGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fileGridView.ColumnHeadersHeight = 24;
            this.fileGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.fileGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.fileGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.fileGridView.Location = new System.Drawing.Point(12, 80);
            this.fileGridView.Name = "fileGridView";
            this.fileGridView.RowTemplate.Height = 27;
            this.fileGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.fileGridView.ShowEditingIcon = false;
            this.fileGridView.Size = new System.Drawing.Size(429, 440);
            this.fileGridView.TabIndex = 15;
            // 
            // ftpFileGridView
            // 
            this.ftpFileGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ftpFileGridView.ColumnHeadersHeight = 24;
            this.ftpFileGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ftpFileGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ftpFileGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.ftpFileGridView.Location = new System.Drawing.Point(544, 108);
            this.ftpFileGridView.Name = "ftpFileGridView";
            this.ftpFileGridView.RowTemplate.Height = 27;
            this.ftpFileGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ftpFileGridView.ShowEditingIcon = false;
            this.ftpFileGridView.Size = new System.Drawing.Size(464, 412);
            this.ftpFileGridView.TabIndex = 16;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(13, 526);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(995, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 557);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ftpFileGridView);
            this.Controls.Add(this.fileGridView);
            this.Controls.Add(this.fromFtpButton);
            this.Controls.Add(this.connectionButton);
            this.Controls.Add(this.toFtpButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.ftpAddressTextBox);
            this.Controls.Add(this.selectDirectoyButton);
            this.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "Form1";
            this.Text = "GFtp v1.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ftpFileGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button selectDirectoyButton;
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
    }
}

