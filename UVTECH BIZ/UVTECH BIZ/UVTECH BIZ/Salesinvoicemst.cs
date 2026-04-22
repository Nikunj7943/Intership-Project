using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;
using System.IO;


namespace UVTECH_BIZ
{
    public partial class Salesinvoicemst : Form
    {
        //public DataTable saleinvoice = new DataTable();
        public DataTable saleinvoice = new DataTable();
        public Salesinvoicemst()
        {
            InitializeComponent();
        }

        public void LoadPurchaseInvoiceFromDb()
        {
            saleinvoice = DbHelper.ExecuteSelectQuery("SELECT * FROM vw_salesinvoice WITH(NOLOCK)");
            salesgrd.DataSource = saleinvoice;
            string[] unwantedCols = { "salesinvoiceid", "createddate", "createdby", "updateddate", "updatedby" };
            foreach (string col in unwantedCols)
            {
                if (salesgrd.Columns.Contains(col))
                    salesgrd.Columns[col].Visible = false;
            }
            // Change column header names
            salesgrd.Columns["salesinvoicedate"].HeaderText = "Sales Invoice Date";
            salesgrd.Columns["salesinvoiceno"].HeaderText = "Sales Invoice No";
            salesgrd.Columns["customeraddress"].HeaderText = "Customer Address";
            salesgrd.Columns["customername"].HeaderText = "Customer Name";
            salesgrd.Columns["customerreference"].HeaderText = "Customer Reference";
            salesgrd.Columns["notes"].HeaderText = "Notes";
            salesgrd.Columns["totalqty"].HeaderText = "Total Quantity";
            salesgrd.Columns["totalamount"].HeaderText = "Total Amount";
            //purchasegrd.Columns["contactphone1"].HeaderText = "Contact Phone1";
            //purchasegrd.Columns["contactname2"].HeaderText = "Contact Name2";
            //purchasegrd.Columns["contactphone2"].HeaderText = "Contact Phone2";
        }

        private void toolbtnadd_Click(object sender, EventArgs e)
        {
            SalesInvoice si = new SalesInvoice(0);
            //purchaseinvouce.ShowDialog();

            //customer cust = new customer(0);
            if (si.ShowDialog() == DialogResult.OK)
            {
                //refresh ()
                LoadPurchaseInvoiceFromDb();
            }
        }

        private void Salesinvoicemst_Load(object sender, EventArgs e)
        {
            LoadPurchaseInvoiceFromDb();
        }

        public void RefreshCustomerGrid()
        {
            salesgrd.DataSource = null;
            salesgrd.DataSource = salesgrd;
        }

        public void DeleteCustomer(int id)
        {
            string query = "DELETE FROM SalesInvoice WHERE salesinvoiceid = " + id;

            DbHelper.ExecuteNonQuery(query);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (salesgrd.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Please Select Row");
                    return;
                }

                DataGridViewRow row = salesgrd.SelectedCells[0].OwningRow;
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                int salesid = Convert.ToInt32(selectedRow["salesinvoiceid"]);

                DialogResult result = MessageBox.Show("Are You Sure Want to Delete?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DeleteCustomer(salesid);
                    LoadPurchaseInvoiceFromDb(); // Refresh grid
                    MessageBox.Show("Invoice deleted" + salesid);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    salesgrd.DataSource =saleinvoice;
                    return;
                }
                var filteredRows = saleinvoice.AsEnumerable()
     .Where(row => row.ItemArray.Any(
         field => field != null && field.ToString().ToLower().Contains(keyword)));

                if (filteredRows.Any())
                {
                    salesgrd.DataSource = filteredRows.CopyToDataTable();
                }
                else
                {
                    salesgrd.DataSource = saleinvoice.Clone(); // Shows empty grid with same columns
                    MessageBox.Show("No customer found with the given search keyword.");
                }

            }
            catch
            {
                salesgrd.DataSource = saleinvoice.Clone();
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Enter key ka default action (beep sound) rokta hai
                btnSearch.PerformClick();  // Search button ka click manually call
            }
        }

        private void ExportToExcel()
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;
            try
            {
                excelApp = new Excel.Application();
                excelApp.DisplayAlerts = false;
                excelApp.Visible = false;
                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "ExportedData";
                // Export headers (only visible columns)
                int colIndex = 0;
                for (int i = 0; i < salesgrd.Columns.Count; i++)
                {
                    if (salesgrd.Columns[i].Visible)
                    {
                        colIndex++;
                        worksheet.Cells[1, colIndex] = salesgrd.Columns[i].HeaderText;
                    }
                }
                // Export data (only visible columns)
                for (int i = 0; i < salesgrd.Rows.Count; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j < salesgrd.Columns.Count; j++)
                    {
                        if (salesgrd.Columns[j].Visible)
                        {
                            colIndex++;
                            var val = salesgrd.Rows[i].Cells[j].Value;
                            worksheet.Cells[i + 2, colIndex] = val?.ToString() ?? "";
                        }
                    }
                }
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Save Excel File",
                    FileName = "CustomerData.xlsx"
                };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = sfd.FileName;
                    if (File.Exists(filePath))
                    {
                        try
                        {
                            File.Delete(filePath);
                        }
                        catch
                        {
                            this.Invoke(new Action(() =>
                            {
                                MessageBox.Show(this, "The file is currently open. Please close it and try again.", "File Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }));
                            return;
                        }
                    }
                    workbook.SaveAs(filePath);
                    this.Invoke(new Action(() =>
                    {
                        DialogResult result = MessageBox.Show(
                            this,
                            "Export completed!\nDo you want to open the exported file?",
                            "Export Done",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );
                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                System.Diagnostics.Process.Start(filePath);
                            }
                            catch (Exception openEx)
                            {
                                MessageBox.Show(this, $"Could not open file:\n{openEx.Message}", "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }));
                }
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(this, $"File Already Open or Export Failed:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
            finally
            {
                if (workbook != null) workbook.Close(false);
                if (excelApp != null) excelApp.Quit();
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            btnExport.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            Thread staThread = new Thread(() =>
            {
                ExportToExcel();
                this.Invoke(new Action(() =>
                {
                    Cursor.Current = Cursors.Default;
                    btnExport.Enabled = true;
                }));
            });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = salesgrd.SelectedCells[0].OwningRow;
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                SalesInvoice it = new SalesInvoice(Convert.ToInt32(selectedRow["salesinvoiceid"]));
                if (it.ShowDialog() == DialogResult.OK)
                {
                    //refresh ()
                    LoadPurchaseInvoiceFromDb ();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
