using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices; // For COM cleanup
using System.IO;
namespace UVTECH_BIZ
{
    public partial class Custmaster : Form
    {
        public DataTable custdata = new DataTable();
        //private int custid = 0;
        public Custmaster()
        {
            //custid = _custid;
            InitializeComponent();
        }
       
        private void Custmaster_Load(object sender, EventArgs e)
        {
            LoadCustomersFromDb();
        }
        public void LoadCustomersFromDb()
        {
           
            custdata = DbHelper.ExecuteSelectQuery("SELECT * FROM Customer WITH(NOLOCK)");
            custgrid.DataSource = custdata;
            string[] unwantedCols = { "customerid", "createddate", "createdby", "updateddate", "updatedby" };
            foreach (string col in unwantedCols)
            {
                if (custgrid.Columns.Contains(col))
                    custgrid.Columns[col].Visible = false;
            }
            // Change column header names
            custgrid.Columns["customername"].HeaderText = "Customer Name";
            custgrid.Columns["customeraddress"].HeaderText = "Customer Address";
            custgrid.Columns["city"].HeaderText = "City";
            custgrid.Columns["country"].HeaderText = "Country";
            custgrid.Columns["postcode"].HeaderText = "PostCode";
            custgrid.Columns["contactname1"].HeaderText = "Contact Name1";
            custgrid.Columns["contactphone1"].HeaderText = "Contact Phone1";
            custgrid.Columns["contactname2"].HeaderText = "Contact Name2";
            custgrid.Columns["contactphone2"].HeaderText = "Contact Phone2";
        }
        public void RefreshCustomerGrid()
        {
            custgrid.DataSource = null;
            custgrid.DataSource = custdata;
        }
        private void toolbtnadd_Click(object sender, EventArgs e)
        {
            customer cust = new customer(0);
            if (cust.ShowDialog() == DialogResult.OK)
            {

                LoadCustomersFromDb();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    custgrid.DataSource = custdata;
                    return;
                }
                var filteredRows = custdata.AsEnumerable()
     .Where(row => row.ItemArray.Any(
         field => field != null && field.ToString().ToLower().Contains(keyword)));

                if (filteredRows.Any())
                {
                    custgrid.DataSource = filteredRows.CopyToDataTable();
                }
                else
                {
                    custgrid.DataSource = custdata.Clone(); // Shows empty grid with same columns
                    MessageBox.Show("No customer found with the given search keyword.");
                }

            }
            catch
            {
                custgrid.DataSource = custdata.Clone();
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
        private void custgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // this.custgrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.custgrid_CellClick);
            if (e.RowIndex >= 0) // Make sure it's not header row
            {
                DataGridViewRow row = custgrid.Rows[e.RowIndex];
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;
                
                customer cust = new customer(Convert.ToInt32(selectedRow["Customerid"]));
                if (cust.ShowDialog() == DialogResult.OK)
                {
                    //refresh ()
                    LoadCustomersFromDb();
                }

            }
        }
         private void custgrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = custgrid.SelectedCells[0].OwningRow;
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                customer cust = new customer(Convert.ToInt32(selectedRow["Customerid"]));
                if (cust.ShowDialog() == DialogResult.OK)
                {
                    //refresh ()
                    LoadCustomersFromDb();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
           

        }


        public void DeleteCustomer(int id)
        {
            string query = "DELETE FROM Customer WHERE CustomerId = " + id;
           
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

                int customerID = Convert.ToInt32(selectedRow["customerid"]);

                DialogResult result = MessageBox.Show("Are You Sure Want to Delete?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DeleteCustomer(customerID);
                    LoadCustomersFromDb(); // Refresh grid
                    MessageBox.Show("Customer deleted"+ customerID);
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
                e.SuppressKeyPress = true; // Stops the "ding" sound
                btnSearch.PerformClick();  // Triggers the search button click
            }
        }

        private void custgrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void custgrid_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure it's not header row
            {
                DataGridViewRow row = custgrid.Rows[e.RowIndex];
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                customer cust = new customer(Convert.ToInt32(selectedRow["Customerid"]));
                if (cust.ShowDialog() == DialogResult.OK)
                {
                    //refresh ()
                    LoadCustomersFromDb();
                }

            }
        }

        private void custgrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure it's not header row
            {
                DataGridViewRow row = custgrid.Rows[e.RowIndex];
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                customer cust = new customer(Convert.ToInt32(selectedRow["Customerid"]));
                if (cust.ShowDialog() == DialogResult.OK)
                {
                    //refresh ()
                    LoadCustomersFromDb();
                }

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

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
    }
}
