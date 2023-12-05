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
    public partial class RegisterForm : Form
    {
        private string Username;
        private string selectedFilePath;
        public RegisterForm(string loggedInUsername)
        {
            InitializeComponent();
            tBox_Ref.Text = GenerateReferenceNo();
            Username = loggedInUsername;
            tB_PIC.Text = Username;
        }
        private string GenerateReferenceNo()
        {
            string referenceNo = string.Empty;
            referenceNo = DateTime.Now.ToString("yyyyMMdd-HHmmss");

            return referenceNo;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private bool AreTextBoxesFilled()
        {
            if(string.IsNullOrWhiteSpace(tBox_Ref.Text) ||
                string.IsNullOrWhiteSpace(tB_Title.Text) ||
                string.IsNullOrWhiteSpace(tB_System.Text) ||
                string.IsNullOrWhiteSpace(tB_Line.Text) ||
                string.IsNullOrWhiteSpace(tB_Description.Text) ||
                string.IsNullOrWhiteSpace(tB_Resolution.Text) ||
                string.IsNullOrWhiteSpace(tB_PIC.Text) ||
                string.IsNullOrWhiteSpace(tb_CauseP.Text) ||
                string.IsNullOrWhiteSpace(cBox_Grp.Text))
            {
                return false;
            }
            return true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (AreTextBoxesFilled())
            {
                string connectionString = "User Id=drs;Password=drs;Data Source=SmartDev.ftcp.ten.fujitsu.com:1521/xepdb1";
                string refNo = tBox_Ref.Text;
                string title = tB_Title.Text;
                string system = tB_System.Text;
                string line = tB_Line.Text;
                string description = tB_Description.Text;
                string causeOFP = tb_CauseP.Text;
                string resolution = tB_Resolution.Text;
                string pic = tB_PIC.Text;
                string secgroup = cBox_Grp.Text;
                string attachFile = txtFilePath.Text;

                IncrementSSCEMPCounts(Username);

                string sqlInsert = "INSERT INTO SSC_CAT (CCREF, CCTITLE, CCSYSTEM, CCLINE, CCDESC, CCCAUSE, CCRESO, \"CCGRP\", CCPIC, CCATTACH) " + "VALUES (:refNo, :title, :system, :line, :description, :causeOFP, :resolution, :secgroup, :pic, :attachFile)";
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (OracleCommand command = new OracleCommand(sqlInsert, connection))
                        {
                            command.Parameters.Add("refNo", OracleDbType.Varchar2).Value = refNo;
                            command.Parameters.Add("title", OracleDbType.Varchar2).Value = title;
                            command.Parameters.Add("system", OracleDbType.Varchar2).Value = system;
                            command.Parameters.Add("line", OracleDbType.Varchar2).Value = line;
                            command.Parameters.Add("description", OracleDbType.Varchar2).Value = description;
                            command.Parameters.Add("causeOFP", OracleDbType.Varchar2).Value = causeOFP;
                            command.Parameters.Add("resolution", OracleDbType.Varchar2).Value = resolution;
                            command.Parameters.Add("secgroup", OracleDbType.Varchar2).Value = secgroup;
                            command.Parameters.Add("pic", OracleDbType.Varchar2).Value = pic;
                            command.Parameters.Add("attachFile", OracleDbType.Varchar2).Value = attachFile;
                            command.ExecuteNonQuery();
                        }
                        tBox_Ref.Text = GenerateReferenceNo();
                        tB_Title.Text = string.Empty;
                        tB_System.Text = string.Empty;
                        tB_Line.Text = string.Empty;
                        tB_Description.Text = string.Empty;
                        tb_CauseP.Text = string.Empty;
                        tB_Resolution.Text = string.Empty;
                        tB_PIC.Text = Username;
                        txtFilePath.Text = string.Empty;
                        cBox_Grp.SelectedIndex = -1;

                        MessageBox.Show("Registration Saved!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error ocurred while registering the datas: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill in all the fields.");
            }
        }

        private void IncrementSSCEMPCounts(string pic)
        {
            string connectionString = "User Id=drs;Password=drs;Data Source=SmartDev.ftcp.ten.fujitsu.com:1521/xepdb1";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT DAILYC, MONTHLYC, OVERALLC FROM SSC_EMP WHERE NAME = :username";
                    using (OracleCommand command = new OracleCommand(sqlQuery, connection))
                    {
                        command.Parameters.Add("username", OracleDbType.Varchar2).Value = Username;
                        OracleDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            int dailyC = Convert.ToInt32(reader["DAILYC"]);
                            int monthlyC = Convert.ToInt32(reader["MONTHLYC"]);
                            int overallC = Convert.ToInt32(reader["OVERALLC"]);
                            dailyC++;
                            monthlyC++;
                            overallC++;

                            string newDailyC = dailyC.ToString();
                            string newMonthlyC = monthlyC.ToString();
                            string newOverallC = overallC.ToString();

                            string updateQuery = "UPDATE SSC_EMP SET DAILYC = :dailyC, MONTHLYC = :monthlyC, OVERALLC = :overallC WHERE NAME = :Username";

                            using (OracleCommand updateCommand = new OracleCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.Add("dailyC", OracleDbType.Varchar2).Value = newDailyC;
                                updateCommand.Parameters.Add("monthlyC", OracleDbType.Varchar2).Value = newMonthlyC;
                                updateCommand.Parameters.Add("overallC", OracleDbType.Varchar2).Value = newOverallC;
                                updateCommand.Parameters.Add("Username", OracleDbType.Varchar2).Value = Username;

                                updateCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("An error occurred while incrementing counts in Table: " + ex.Message);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
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
