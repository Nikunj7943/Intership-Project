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
    public partial class PurchaseInvoice : Form
    {
        public string connStr = ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
        private DataTable dtSupplier = new DataTable();
        private DataTable dtItem = new DataTable();
        public DataTable purinvoice = new DataTable();
        private DataTable dtInvoiceItems = new DataTable();
        private int pi = 0;
        public PurchaseInvoice(int _pi)
        {
            InitializeComponent();
            pi = _pi;
        }

        private void FillData()
        {
            try
            {
                string query = "SELECT * FROM [dbo].[Purchaseinvoice] where purchaseinvoiceid=" + pi;
                DataTable dtPurchase = DbHelper.ExecuteSelectQuery(query);

                //if (cmbitem.SelectedItem is DataRowView drv)
                //{
                //    txtrate.Text = drv["purchasrprice"].ToString();
                //    CalculateAmount();
                //    UpdateTotal();
                //}

                if (dtPurchase.Rows.Count > 0)
                {

                    cmbsuplier.SelectedValue = Convert.ToInt32(dtPurchase.Rows[0]["supplierid"]);
                    //cmbitem.SelectedValue = Convert.ToInt32(purinvoice.Rows[0]["itemid"]);
                    txtsupaddr.Text = dtPurchase.Rows[0]["supplieraddress"].ToString();
                    txtinvno.Text = dtPurchase.Rows[0]["purchaseinvoiceno"].ToString();
                    txtsupref.Text = dtPurchase.Rows[0]["supplierrference"].ToString();
                    txtpurchasedt.Value = Convert.ToDateTime(dtPurchase.Rows[0]["purchaseinvoicedate"]);
                    //txtqty.Text = purinvoice.Rows[0]["qty"].ToString();
                    //txtrate.Text = purinvoice.Rows[0]["rate"].ToString();
                    //txtamount.Text = purinvoice.Rows[0]["amount"].ToString();
                    txtnotes.Text = dtPurchase.Rows[0]["notes"].ToString();
                    txttotalqty.Text = dtPurchase.Rows[0]["totalqty"].ToString();
                    txttotalamount.Text = dtPurchase.Rows[0]["totalamount"].ToString();


                }


                query = "SELECT * FROM vw_purchaseinvoicedetail where purchaseinvoiceid=" + pi;
                dtInvoiceItems = DbHelper.ExecuteSelectQuery(query);

                purchasegrd.DataSource = dtInvoiceItems;
                purchasegrd.Columns["purchaseinvoiceid"].Visible = false;
                purchasegrd.Columns["purchaseinvoicedetailid"].Visible = false;
                purchasegrd.Columns["itemid"].Visible = false;
                purchasegrd.Columns["createdby"].Visible = false;
                purchasegrd.Columns["itemname"].HeaderText = "ItemName";
                purchasegrd.Columns["qty"].HeaderText = "Quantity";
                purchasegrd.Columns["rate"].HeaderText = "Rate";
                purchasegrd.Columns["amount"].HeaderText = "Amount";

            }
            catch (Exception ex)
            {
                MessageBox.Show(" Error: " + ex.Message);
            }
        }
        private void LoadSuppliers()
        {
            try
            {
                string query = "SELECT supplierid, suppliername,supplieraddress FROM Supplier";
                dtSupplier = DbHelper.ExecuteSelectQuery(query);
                cmbsuplier.DataSource = dtSupplier;
                cmbsuplier.DisplayMember = "suppliername";
                cmbsuplier.ValueMember = "supplierid";
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
        public void LoadPurchaseInvoice(int pi)
        {
            try
            {
                //purinvoice = DbHelper.ExecuteSelectQuery("SELECT *  FROM [dbo].[vw_PurchaseInvoice2] WITH(NOLOCK) where purchaseinvoiceid=" + pi.ToString());
                purinvoice = DbHelper.ExecuteSelectQuery("SELECT * FROM PurchaseInvoice with(nolock) where purchaseinvoiceid=" + pi.ToString());
                dtInvoiceItems = DbHelper.ExecuteSelectQuery("Select * from vw_purchaseinvoicedetail with(nolock) where purchaseinvoiceid=" + pi.ToString());

                if (dtInvoiceItems.Rows.Count > 0)
                {

                }
                if (purinvoice.Rows.Count > 0)
                {
                    cmbsuplier.SelectedValue = Convert.ToInt32(purinvoice.Rows[0]["supplierid"]);
                    //cmbitem.SelectedValue = Convert.ToInt32(purinvoice.Rows[0]["itemid"]);
                    txtsupaddr.Text = purinvoice.Rows[0]["supplieraddress"].ToString();
                    txtinvno.Text = purinvoice.Rows[0]["purchaseinvoiceno"].ToString();
                    txtsupref.Text = purinvoice.Rows[0]["supplierrference"].ToString();
                    txtpurchasedt.Value = Convert.ToDateTime(purinvoice.Rows[0]["purchaseinvoicedate"]);
                    //txtqty.Text = purinvoice.Rows[0]["qty"].ToString();
                    //txtrate.Text = purinvoice.Rows[0]["rate"].ToString();
                    //txtamount.Text = purinvoice.Rows[0]["amount"].ToString();
                    txtnotes.Text = purinvoice.Rows[0]["notes"].ToString();
                    txttotalqty.Text = purinvoice.Rows[0]["totalqty"].ToString();
                    txttotalamount.Text = purinvoice.Rows[0]["totalamount"].ToString();

                }
                else
                {

                    //txtbarcode.Text = "";
                    //txtbarcode.Text = "";
                    //txtitemgroup.Text = "";
                    //txtpurchase.Text = "";
                    //txtsale.Text = "";
                    //txtbarcode.Text = "";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }
        private void PurchaseInvoice_Load(object sender, EventArgs e)
        {
            cmbsuplier.SelectedIndex = -1;
            cmbitem.SelectedIndex = -1;
            txtsupaddr.Clear();
            txtrate.Clear();

            LoadSuppliers();
            LoadItem();
            FillData();
            //LoadPurchaseInvoice(pi);

            //purchasegrd.DataSource = dtInvoiceItems;
        }
        private void button1_Click(object sender, EventArgs e)
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


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    txtsupaddr.Text = drv["supplieraddress"].ToString();
            }
        }
        private void cmbitem_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (purchasegrd.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Please Select Row");
                    return;
                }

                DataGridViewRow row = purchasegrd.SelectedCells[0].OwningRow;
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;
                if (selectedRow["purchaseinvoicedetailid"] == DBNull.Value)
                {
                    MessageBox.Show("Item ID is missing, cannot delete.");
                    return;
                }

                int detailID = Convert.ToInt32(selectedRow["purchaseinvoicedetailid"]);

                //int detailID = Convert.ToInt32(selectedRow["purchaseinvoicedetailid"]);

                DialogResult result = MessageBox.Show("Are You Sure Want to Delete?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM PurchaseInvoiceDetail WHERE purchaseinvoicedetailid = " + detailID;
                    DbHelper.ExecuteNonQuery(query);

                    dtInvoiceItems.Rows.Remove(selectedRow);
                    MessageBox.Show("Item deleted successfully.");

                    UpdateTotal(); // ✅ Total update karo
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }



        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("purchaseinvoice_sp", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@purchaseinvoiceid", pi);
                        //cmd.Parameters.AddWithValue("@supplierid", cmbsuplier.Text.Trim());//this is combobox
                        cmd.Parameters.AddWithValue("@supplierid", Convert.ToInt32(cmbsuplier.SelectedValue)); // ✅ Yeh sahi hai

                        cmd.Parameters.AddWithValue("@supplieraddress", txtsupaddr.Text.Trim());
                        cmd.Parameters.AddWithValue("@purchaseinvoiceno", txtinvno.Text.Trim());
                        //cmd.Parameters.AddWithValue("@purchaseinvoicedate", txtpurchasedt.Text.Trim()); // this is date time picker
                        //cmd.Parameters.Add("@purchaseinvoicedate", SqlDbType.DateTime).Value = txtpurchasedt.Value;

                        cmd.Parameters.AddWithValue("@purchaseinvoicedate", txtpurchasedt.Value);

                        cmd.Parameters.AddWithValue("@supplierrference", txtsupref.Text.Trim());

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
                            pi = Convert.ToInt32(dt.Rows[0][0]);

                            using (SqlCommand cmditem = new SqlCommand("Delete From [dbo].[PurchaseInvoiceDetail] where purchaseinvoiceid= " + pi, conn))
                            {
                                conn.Open();
                                cmditem.CommandType = CommandType.Text;
                                cmditem.ExecuteNonQuery();
                                conn.Close();
                            }

                            foreach (DataRow row in dtInvoiceItems.Rows)
                            {

                                using (SqlCommand cmditem = new SqlCommand("purchaseinvoicedetail_sp", conn))
                                {
                                    cmditem.CommandType = CommandType.StoredProcedure;

                                    cmditem.Parameters.AddWithValue("@purchaseinvoiceid", pi);
                                    //cmd.Parameters.AddWithValue("@purchaseinvoiceid", Convert.ToInt32(cmbsuplier.SelectedValue)); // ✅ Yeh sahi hai
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



                            MessageBox.Show("Purchase Invoice saved successfully! ID: " + pi);


                            //Auto refresh gridview
                            DialogResult = DialogResult.OK;
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("Purchase Invoice save failed.");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txttotalamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsupaddr_TextChanged(object sender, EventArgs e)
        {

        }


        private void purchasegrd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

    }
}