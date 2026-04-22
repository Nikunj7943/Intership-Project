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
    public partial class User: Form
    {
        public DataTable userdata = new DataTable();
        private int uid = 0;
        public string connStr = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;

        public User(int _uid)
        {
            InitializeComponent();
            uid = _uid;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                {

                    {

                        {

                            {
                                //sql server - sp calling and store data
                                //DataTable dataTable = new DataTable();  

                                //custid = 0; // return from sql server
                                using (SqlConnection conn = new SqlConnection(connStr))
                                {
                                    using (SqlCommand cmd = new SqlCommand("user_sp", conn))
                                    {
                                        cmd.CommandType = CommandType.StoredProcedure;

                                        // Add parameters
                                        cmd.Parameters.AddWithValue("@userid", uid);
                                        cmd.Parameters.AddWithValue("@username", txtunm.Text.Trim());
                                        cmd.Parameters.AddWithValue("@password", txtpwd.Text.Trim());
                                        //cmd.Parameters.AddWithValue("@lastlogindate", DateTime.Now);

                                        // cmd.Parameters.AddWithValue("@city", txtpayment.Text.Trim());

                                        cmd.Parameters.AddWithValue("@createdby", Program.gblVer.userid); // Replace with actual user
                                        cmd.Parameters.AddWithValue("@updatedby", DBNull.Value); // For insert

                                        // Fill into DataTable
                                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                                        DataTable dt = new DataTable();
                                        da.Fill(dt);

                                        if (dt.Rows.Count > 0)
                                        {
                                            uid = Convert.ToInt32(dt.Rows[0][0]);
                                            MessageBox.Show("user saved successfully! ID: " + uid);
                                            //Auto refresh gridview
                                            DialogResult = DialogResult.OK;
                                            this.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("user saved failed.");
                                        }
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

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void User_Load(object sender, EventArgs e)
        {
            LoadUser(uid);
        }

        public void LoadUser(int custid)
        {
            try
            {
                userdata = DbHelper.ExecuteSelectQuery("SELECT * FROM [User] WITH(NOLOCK) where userid=" + uid.ToString());

                if (userdata.Rows.Count > 0)
                {
                    txtunm.Text = userdata.Rows[0]["username"].ToString();
                    txtpwd.Text = userdata.Rows[0]["password"].ToString();
                  

                }
                else
                {
                    // Clear fields for new customer
                    txtunm.Text = "";
                    txtpwd.Text = "";
                 

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }
    }
}
