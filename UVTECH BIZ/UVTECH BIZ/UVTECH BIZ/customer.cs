using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace UVTECH_BIZ
{
    public partial class customer : Form
    {
        public DataTable custdata = new DataTable();
        private Custmaster _formShow;
        private int custid = 0;
        public string connStr = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
        public customer(int _cust)
        {
            InitializeComponent();
            custid = _cust;
           //formShow = formShow;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                //sql server - sp calling and store data
                //DataTable dataTable = new DataTable();  

                //custid = 0; // return from sql server
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("customer_sp", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@customerid", custid);
                        cmd.Parameters.AddWithValue("@customername", txtcustomername.Text.Trim());
                        cmd.Parameters.AddWithValue("@customeraddress", txtaddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@city", txtcity.Text.Trim());
                        cmd.Parameters.AddWithValue("@postcode", txtpostcode.Text.Trim()); // Replace if needed
                        cmd.Parameters.AddWithValue("@country", txtcountry.Text.Trim());

                        cmd.Parameters.AddWithValue("@contactname1", txtcontactname.Text.Trim());
                        cmd.Parameters.AddWithValue("@contactphone1", txtphone1.Text.Trim());
                        cmd.Parameters.AddWithValue("@contactname2", txtname2.Text.Trim());
                        cmd.Parameters.AddWithValue("@contactphone2", txtphone2.Text.Trim());
                       
                        // cmd.Parameters.AddWithValue("@contactname2", string.IsNullOrWhiteSpace(txtname2.Text) ? (object)DBNull.Value : txtname2.Text.Trim());
                        //cmd.Parameters.AddWithValue("@contactphone2", string.IsNullOrWhiteSpace(txtphone2.Text) ? (object)DBNull.Value : Convert.ToInt32(txtphone2.Text.Trim()));

                        cmd.Parameters.AddWithValue("@createdby", Program.gblVer.userid); // Replace with actual user
                        cmd.Parameters.AddWithValue("@updatedby", DBNull.Value); // For insert

                        // Fill into DataTable
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)

                        {
                            //Program.gblVer.userid = usrid;
                            custid = Convert.ToInt32(dt.Rows[0][0]);
                            MessageBox.Show("Customer saved successfully! ID: " + custid);


                            //Auto refresh gridview
                            DialogResult = DialogResult.OK;
                            this.Close();
                        
                        }
                        else
                        {
                            MessageBox.Show("Customer save failed.");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void LoadCustomersFromDb(int custid)
        {
            try
            {
                custdata = DbHelper.ExecuteSelectQuery("SELECT * FROM Customer WITH(NOLOCK) where Customerid=" + custid.ToString());

                if (custdata.Rows.Count > 0)
                {
                    txtcustomername.Text = custdata.Rows[0]["CustomerName"].ToString();
                    txtaddress.Text = custdata.Rows[0]["customeraddress"].ToString();
                    txtcity.Text = custdata.Rows[0]["City"].ToString();
                    txtpostcode.Text = custdata.Rows[0]["PostCode"].ToString();
                    txtcountry.Text = custdata.Rows[0]["country"].ToString();
                    txtcontactname.Text = custdata.Rows[0]["contactname1"].ToString();
                    txtphone1.Text = custdata.Rows[0]["contactphone1"].ToString();
                    txtname2.Text = custdata.Rows[0]["contactname2"].ToString();
                    txtphone2.Text = custdata.Rows[0]["contactphone2"].ToString();
                }
                else
                {
                    // Clear fields for new customer
                    txtcustomername.Text = "";
                    txtaddress.Text = "";
                    txtcity.Text = "";
                    txtpostcode.Text = "";
                    txtcountry.Text = "";
                    txtcontactname.Text = "";
                    txtphone1.Text = "";
                    txtname2.Text = "";
                    txtphone2.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
         }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblcustomer_Click(object sender, EventArgs e)
        {

        }

        private void txtphone2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtname2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtphone1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcontactname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtcity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbladdr_Click(object sender, EventArgs e)
        {

        }

        private void lblcity_Click(object sender, EventArgs e)
        {

        }

        private void lblpostcode_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void customer_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(custid.ToString());
            LoadCustomersFromDb(custid);
        }
        //try
        //{
        //    custdata = DbHelper.ExecuteSelectQuery("SELECT * FROM Customer WITH(NOLOCK) where Customerid=" + custid.ToString());

        //    txtcustomername.Text = custdata.Rows[0]["CustomerName"].ToString();
        //    txtaddress.Text = custdata.Rows[0]["customeraddress"].ToString();
        //    txtcity.Text = custdata.Rows[0]["City"].ToString();
        //    txtpostcode.Text = custdata.Rows[0]["PostCode"].ToString();
        //    txtcountry.Text = custdata.Rows[0]["country"].ToString();
        //    txtcontactname.Text = custdata.Rows[0]["contactname1"].ToString();
        //    txtphone1.Text = custdata.Rows[0]["contactphone1"].ToString();
        //    txtname2.Text = custdata.Rows[0]["contactname2"].ToString();
        //    txtphone2.Text = custdata.Rows[0]["contactphone2"].ToString();
        //}
        //catch(Exception ex)
        //{
        //    MessageBox.Show(ex.Message.ToString());
        //}
}
}
