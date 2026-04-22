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
    public partial class itemmaster : Form
    {
        public DataTable itemdata = new DataTable();
        public itemmaster()
        {
            InitializeComponent();
        }

        private void toolbtnadd_Click(object sender, EventArgs e)
        {
            Item i = new Item(0);
            if (i.ShowDialog() == DialogResult.OK)
            {
                //refresh ()
                LoadItemFromDb();
            }
        }

        private void itemmaster_Load(object sender, EventArgs e)
        {
            LoadItemFromDb();
        }

        public void LoadItemFromDb()
        {
            try
            {
                itemdata = DbHelper.ExecuteSelectQuery("SELECT * FROM Item WITH(NOLOCK)");
                itemgrd.DataSource = itemdata;
                string[] unwantedCols = { "itemid", "createddate", "createdby", "updateddate", "updatedby" };
                foreach (string col in unwantedCols)
                {
                    if (itemgrd.Columns.Contains(col))
                        itemgrd.Columns[col].Visible = false;
                }
                // Change column header names
                itemgrd.Columns["itemname"].HeaderText = "Item Name";
                itemgrd.Columns["itemgroup"].HeaderText = "Item Group";
                itemgrd.Columns["purchasrprice"].HeaderText = "Purchase Price";
                itemgrd.Columns["saleprice"].HeaderText = "Sale Price";
                itemgrd.Columns["barcode"].HeaderText = "Barcode";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        public void RefreshCustomerGrid()
        {
            itemgrd.DataSource = null;
            itemgrd.DataSource = itemgrd;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim().ToLower();
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    itemgrd.DataSource = itemdata;
                    return;
                }
                var filteredRows = itemdata.AsEnumerable()
                .Where(row => row.ItemArray.Any(
                    field => field != null && field.ToString().ToLower().Contains(keyword)))
                .CopyToDataTable();
                itemgrd.DataSource = filteredRows;
            }
            catch
            {
                itemgrd.DataSource = itemdata.Clone();
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
                for (int i = 0; i < itemgrd.Columns.Count; i++)
                {
                    if (itemgrd.Columns[i].Visible)
                    {
                        colIndex++;
                        worksheet.Cells[1, colIndex] = itemgrd.Columns[i].HeaderText;
                    }
                }
                // Export data (only visible columns)
                for (int i = 0; i < itemgrd.Rows.Count; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j < itemgrd.Columns.Count; j++)
                    {
                        if (itemgrd.Columns[j].Visible)
                        {
                            colIndex++;
                            var val = itemgrd.Rows[i].Cells[j].Value;
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

        private void itemgrd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // this.itemgrd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemgrd_CellClick);
            if (e.RowIndex >= 0) // Make sure it's not header row
            {
                DataGridViewRow row = itemgrd.Rows[e.RowIndex];
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                Item it = new Item(Convert.ToInt32(selectedRow["itemid"]));
                if (it.ShowDialog() == DialogResult.OK)
                {
                    //refresh ()
                    LoadItemFromDb();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = itemgrd.SelectedCells[0].OwningRow;
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                Item it = new Item(Convert.ToInt32(selectedRow["itemid"]));
                if (it.ShowDialog() == DialogResult.OK)
                {
                    //refresh ()
                    LoadItemFromDb();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void DeleteCustomer(int id)
        {
            string query = "DELETE FROM item WHERE itemid = " + id;

            DbHelper.ExecuteNonQuery(query);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemgrd.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Please Select Row");
                    return;
                }

                DataGridViewRow row = itemgrd.SelectedCells[0].OwningRow;
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                int itemID = Convert.ToInt32(selectedRow["itemid"]);

                DialogResult result = MessageBox.Show("Are You Sure Want to Delete?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DeleteCustomer(itemID);
                    LoadItemFromDb(); // Refresh grid
                    MessageBox.Show("Item deleted" +"ID:"+ itemID);
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
    }
}
