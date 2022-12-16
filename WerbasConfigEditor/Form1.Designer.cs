namespace WerbasConfigEditor
{
    partial class frmConfigEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpServer = new System.Windows.Forms.GroupBox();
            this.lstServerList = new System.Windows.Forms.ListBox();
            this.txtServerConnectionString = new System.Windows.Forms.TextBox();
            this.txtServerPath = new System.Windows.Forms.TextBox();
            this.lblServerConnectionString = new System.Windows.Forms.Label();
            this.lblServerPath = new System.Windows.Forms.Label();
            this.grpClient = new System.Windows.Forms.GroupBox();
            this.optTSClientNo = new System.Windows.Forms.RadioButton();
            this.optTSClientYes = new System.Windows.Forms.RadioButton();
            this.txtClientPath = new System.Windows.Forms.TextBox();
            this.lblClientTSClient = new System.Windows.Forms.Label();
            this.lblClientPath = new System.Windows.Forms.Label();
            this.grpServer.SuspendLayout();
            this.grpClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(93, 293);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 293);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "&Löschen";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 293);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "&Neu";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // grpServer
            // 
            this.grpServer.Controls.Add(this.lstServerList);
            this.grpServer.Controls.Add(this.txtServerConnectionString);
            this.grpServer.Controls.Add(this.txtServerPath);
            this.grpServer.Controls.Add(this.lblServerConnectionString);
            this.grpServer.Controls.Add(this.lblServerPath);
            this.grpServer.Location = new System.Drawing.Point(12, 12);
            this.grpServer.Name = "grpServer";
            this.grpServer.Size = new System.Drawing.Size(742, 139);
            this.grpServer.TabIndex = 4;
            this.grpServer.TabStop = false;
            this.grpServer.Text = "Server";
            // 
            // lstServerList
            // 
            this.lstServerList.FormattingEnabled = true;
            this.lstServerList.ItemHeight = 15;
            this.lstServerList.Location = new System.Drawing.Point(435, 19);
            this.lstServerList.Name = "lstServerList";
            this.lstServerList.Size = new System.Drawing.Size(301, 109);
            this.lstServerList.TabIndex = 8;
            this.lstServerList.Click += new System.EventHandler(this.lstServerList_Click);
            // 
            // txtServerConnectionString
            // 
            this.txtServerConnectionString.Location = new System.Drawing.Point(9, 92);
            this.txtServerConnectionString.Name = "txtServerConnectionString";
            this.txtServerConnectionString.Size = new System.Drawing.Size(387, 23);
            this.txtServerConnectionString.TabIndex = 7;
            // 
            // txtServerPath
            // 
            this.txtServerPath.Location = new System.Drawing.Point(6, 37);
            this.txtServerPath.Name = "txtServerPath";
            this.txtServerPath.Size = new System.Drawing.Size(390, 23);
            this.txtServerPath.TabIndex = 6;
            // 
            // lblServerConnectionString
            // 
            this.lblServerConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServerConnectionString.AutoSize = true;
            this.lblServerConnectionString.Location = new System.Drawing.Point(6, 74);
            this.lblServerConnectionString.Name = "lblServerConnectionString";
            this.lblServerConnectionString.Size = new System.Drawing.Size(103, 15);
            this.lblServerConnectionString.TabIndex = 5;
            this.lblServerConnectionString.Text = "ConnectionString:";
            // 
            // lblServerPath
            // 
            this.lblServerPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServerPath.AutoSize = true;
            this.lblServerPath.Location = new System.Drawing.Point(6, 19);
            this.lblServerPath.Name = "lblServerPath";
            this.lblServerPath.Size = new System.Drawing.Size(34, 15);
            this.lblServerPath.TabIndex = 4;
            this.lblServerPath.Text = "Path:";
            // 
            // grpClient
            // 
            this.grpClient.Controls.Add(this.optTSClientNo);
            this.grpClient.Controls.Add(this.optTSClientYes);
            this.grpClient.Controls.Add(this.txtClientPath);
            this.grpClient.Controls.Add(this.lblClientTSClient);
            this.grpClient.Controls.Add(this.lblClientPath);
            this.grpClient.Location = new System.Drawing.Point(12, 157);
            this.grpClient.Name = "grpClient";
            this.grpClient.Size = new System.Drawing.Size(421, 110);
            this.grpClient.TabIndex = 5;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "Client";
            // 
            // optTSClientNo
            // 
            this.optTSClientNo.AutoSize = true;
            this.optTSClientNo.Location = new System.Drawing.Point(113, 72);
            this.optTSClientNo.Name = "optTSClientNo";
            this.optTSClientNo.Size = new System.Drawing.Size(50, 19);
            this.optTSClientNo.TabIndex = 8;
            this.optTSClientNo.TabStop = true;
            this.optTSClientNo.Text = "&Nein";
            this.optTSClientNo.UseVisualStyleBackColor = true;
            // 
            // optTSClientYes
            // 
            this.optTSClientYes.AutoSize = true;
            this.optTSClientYes.Location = new System.Drawing.Point(68, 72);
            this.optTSClientYes.Name = "optTSClientYes";
            this.optTSClientYes.Size = new System.Drawing.Size(35, 19);
            this.optTSClientYes.TabIndex = 7;
            this.optTSClientYes.TabStop = true;
            this.optTSClientYes.Text = "&Ja";
            this.optTSClientYes.UseVisualStyleBackColor = true;
            // 
            // txtClientPath
            // 
            this.txtClientPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientPath.Location = new System.Drawing.Point(6, 37);
            this.txtClientPath.Name = "txtClientPath";
            this.txtClientPath.Size = new System.Drawing.Size(386, 23);
            this.txtClientPath.TabIndex = 6;
            // 
            // lblClientTSClient
            // 
            this.lblClientTSClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientTSClient.AutoSize = true;
            this.lblClientTSClient.Location = new System.Drawing.Point(6, 74);
            this.lblClientTSClient.Name = "lblClientTSClient";
            this.lblClientTSClient.Size = new System.Drawing.Size(56, 15);
            this.lblClientTSClient.TabIndex = 5;
            this.lblClientTSClient.Text = "TS Client:";
            // 
            // lblClientPath
            // 
            this.lblClientPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientPath.AutoSize = true;
            this.lblClientPath.Location = new System.Drawing.Point(6, 19);
            this.lblClientPath.Name = "lblClientPath";
            this.lblClientPath.Size = new System.Drawing.Size(34, 15);
            this.lblClientPath.TabIndex = 4;
            this.lblClientPath.Text = "Path:";
            // 
            // frmConfigEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 343);
            this.Controls.Add(this.grpClient);
            this.Controls.Add(this.grpServer);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.Name = "frmConfigEditor";
            this.ShowIcon = false;
            this.Text = "Config Editor";
            this.Load += new System.EventHandler(this.frmConfigEditor_Load);
            this.grpServer.ResumeLayout(false);
            this.grpServer.PerformLayout();
            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnSave;
        private Button btnDelete;
        private Button btnAdd;
        private GroupBox grpServer;
        private Label lblServerPath;
        private TextBox txtServerConnectionString;
        private TextBox txtServerPath;
        private Label lblServerConnectionString;
        private GroupBox grpClient;
        private RadioButton optTSClientNo;
        private RadioButton optTSClientYes;
        private TextBox txtClientPath;
        private Label lblClientTSClient;
        private Label lblClientPath;
        private ListBox lstServerList;
    }
}