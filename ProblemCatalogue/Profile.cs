using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;
using System.Windows.Forms;
using System.IO;


namespace ProblemCatalogue
{
    public partial class btnUploadPicture : Form
    {
        private const int DefaultImageWidth = 188;
        private const int DefaultImageHeight = 175;
        private string userName;
        private const string profilePicturesFolderPath = @"\\smartdev\Drive_D\OSS_Knowledge-Library\UserProfiles";
        public btnUploadPicture(string loggedInUsername)
        {
            InitializeComponent();
            userName = loggedInUsername;
            lblUserName.Text = loggedInUsername;
            LoadUserData();

            supportGrid.RowPrePaint += supportGrid_RowPrePaint;
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Details";
            buttonColumn.Name = "viewDetails";
            buttonColumn.Text = "View";
            buttonColumn.UseColumnTextForButtonValue = true;
            supportGrid.Columns.Add(buttonColumn);

            int columnIndex = 0;
            supportGrid.Sort(supportGrid.Columns[columnIndex], System.ComponentModel.ListSortDirection.Descending);
        }

        private void LoadUserData()
        {
            string connectionString = "User Id=drs;Password=drs;Data Source=SmartDev.ftcp.ten.fujitsu.com:1521/xepdb1";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT SECTION, DAILYC, MONTHLYC, OVERALLC FROM SSC_EMP WHERE NAME = :userName";
                    using (OracleCommand command = new OracleCommand(sqlQuery, connection))
                    {
                        command.Parameters.Add("loggedInUsername", OracleDbType.Varchar2).Value = userName;
                        OracleDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            lblUserName.Text = userName;
                            lblSection.Text = reader["SECTION"].ToString();
                            lblDailyC.Text = reader["DAILYC"].ToString();
                            lblMonthlyC.Text = reader["MONTHLYC"].ToString();
                            lblOverallC.Text = reader["OVERALLC"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("User not found.");
                            this.Close();
                        }
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("An error occured while loading user data: " + ex.Message);
                this.Close();
            }
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            LoadDataGridViewData();
            LoadProfilePicture();

        }
        private void supportGrid_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            supportGrid.Rows[e.RowIndex].Height = 75;
        }

        private void LoadDataGridViewData()
        {
            DataTable dataTable = new DataTable();
            string connectionString = "User Id=drs;Password=drs;Data Source=SmartDev.ftcp.ten.fujitsu.com:1521/xepdb1";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT CCREF, CCTITLE, CCSYSTEM, CCGRP, CCPIC FROM SSC_CAT WHERE CCPIC = :userName";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("userName", OracleDbType.Varchar2).Value = userName;
                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            supportGrid.DataSource = dataTable;

            supportGrid.Columns["CCREF"].HeaderText = "Reference No";
            supportGrid.Columns["CCTITLE"].HeaderText = "Title";
            supportGrid.Columns["CCSYSTEM"].HeaderText = "System";
            supportGrid.Columns["CCGRP"].HeaderText = "Group";
            supportGrid.Columns["CCPIC"].HeaderText = "PIC";
        }

        private void supportGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == supportGrid.Columns["viewDetails"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = supportGrid.Rows[e.RowIndex];
                string referenceNo = selectedRow.Cells[1].Value.ToString();

                Dictionary<string, string> rowData = FetchRowDataFromDatabase(referenceNo);

                DetailsForm detailsForm = new DetailsForm(rowData, userName);
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

        private void button1_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files | *.jpg;*.jpeg;*.png;*.gif;*.bmp;*";
                openFileDialog.Title = "Select Profile Picture";

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image selectedImage = Image.FromFile(openFileDialog.FileName);
                        Image resizedImage = ResizeImage(selectedImage, DefaultImageWidth, DefaultImageHeight);

                        pictureBox1.Image = resizedImage;
                        string filePath = SaveProfilePictureToFile(resizedImage);
                        SaveProfilePictureToDataBase(filePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading the image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadProfilePicture()
        {
            string connectionString = "User Id=drs;Password=drs;Data Source=SmartDev.ftcp.ten.fujitsu.com:1521/xepdb1";
            try
            {
                string profilePicturePath;
                using(OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT PROFILEPICT FROM SSC_EMP WHERE NAME = :userName";
                    using(OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("userName", OracleDbType.Varchar2).Value = userName;
                        profilePicturePath = (string)command.ExecuteScalar();
                    }
                }
                if(!string.IsNullOrEmpty(profilePicturePath) && File.Exists(profilePicturePath))
                {
                    Image profileImage = Image.FromFile(profilePicturePath);
                    pictureBox1.Image = profileImage;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error loading the profile picture: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SaveProfilePictureToFile(Image image)
        {
            string fileNameWithoutExtension = $"{userName}_profile_picture";
            string filePath;
            int counter = 0;
            do
            {
                string fileName = $"{fileNameWithoutExtension}_{counter}.png";
                filePath = Path.Combine(profilePicturesFolderPath, fileName);
                counter++;
            } while (File.Exists(filePath));

            if (!Directory.Exists(profilePicturesFolderPath))
                Directory.CreateDirectory(profilePicturesFolderPath);
            image.Save(filePath, ImageFormat.Png);
            return filePath;
        }

        private void SaveProfilePictureToDataBase(string filePath)
        {
            string connectionString = "User Id=drs;Password=drs;Data Source=SmartDev.ftcp.ten.fujitsu.com:1521/xepdb1";
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE SSC_EMP SET PROFILEPICT = :filePath WHERE NAME = :userName";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add("filePath", OracleDbType.Varchar2).Value = filePath;
                    command.Parameters.Add("userName", OracleDbType.Varchar2).Value = userName;
                    command.ExecuteNonQuery();
                }
            }
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using(Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
