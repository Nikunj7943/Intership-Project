using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UVTECH_BIZ
{
    public partial class DASHBOARD : Form
    {
        public DASHBOARD()
        {
            InitializeComponent();
        }

        private void cUSTOMERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Custmaster Custmst =new Custmaster();
            Custmst.TopLevel = true;
            Custmst.MdiParent = this;
            Custmst.WindowState = FormWindowState.Maximized;
            Custmst.Show();
        }

        private void sUPPLIERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Supmaster supmast = new Supmaster();
            supmast.TopLevel = true;
            supmast.MdiParent = this;
            supmast.WindowState = FormWindowState.Maximized;
            supmast.Show();


        }

        private void iTEMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            itemmaster item = new itemmaster();
            item.TopLevel = true;
            item.MdiParent = this;
            item.WindowState = FormWindowState.Maximized;
            item.Show();
        }

        private void rECEIPTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Receiptmaster receipt=new Receiptmaster();
           
            receipt.TopLevel = true;
            receipt.MdiParent = this;
            receipt.WindowState = FormWindowState.Maximized;
            receipt.Show();
        }   

        private void pAYMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paymentmst pay = new Paymentmst();
            pay.MdiParent = this;
            pay.WindowState = FormWindowState.Maximized;
            pay.Show();
        }

        private void uSERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usermst use = new usermst();
            use.MdiParent = this;
            use.WindowState = FormWindowState.Maximized;
            use.Show();

           
        }

        private void DASHBOARD_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pURCHASEINVOICEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PurchaseInvoice pinvoice = new PurchaseInvoice();
            //pinvoice.ShowDialog();
            Purchasemaster purmst = new Purchasemaster();
            purmst.TopLevel = true;
            purmst.MdiParent = this;
            purmst.WindowState = FormWindowState.Maximized;
            purmst.Show();
        }

        private void sALESINVOICEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salesinvoicemst slmst = new Salesinvoicemst();
            slmst.TopLevel = true;
            slmst.MdiParent = this;
            slmst.WindowState = FormWindowState.Maximized;
            slmst.Show();
        }
    }
}
