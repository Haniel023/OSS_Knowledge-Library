using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace ProblemCatalogue
{
    public partial class DetailsForm : Form
    {
        private Dictionary<string, string> rowData;
        private string loggedInUser;
        private const string profilePicturesFolderPath = @"\\smartdev\Drive_D\OSS_Knowledge-Library\UserProfiles";
        private const int DefaultImageWidth = 130;
        private const int DefaultImageHeight = 130;
        private string PIC;
        public DetailsForm(Dictionary<string, string> rowData, string Username)
        {
            InitializeComponent();
            this.rowData = rowData;
            this.Load += DetailsForm_Load;
            loggedInUser = Username;
            PIC = rowData["CCPIC"];
        }
        private void DetailsForm_Load(object sender, EventArgs e)
        {
            textBox_ref.Text = rowData["CCREF"];
            textBox_title.Text = rowData["CCTITLE"];
            textBox_System.Text = rowData["CCSYSTEM"];
            textBox_Line.Text = rowData["CCLINE"];
            textBox_Desc.Text = rowData["CCDESC"];
            textBox_Cause.Text = rowData["CCCAUSE"];
            textBox_Reso.Text = rowData["CCRESO"];
            textBox_Grp.Text = rowData["CCGRP"];
            textBox_PIC.Text = rowData["CCPIC"];
            txtSavedPath.Text = rowData["CCATTACH"];
            
            if(textBox_PIC.Text != loggedInUser)
            {
                btn_Edit.Visible = false;
            }

            LoadProfilePicture();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox_title_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_PIC_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string filePath = txtSavedPath.Text;

            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    Process.Start(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured while opening the file: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No file path available");
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm(rowData);
            editForm.ShowDialog();
            this.Close();
        }

        private void LoadProfilePicture()
        {
            string connectionString = "User Id=drs;Password=drs;Data Source=SmartDev.ftcp.ten.fujitsu.com:1521/xepdb1";
            try
            {
                string profilePicturePath;
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT PROFILEPICT FROM SSC_EMP WHERE NAME = :userName";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("userName", OracleDbType.Varchar2).Value = PIC;
                        profilePicturePath = (string)command.ExecuteScalar();
                    }
                }
                if (!string.IsNullOrEmpty(profilePicturePath) && File.Exists(profilePicturePath))
                {
                    Image profileImage = Image.FromFile(profilePicturePath);
                    pictureBox1.Image = profileImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading the profile picture: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

