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
            this.grpServer = new System.Windows.Forms.GroupBox();
            this.btnAddServer = new System.Windows.Forms.Button();
            this.btnDeleteServer = new System.Windows.Forms.Button();
            this.btnSaveServer = new System.Windows.Forms.Button();
            this.lstServerList = new System.Windows.Forms.ListBox();
            this.txtServerConnectionString = new System.Windows.Forms.TextBox();
            this.txtServerPath = new System.Windows.Forms.TextBox();
            this.lblServerConnectionString = new System.Windows.Forms.Label();
            this.lblServerPath = new System.Windows.Forms.Label();
            this.grpClient = new System.Windows.Forms.GroupBox();
            this.lstClientList = new System.Windows.Forms.ListBox();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.btnSaveClient = new System.Windows.Forms.Button();
            this.optTSClientNo = new System.Windows.Forms.RadioButton();
            this.optTSClientYes = new System.Windows.Forms.RadioButton();
            this.txtClientPath = new System.Windows.Forms.TextBox();
            this.lblClientTSClient = new System.Windows.Forms.Label();
            this.lblClientPath = new System.Windows.Forms.Label();
            this.grpServer.SuspendLayout();
            this.grpClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpServer
            // 
            this.grpServer.Controls.Add(this.btnAddServer);
            this.grpServer.Controls.Add(this.btnDeleteServer);
            this.grpServer.Controls.Add(this.btnSaveServer);
            this.grpServer.Controls.Add(this.lstServerList);
            this.grpServer.Controls.Add(this.txtServerConnectionString);
            this.grpServer.Controls.Add(this.txtServerPath);
            this.grpServer.Controls.Add(this.lblServerConnectionString);
            this.grpServer.Controls.Add(this.lblServerPath);
            this.grpServer.Location = new System.Drawing.Point(12, 12);
            this.grpServer.Name = "grpServer";
            this.grpServer.Size = new System.Drawing.Size(742, 183);
            this.grpServer.TabIndex = 4;
            this.grpServer.TabStop = false;
            this.grpServer.Text = "Server";
            // 
            // btnAddServer
            // 
            this.btnAddServer.Location = new System.Drawing.Point(6, 154);
            this.btnAddServer.Name = "btnAddServer";
            this.btnAddServer.Size = new System.Drawing.Size(75, 23);
            this.btnAddServer.TabIndex = 11;
            this.btnAddServer.Text = "&Neu";
            this.btnAddServer.UseVisualStyleBackColor = true;
            this.btnAddServer.Click += new System.EventHandler(this.btnAddServer_Click);
            // 
            // btnDeleteServer
            // 
            this.btnDeleteServer.Enabled = false;
            this.btnDeleteServer.Location = new System.Drawing.Point(168, 154);
            this.btnDeleteServer.Name = "btnDeleteServer";
            this.btnDeleteServer.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteServer.TabIndex = 10;
            this.btnDeleteServer.Text = "&Löschen";
            this.btnDeleteServer.UseVisualStyleBackColor = true;
            this.btnDeleteServer.Click += new System.EventHandler(this.btnDeleteServer_Click);
            // 
            // btnSaveServer
            // 
            this.btnSaveServer.Enabled = false;
            this.btnSaveServer.Location = new System.Drawing.Point(87, 154);
            this.btnSaveServer.Name = "btnSaveServer";
            this.btnSaveServer.Size = new System.Drawing.Size(75, 23);
            this.btnSaveServer.TabIndex = 9;
            this.btnSaveServer.Text = "&Speichern";
            this.btnSaveServer.UseVisualStyleBackColor = true;
            this.btnSaveServer.Click += new System.EventHandler(this.btnSaveServer_Click);
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
            this.txtServerConnectionString.TextChanged += new System.EventHandler(this.txtServer_TextChanged);
            // 
            // txtServerPath
            // 
            this.txtServerPath.Location = new System.Drawing.Point(6, 37);
            this.txtServerPath.Name = "txtServerPath";
            this.txtServerPath.Size = new System.Drawing.Size(390, 23);
            this.txtServerPath.TabIndex = 6;
            this.txtServerPath.TextChanged += new System.EventHandler(this.txtServer_TextChanged);
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
            this.grpClient.Controls.Add(this.lstClientList);
            this.grpClient.Controls.Add(this.btnAddClient);
            this.grpClient.Controls.Add(this.btnDeleteClient);
            this.grpClient.Controls.Add(this.btnSaveClient);
            this.grpClient.Controls.Add(this.optTSClientNo);
            this.grpClient.Controls.Add(this.optTSClientYes);
            this.grpClient.Controls.Add(this.txtClientPath);
            this.grpClient.Controls.Add(this.lblClientTSClient);
            this.grpClient.Controls.Add(this.lblClientPath);
            this.grpClient.Location = new System.Drawing.Point(12, 221);
            this.grpClient.Name = "grpClient";
            this.grpClient.Size = new System.Drawing.Size(742, 154);
            this.grpClient.TabIndex = 5;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "Client";
            // 
            // lstClientList
            // 
            this.lstClientList.FormattingEnabled = true;
            this.lstClientList.ItemHeight = 15;
            this.lstClientList.Location = new System.Drawing.Point(435, 19);
            this.lstClientList.Name = "lstClientList";
            this.lstClientList.Size = new System.Drawing.Size(301, 124);
            this.lstClientList.TabIndex = 15;
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(6, 115);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(75, 23);
            this.btnAddClient.TabIndex = 14;
            this.btnAddClient.Text = "N&eu";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // btnDeleteClient
            // 
            this.btnDeleteClient.Enabled = false;
            this.btnDeleteClient.Location = new System.Drawing.Point(168, 115);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteClient.TabIndex = 13;
            this.btnDeleteClient.Text = "Lös&chen";
            this.btnDeleteClient.UseVisualStyleBackColor = true;
            // 
            // btnSaveClient
            // 
            this.btnSaveClient.Enabled = false;
            this.btnSaveClient.Location = new System.Drawing.Point(87, 115);
            this.btnSaveClient.Name = "btnSaveClient";
            this.btnSaveClient.Size = new System.Drawing.Size(75, 23);
            this.btnSaveClient.TabIndex = 12;
            this.btnSaveClient.Text = "S&peichern";
            this.btnSaveClient.UseVisualStyleBackColor = true;
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
            this.txtClientPath.Size = new System.Drawing.Size(390, 23);
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
            this.ClientSize = new System.Drawing.Size(772, 412);
            this.Controls.Add(this.grpClient);
            this.Controls.Add(this.grpServer);
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
        private Button btnAddServer;
        private Button btnDeleteServer;
        private Button btnSaveServer;
        private ListBox lstClientList;
        private Button btnAddClient;
        private Button btnDeleteClient;
        private Button btnSaveClient;
    }
}