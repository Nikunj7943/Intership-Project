namespace UVTECH_BIZ
{
    partial class frmlogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmlogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.linkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.chkRememberMe = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.lblDateTime);
            this.panel1.Controls.Add(this.panelLogin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 450);
            this.panel1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(748, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "ToolStripStatusLabel";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(64, 17);
            this.toolStripStatusLabel1.Text = "v1.25.364.0";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(170, 17);
            this.toolStripStatusLabel2.Text = "CONNECTED: LIVE SERVER ****";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(164, 17);
            this.toolStripStatusLabel3.Text = "Powered By UVTECH GLOBAL";
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDateTime.Location = new System.Drawing.Point(611, 13);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(7, 16);
            this.lblDateTime.TabIndex = 2;
            this.lblDateTime.Text = "\r\n";
            // 
            // panelLogin
            // 
            this.panelLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelLogin.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.linkForgotPassword);
            this.panelLogin.Controls.Add(this.chkRememberMe);
            this.panelLogin.Controls.Add(this.txtPassword);
            this.panelLogin.Controls.Add(this.txtUsername);
            this.panelLogin.Controls.Add(this.password);
            this.panelLogin.Controls.Add(this.Username);
            this.panelLogin.Controls.Add(this.pictureBoxLogo);
            this.panelLogin.Location = new System.Drawing.Point(89, 64);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(585, 300);
            this.panelLogin.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(372, 204);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // linkForgotPassword
            // 
            this.linkForgotPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkForgotPassword.AutoSize = true;
            this.linkForgotPassword.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.linkForgotPassword.Location = new System.Drawing.Point(260, 249);
            this.linkForgotPassword.Name = "linkForgotPassword";
            this.linkForgotPassword.Size = new System.Drawing.Size(118, 13);
            this.linkForgotPassword.TabIndex = 6;
            this.linkForgotPassword.TabStop = true;
            this.linkForgotPassword.Text = "FORGOT PASSWORD";
            // 
            // chkRememberMe
            // 
            this.chkRememberMe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRememberMe.AutoSize = true;
            this.chkRememberMe.Location = new System.Drawing.Point(236, 208);
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.Size = new System.Drawing.Size(107, 17);
            this.chkRememberMe.TabIndex = 5;
            this.chkRememberMe.Text = "REMEMBER ME";
            this.chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtPassword.Location = new System.Drawing.Point(331, 168);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(222, 25);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Tag = "";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtUsername.Location = new System.Drawing.Point(331, 123);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(222, 25);
            this.txtUsername.TabIndex = 3;
            // 
            // password
            // 
            this.password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.password.AutoSize = true;
            this.password.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.password.Location = new System.Drawing.Point(234, 168);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(78, 17);
            this.password.TabIndex = 2;
            this.password.Text = "PASSWORD:";
            // 
            // Username
            // 
            this.Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username.Location = new System.Drawing.Point(233, 123);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(79, 17);
            this.Username.TabIndex = 1;
            this.Username.Text = "USERNAME:";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.ErrorImage")));
            this.pictureBoxLogo.ImageLocation = "Center Top";
            this.pictureBoxLogo.Location = new System.Drawing.Point(25, 119);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(185, 106);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // frmlogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(748, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmlogin";
            this.Text = "UVTECH BIZ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmlogin_Load);
            this.Resize += new System.EventHandler(this.frmlogin_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel linkForgotPassword;
        private System.Windows.Forms.CheckBox chkRememberMe;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

