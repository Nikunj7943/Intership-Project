using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UVTECH_BIZ
{
    public partial class Receipt : Form
    {
        public DataTable receiptdata = new DataTable();
        private int receipt_id = 0;
        private DataTable dtcust = new DataTable();
        private DataTable dtItem = new DataTable();
        private DataTable dtInvoiceItems = new DataTable();
        public string connStr = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;

        public Receipt(int _receiptid)
        {
            InitializeComponent();
            receipt_id = _receiptid;
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                // SQL Server - Calling stored procedure to save data
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("receipt_sp", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@receiptid", receipt_id);
                        cmd.Parameters.AddWithValue("@receiptno", txtreceiptno.Text.Trim());
                        cmd.Parameters.AddWithValue("@receiptdate", txtreceiptdate.Value);
                        //cmd.Parameters.AddWithValue("@customerid", txtxustid.Text.Trim());
                        cmd.Parameters.AddWithValue("@customerid", cmbcustomer.SelectedValue);

                        cmd.Parameters.AddWithValue("@totalamount", txttotalamount.Text.Trim());
                        cmd.Parameters.AddWithValue("@createdby", Program.gblVer.userid); // Replace with actual user
                        cmd.Parameters.AddWithValue("@updatedby", DBNull.Value); // For insert

                        // Execute and get result
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            receipt_id = Convert.ToInt32(dt.Rows[0][0]);
                            MessageBox.Show("Receipt saved successfully! ID: " + receipt_id);

                            //Auto refresh gridview
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Receipt save failed.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadReceiptfromDB(int receipt_id)
        {
            try
            {
                receiptdata = DbHelper.ExecuteSelectQuery("SELECT * FROM vw_receipt WITH(NOLOCK) where receiptid=" + receipt_id.ToString());

                if (receiptdata.Rows.Count > 0)
                {
                    DataRow row = receiptdata.Rows[0];

                    txtreceiptno.Text = receiptdata.Rows[0]["receiptno"].ToString();
                    txtreceiptdate.Value = Convert.ToDateTime(receiptdata.Rows[0]["receiptdate"]);

                    //cmbcustomer.SelectedValue = receiptdata.Rows[0]["customername"];
                    //cmbcustomer.Text = receiptdata.Rows[0]["customername"].ToString();
                    //cmbcustomer.SelectedValue = Convert.ToInt32(receiptdata.Rows[0]["customerid"]);
                    cmbcustomer.Text = receiptdata.Rows[0]["customername"].ToString();


                    //cmbcustomer.SelectedValue = receiptdata.Rows[0]["customerid"];

                    txttotalamount.Text = receiptdata.Rows[0]["totalamount"].ToString();
                    btnsave.Text = "Update";
                }
                else
                {
                    // Clear fields for new customer
                    txtreceiptno.Text = "";
                    txtreceiptdate.Text = "";
                    cmbcustomer.SelectedIndex = -1;
                    txttotalamount.Text = "";
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }
        private void LoadCustomer()
        {
            try
            {
                string query = "SELECT customername, customerid FROM Customer";
                dtcust = DbHelper.ExecuteSelectQuery(query);
                cmbcustomer.DataSource = dtcust;
                cmbcustomer.DisplayMember = "customername";
                cmbcustomer.ValueMember = "customerid";
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message);
            }
        }
        private void Receipt_Load(object sender, EventArgs e)
        {
            cmbcustomer.SelectedIndex = -1;
            LoadCustomer();
            LoadReceiptfromDB(receipt_id);
     
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbcustomer.SelectedIndex != -1)
            //{
            //    DataRowView drv = cmbcustomer.SelectedItem as DataRowView;
            //    if (drv != null)
            //        cmbcustomer.Text = drv["customerid"].ToString();
            //}
        }

        private void txtreceiptno_KeyDown(object sender, KeyEventArgs e)
        {

        }

      


    }
}

