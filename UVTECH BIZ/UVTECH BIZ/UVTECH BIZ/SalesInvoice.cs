using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace UVTECH_BIZ
{
    public partial class SalesInvoice : Form
    {
        public string connStr = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
        private DataTable dtCustpmer = new DataTable();
        private DataTable dtItem = new DataTable();
        private DataTable dtInvoiceItems = new DataTable();
        private int si = 0;
        public SalesInvoice(int _si)
        {
            si = _si;
            InitializeComponent();
        }

        private void FillData()
        {
            try
            {
                string query = "SELECT * FROM [dbo].[SalesInvoice] where salesinvoiceid=" + si;
                DataTable dtPurchase = DbHelper.ExecuteSelectQuery(query);

                //if (cmbitem.SelectedItem is DataRowView drv)
                //{
                //    txtrate.Text = drv["purchasrprice"].ToString();
                //    CalculateAmount();
                //    UpdateTotal();
                //}

                if (dtPurchase.Rows.Count > 0)
                {

                    cmbsuplier.SelectedValue = Convert.ToInt32(dtPurchase.Rows[0]["customerid"]);
                    //cmbitem.SelectedValue = Convert.ToInt32(purinvoice.Rows[0]["itemid"]);
                    txtsupaddr.Text = dtPurchase.Rows[0]["customeraddress"].ToString();
                    txtinvno.Text = dtPurchase.Rows[0]["salesinvoiceno"].ToString();
                    txtsupref.Text = dtPurchase.Rows[0]["customerreference"].ToString();
                    txtpurchasedt.Value = Convert.ToDateTime(dtPurchase.Rows[0]["salesinvoicedate"]);
                    //txtqty.Text = purinvoice.Rows[0]["qty"].ToString();
                    //txtrate.Text = purinvoice.Rows[0]["rate"].ToString();
                    //txtamount.Text = purinvoice.Rows[0]["amount"].ToString();
                    txtnotes.Text = dtPurchase.Rows[0]["notes"].ToString();
                    txttotalqty.Text = dtPurchase.Rows[0]["totalqty"].ToString();
                    txttotalamount.Text = dtPurchase.Rows[0]["totalamount"].ToString();


                }


                query = "SELECT * FROM [dbo].[vw_salesinvoicedetail] where salesinvoiceid=" + si;
                dtInvoiceItems = DbHelper.ExecuteSelectQuery(query);

                salesinvoicegrd.DataSource = dtInvoiceItems;
                salesinvoicegrd.Columns["salesinvoiceid"].Visible = false;
                salesinvoicegrd.Columns["salesinvoicedetailid"].Visible = false;
                salesinvoicegrd.Columns["itemid"].Visible = false;
                salesinvoicegrd.Columns["createdby"].Visible = false;
                //salesinvoicegrd.Columns["notes"].HeaderText = "Notes";
                salesinvoicegrd.Columns["qty"].HeaderText = "Quantity";
                salesinvoicegrd.Columns["rate"].HeaderText = "Rate";
                salesinvoicegrd.Columns["amount"].HeaderText = "Amount";

            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message);
            }
        }

        //private void FillData()
        //{
        //    try
        //    {
        //    //    string query = "SELECT * FROM [dbo].[SalesInvoice] where salesinvoiceid=" + si;
        //    //    DataTable dtPurchase = DbHelper.ExecuteSelectQuery(query);
        //        //set data for all text box or other controls.


        //        string query = "SELECT * FROM [dbo].[SalesInvoice] where salesinvoiceid=" + si;
        //        DataTable dtsales = DbHelper.ExecuteSelectQuery(query);
        //        dtsales = DbHelper.ExecuteSelectQuery(query);
        //        salesinvoicegrd.DataSource = dtsales;
        //        salesinvoicegrd.Columns["salesinvoiceid"].Visible = false;
        //        salesinvoicegrd.Columns["itemid"].Visible = false;
        //        salesinvoicegrd.Columns["createdby"].Visible = false;
        //        salesinvoicegrd.Columns["itemname"].HeaderText = "ItemName";
        //        salesinvoicegrd.Columns["qty"].HeaderText = "Quantity";
        //        salesinvoicegrd.Columns["rate"].HeaderText = "Rate";
        //        salesinvoicegrd.Columns["amount"].HeaderText = "Amount";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(" Error: " + ex.Message);
        //    }


        //}

        private void LoadCustomer()
        {
            try
            {
                string query = "SELECT customerid, customername,customeraddress FROM Customer";
                dtCustpmer = DbHelper.ExecuteSelectQuery(query);
                cmbsuplier.DataSource = dtCustpmer;
                cmbsuplier.DisplayMember = "customername";
                cmbsuplier.ValueMember = "customerid";
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message);
            }
        }

        private void LoadItem()
        {
            try
            {
                string query = "SELECT itemid, itemname, purchasrprice FROM Item";
                dtItem = DbHelper.ExecuteSelectQuery(query);
                cmbitem.DataSource = dtItem;
                cmbitem.DisplayMember = "itemname";
                cmbitem.ValueMember = "itemid";
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message);
            }
        }

        private void SalesInvoice_Load(object sender, EventArgs e)
        {
            cmbsuplier.SelectedIndex = -1;
            cmbitem.SelectedIndex = -1;
            txtsupaddr.Clear();
            txtrate.Clear();

            LoadCustomer();
            LoadItem();
            FillData();


        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {

                var item = (DataRowView)cmbitem.SelectedItem;
               
                DataRow newrow = dtInvoiceItems.NewRow();
                //newrow["itemid"] = 9;
                newrow["itemid"] = item["itemid"];
                newrow["itemname"] = cmbitem.Text;
                newrow["qty"] = Convert.ToDecimal(txtqty.Text);
                newrow["rate"] = Convert.ToDecimal(txtrate.Text);
                newrow["amount"] = Convert.ToDecimal(txtamount.Text);
                //newrow["createddate"] = DateTime.Now ;
                newrow["createdby"] = Program.gblVer.userid;

                dtInvoiceItems.Rows.Add(newrow);

                // Clear inputs
                cmbitem.SelectedIndex = -1;
                txtqty.Text = "1";
                txtrate.Clear();
                txtamount.Clear();

                UpdateTotal();
            }
            catch (Exception ex)
            {

                MessageBox.Show(" Error: " + ex.Message);

            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void cmbsuplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbsuplier.SelectedIndex != -1)
            {
                DataRowView drv = cmbsuplier.SelectedItem as DataRowView;
                if (drv != null)
                    txtsupaddr.Text = drv["customeraddress"].ToString();
            }
        }

        private void cmbitem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbitem.SelectedIndex != -1)
            //{
            //    DataRowView drv = cmbitem.SelectedItem as DataRowView;
            //    if (drv != null)
            //        txtrate.Text = drv["purchasrprice"].ToString();
            //}
            if (cmbitem.SelectedItem is DataRowView drv)
            {
                txtrate.Text = drv["purchasrprice"].ToString();
                CalculateAmount();
                UpdateTotal();

            }
        }

        private void CalculateAmount()
        {
            if (decimal.TryParse(txtqty.Text, out decimal qty) &&
                decimal.TryParse(txtrate.Text, out decimal rate) &&
                qty > 0 && rate > 0)
            {
                txtamount.Text = (qty * rate).ToString("0.00");
            }
            else
            {
                txtamount.Clear();
            }
        }
        private void txtqty_TextChanged(object sender, EventArgs e)
        {
            CalculateAmount();
            UpdateTotal();
        }
        private void txtrate_TextChanged(object sender, EventArgs e)
        {
            UpdateTotal();
            CalculateAmount();
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            try
            {
                if (decimal.TryParse(txtqty.Text, out decimal currentQty) &&
                    decimal.TryParse(txtrate.Text, out decimal currentRate))
                {
                    decimal currentAmount = currentQty * currentRate;

                    // Total = ONLY current textbox values
                    txttotalqty.Text = currentQty.ToString("0.##");
                    txttotalamount.Text = currentAmount.ToString("0.00");
                }
                else
                {
                    txttotalqty.Text = "";
                    txttotalamount.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //private void UpdateTotal()
        //{
        //    try
        //    {
        //        if (decimal.TryParse(txtqty.Text, out decimal currentQty) &&
        //       decimal.TryParse(txtrate.Text, out decimal currentRate))
        //        {
        //            decimal currentAmount = currentQty * currentRate;

        //            decimal totalQty = currentQty;
        //            decimal totalAmount = currentAmount;

        //            foreach (DataRow row in dtInvoiceItems.Rows)
        //            {
        //                totalQty += Convert.ToDecimal(row["Quantity"]);
        //                totalAmount += Convert.ToDecimal(row["Amount"]);
        //            }

        //            txttotalqty.Text = totalQty.ToString();
        //            txttotalamount.Text = totalAmount.ToString("");
        //        }
        //        else
        //        {
        //            // Just clear the totals if input is invalid
        //            txttotalqty.Text = "";
        //            txttotalamount.Text = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString());
        //    }

        //}

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("salesinvoice_sp", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@salesinvoiceid", si);
                        //cmd.Parameters.AddWithValue("@supplierid", cmbsuplier.Text.Trim());//this is combobox
                        cmd.Parameters.AddWithValue("@customerid", Convert.ToInt32(cmbsuplier.SelectedValue)); // ✅ Yeh sahi hai

                        cmd.Parameters.AddWithValue("@customeraddress", txtsupaddr.Text.Trim());
                        cmd.Parameters.AddWithValue("@salesinvoiceno", txtinvno.Text.Trim());
                        //cmd.Parameters.AddWithValue("@purchaseinvoicedate", txtpurchasedt.Text.Trim()); // this is date time picker
                        //cmd.Parameters.Add("@purchaseinvoicedate", SqlDbType.DateTime).Value = txtpurchasedt.Value;

                        cmd.Parameters.AddWithValue("@salesinvoicedate", txtpurchasedt.Value);

                        cmd.Parameters.AddWithValue("@customerreference", txtsupref.Text.Trim());

                        cmd.Parameters.AddWithValue("@notes", txtnotes.Text.Trim());
                        cmd.Parameters.AddWithValue("@totalqty", txttotalqty.Text.Trim());
                        cmd.Parameters.AddWithValue("@totalamount", txttotalamount.Text.Trim());

                        cmd.Parameters.AddWithValue("@createdby", Program.gblVer.userid); // Replace with actual user
                        cmd.Parameters.AddWithValue("@updatedby", DBNull.Value); // For insert


                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)

                        {
                            //Program.gblVer.userid = usrid;
                            si = Convert.ToInt32(dt.Rows[0][0]);


                            using (SqlCommand cmditem = new SqlCommand("Delete From SalesInvoiceDetail where salesinvoiceid= " + si, conn))
                            {
                                conn.Open();
                                cmditem.CommandType = CommandType.Text;
                                cmditem.ExecuteNonQuery();
                                conn.Close();
                            }


                            foreach (DataRow row in dtInvoiceItems.Rows)
                            {

                                using (SqlCommand cmditem = new SqlCommand("salesinvoicedetail_sp", conn))
                                {
                                    cmditem.CommandType = CommandType.StoredProcedure;

                                    cmditem.Parameters.AddWithValue("@salesinvoiceid", si);
                                   
                                    cmditem.Parameters.AddWithValue("@itemid", row["itemid"]);
                                    cmditem.Parameters.AddWithValue("@qty", row["qty"]);

                                    cmditem.Parameters.AddWithValue("@rate", row["rate"]);

                                    cmditem.Parameters.AddWithValue("@amount", row["amount"]);
                                    cmditem.Parameters.AddWithValue("@createdby", Program.gblVer.userid); // Replace with actual user
                                    cmditem.Parameters.AddWithValue("@updatedby", DBNull.Value); // For insert


                                    SqlDataAdapter ditem = new SqlDataAdapter(cmditem);
                                    DataTable dtitem = new DataTable();
                                    ditem.Fill(dtitem);

                                }



                            }
                            MessageBox.Show("Sales Invoice saved successfully! ID: " + si);
                            

                            //Auto refresh gridview
                            DialogResult = DialogResult.OK;
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("Sales Invoice save failed.");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cmbitem_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbitem.SelectedItem is DataRowView drv)
            {
                txtrate.Text = drv["purchasrprice"].ToString();
                CalculateAmount();
                UpdateTotal();

            }
        }

        private void txtrate_TextChanged_1(object sender, EventArgs e)
        {
            UpdateTotal();
            CalculateAmount();
        }

        private void txtamount_TextChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void txttotalqty_TextChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void txtqty_TextChanged_1(object sender, EventArgs e)
        {
            CalculateAmount();
            UpdateTotal();
        }

        private void cmbsuplier_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbsuplier.SelectedIndex != -1)
            {
                DataRowView drv = cmbsuplier.SelectedItem as DataRowView;
                if (drv != null)
                    txtsupaddr.Text = drv["customeraddress"].ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
    

