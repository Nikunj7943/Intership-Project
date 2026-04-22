namespace UVTECH_BIZ
{
    partial class User
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
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.txtunm = new System.Windows.Forms.TextBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.lblcustomer = new System.Windows.Forms.Label();
            this.lbladdr = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtpwd
            // 
            this.txtpwd.Location = new System.Drawing.Point(137, 79);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.Size = new System.Drawing.Size(180, 20);
            this.txtpwd.TabIndex = 1;
            // 
            // txtunm
            // 
            this.txtunm.Location = new System.Drawing.Point(138, 38);
            this.txtunm.Name = "txtunm";
            this.txtunm.Size = new System.Drawing.Size(179, 20);
            this.txtunm.TabIndex = 0;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(242, 8);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 1;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(147, 8);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 0;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // lblcustomer
            // 
            this.lblcustomer.AutoSize = true;
            this.lblcustomer.Location = new System.Drawing.Point(47, 45);
            this.lblcustomer.Name = "lblcustomer";
            this.lblcustomer.Size = new System.Drawing.Size(60, 13);
            this.lblcustomer.TabIndex = 2;
            this.lblcustomer.Text = "User Name";
            // 
            // lbladdr
            // 
            this.lbladdr.AutoSize = true;
            this.lbladdr.Location = new System.Drawing.Point(54, 82);
            this.lbladdr.Name = "lbladdr";
            this.lbladdr.Size = new System.Drawing.Size(53, 13);
            this.lbladdr.TabIndex = 3;
            this.lbladdr.Text = "Password";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtpwd);
            this.groupBox1.Controls.Add(this.txtunm);
            this.groupBox1.Controls.Add(this.lblcustomer);
            this.groupBox1.Controls.Add(this.lbladdr);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 290);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 254);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 36);
            this.panel1.TabIndex = 14;
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 290);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User";
            this.Load += new System.EventHandler(this.User_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.TextBox txtunm;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label lblcustomer;
        private System.Windows.Forms.Label lbladdr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
    }
}