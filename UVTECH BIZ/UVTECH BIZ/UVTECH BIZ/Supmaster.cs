using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices; // For COM cleanup
using System.IO;
using System.Threading;


namespace UVTECH_BIZ
{
    public partial class Supmaster : Form
    {
        public DataTable supdata = new DataTable();
        public Supmaster()
        {
            InitializeComponent();
        }

        private void toolbtnadd_Click(object sender, EventArgs e)
        {
            supplier sup = new supplier(0);
            if (sup.ShowDialog() == DialogResult.OK)
            {
                //refresh ()
                LoadSupplierFromDb();
            }
        }
        public void LoadSupplierFromDb()
        {

            supdata = DbHelper.ExecuteSelectQuery("SELECT * FROM Supplier WITH(NOLOCK)");
            supgrd.DataSource = supdata;
            string[] unwantedCols = { "supplierid", "createddate", "createdby", "updateddate", "updatedby" };
            foreach (string col in unwantedCols)
            {
                if (supgrd.Columns.Contains(col))
                    supgrd.Columns[col].Visible = false;
            }
            // Change column header names
            supgrd.Columns["suppliername"].HeaderText = "Supplier Name";
            supgrd.Columns["supplieraddress"].HeaderText = "Supplier Address";
            supgrd.Columns["city"].HeaderText = "City";
            supgrd.Columns["country"].HeaderText = "Country";
            supgrd.Columns["postcode"].HeaderText = "PostCode";
            supgrd.Columns["contactname1"].HeaderText = "Contact Name1";
            supgrd.Columns["contactphone1"].HeaderText = "Contact Phone1";
            supgrd.Columns["contactname2"].HeaderText = "Contact Name2";
            supgrd.Columns["contactphone2"].HeaderText = "Contact Phone2";
        }
        public void RefreshCustomerGrid()
        {
            supgrd.DataSource = null;
            supgrd.DataSource = supdata;
        }

        private void Supmaster_Load(object sender, EventArgs e)
        {
            LoadSupplierFromDb();
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
                for (int i = 0; i < supgrd.Columns.Count; i++)
                {
                    if (supgrd.Columns[i].Visible)
                    {
                        colIndex++;
                        worksheet.Cells[1, colIndex] = supgrd.Columns[i].HeaderText;
                    }
                }
                // Export data (only visible columns)
                for (int i = 0; i < supgrd.Rows.Count; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j < supgrd.Columns.Count; j++)
                    {
                        if (supgrd.Columns[j].Visible)
                        {
                            colIndex++;
                            var val = supgrd.Rows[i].Cells[j].Value;
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
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            
            try
            {
                if (supgrd.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Please select a supplier row.");
                    return;
                }

                var row = supgrd.SelectedCells[0].OwningRow;
                if (row.DataBoundItem is DataRowView drv)
                {
                    var selectedRow = drv.Row;
                    supplier sup = new supplier(Convert.ToInt32(selectedRow["supplierid"]));
                    if (sup.ShowDialog() == DialogResult.OK)
                    {
                        LoadSupplierFromDb();
                    }
                }
                else
                {
                    MessageBox.Show("Could not read selected data. Try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        

            //try
            //{
            //    DataGridViewRow row = supgrd.SelectedCells[0].OwningRow;
            //    DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

            //    supplier sup = new supplier(Convert.ToInt32(selectedRow["supplierid"]));
            //    if (sup.ShowDialog() == DialogResult.OK)
            //    {
            //        //refresh ()
            //        LoadSupplierFromDb();
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }

        private void custgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure it's not header row
            {
                DataGridViewRow row = supgrd.Rows[e.RowIndex];
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                supplier sup = new supplier(Convert.ToInt32(selectedRow["supplierid"]));
                if (sup.ShowDialog() == DialogResult.OK)
                {
                    //refresh ()
                    LoadSupplierFromDb();
                }

            }
        }

        public void DeleteSupplier(int id)
        {
            string query = "DELETE FROM Supplier WHERE supplierid ="+id;

            DbHelper.ExecuteNonQuery(query);
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (supgrd.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Please Select Row");
                    return;
                }

                DataGridViewRow row = supgrd.SelectedCells[0].OwningRow;
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                int supplierID = Convert.ToInt32(selectedRow["supplierid"]);

                DialogResult result = MessageBox.Show("Are You Sure Want to Delete?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DeleteSupplier(supplierID);
                    LoadSupplierFromDb(); // Refresh grid
                    MessageBox.Show("Supplier deleted " + " ID" + supplierID);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    supgrd.DataSource = supdata;
                    return;
                }
                var filteredRows = supdata.AsEnumerable()
     .Where(row => row.ItemArray.Any(
         field => field != null && field.ToString().ToLower().Contains(keyword)));

                if (filteredRows.Any())
                {
                    supgrd.DataSource = filteredRows.CopyToDataTable();
                }
                else
                {
                    supgrd.DataSource = supdata.Clone(); // Shows empty grid with same columns
                    MessageBox.Show("No Supplier found with the given search keyword.");
                }

            }
            catch
            {
                supgrd.DataSource = supdata.Clone();
            }
        }

       

        private void supgrd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // this.custgrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.custgrid_CellClick);
            if (e.RowIndex >= 0) // Make sure it's not header row
            {
                DataGridViewRow row = supgrd.Rows[e.RowIndex];
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                supplier sup = new supplier(Convert.ToInt32(selectedRow["supplierid"]));
                if (sup.ShowDialog() == DialogResult.OK)
                {
                    //refresh ()
                    LoadSupplierFromDb();
                }
            }
        }

        private void supgrd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void supgrd_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

      
        private void toolStripButton3_Click_1(object sender, EventArgs e)
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
