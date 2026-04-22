using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Configuration;



namespace UVTECH_BIZ
{
    public partial class frmlogin : Form

    {
        private Timer timer;
        public string connStr = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;

        public frmlogin()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }



        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }







        private void frmlogin_Load(object sender, EventArgs e)
        {
            CenterPanel();
            timer.Start();
            lblDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dd-MMM-yy hh:mm tt");
        }
        private void frmlogin_Resize(object sender, EventArgs e)
        {
            CenterPanel();
        }
        private void CenterPanel()
        {
            panelLogin.Left = (this.ClientSize.Width - panelLogin.Width) / 2;
            panelLogin.Top = (this.ClientSize.Height - panelLogin.Height) / 3;
        }



        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    string storedProcedure = "login_sp";

                    using (SqlCommand cmd = new SqlCommand(storedProcedure, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                        con.Open();

                        object result = cmd.ExecuteScalar();
                        int usrid = Convert.ToInt32(result.ToString());

                        if (result != null)
                        {
                            if (usrid > 0)
                            {
                                Program.gblVer.userid = usrid;

                               // MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                DASHBOARD dashboard = new DASHBOARD();
                                dashboard.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Unexpected response from the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to log in: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
