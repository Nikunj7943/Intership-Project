using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UVTECH_BIZ
{
    public partial class Customerupd: Form
    {
        private int custid;

        public Customerupd(DataRow data)
        {

            InitializeComponent();
            custid = Convert.ToInt32(data["customerid"]);

            txtcustomername.Text = data["customername"].ToString();
            txtaddress.Text = data["customeraddress"].ToString();
            txtcity.Text = data["city"].ToString();
            txtcountry.Text = data["country"].ToString();
            txtpostcode.Text = data["postcode"].ToString();
            txtcontactname.Text = data["contactname1"].ToString();
            txtphone1.Text = data["contactphone1"].ToString();
            txtname2.Text = data["contactname2"].ToString();
            txtphone2.Text = data["contactphone2"].ToString();
        }

        private void Customerupd_Load(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
           
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@customerid", custid),
            new SqlParameter("@customername", txtcustomername.Text.Trim()),
            new SqlParameter("@customeraddress", txtaddress.Text.Trim()),
            new SqlParameter("@city", txtcity.Text.Trim()),
            new SqlParameter("@postcode", txtpostcode.Text.Trim()),
            new SqlParameter("@country", txtcountry.Text.Trim()),
            new SqlParameter("@contactname1", txtcontactname.Text.Trim()),
            new SqlParameter("@contactphone1", txtphone1.Text.Trim()),
            new SqlParameter("@contactname2", txtname2.Text.Trim()),
            new SqlParameter("@contactphone2", txtphone2.Text.Trim()),
            new SqlParameter("@createdby", Program.gblVer.userid), 
            new SqlParameter("@updatedby", Program.gblVer.userid) 
                };

                DataTable dt = DbHelper.ExecuteStoredProcedure("customer_sp", parameters);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Customer updated successfully!");
                    custid = Convert.ToInt32(dt.Rows[0][0]); // Return ID update
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update failed. No data returned.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    
}
}
