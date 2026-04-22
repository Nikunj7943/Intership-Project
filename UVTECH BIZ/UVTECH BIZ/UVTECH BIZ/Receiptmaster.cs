using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

using System.IO;
using System.Threading;

namespace UVTECH_BIZ
{
    public partial class Receiptmaster : Form
    {

        public DataTable receiptdata = new DataTable();
        public Receiptmaster()
        {
            InitializeComponent();
        }

        private void Receiptmaster_Load(object sender, EventArgs e)
        {
            LoadReceiptFromDb();
        }

        public void LoadReceiptFromDb()
        {

            receiptdata = DbHelper.ExecuteSelectQuery("SELECT * FROM vw_receipt WITH(NOLOCK)");
            custgrid.DataSource = receiptdata;
            string[] unwantedCols = { "receiptid", "createddate", "createdby", "updateddate", "updatedby" };
            foreach (string col in unwantedCols)
            {
                if (custgrid.Columns.Contains(col))
                    custgrid.Columns[col].Visible = false;
            }
            // Change column header names
            custgrid.Columns["receiptno"].HeaderText = "Receipt No";
            custgrid.Columns["receiptdate"].HeaderText = "Receipt Date";
            custgrid.Columns["customername"].HeaderText = "Customer Name";
            custgrid.Columns["totalamount"].HeaderText = "Total Amount";
            
        }


        public void RefreshCustomerGrid()
        {
            custgrid.DataSource = null;
            custgrid.DataSource = receiptdata;
        }

        private void toolbtnadd_Click(object sender, EventArgs e)
        {
            Receipt rp = new Receipt(0);
            if (rp.ShowDialog() == DialogResult.OK)
            {
                //refresh ()
                LoadReceiptFromDb();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    custgrid.DataSource = receiptdata;
                    return;
                }
                var filteredRows = receiptdata.AsEnumerable()
                .Where(row => row.ItemArray.Any(
                    field => field != null && field.ToString().ToLower().Contains(keyword)))
                .CopyToDataTable();
                custgrid.DataSource = filteredRows;
            }
            catch
            {
                custgrid.DataSource = receiptdata.Clone();
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = custgrid.SelectedCells[0].OwningRow;
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                Receipt re = new Receipt(Convert.ToInt32(selectedRow["receiptid"]));
                if (re.ShowDialog() == DialogResult.OK)
                {
                    //refresh ()
                    LoadReceiptFromDb();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void custgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public void DeleteCustomer(int id)
        {
            string query = "DELETE FROM Receipt WHERE receiptid = " + id;

            DbHelper.ExecuteNonQuery(query);
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

                int receiptID = Convert.ToInt32(selectedRow["receiptid"]);

                DialogResult result = MessageBox.Show("Are You Sure Want to Delete?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DeleteCustomer(receiptID = Convert.ToInt32(selectedRow["receiptid"])); LoadReceiptFromDb(); // Refresh grid
                    MessageBox.Show("Receipt deleted" + "ID" + receiptID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void custgrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Make sure it's not header row
                {
                    DataGridViewRow row = custgrid.Rows[e.RowIndex];
                    DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                    Receipt re = new Receipt(Convert.ToInt32(selectedRow["receiptid"]));
                    if (re.ShowDialog() == DialogResult.OK)
                    {
                        //refresh ()
                        LoadReceiptFromDb();

                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ToString());
            }
            
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                btnSearch.PerformClick();  
            }

        }
    }
}
