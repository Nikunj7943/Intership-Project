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
    public partial class Item: Form
    {
        public DataTable itemdata = new DataTable();
        private int item_id = 0;
        public string connStr = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;

        public Item(int _item)
        {
            InitializeComponent();
            item_id = _item;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
         
        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                {

                    {
                        //sql server - sp calling and store data
                        //DataTable dataTable = new DataTable();  

                        //custid = 0; // return from sql server
                        using (SqlConnection conn = new SqlConnection(connStr))
                        {
                            using (SqlCommand cmd = new SqlCommand("item_sp", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                // Add parameters
                                cmd.Parameters.AddWithValue("@itemid", item_id);
                                cmd.Parameters.AddWithValue("@itemname", txtitemname.Text.Trim());
                                cmd.Parameters.AddWithValue("@itemgroup", txtitemgroup.Text.Trim());
                                cmd.Parameters.AddWithValue("@purchasrprice", txtpurchase.Text.Trim());
                                cmd.Parameters.AddWithValue("@saleprice", txtsale.Text.Trim()); // Replace if needed
                                cmd.Parameters.AddWithValue("@barcode", txtbarcode.Text.Trim());
                                //cmd.Parameters.AddWithValue("@barcode", txtitemcode.Text.Trim());
                                cmd.Parameters.AddWithValue("@itemcode", txtitemcode.Text.Trim());
                                //cmd.Parameters.AddWithValue("@contactphone1", Convert.ToInt64(txtphone1.Text.Trim()));

                                cmd.Parameters.AddWithValue("@createdby", Program.gblVer.userid); // Replace with actual user
                                cmd.Parameters.AddWithValue("@updatedby", DBNull.Value); // For insert

                                // Fill into DataTable
                                SqlDataAdapter da = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                if (dt.Rows.Count > 0)
                                {
                                    item_id = Convert.ToInt32(dt.Rows[0][0]);
                                    MessageBox.Show("Item saved successfully! ID: " + item_id);


                                    //Auto refresh gridview
                                    DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Item save failed.");
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

        public void LoadItemFromDM(int custid)
        {
            try
            {
                itemdata = DbHelper.ExecuteSelectQuery("SELECT * FROM Item WITH(NOLOCK) where itemid=" + item_id.ToString());

                if (itemdata.Rows.Count > 0)
                {
                    txtitemcode.Text = itemdata.Rows[0]["itemcode"].ToString();
                    txtitemname.Text = itemdata.Rows[0]["itemname"].ToString();
                    txtitemgroup.Text = itemdata.Rows[0]["itemgroup"].ToString();
                    txtpurchase.Text = itemdata.Rows[0]["purchasrprice"].ToString();
                    txtsale.Text = itemdata.Rows[0]["saleprice"].ToString();
                    txtbarcode.Text = itemdata.Rows[0]["barcode"].ToString();
                   
                }
                else
                {
                    // Clear fields for new customer
                    txtbarcode.Text = "";
                    txtbarcode.Text = "";
                    txtitemgroup.Text = "";
                    txtpurchase.Text = "";
                    txtsale.Text = "";
                    txtbarcode.Text = "";
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }

        private void Item_Load(object sender, EventArgs e)
        {
            LoadItemFromDM(item_id);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

