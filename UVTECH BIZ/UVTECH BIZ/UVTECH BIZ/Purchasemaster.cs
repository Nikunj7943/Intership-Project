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
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace UVTECH_BIZ
{
    public partial class Purchasemaster : Form
    {
        public DataTable purinvoice = new DataTable();
        public Purchasemaster()
        {
            InitializeComponent();
        }

        public void LoadPurchaseInvoiceFromDb()
        {
            purinvoice = DbHelper.ExecuteSelectQuery("SELECT * FROM vw_purchaseinvoice WITH(NOLOCK)");
            purchasegrd.DataSource = purinvoice;
            string[] unwantedCols = { "purchaseinvoiceid", "createddate", "createdby", "updateddate", "updatedby" };
            foreach (string col in unwantedCols)
            {
                if (purchasegrd.Columns.Contains(col))
                    purchasegrd.Columns[col].Visible = false;
            }
            // Change column header names
            purchasegrd.Columns["purchaseinvoiceno"].HeaderText = "Purchase Invoice No";
            purchasegrd.Columns["suppliername"].HeaderText = "Supplier Name";
            purchasegrd.Columns["supplieraddress"].HeaderText = "Supplier Address";
            purchasegrd.Columns["supplierrference"].HeaderText = "Supplier Reference";
            purchasegrd.Columns["notes"].HeaderText = "Notes";
            purchasegrd.Columns["purchaseinvoicedate"].HeaderText = "Purchase Invoice Date";
            purchasegrd.Columns["totalqty"].HeaderText = "Total Quantity";
            purchasegrd.Columns["totalamount"].HeaderText = "Total Amount";
              }
        private void toolbtnadd_Click(object sender, EventArgs e)
        {
            PurchaseInvoice pi = new PurchaseInvoice(0);
           
            if (pi.ShowDialog() == DialogResult.OK)
            {
              
                LoadPurchaseInvoiceFromDb();
            }
        }

        private void Purchasemaster_Load(object sender, EventArgs e)
        {
            LoadPurchaseInvoiceFromDb();
        }

        public void RefreshCustomerGrid()
        {
            purchasegrd.DataSource = null;
            purchasegrd.DataSource = purchasegrd;
        }

        private void purchasegrd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // this.custgrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.custgrid_CellClick);
            if (e.RowIndex >= 0) // Make sure it's not header row
            {
                DataGridViewRow row = purchasegrd.Rows[e.RowIndex];
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;
                Customerupd updForm = new Customerupd(selectedRow);
                updForm.ShowDialog();
                // Optionally refresh after update
                LoadPurchaseInvoiceFromDb();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    purchasegrd.DataSource = purinvoice;
                    return;
                }
                var filteredRows = purinvoice.AsEnumerable()
     .Where(row => row.ItemArray.Any(
         field => field != null && field.ToString().ToLower().Contains(keyword)));

                if (filteredRows.Any())
                {
                    purchasegrd.DataSource = filteredRows.CopyToDataTable();
                }
                else
                {
                    purchasegrd.DataSource = purinvoice.Clone(); // Shows empty grid with same columns
                    MessageBox.Show("No invoice found with the given search keyword.");
                }

            }
            catch
            {
                purchasegrd.DataSource = purinvoice.Clone();
            }
        }

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Enter key ka default action (beep sound) rokta hai
                btnSearch.PerformClick();  // Search button ka click manually call
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = purchasegrd.SelectedCells[0].OwningRow;
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                PurchaseInvoice pus = new PurchaseInvoice(Convert.ToInt32(selectedRow["purchaseinvoiceid"]));
                if (pus.ShowDialog() == DialogResult.OK)
                {
                    //refresh ()
                    LoadPurchaseInvoiceFromDb();
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void DeleteCustomer(int id)
        {
            string query = "DELETE FROM Purchaseinvoice WHERE purchaseinvoiceid = " + id;

            DbHelper.ExecuteNonQuery(query);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
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

                int purchaseid = Convert.ToInt32(selectedRow["purchaseinvoiceid"]);

                DialogResult result = MessageBox.Show("Are You Sure Want to Delete?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DeleteCustomer(purchaseid);
                    LoadPurchaseInvoiceFromDb(); 
                    MessageBox.Show(" deleted" + purchaseid);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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

        private void purchasegrd_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure it's not header row
            {
                DataGridViewRow row = purchasegrd.Rows[e.RowIndex];
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                PurchaseInvoice pur = new PurchaseInvoice(Convert.ToInt32(selectedRow["purchaseinvoiceid"]));
                if (pur.ShowDialog() == DialogResult.OK)
                {
                    //refresh ()
                    LoadPurchaseInvoiceFromDb();
                }

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
                for (int i = 0; i < purchasegrd.Columns.Count; i++)
                {
                    if (purchasegrd.Columns[i].Visible)
                    {
                        colIndex++;
                        worksheet.Cells[1, colIndex] = purchasegrd.Columns[i].HeaderText;
                    }
                }
                // Export data (only visible columns)
                for (int i = 0; i < purchasegrd.Rows.Count; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j < purchasegrd.Columns.Count; j++)
                    {
                        if (purchasegrd.Columns[j].Visible)
                        {
                            colIndex++;
                            var val = purchasegrd.Rows[i].Cells[j].Value;
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

        private void purchasegrd_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

           

        }
    }
}
