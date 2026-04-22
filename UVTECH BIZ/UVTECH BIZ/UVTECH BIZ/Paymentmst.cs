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
    public partial class Paymentmst : Form
    {
        public DataTable paymentdata = new DataTable();
        public Paymentmst()
        {
            InitializeComponent();
        }

        public void LoadPaymentFromDb()
        {

            paymentdata = DbHelper.ExecuteSelectQuery("SELECT * FROM vw_payment WITH(NOLOCK)");
            custgrid.DataSource = paymentdata;
            string[] unwantedCols = { "paymentid", "createddate", "createdby", "updateddate", "updatedby" };
            foreach (string col in unwantedCols)
            {
                if (custgrid.Columns.Contains(col))
                    custgrid.Columns[col].Visible = false;
            }
            // Change column header names
            custgrid.Columns["paymentno"].HeaderText = "Payment No";
            custgrid.Columns["paymentdate"].HeaderText = "Payment Date";
            custgrid.Columns["suppliername"].HeaderText = "Supplier Name";
            custgrid.Columns["totalamount"].HeaderText = "Total Amount";

        }

        private void Paymentmst_Load(object sender, EventArgs e)
        {
            LoadPaymentFromDb();
        }

        public void RefreshCustomerGrid()
        {
            custgrid.DataSource = null;
            custgrid.DataSource = paymentdata;
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

    private void toolbtnadd_Click(object sender, EventArgs e)
        {
            Payment pay = new Payment(0);
            if (pay.ShowDialog() == DialogResult.OK)
            {
                //refresh ()
                LoadPaymentFromDb();
            }

            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                string keyword = txtSearch.Text.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    custgrid.DataSource = paymentdata;
                    return;
                }
                var filteredRows = paymentdata.AsEnumerable()
                .Where(row => row.ItemArray.Any(
                    field => field != null && field.ToString().ToLower().Contains(keyword)))
                .CopyToDataTable();
                custgrid.DataSource = filteredRows;
            }
            catch
            {
                custgrid.DataSource = paymentdata.Clone();
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
                for (int i = 0; i < custgrid.Columns.Count; i++)
                {
                    if (custgrid.Columns[i].Visible)
                    {
                        colIndex++;
                        worksheet.Cells[1, colIndex] = custgrid.Columns[i].HeaderText;
                    }
                }
                // Export data (only visible columns)
                for (int i = 0; i < custgrid.Rows.Count; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j < custgrid.Columns.Count; j++)
                    {
                        if (custgrid.Columns[j].Visible)
                        {
                            colIndex++;
                            var val = custgrid.Rows[i].Cells[j].Value;
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

            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void DeleteCustomer(int id)
        {
            string query = "DELETE FROM Payment WHERE paymentid = " + id;

            DbHelper.ExecuteNonQuery(query);
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = custgrid.SelectedCells[0].OwningRow;
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                Payment pay = new Payment(Convert.ToInt32(selectedRow["paymentid"]));
                if (pay.ShowDialog() == DialogResult.OK)
                {
                    //refresh ()
                    LoadPaymentFromDb();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (custgrid.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Please Select Row");
                    return;
                }

                DataGridViewRow row = custgrid.SelectedCells[0].OwningRow;
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                int supID = Convert.ToInt32(selectedRow["paymentid"]);

                DialogResult result = MessageBox.Show("Are You Sure Want to Delete?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DeleteCustomer(supID);
                    LoadPaymentFromDb(); // Refresh grid
                    MessageBox.Show("Payment deleted" +" "+ supID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void custgrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure it's not header row
            {
                DataGridViewRow row = custgrid.Rows[e.RowIndex];
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                Payment pay = new Payment(Convert.ToInt32(selectedRow["paymentid"]));
                if (pay.ShowDialog() == DialogResult.OK)
                {
                    //refresh ()
                    LoadPaymentFromDb();
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Stops the "ding" sound
                btnSearch.PerformClick();  // Triggers the search button click
            }
        }
    }
}
