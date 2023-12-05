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
using System.Data.SqlClient;
using System.IO;

namespace ProblemCatalogue
{
    public partial class EditForm : Form
    {
        private Dictionary<string, string> rowData;
        public EditForm(Dictionary<string, string> rowData)
        {
            this.rowData = rowData;
            this.Load += EditForm_Load;
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            int groupIndex = -1;
            if(rowData["CCGRP"] == "SMART")
            {
                groupIndex = 0;
            }
            else if (rowData["CCGRP"] == "DEV")
            {
                groupIndex = 1;
            }
            else if (rowData["CCGRP"] == "NETWORK")
            {
                groupIndex = 2;
            }
            else
            {

            }
            tBox_Ref.Text = rowData["CCREF"];
            tB_Title.Text = rowData["CCTITLE"];
            tB_System.Text = rowData["CCSYSTEM"];
            tB_Line.Text = rowData["CCLINE"];
            tB_Description.Text = rowData["CCDESC"];
            tb_CauseP.Text = rowData["CCCAUSE"];
            tB_Resolution.Text = rowData["CCRESO"];
            tB_PIC.Text = rowData["CCPIC"];
            txtFilePath.Text = rowData["CCATTACH"];
            cBox_Grp.SelectedIndex = groupIndex;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string entryRef = tBox_Ref.Text;
            string editedTitle = tB_Title.Text;
            string editedSystem = tB_System.Text;
            string editedLine = tB_Line.Text;
            string editedDesc = tB_Description.Text;
            string editedCause = tb_CauseP.Text;
            string editedResolution = tB_Resolution.Text;
            string editedPIC = tB_PIC.Text;
            string editedAttach = txtFilePath.Text;
            string editedGrp = cBox_Grp.Text;

            UpdateDatabaseRecord(entryRef, editedTitle, editedSystem, editedLine, editedDesc, editedCause, editedResolution, editedPIC, editedAttach, editedGrp);
            this.Close();

        }

        private void UpdateDatabaseRecord(string entryRef, string editedTitle, string editedSystem, string editedLine, string editedDesc, string editedCause, string editedResolution, string editedPIC, string editedAttach, string editedGrp)
        {
            try
            {
                string connectionString = "User Id=drs;Password=drs;Data Source=SmartDev.ftcp.ten.fujitsu.com:1521/xepdb1";
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE SSC_CAT SET " + "CCTITLE = :Title, " + "CCSYSTEM = :System, " + "CCLINE = :Line, " + "CCDESC = :Description, " + "CCCAUSE = :Cause, " + "CCRESO = :Resolution, " + "CCPIC = :PIC, " + "CCATTACH = :Attach, " + "CCGRP = :GroupSelected " + "WHERE CCREF = :Ref";

                    using (OracleCommand command = new OracleCommand(updateQuery, connection))
                    {
                        command.Parameters.Add(":Title", OracleDbType.Varchar2).Value = editedTitle;
                        command.Parameters.Add(":System", OracleDbType.Varchar2).Value = editedSystem;
                        command.Parameters.Add(":Line", OracleDbType.Varchar2).Value = editedLine;
                        command.Parameters.Add(":Description", OracleDbType.Varchar2).Value = editedDesc;
                        command.Parameters.Add(":Cause", OracleDbType.Varchar2).Value = editedCause;
                        command.Parameters.Add(":Resolution", OracleDbType.Varchar2).Value = editedResolution;
                        command.Parameters.Add(":PIC", OracleDbType.Varchar2).Value = editedPIC;
                        command.Parameters.Add(":Attach", OracleDbType.Varchar2).Value = editedAttach;
                        command.Parameters.Add(":GroupSelected", OracleDbType.Varchar2).Value = editedGrp;
                        command.Parameters.Add(":Ref", OracleDbType.Varchar2).Value = entryRef;
                        command.ExecuteNonQuery();
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
            }
            }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls|PowerPoint Files (*.pptx;*.ppt)|*.pptx;*.ppt|All Files (*.*)|*.*";
                    openFileDialog.Title = "Select a file";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string selectedFilePath = openFileDialog.FileName;
                        string destinationFolder = @"\\smartdev\Drive_D\OSS_Knowledge-Library\attachments";

                        try
                        {
                            string fileName = Path.GetFileName(selectedFilePath);
                            string destinationFilePath = Path.Combine(destinationFolder, fileName);
                            txtFilePath.Text = destinationFilePath;

                            File.Copy(selectedFilePath, destinationFilePath, true);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occured while uploading the file " + ex.Message);
                        }
                    }
                }
            }
        }
    }
}
