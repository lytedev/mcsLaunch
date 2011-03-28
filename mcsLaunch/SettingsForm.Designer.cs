namespace mcsLaunch
{
    partial class SettingsForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSetup = new System.Windows.Forms.Button();
            this.chkRemUser = new System.Windows.Forms.CheckBox();
            this.chkRemPass = new System.Windows.Forms.CheckBox();
            this.txtLauncher = new System.Windows.Forms.TextBox();
            this.lblLauncher = new System.Windows.Forms.Label();
            this.lblOldLaunch = new System.Windows.Forms.Label();
            this.txtOldLaunch = new System.Windows.Forms.TextBox();
            this.chkUseOldLaunch = new System.Windows.Forms.CheckBox();
            this.chkCloseOnLaunch = new System.Windows.Forms.CheckBox();
            this.lstServers = new System.Windows.Forms.ListBox();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.lblNickname = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.chkLaunchOnStartup = new System.Windows.Forms.CheckBox();
            this.chkNotchBlog = new System.Windows.Forms.CheckBox();
            this.txtToShow = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(220, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 30;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnSetup);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 338);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 53);
            this.panel1.TabIndex = 11;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(58, 11);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.TabIndex = 32;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSetup
            // 
            this.btnSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetup.Location = new System.Drawing.Point(139, 11);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(75, 30);
            this.btnSetup.TabIndex = 31;
            this.btnSetup.Text = "&Setup";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // chkRemUser
            // 
            this.chkRemUser.AutoSize = true;
            this.chkRemUser.Location = new System.Drawing.Point(12, 12);
            this.chkRemUser.Name = "chkRemUser";
            this.chkRemUser.Size = new System.Drawing.Size(140, 19);
            this.chkRemUser.TabIndex = 0;
            this.chkRemUser.Text = "Remember &Username";
            this.chkRemUser.UseVisualStyleBackColor = true;
            this.chkRemUser.CheckedChanged += new System.EventHandler(this.chkRemUser_CheckedChanged);
            // 
            // chkRemPass
            // 
            this.chkRemPass.AutoSize = true;
            this.chkRemPass.Location = new System.Drawing.Point(160, 12);
            this.chkRemPass.Name = "chkRemPass";
            this.chkRemPass.Size = new System.Drawing.Size(137, 19);
            this.chkRemPass.TabIndex = 1;
            this.chkRemPass.Text = "Remember &Password";
            this.chkRemPass.UseVisualStyleBackColor = true;
            this.chkRemPass.CheckedChanged += new System.EventHandler(this.chkRemPass_CheckedChanged);
            // 
            // txtLauncher
            // 
            this.txtLauncher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLauncher.Location = new System.Drawing.Point(104, 37);
            this.txtLauncher.Name = "txtLauncher";
            this.txtLauncher.ReadOnly = true;
            this.txtLauncher.Size = new System.Drawing.Size(191, 23);
            this.txtLauncher.TabIndex = 3;
            // 
            // lblLauncher
            // 
            this.lblLauncher.Location = new System.Drawing.Point(12, 37);
            this.lblLauncher.Name = "lblLauncher";
            this.lblLauncher.Size = new System.Drawing.Size(86, 23);
            this.lblLauncher.TabIndex = 2;
            this.lblLauncher.Text = "&Launcher:";
            this.lblLauncher.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOldLaunch
            // 
            this.lblOldLaunch.Location = new System.Drawing.Point(12, 66);
            this.lblOldLaunch.Name = "lblOldLaunch";
            this.lblOldLaunch.Size = new System.Drawing.Size(86, 23);
            this.lblOldLaunch.TabIndex = 4;
            this.lblOldLaunch.Text = "&Old Launcher:";
            this.lblOldLaunch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOldLaunch
            // 
            this.txtOldLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldLaunch.Location = new System.Drawing.Point(104, 66);
            this.txtOldLaunch.Name = "txtOldLaunch";
            this.txtOldLaunch.ReadOnly = true;
            this.txtOldLaunch.Size = new System.Drawing.Size(191, 23);
            this.txtOldLaunch.TabIndex = 5;
            // 
            // chkUseOldLaunch
            // 
            this.chkUseOldLaunch.AutoSize = true;
            this.chkUseOldLaunch.Location = new System.Drawing.Point(12, 95);
            this.chkUseOldLaunch.Name = "chkUseOldLaunch";
            this.chkUseOldLaunch.Size = new System.Drawing.Size(119, 19);
            this.chkUseOldLaunch.TabIndex = 12;
            this.chkUseOldLaunch.Text = "Use Old L&auncher";
            this.chkUseOldLaunch.UseVisualStyleBackColor = true;
            // 
            // chkCloseOnLaunch
            // 
            this.chkCloseOnLaunch.AutoSize = true;
            this.chkCloseOnLaunch.Location = new System.Drawing.Point(12, 120);
            this.chkCloseOnLaunch.Name = "chkCloseOnLaunch";
            this.chkCloseOnLaunch.Size = new System.Drawing.Size(178, 19);
            this.chkCloseOnLaunch.TabIndex = 13;
            this.chkCloseOnLaunch.Text = "Close &mcsLaunch on Launch";
            this.chkCloseOnLaunch.UseVisualStyleBackColor = true;
            // 
            // lstServers
            // 
            this.lstServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstServers.FormattingEnabled = true;
            this.lstServers.IntegralHeight = false;
            this.lstServers.ItemHeight = 15;
            this.lstServers.Location = new System.Drawing.Point(12, 200);
            this.lstServers.Name = "lstServers";
            this.lstServers.Size = new System.Drawing.Size(283, 74);
            this.lstServers.TabIndex = 14;
            this.lstServers.SelectedIndexChanged += new System.EventHandler(this.lstServers_SelectedIndexChanged);
            // 
            // txtNickname
            // 
            this.txtNickname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNickname.Location = new System.Drawing.Point(82, 309);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(132, 23);
            this.txtNickname.TabIndex = 18;
            this.txtNickname.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtServer_KeyUp);
            // 
            // lblNickname
            // 
            this.lblNickname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNickname.Location = new System.Drawing.Point(12, 309);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(64, 23);
            this.lblNickname.TabIndex = 17;
            this.lblNickname.Text = "&Nickname:";
            this.lblNickname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblServer
            // 
            this.lblServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServer.Location = new System.Drawing.Point(12, 280);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(64, 23);
            this.lblServer.TabIndex = 15;
            this.lblServer.Text = "S&erver IP:";
            this.lblServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.Location = new System.Drawing.Point(82, 280);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(132, 23);
            this.txtServer.TabIndex = 16;
            this.txtServer.TextChanged += new System.EventHandler(this.txtServer_TextChanged);
            this.txtServer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtServer_KeyUp);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(220, 309);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Sa&ve/Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(220, 280);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 19;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // chkLaunchOnStartup
            // 
            this.chkLaunchOnStartup.AutoSize = true;
            this.chkLaunchOnStartup.Location = new System.Drawing.Point(12, 145);
            this.chkLaunchOnStartup.Name = "chkLaunchOnStartup";
            this.chkLaunchOnStartup.Size = new System.Drawing.Size(122, 19);
            this.chkLaunchOnStartup.TabIndex = 21;
            this.chkLaunchOnStartup.Text = "Launc&h on startup";
            this.chkLaunchOnStartup.UseVisualStyleBackColor = true;
            this.chkLaunchOnStartup.CheckedChanged += new System.EventHandler(this.chkLaunchOnStartup_CheckedChanged);
            // 
            // chkNotchBlog
            // 
            this.chkNotchBlog.AutoSize = true;
            this.chkNotchBlog.Location = new System.Drawing.Point(12, 170);
            this.chkNotchBlog.Name = "chkNotchBlog";
            this.chkNotchBlog.Size = new System.Drawing.Size(157, 19);
            this.chkNotchBlog.TabIndex = 22;
            this.chkNotchBlog.Text = "Show Notch\'s &blog posts";
            this.chkNotchBlog.UseVisualStyleBackColor = true;
            this.chkNotchBlog.CheckedChanged += new System.EventHandler(this.chkNotchBlog_CheckedChanged);
            // 
            // txtToShow
            // 
            this.txtToShow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToShow.Location = new System.Drawing.Point(175, 171);
            this.txtToShow.Name = "txtToShow";
            this.txtToShow.Size = new System.Drawing.Size(120, 23);
            this.txtToShow.TabIndex = 23;
            this.txtToShow.Text = "5";
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(307, 391);
            this.Controls.Add(this.txtToShow);
            this.Controls.Add(this.chkNotchBlog);
            this.Controls.Add(this.chkLaunchOnStartup);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNickname);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblNickname);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lstServers);
            this.Controls.Add(this.chkCloseOnLaunch);
            this.Controls.Add(this.chkUseOldLaunch);
            this.Controls.Add(this.txtOldLaunch);
            this.Controls.Add(this.lblOldLaunch);
            this.Controls.Add(this.lblLauncher);
            this.Controls.Add(this.txtLauncher);
            this.Controls.Add(this.chkRemPass);
            this.Controls.Add(this.chkRemUser);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(315, 367);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mcsLaunch Settings";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkRemUser;
        private System.Windows.Forms.CheckBox chkRemPass;
        private System.Windows.Forms.TextBox txtLauncher;
        private System.Windows.Forms.Label lblLauncher;
        private System.Windows.Forms.Label lblOldLaunch;
        private System.Windows.Forms.TextBox txtOldLaunch;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.CheckBox chkUseOldLaunch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox chkCloseOnLaunch;
        private System.Windows.Forms.ListBox lstServers;
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtNickname;
        private System.Windows.Forms.CheckBox chkLaunchOnStartup;
        private System.Windows.Forms.CheckBox chkNotchBlog;
        private System.Windows.Forms.TextBox txtToShow;
    }
}

