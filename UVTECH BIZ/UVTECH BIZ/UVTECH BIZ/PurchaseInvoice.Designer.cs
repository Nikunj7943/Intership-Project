namespace UVTECH_BIZ
{
    partial class PurchaseInvoice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbsuplier = new System.Windows.Forms.ComboBox();
            this.txtpurchasedt = new System.Windows.Forms.DateTimePicker();
            this.txtsupref = new System.Windows.Forms.TextBox();
            this.txtsupaddr = new System.Windows.Forms.TextBox();
            this.txtinvno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.purchasegrd = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txttotalamount = new System.Windows.Forms.TextBox();
            this.txttotalqty = new System.Windows.Forms.TextBox();
            this.txtnotes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.txtrate = new System.Windows.Forms.TextBox();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.cmbitem = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.purchasegrd)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbsuplier);
            this.panel1.Controls.Add(this.txtpurchasedt);
            this.panel1.Controls.Add(this.txtsupref);
            this.panel1.Controls.Add(this.txtsupaddr);
            this.panel1.Controls.Add(this.txtinvno);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 143);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cmbsuplier
            // 
            this.cmbsuplier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbsuplier.FormattingEnabled = true;
            this.cmbsuplier.Location = new System.Drawing.Point(95, 7);
            this.cmbsuplier.Name = "cmbsuplier";
            this.cmbsuplier.Size = new System.Drawing.Size(380, 21);
            this.cmbsuplier.TabIndex = 0;
            this.cmbsuplier.SelectedIndexChanged += new System.EventHandler(this.cmbsuplier_SelectedIndexChanged);
            // 
            // txtpurchasedt
            // 
            this.txtpurchasedt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpurchasedt.CustomFormat = "dd/MM/yyyy";
            this.txtpurchasedt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtpurchasedt.Location = new System.Drawing.Point(633, 37);
            this.txtpurchasedt.Name = "txtpurchasedt";
            this.txtpurchasedt.Size = new System.Drawing.Size(140, 20);
            this.txtpurchasedt.TabIndex = 3;
            // 
            // txtsupref
            // 
            this.txtsupref.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsupref.Location = new System.Drawing.Point(633, 65);
            this.txtsupref.Name = "txtsupref";
            this.txtsupref.Size = new System.Drawing.Size(140, 20);
            this.txtsupref.TabIndex = 4;
            // 
            // txtsupaddr
            // 
            this.txtsupaddr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsupaddr.Location = new System.Drawing.Point(95, 34);
            this.txtsupaddr.Multiline = true;
            this.txtsupaddr.Name = "txtsupaddr";
            this.txtsupaddr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtsupaddr.Size = new System.Drawing.Size(380, 103);
            this.txtsupaddr.TabIndex = 1;
            this.txtsupaddr.TextChanged += new System.EventHandler(this.txtsupaddr_TextChanged);
            // 
            // txtinvno
            // 
            this.txtinvno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtinvno.Location = new System.Drawing.Point(633, 9);
            this.txtinvno.Name = "txtinvno";
            this.txtinvno.Size = new System.Drawing.Size(140, 20);
            this.txtinvno.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(512, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Supplier Reference";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Supplier Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Supplier Name";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(494, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Purchase Invoice Date";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Purchase Invoice No";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 537);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 27);
            this.panel2.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Right;
            this.button4.Location = new System.Drawing.Point(650, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 27);
            this.button4.TabIndex = 0;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.Location = new System.Drawing.Point(725, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 27);
            this.button3.TabIndex = 1;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.purchasegrd);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 143);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 394);
            this.panel3.TabIndex = 1;
            // 
            // purchasegrd
            // 
            this.purchasegrd.AllowUserToAddRows = false;
            this.purchasegrd.AllowUserToResizeColumns = false;
            this.purchasegrd.AllowUserToResizeRows = false;
            this.purchasegrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.purchasegrd.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.purchasegrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.purchasegrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.purchasegrd.Location = new System.Drawing.Point(0, 60);
            this.purchasegrd.Name = "purchasegrd";
            this.purchasegrd.ReadOnly = true;
            this.purchasegrd.Size = new System.Drawing.Size(800, 274);
            this.purchasegrd.TabIndex = 3;
            this.purchasegrd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.purchasegrd_CellContentClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.txttotalamount);
            this.panel5.Controls.Add(this.txttotalqty);
            this.panel5.Controls.Add(this.txtnotes);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 334);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(800, 60);
            this.panel5.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(652, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Total Amount";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(526, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Total Quantity";
            // 
            // txttotalamount
            // 
            this.txttotalamount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotalamount.Location = new System.Drawing.Point(635, 19);
            this.txttotalamount.Name = "txttotalamount";
            this.txttotalamount.ReadOnly = true;
            this.txttotalamount.Size = new System.Drawing.Size(140, 20);
            this.txttotalamount.TabIndex = 2;
            this.txttotalamount.TextChanged += new System.EventHandler(this.txttotalamount_TextChanged);
            // 
            // txttotalqty
            // 
            this.txttotalqty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotalqty.Location = new System.Drawing.Point(479, 19);
            this.txttotalqty.Name = "txttotalqty";
            this.txttotalqty.ReadOnly = true;
            this.txttotalqty.Size = new System.Drawing.Size(140, 20);
            this.txttotalqty.TabIndex = 1;
            this.txttotalqty.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // txtnotes
            // 
            this.txtnotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtnotes.Location = new System.Drawing.Point(63, 2);
            this.txtnotes.Multiline = true;
            this.txtnotes.Name = "txtnotes";
            this.txtnotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtnotes.Size = new System.Drawing.Size(400, 55);
            this.txtnotes.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Notes";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.btndelete);
            this.panel4.Controls.Add(this.btnadd);
            this.panel4.Controls.Add(this.txtamount);
            this.panel4.Controls.Add(this.txtrate);
            this.panel4.Controls.Add(this.txtqty);
            this.panel4.Controls.Add(this.cmbitem);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 60);
            this.panel4.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(489, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Amount";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(369, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Rate";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(250, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Quantity";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Item";
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndelete.Location = new System.Drawing.Point(718, 21);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 21);
            this.btndelete.TabIndex = 2;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnadd
            // 
            this.btnadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnadd.Location = new System.Drawing.Point(619, 21);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 21);
            this.btnadd.TabIndex = 1;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtamount
            // 
            this.txtamount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtamount.Location = new System.Drawing.Point(473, 21);
            this.txtamount.Name = "txtamount";
            this.txtamount.ReadOnly = true;
            this.txtamount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtamount.Size = new System.Drawing.Size(122, 20);
            this.txtamount.TabIndex = 3;
            this.txtamount.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // txtrate
            // 
            this.txtrate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtrate.Location = new System.Drawing.Point(327, 21);
            this.txtrate.Name = "txtrate";
            this.txtrate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtrate.Size = new System.Drawing.Size(122, 20);
            this.txtrate.TabIndex = 2;
            this.txtrate.TextChanged += new System.EventHandler(this.txtrate_TextChanged);
            // 
            // txtqty
            // 
            this.txtqty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtqty.Location = new System.Drawing.Point(245, 22);
            this.txtqty.Name = "txtqty";
            this.txtqty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtqty.Size = new System.Drawing.Size(58, 20);
            this.txtqty.TabIndex = 1;
            this.txtqty.Text = "1";
            this.txtqty.TextChanged += new System.EventHandler(this.txtqty_TextChanged);
            // 
            // cmbitem
            // 
            this.cmbitem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbitem.FormattingEnabled = true;
            this.cmbitem.Location = new System.Drawing.Point(17, 21);
            this.cmbitem.Name = "cmbitem";
            this.cmbitem.Size = new System.Drawing.Size(204, 21);
            this.cmbitem.TabIndex = 0;
            this.cmbitem.SelectedIndexChanged += new System.EventHandler(this.cmbitem_SelectedIndexChanged);
            // 
            // PurchaseInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 564);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "PurchaseInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PurchaseInvoice";
            this.Load += new System.EventHandler(this.PurchaseInvoice_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.purchasegrd)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtpurchasedt;
        private System.Windows.Forms.TextBox txtsupref;
        private System.Windows.Forms.TextBox txtsupaddr;
        private System.Windows.Forms.TextBox txtinvno;
        private System.Windows.Forms.ComboBox cmbsuplier;
        private System.Windows.Forms.TextBox txtqty;
        private System.Windows.Forms.ComboBox cmbitem;
        private System.Windows.Forms.TextBox txtrate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.TextBox txtnotes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txttotalamount;
        private System.Windows.Forms.TextBox txttotalqty;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView purchasegrd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}