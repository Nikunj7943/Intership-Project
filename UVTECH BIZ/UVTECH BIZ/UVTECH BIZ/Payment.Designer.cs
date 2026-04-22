namespace UVTECH_BIZ
{
    partial class Payment
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
            this.txtpaymentno = new System.Windows.Forms.TextBox();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.txtsupid = new System.Windows.Forms.TextBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.lblcity = new System.Windows.Forms.Label();
            this.lbladdr = new System.Windows.Forms.Label();
            this.lblcustomer = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbsupplier = new System.Windows.Forms.ComboBox();
            this.paymetndt = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtpaymentno
            // 
            this.txtpaymentno.Location = new System.Drawing.Point(129, 34);
            this.txtpaymentno.Name = "txtpaymentno";
            this.txtpaymentno.ReadOnly = true;
            this.txtpaymentno.Size = new System.Drawing.Size(189, 20);
            this.txtpaymentno.TabIndex = 0;
            // 
            // txttotal
            // 
            this.txttotal.Location = new System.Drawing.Point(129, 129);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(189, 20);
            this.txttotal.TabIndex = 3;
            // 
            // txtsupid
            // 
            this.txtsupid.Location = new System.Drawing.Point(24, 211);
            this.txtsupid.Name = "txtsupid";
            this.txtsupid.Size = new System.Drawing.Size(189, 20);
            this.txtsupid.TabIndex = 2;
            this.txtsupid.Visible = false;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(263, 7);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 1;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(167, 7);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 0;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // lblcity
            // 
            this.lblcity.AutoSize = true;
            this.lblcity.Location = new System.Drawing.Point(34, 131);
            this.lblcity.Name = "lblcity";
            this.lblcity.Size = new System.Drawing.Size(70, 13);
            this.lblcity.TabIndex = 4;
            this.lblcity.Text = "Total Amount";
            // 
            // lbladdr
            // 
            this.lbladdr.AutoSize = true;
            this.lbladdr.Location = new System.Drawing.Point(47, 100);
            this.lbladdr.Name = "lbladdr";
            this.lbladdr.Size = new System.Drawing.Size(57, 13);
            this.lbladdr.TabIndex = 3;
            this.lbladdr.Text = "Supplier Id";
            // 
            // lblcustomer
            // 
            this.lblcustomer.AutoSize = true;
            this.lblcustomer.Location = new System.Drawing.Point(30, 69);
            this.lblcustomer.Name = "lblcustomer";
            this.lblcustomer.Size = new System.Drawing.Size(74, 13);
            this.lblcustomer.TabIndex = 2;
            this.lblcustomer.Text = "Payment Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Payment No";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbsupplier);
            this.groupBox1.Controls.Add(this.paymetndt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtpaymentno);
            this.groupBox1.Controls.Add(this.txttotal);
            this.groupBox1.Controls.Add(this.lblcustomer);
            this.groupBox1.Controls.Add(this.txtsupid);
            this.groupBox1.Controls.Add(this.lbladdr);
            this.groupBox1.Controls.Add(this.lblcity);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 286);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbsupplier
            // 
            this.cmbsupplier.FormattingEnabled = true;
            this.cmbsupplier.Location = new System.Drawing.Point(129, 100);
            this.cmbsupplier.Name = "cmbsupplier";
            this.cmbsupplier.Size = new System.Drawing.Size(189, 21);
            this.cmbsupplier.TabIndex = 2;
            // 
            // paymetndt
            // 
            this.paymetndt.CustomFormat = "01/12/2025";
            this.paymetndt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.paymetndt.Location = new System.Drawing.Point(129, 68);
            this.paymetndt.MaxDate = new System.DateTime(2025, 4, 17, 0, 0, 0, 0);
            this.paymetndt.Name = "paymetndt";
            this.paymetndt.Size = new System.Drawing.Size(189, 20);
            this.paymetndt.TabIndex = 1;
            this.paymetndt.Value = new System.DateTime(2025, 4, 17, 0, 0, 0, 0);
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
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 286);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Paymet";
            this.Load += new System.EventHandler(this.Payment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtpaymentno;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.TextBox txtsupid;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label lblcity;
        private System.Windows.Forms.Label lbladdr;
        private System.Windows.Forms.Label lblcustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker paymetndt;
        private System.Windows.Forms.ComboBox cmbsupplier;
    }
}