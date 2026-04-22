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
using System.Runtime.InteropServices; // For COM cleanup
using System.IO;

namespace UVTECH_BIZ
{
    public partial class usermst : Form
    {

        public DataTable userdata = new DataTable();
        public usermst()
        {

            InitializeComponent();
        }

        private void toolbtnadd_Click(object sender, EventArgs e)
        {
            User cust = new User(0);
            if (cust.ShowDialog() == DialogResult.OK)
            {
                //refresh ()
                LoadUserFromDB();
            }
        }

        public void LoadUserFromDB()
        {
            userdata = DbHelper.ExecuteSelectQuery("SELECT * FROM [User] WITH(NOLOCK)");
            usrgrd.DataSource = userdata;
            string[] unwantedCols = { "userid", "createddate", "createdby", "updateddate", "updatedby" };
            foreach (string col in unwantedCols)
            {
                if (usrgrd.Columns.Contains(col))
                    usrgrd.Columns[col].Visible = false;
            }
            // Change column header names
            usrgrd.Columns["username"].HeaderText = "User Name";
            usrgrd.Columns["password"].HeaderText = "Password";
            usrgrd.Columns["lastlogindate"].HeaderText = "lastlogindate";
           
        }
        public void RefreshCustomerGrid()
        {
            usrgrd.DataSource = null;
            usrgrd.DataSource = userdata;
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
                for (int i = 0; i < usrgrd.Columns.Count; i++)
                {
                    if (usrgrd.Columns[i].Visible)
                    {
                        colIndex++;
                        worksheet.Cells[1, colIndex] = usrgrd.Columns[i].HeaderText;
                    }
                }
                // Export data (only visible columns)
                for (int i = 0; i < usrgrd.Rows.Count; i++)
                {
                    colIndex = 0;
                    for (int j = 0; j < usrgrd.Columns.Count; j++)
                    {
                        if (usrgrd.Columns[j].Visible)
                        {
                            colIndex++;
                            var val = usrgrd.Rows[i].Cells[j].Value;
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

        private void usermst_Load(object sender, EventArgs e)
        {
            LoadUserFromDB();
        }
        //public void RefreshCustomerGrid()
        //{
        //    usrgrd.DataSource = null;
        //    usrgrd.DataSource = userdata;
        //}

        public void LoadCustomersFromDb()
        {

            userdata = DbHelper.ExecuteSelectQuery("SELECT * FROM User WITH(NOLOCK)");
            usrgrd.DataSource = userdata;
            string[] unwantedCols = { "userid", "createddate", "createdby", "updateddate", "updatedby" };
            foreach (string col in unwantedCols)
            {
                if (usrgrd.Columns.Contains(col))
                    usrgrd.Columns[col].Visible = false;
            }
            // Change column header names
            usrgrd.Columns["username"].HeaderText = "Username Name";
            usrgrd.Columns["customeraddress"].HeaderText = "Password";
            usrgrd.Columns["lastlogindate"].HeaderText = "Last Login";
         
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = usrgrd.SelectedCells[0].OwningRow;
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                User ui = new User(Convert.ToInt32(selectedRow["userid"]));
                if (ui.ShowDialog() == DialogResult.OK)
                {
                    //refresh ()
                    LoadCustomersFromDb();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void DeleteCustomer(int id)
        {
            string query = "DELETE FROM [User] WHERE userid = " + id;

            DbHelper.ExecuteNonQuery(query);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (usrgrd.SelectedCells.Count == 0)
                {
                    MessageBox.Show("Please Select Row");
                    return;
                }

                DataGridViewRow row = usrgrd.SelectedCells[0].OwningRow;
                DataRow selectedRow = ((DataRowView)row.DataBoundItem).Row;

                int itemID = Convert.ToInt32(selectedRow["userid"]);

                DialogResult result = MessageBox.Show("Are You Sure Want to Delete?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DeleteCustomer(itemID);
                    LoadUserFromDB(); // Refresh grid
                    MessageBox.Show("User deleted" + "ID:" + itemID);
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
                    usrgrd.DataSource = userdata;
                    return;
                }
                var filteredRows = userdata.AsEnumerable()
                .Where(row => row.ItemArray.Any(
                    field => field != null && field.ToString().ToLower().Contains(keyword)))
                .CopyToDataTable();
                usrgrd.DataSource = filteredRows;
            }
            catch
            {
                usrgrd.DataSource = userdata.Clone();
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
