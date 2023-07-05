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
    public partial class RegisterForm : Form
    {
        private string loggedInUsername;
        public RegisterForm(string loggedInUsername)
        {
            InitializeComponent();
            tBox_Ref.Text = GenerateReferenceNo();
            this.loggedInUsername = loggedInUsername;
            tB_PIC.Text = loggedInUsername;
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
                string connectionString = "Data Source=10.164.11.44:1521/xepdb1;User Id = drs; Password=drs;";
                string refNo = tBox_Ref.Text;
                string title = tB_Title.Text;
                string system = tB_System.Text;
                string line = tB_Line.Text;
                string description = tB_Description.Text;
                string resolution = tB_Resolution.Text;
                string pic = tB_PIC.Text;
                string secgroup = cBox_Grp.Text;

                string sqlInsert = "INSERT INTO SSC_CAT (CCREF, CCTITLE, CCSYSTEM, CCLINE, CCDESC, CCRESO, \"CCGRP\", CCPIC) " + "VALUES (:refNo, :title, :system, :line, :description, :resolution, :secgroup, :pic)";
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
                            command.Parameters.Add("resolution", OracleDbType.Varchar2).Value = resolution;
                            command.Parameters.Add("secgroup", OracleDbType.Varchar2).Value = secgroup;
                            command.Parameters.Add("pic", OracleDbType.Varchar2).Value = pic;
                            command.ExecuteNonQuery();
                        }
                        tBox_Ref.Text = GenerateReferenceNo();
                        tB_Title.Text = string.Empty;
                        tB_System.Text = string.Empty;
                        tB_Line.Text = string.Empty;
                        tB_Description.Text = string.Empty;
                        tB_Resolution.Text = string.Empty;
                        tB_PIC.Text = string.Empty;
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
    }
}
