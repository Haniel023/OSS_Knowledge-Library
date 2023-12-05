using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace ProblemCatalogue
{
    public partial class CatalogueTable : Form
    {
        private string Username;
        public event EventHandler DataRefreshed;
        public CatalogueTable(string loggedInUsername)
        {
            InitializeComponent();
            Username = loggedInUsername;
            LoadDataFromDatabase();

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Details";
            buttonColumn.Name = "viewDetails";
            buttonColumn.Text = "View";
            buttonColumn.UseColumnTextForButtonValue = true;
            supportGrid.Columns.Add(buttonColumn);

            supportGrid.RowPrePaint += supportGrid_RowPrePaint;
            int columnIndex = 0;
            supportGrid.Sort(supportGrid.Columns[columnIndex], System.ComponentModel.ListSortDirection.Descending);
        }

        private void supportGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            supportGrid.Rows[e.RowIndex].Height = 100;
            supportGrid.Columns[0].DefaultCellStyle.Padding = new Padding((supportGrid.Columns[0].Width - 140) / 2, 0, 0, 0);
            supportGrid.Columns[0].Width = 30;
            supportGrid.Columns[1].Width = 100;
            supportGrid.Columns[2].Width = 400;
            supportGrid.Columns[3].Width = 80;
            supportGrid.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            supportGrid.Columns[4].Width = 80;
            supportGrid.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            supportGrid.Columns[5].Width = 80;
            supportGrid.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private DataTable originalDataTable;
        private DataTable filteredDataTable;

        private void Form_Load(object sender, EventArgs e)
        {
            originalDataTable = ((DataTable)supportGrid.DataSource)?.Copy();
        }

        private void supportGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == supportGrid.Columns["viewDetails"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = supportGrid.Rows[e.RowIndex];
                string referenceNo = selectedRow.Cells[1].Value.ToString();

                Dictionary<string, string> rowData = FetchRowDataFromDatabase(referenceNo);

                DetailsForm detailsForm = new DetailsForm(rowData, Username);
                detailsForm.Show();
            }
        }

        private Dictionary<string, string> FetchRowDataFromDatabase(string referenceNo)
        {
            Dictionary<string, string> rowData = new Dictionary<string, string>();

            string connectionString = "User Id=drs;Password=drs;Data Source=SmartDev.ftcp.ten.fujitsu.com:1521/xepdb1";
             
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();
                using (OracleCommand command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM SSC_CAT WHERE CCREF = :referenceNo";
                    command.Parameters.Add(new OracleParameter("referenceNo", referenceNo));

                    OracleDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);
                            string columnValue = reader.IsDBNull(i) ? string.Empty : reader.GetString(i);
                            rowData[columnName] = columnValue;
                        }
                    }
                    reader.Close();
                }
            }
            return rowData;
        }

        private void LoadDataFromDatabase()
        {
            string connectionString = "User Id=drs;Password=drs;Data Source=SmartDev.ftcp.ten.fujitsu.com:1521/xepdb1";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT CCREF, CCTITLE, CCSYSTEM, CCGRP, CCPIC FROM SSC_CAT";
                using (OracleCommand command = new OracleCommand(query, connection))
                {

                    using (OracleDataAdapter adapater = new OracleDataAdapter(command))
                    {
                        originalDataTable = new DataTable();
                        adapater.Fill(originalDataTable);

                        supportGrid.DataSource = originalDataTable;

                        supportGrid.Columns["CCREF"].HeaderText = "Reference No";
                        supportGrid.Columns["CCTITLE"].HeaderText = "Title";
                        supportGrid.Columns["CCSYSTEM"].HeaderText = "System";
                        supportGrid.Columns["CCGRP"].HeaderText = "Group";
                        supportGrid.Columns["CCPIC"].HeaderText = "PIC";
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(searchQuery))
            {
                supportGrid.DataSource = originalDataTable;
            }
            else
            {
                filteredDataTable = originalDataTable.Clone();
                foreach (DataRow row in originalDataTable.Rows)
                {
                    object cellValue = row[1];
                    object cellValue2 = row[2];
                    if ((cellValue != null && cellValue.ToString().IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0) || (cellValue2 != null && cellValue.ToString().IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0))
                    {
                        filteredDataTable.Rows.Add(row.ItemArray);
                    }
                }
                supportGrid.DataSource = filteredDataTable;
            }
        }
    }
}
