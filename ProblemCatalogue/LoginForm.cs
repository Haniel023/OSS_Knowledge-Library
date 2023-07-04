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
using System.Data;

namespace ProblemCatalogue
{
    public partial class LoginForm : Form
    {

        private static string connectionString = "Data Source=10.164.11.44:1521/xepdb1;User Id = drs; Password=drs;";
        public LoginForm()
        {
            InitializeComponent();
        }
        private OracleConnection GetOracleConnection()
        {
            return new OracleConnection(connectionString);
        }

        private UserCredentials ValidateUser(string username, string password)
        {
            int userId = 0;
            string userName = string.Empty;
            string userSection = string.Empty;

            using (OracleConnection connection = GetOracleConnection())
            {
                connection.Open();
                string query = "SELECT EMPNO, NAME, SECTION FROM SSC_EMP WHERE EMPNO = :username AND PASSWORD = :password";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    command.Parameters.Add(":username", OracleDbType.Varchar2).Value = username;
                    command.Parameters.Add(":password", OracleDbType.Varchar2).Value = password;

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = Convert.ToInt32(reader["EMPNO"]);
                            userName = reader["NAME"].ToString();
                            userSection = reader["SECTION"].ToString();
                        }
                    }
                }
            }
            return new UserCredentials(userId, userName, userSection);
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = userTB.Text;
            string password = passTB.Text;

            UserCredentials credentials = ValidateUser(username, password);
            if (credentials.UserId != 0)
            {
                string loggedInUsername = credentials.UserName;
                RegisterForm registerForm = new RegisterForm();
                registerForm.LoggedInUsername = loggedInUsername;

                // Open MainForm and set the connection
                LandForm landForm = new LandForm();
                landForm.Connection = GetOracleConnection();
                landForm.Show();

                // Hide the login form if desired
                Hide();
                // Display logged-in user's name in MainForm
                landForm.lblUserName.Text = credentials.UserName;
                landForm.lblSection.Text = credentials.UserSection;
            }
            else
            {
                invalidLbl.Visible = true;
            }
        }

        public struct UserCredentials {
            public int UserId { get; }
            public string UserName { get; }
            public string UserSection { get;  }

            public UserCredentials(int userId, string userName, string userSection)
            {
                UserId = userId;
                UserName = userName;
                UserSection = userSection;
            }
        }
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
