namespace UVTECH_BIZ
{
    partial class customer
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
            this.btnclose = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.lblcustomer = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpostcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcountry = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtphone2 = new System.Windows.Forms.TextBox();
            this.lbladdr = new System.Windows.Forms.Label();
            this.txtname2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtphone1 = new System.Windows.Forms.TextBox();
            this.lblcity = new System.Windows.Forms.Label();
            this.txtcontactname = new System.Windows.Forms.TextBox();
            this.lblpostcode = new System.Windows.Forms.Label();
            this.txtcity = new System.Windows.Forms.TextBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtcustomername = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 340);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 37);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.Location = new System.Drawing.Point(325, 6);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 10;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.Location = new System.Drawing.Point(244, 6);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 9;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // lblcustomer
            // 
            this.lblcustomer.AutoSize = true;
            this.lblcustomer.Location = new System.Drawing.Point(3, 9);
            this.lblcustomer.Name = "lblcustomer";
            this.lblcustomer.Size = new System.Drawing.Size(82, 13);
            this.lblcustomer.TabIndex = 2;
            this.lblcustomer.Text = "Customer Name";
            this.lblcustomer.Click += new System.EventHandler(this.lblcustomer_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtpostcode);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtcountry);
            this.panel3.Controls.Add(this.lblcustomer);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtphone2);
            this.panel3.Controls.Add(this.lbladdr);
            this.panel3.Controls.Add(this.txtname2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.txtphone1);
            this.panel3.Controls.Add(this.lblcity);
            this.panel3.Controls.Add(this.txtcontactname);
            this.panel3.Controls.Add(this.lblpostcode);
            this.panel3.Controls.Add(this.txtcity);
            this.panel3.Controls.Add(this.txtaddress);
            this.panel3.Controls.Add(this.txtcustomername);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(412, 340);
            this.panel3.TabIndex = 0;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Postcode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Country";
            // 
            // txtpostcode
            // 
            this.txtpostcode.Location = new System.Drawing.Point(102, 155);
            this.txtpostcode.Name = "txtpostcode";
            this.txtpostcode.Size = new System.Drawing.Size(194, 20);
            this.txtpostcode.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Contact Phone 2";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtcountry
            // 
            this.txtcountry.Location = new System.Drawing.Point(102, 184);
            this.txtcountry.Name = "txtcountry";
            this.txtcountry.Size = new System.Drawing.Size(217, 20);
            this.txtcountry.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Contact Name 2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtphone2
            // 
            this.txtphone2.Location = new System.Drawing.Point(102, 300);
            this.txtphone2.Name = "txtphone2";
            this.txtphone2.Size = new System.Drawing.Size(194, 20);
            this.txtphone2.TabIndex = 8;
            this.txtphone2.TextChanged += new System.EventHandler(this.txtphone2_TextChanged);
            // 
            // lbladdr
            // 
            this.lbladdr.AutoSize = true;
            this.lbladdr.Location = new System.Drawing.Point(3, 68);
            this.lbladdr.Name = "lbladdr";
            this.lbladdr.Size = new System.Drawing.Size(92, 13);
            this.lbladdr.TabIndex = 3;
            this.lbladdr.Text = "Customer Address";
            this.lbladdr.Click += new System.EventHandler(this.lbladdr_Click);
            // 
            // txtname2
            // 
            this.txtname2.Location = new System.Drawing.Point(102, 271);
            this.txtname2.Name = "txtname2";
            this.txtname2.Size = new System.Drawing.Size(298, 20);
            this.txtname2.TabIndex = 7;
            this.txtname2.TextChanged += new System.EventHandler(this.txtname2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Contact Phone 1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtphone1
            // 
            this.txtphone1.Location = new System.Drawing.Point(102, 242);
            this.txtphone1.Name = "txtphone1";
            this.txtphone1.Size = new System.Drawing.Size(194, 20);
            this.txtphone1.TabIndex = 6;
            this.txtphone1.TextChanged += new System.EventHandler(this.txtphone1_TextChanged);
            // 
            // lblcity
            // 
            this.lblcity.AutoSize = true;
            this.lblcity.Location = new System.Drawing.Point(3, 126);
            this.lblcity.Name = "lblcity";
            this.lblcity.Size = new System.Drawing.Size(24, 13);
            this.lblcity.TabIndex = 4;
            this.lblcity.Text = "City";
            this.lblcity.Click += new System.EventHandler(this.lblcity_Click);
            // 
            // txtcontactname
            // 
            this.txtcontactname.Location = new System.Drawing.Point(102, 213);
            this.txtcontactname.Name = "txtcontactname";
            this.txtcontactname.Size = new System.Drawing.Size(298, 20);
            this.txtcontactname.TabIndex = 5;
            this.txtcontactname.TextChanged += new System.EventHandler(this.txtcontactname_TextChanged);
            // 
            // lblpostcode
            // 
            this.lblpostcode.AutoSize = true;
            this.lblpostcode.Location = new System.Drawing.Point(3, 212);
            this.lblpostcode.Name = "lblpostcode";
            this.lblpostcode.Size = new System.Drawing.Size(84, 13);
            this.lblpostcode.TabIndex = 5;
            this.lblpostcode.Text = "Contact Name 1";
            this.lblpostcode.Click += new System.EventHandler(this.lblpostcode_Click);
            // 
            // txtcity
            // 
            this.txtcity.Location = new System.Drawing.Point(102, 126);
            this.txtcity.Name = "txtcity";
            this.txtcity.Size = new System.Drawing.Size(217, 20);
            this.txtcity.TabIndex = 2;
            this.txtcity.TextChanged += new System.EventHandler(this.txtcity_TextChanged);
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(102, 35);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtaddress.Size = new System.Drawing.Size(298, 82);
            this.txtaddress.TabIndex = 1;
            this.txtaddress.TextChanged += new System.EventHandler(this.txtaddress_TextChanged);
            // 
            // txtcustomername
            // 
            this.txtcustomername.Location = new System.Drawing.Point(100, 6);
            this.txtcustomername.Name = "txtcustomername";
            this.txtcustomername.Size = new System.Drawing.Size(300, 20);
            this.txtcustomername.TabIndex = 0;
            this.txtcustomername.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 377);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "customer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.customer_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label lblpostcode;
        private System.Windows.Forms.Label lblcity;
        private System.Windows.Forms.Label lbladdr;
        private System.Windows.Forms.Label lblcustomer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtphone2;
        private System.Windows.Forms.TextBox txtname2;
        private System.Windows.Forms.TextBox txtphone1;
        private System.Windows.Forms.TextBox txtcontactname;
        private System.Windows.Forms.TextBox txtcity;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtcustomername;
        private System.Windows.Forms.TextBox txtpostcode;
        private System.Windows.Forms.TextBox txtcountry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}