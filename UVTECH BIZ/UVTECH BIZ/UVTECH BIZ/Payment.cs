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


    public partial class Payment : Form
    {
        public DataTable paydata = new DataTable();
        private int payment_id = 0;
        private DataTable dtsup = new DataTable();
        public string connStr = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;

        public Payment(int _paymentid)
        {
            InitializeComponent();
            payment_id = _paymentid;
        }

        public void LoadPaymentFromDB(int payment_id)
        {
            try
            {
                paydata = DbHelper.ExecuteSelectQuery("SELECT * FROM vw_payment WITH(NOLOCK) where paymentid=" + payment_id.ToString());

                if (paydata.Rows.Count > 0)
                {
                    txtpaymentno.Text = paydata.Rows[0]["paymentno"].ToString();
                    paymetndt.Value = Convert.ToDateTime(paydata.Rows[0]["paymentdate"]);
                    //txtsupid.Text = paydata.Rows[0]["suppliername"].ToString();
                    cmbsupplier.Text = paydata.Rows[0]["suppliername"].ToString();
                    txttotal.Text = paydata.Rows[0]["totalamount"].ToString();
                    btnsave.Text = "Update";
                }
                else
                {
                    // Clear fields for new customer
                    txtpaymentno.Text = "";
                    paymetndt.Text = "";
                    txtsupid.Text = "";
                    txttotal.Text = "";
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                {

                    {

                        {
                            //sql server - sp calling and store data
                            //DataTable dataTable = new DataTable();  

                            //custid = 0; // return from sql server
                            using (SqlConnection conn = new SqlConnection(connStr))
                            {
                                using (SqlCommand cmd = new SqlCommand("payment_sp", conn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    // Add parameters
                                    cmd.Parameters.AddWithValue("@paymentid", payment_id);
                                    cmd.Parameters.AddWithValue("@paymentno", txtpaymentno.Text.Trim());
                                    cmd.Parameters.AddWithValue("@paymentdate", paymetndt.Value);
                                    cmd.Parameters.AddWithValue("@supplierid", cmbsupplier.SelectedValue);
                                    cmd.Parameters.AddWithValue("@totalamount", txttotal.Text.Trim());
                                    cmd.Parameters.AddWithValue("@createdby", Program.gblVer.userid); // Replace with actual user
                                    cmd.Parameters.AddWithValue("@updatedby", DBNull.Value); // For insert

                                    // Fill into DataTable
                                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                                    DataTable dt = new DataTable();
                                    da.Fill(dt);

                                    if (dt.Rows.Count > 0)
                                    {
                                        payment_id = Convert.ToInt32(dt.Rows[0][0]);
                                        MessageBox.Show("Payment saved successfully! ID: " + payment_id);

                                        //Auto refresh gridview
                                        DialogResult = DialogResult.OK;
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Payment save failed.");
                                    }
                                }
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


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        public string GeneratePaymentID()
        {
            // Payment ID ka prefix
            string prefix = "PAY";

            // Current date in YYYYMMDD format
            string datePart = DateTime.Now.ToString("yyyyMMdd");

            // Random 4-digit number (1000 to 9999)
            Random rnd = new Random();
            int randomPart = rnd.Next(1000, 9999);

            // Complete Payment ID by combining prefix, date and random number
            string paymentID = $"{prefix}{datePart}{randomPart}";

            return paymentID;
        }


        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            cmbsupplier.SelectedIndex = -1;
            LoadSupplier();
            LoadPaymentFromDB(payment_id);
          
        }

        private void LoadSupplier()
        {
            try
            {
                string query = "SELECT suppliername, supplierid FROM Supplier";
                dtsup = DbHelper.ExecuteSelectQuery(query);
                cmbsupplier.DataSource = dtsup;
                cmbsupplier.DisplayMember = "suppliername";
                cmbsupplier.ValueMember = "supplierid";
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message);
            }
        }
    }
}
