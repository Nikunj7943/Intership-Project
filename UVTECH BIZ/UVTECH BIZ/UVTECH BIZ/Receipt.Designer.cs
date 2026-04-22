namespace UVTECH_BIZ
{
    partial class Receipt
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
            this.btnsave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblcustomer = new System.Windows.Forms.Label();
            this.lbladdr = new System.Windows.Forms.Label();
            this.lblcity = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbcustomer = new System.Windows.Forms.ComboBox();
            this.txtreceiptdate = new System.Windows.Forms.DateTimePicker();
            this.txtxustid = new System.Windows.Forms.TextBox();
            this.txttotalamount = new System.Windows.Forms.TextBox();
            this.txtreceiptno = new System.Windows.Forms.TextBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(180, 7);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 1;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Total Amount";
            // 
            // lblcustomer
            // 
            this.lblcustomer.AutoSize = true;
            this.lblcustomer.Location = new System.Drawing.Point(69, 35);
            this.lblcustomer.Name = "lblcustomer";
            this.lblcustomer.Size = new System.Drawing.Size(61, 13);
            this.lblcustomer.TabIndex = 2;
            this.lblcustomer.Text = "Receipt No";
            // 
            // lbladdr
            // 
            this.lbladdr.AutoSize = true;
            this.lbladdr.Location = new System.Drawing.Point(60, 70);
            this.lbladdr.Name = "lbladdr";
            this.lbladdr.Size = new System.Drawing.Size(70, 13);
            this.lbladdr.TabIndex = 3;
            this.lbladdr.Text = "Receipt Date";
            // 
            // lblcity
            // 
            this.lblcity.AutoSize = true;
            this.lblcity.Location = new System.Drawing.Point(60, 105);
            this.lblcity.Name = "lblcity";
            this.lblcity.Size = new System.Drawing.Size(82, 13);
            this.lblcity.TabIndex = 4;
            this.lblcity.Text = "Customer Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbcustomer);
            this.groupBox1.Controls.Add(this.txtreceiptdate);
            this.groupBox1.Controls.Add(this.txtxustid);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txttotalamount);
            this.groupBox1.Controls.Add(this.lblcustomer);
            this.groupBox1.Controls.Add(this.txtreceiptno);
            this.groupBox1.Controls.Add(this.lbladdr);
            this.groupBox1.Controls.Add(this.lblcity);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 286);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbcustomer
            // 
            this.cmbcustomer.FormattingEnabled = true;
            this.cmbcustomer.Location = new System.Drawing.Point(143, 102);
            this.cmbcustomer.Name = "cmbcustomer";
            this.cmbcustomer.Size = new System.Drawing.Size(189, 21);
            this.cmbcustomer.TabIndex = 2;
            this.cmbcustomer.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtreceiptdate
            // 
            this.txtreceiptdate.CustomFormat = "01/01/2025";
            this.txtreceiptdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtreceiptdate.Location = new System.Drawing.Point(143, 69);
            this.txtreceiptdate.Name = "txtreceiptdate";
            this.txtreceiptdate.Size = new System.Drawing.Size(189, 20);
            this.txtreceiptdate.TabIndex = 1;
            // 
            // txtxustid
            // 
            this.txtxustid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtxustid.Location = new System.Drawing.Point(6, 226);
            this.txtxustid.Name = "txtxustid";
            this.txtxustid.Size = new System.Drawing.Size(189, 20);
            this.txtxustid.TabIndex = 2;
            this.txtxustid.Visible = false;
            // 
            // txttotalamount
            // 
            this.txttotalamount.Location = new System.Drawing.Point(143, 138);
            this.txttotalamount.Name = "txttotalamount";
            this.txttotalamount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttotalamount.Size = new System.Drawing.Size(189, 20);
            this.txttotalamount.TabIndex = 3;
            // 
            // txtreceiptno
            // 
            this.txtreceiptno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtreceiptno.Location = new System.Drawing.Point(143, 32);
            this.txtreceiptno.Name = "txtreceiptno";
            this.txtreceiptno.Size = new System.Drawing.Size(189, 20);
            this.txtreceiptno.TabIndex = 0;
            this.txtreceiptno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtreceiptno_KeyDown);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(269, 6);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 0;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 252);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 34);
            this.panel1.TabIndex = 1;
            // 
            // Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 286);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Receipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Receipt";
            this.Load += new System.EventHandler(this.Receipt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblcustomer;
        private System.Windows.Forms.Label lbladdr;
        private System.Windows.Forms.Label lblcity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.TextBox txttotalamount;
        private System.Windows.Forms.TextBox txtxustid;
        private System.Windows.Forms.TextBox txtreceiptno;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker txtreceiptdate;
        private System.Windows.Forms.ComboBox cmbcustomer;
    }
}