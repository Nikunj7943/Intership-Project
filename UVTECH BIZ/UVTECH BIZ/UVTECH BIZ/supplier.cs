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
    public partial class supplier: Form
    {
        public DataTable supdata = new DataTable();
        private int supid = 0;
        public string connStr = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
        public supplier(int _supp)
        {
            InitializeComponent();
            supid = _supp;
        }

        private void txtcity_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            
           
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnclose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadSupplierFromDb(int supid)
        {
            try
            {
                supdata = DbHelper.ExecuteSelectQuery("SELECT * FROM Supplier WITH(NOLOCK) where supplierid=" + supid.ToString());

                if (supdata.Rows.Count > 0)
                {
                    txtsupplier.Text = supdata.Rows[0]["suppliername"].ToString();
                    txtaddress.Text = supdata.Rows[0]["supplieraddress"].ToString();
                    txtcity.Text = supdata.Rows[0]["City"].ToString();
                    txtpostcode.Text = supdata.Rows[0]["PostCode"].ToString();
                    txtcountry.Text = supdata.Rows[0]["country"].ToString();
                    txtcontactname.Text = supdata.Rows[0]["contactname1"].ToString();
                    txtphone1.Text = supdata.Rows[0]["contactphone1"].ToString();
                    txtname2.Text = supdata.Rows[0]["contactname2"].ToString();
                    txtphone2.Text = supdata.Rows[0]["contactphone2"].ToString();
                }
                else
                {
                    // Clear fields for new customer
                    txtsupplier.Text = "";
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


        private void btnsave_Click_1(object sender, EventArgs e)
        {
            try
            {

                {
                    //sql server - sp calling and store data
                    //DataTable dataTable = new DataTable();  

                    //custid = 0; // return from sql server
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        using (SqlCommand cmd = new SqlCommand("supplier_sp", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Add parameters
                            cmd.Parameters.AddWithValue("@supplierid", supid);
                            cmd.Parameters.AddWithValue("@suppliername", txtsupplier.Text.Trim());
                            cmd.Parameters.AddWithValue("@supplieraddress", txtaddress.Text.Trim());
                            cmd.Parameters.AddWithValue("@city", txtcity.Text.Trim());
                            cmd.Parameters.AddWithValue("@postcode", txtpostcode.Text.Trim()); // Replace if needed
                            cmd.Parameters.AddWithValue("@country", txtcontactname.Text.Trim());

                            cmd.Parameters.AddWithValue("@contactname1", txtname2.Text.Trim());
                            cmd.Parameters.AddWithValue("@contactphone1", Convert.ToInt64(txtphone1.Text.Trim()));

                            cmd.Parameters.AddWithValue("@contactname2", string.IsNullOrWhiteSpace(txtname2.Text) ? (object)DBNull.Value : txtname2.Text.Trim());
                            cmd.Parameters.AddWithValue("@contactphone2", Convert.ToInt64(txtphone1.Text.Trim()));
                            //cmd.Parameters.AddWithValue("@contactphone2", string.IsNullOrWhiteSpace(txtphone2.Text) ? (object)DBNull.Value : Convert.ToInt32(txtphone2.Text.Trim()));

                            cmd.Parameters.AddWithValue("@createdby", Program.gblVer.userid); // Replace with actual user
                            cmd.Parameters.AddWithValue("@updatedby", DBNull.Value); // For insert

                            // Fill into DataTable
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                supid = Convert.ToInt32(dt.Rows[0][0]);
                                MessageBox.Show("Suuplier saved successfully! ID: " + supid);

                                //Auto refresh gridview
                                DialogResult = DialogResult.OK;
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("Supplier save failed.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }

        private void supplier_Load(object sender, EventArgs e)
        {
            LoadSupplierFromDb(supid);
        }
    }
}
