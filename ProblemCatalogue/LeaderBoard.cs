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
using System.Drawing.Imaging;
using System.IO;


namespace ProblemCatalogue
{
    public partial class LeaderBoard : Form
    {
        public class User
        {
            public string Name { get; set; }
            public string Section { get; set; }
            public string ProfilePicturePath { get; set; }
            public decimal MonthlyScore { get; set; }
        }

        public LeaderBoard()
        {
            InitializeComponent();
        }

        private void LeaderBoard_Load(object sender, EventArgs e)
        {
            List<User> users = FetchUsersFromDatabase();
            users.Sort((user1, user2) => user2.MonthlyScore.CompareTo(user1.MonthlyScore));

            lbl_Top1.Text = users[0].Name;
            lbl_Top1Grp.Text = users[0].Section;
            lbl_points1.Text = users[0].MonthlyScore.ToString();
            pb_Top1.Image = GetProfilePictureFromPath(users[0].ProfilePicturePath);
            pb_Top1.SizeMode = PictureBoxSizeMode.StretchImage;

            lbl_Top2.Text = users[1].Name;
            lbl_Top2Grp.Text = users[1].Section;
            lbl_points2.Text = users[1].MonthlyScore.ToString();
            pb_Top2.Image = GetProfilePictureFromPath(users[1].ProfilePicturePath);
            pb_Top2.SizeMode = PictureBoxSizeMode.StretchImage;

            lbl_Top3.Text = users[2].Name;
            lbl_Top3Grp.Text = users[2].Section;
            lbl_points3.Text = users[2].MonthlyScore.ToString();
            pb_Top3.Image = GetProfilePictureFromPath(users[2].ProfilePicturePath);
            pb_Top3.SizeMode = PictureBoxSizeMode.StretchImage;

            lbl_Top4.Text = users[3].Name;
            lbl_Top4Grp.Text = users[3].Section;
            lbl_points4.Text = users[3].MonthlyScore.ToString();
            pb_Top4.Image = GetProfilePictureFromPath(users[3].ProfilePicturePath);
            pb_Top4.SizeMode = PictureBoxSizeMode.StretchImage;

            lbl_Top5.Text = users[4].Name;
            lbl_Top5Grp.Text = users[4].Section;
            lbl_points5.Text = users[4].MonthlyScore.ToString();
            pb_Top5.Image = GetProfilePictureFromPath(users[4].ProfilePicturePath);
            pb_Top5.SizeMode = PictureBoxSizeMode.StretchImage;

            lbl_Top6.Text = users[5].Name;
            lbl_Top6Grp.Text = users[5].Section;
            lbl_points6.Text = users[5].MonthlyScore.ToString();
            pb_Top6.Image = GetProfilePictureFromPath(users[5].ProfilePicturePath);
            pb_Top6.SizeMode = PictureBoxSizeMode.StretchImage;

            lbl_Top7.Text = users[6].Name;
            lbl_Top7Grp.Text = users[6].Section;
            lbl_points7.Text = users[6].MonthlyScore.ToString();
            pb_Top7.Image = GetProfilePictureFromPath(users[6].ProfilePicturePath);
            pb_Top7.SizeMode = PictureBoxSizeMode.StretchImage;

            lbl_Top8.Text = users[7].Name;
            lbl_Top8Grp.Text = users[7].Section;
            lbl_points8.Text = users[7].MonthlyScore.ToString();
            pb_Top8.Image = GetProfilePictureFromPath(users[7].ProfilePicturePath);
            pb_Top8.SizeMode = PictureBoxSizeMode.StretchImage;

            lbl_Top9.Text = users[8].Name;
            lbl_Top9Grp.Text = users[8].Section;
            lbl_points9.Text = users[8].MonthlyScore.ToString();
            pb_Top9.Image = GetProfilePictureFromPath(users[8].ProfilePicturePath);
            pb_Top9.SizeMode = PictureBoxSizeMode.StretchImage;

            lbl_Top10.Text = users[9].Name;
            lbl_Top10Grp.Text = users[9].Section;
            lbl_points10.Text = users[9].MonthlyScore.ToString();
            pb_Top10.Image = GetProfilePictureFromPath(users[9].ProfilePicturePath);
            pb_Top10.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private List<User> FetchUsersFromDatabase()
        {
            List<User> users = new List<User>();
            string connectionString = "User Id=drs;Password=drs;Data Source=SmartDev.ftcp.ten.fujitsu.com:1521/xepdb1";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT NAME, SECTION, PROFILEPICT, MONTHLYC FROM SSC_EMP";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = reader["NAME"].ToString();
                                string section = reader["SECTION"].ToString();
                                string profilePicturePath = reader["PROFILEPICT"].ToString();
                                decimal monthlyScore = Convert.ToDecimal(reader["MONTHLYC"]);

                                users.Add(new User { Name = name, Section = section, ProfilePicturePath = profilePicturePath, MonthlyScore = monthlyScore });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return users;
        }

        private Image GetProfilePictureFromPath(string imagePath)
        {
            try
            {
                if (File.Exists(imagePath))
                {
                    return Image.FromFile(imagePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading profile picture: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
