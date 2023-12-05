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
using System.Diagnostics;

namespace ProblemCatalogue
{
    public partial class LandingPage : Form
    {
        private string Username;
        private Timer resetTimer = new Timer();
        public LandingPage(string loggedInUsername)
        {
            InitializeComponent();
            Username = loggedInUsername;
            lblSystemDate.Text = DateTime.Now.ToShortDateString();
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            resetTimer.Interval = 3600000;
            resetTimer.Tick += ResetTimer_Tick;
            resetTimer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblSystemTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void ResetTimer_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            if (CheckDailyReset(currentTime))
            {
                ResetDailyC(currentTime);
            }
            if (CheckMonthlyReset(currentTime))
            {
                ResetMonthlyC(currentTime);
            }
        }

        private DateTime GetLastDailyResetDateFromDatabase()
        {
            string connectionString = "User Id=drs;Password=drs;Data Source=SmartDev.ftcp.ten.fujitsu.com:1521/xepdb1";
            DateTime lastDailyReset = DateTime.MinValue;

            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT DAILYC_LAST_RESET FROM SSC_EMP WHERE NAME = :Username";
                    string userName = Username;

                    using(OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("name", OracleDbType.Varchar2).Value = userName;
                        object result = command.ExecuteScalar();
                        if(result != null && result != DBNull.Value)
                        {
                            lastDailyReset = Convert.ToDateTime(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieveing the last daily reset date: " + ex.Message);
            }
            return lastDailyReset;
        }

        private bool CheckDailyReset(DateTime currentTime)
        {
            DateTime lastDailyReset = GetLastDailyResetDateFromDatabase();
            if((currentTime - lastDailyReset).TotalHours >= 24)
            {
                return true;
            }
            return false;
        }

        private void ResetDailyC(DateTime currentTime)
        {
            string connectionString = "User Id=drs;Password=drs;Data Source=SmartDev.ftcp.ten.fujitsu.com:1521/xepdb1";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE SSC_EMP SET DAILYC = '0', DAILYC_LAST_RESET = :currentTime";
                    using (OracleCommand updateCommand = new OracleCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.Add("currentTime", OracleDbType.Date).Value = currentTime;
                        updateCommand.ExecuteNonQuery();
                    }
                }
            } catch(Exception ex)
            {
                MessageBox.Show("An error occurred while resetting DAILYC Column in Table: " + ex.Message);
            }
        }

        private DateTime GetLastMonthlyResetDateFromDatabase()
        {
            string connectionString = "User Id=drs;Password=drs;Data Source=SmartDev.ftcp.ten.fujitsu.com:1521/xepdb1";
            DateTime lastMonthlyReset = DateTime.MinValue;

            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT MONTHLY_LAST_RESET FROM SSC_EMP WHERE NAME = :Username";
                    string userName = Username;

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.Parameters.Add("name", OracleDbType.Varchar2).Value = userName;
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            lastMonthlyReset = Convert.ToDateTime(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieveing the last monthly reset date: " + ex.Message);
            }
            return lastMonthlyReset;
        }

        private bool CheckMonthlyReset(DateTime currentTime)
        {
            DateTime lastMonthlyReset = GetLastMonthlyResetDateFromDatabase();
            if((currentTime - lastMonthlyReset).TotalDays >= 30)
            {
                return true;
            }
            return false;
        }

        private void ResetMonthlyC(DateTime currentTime)
        {
            string connectionString = "User Id=drs;Password=drs;Data Source=SmartDev.ftcp.ten.fujitsu.com:1521/xepdb1";
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE SSC_EMP SET MONTHLYC = '0', MONTHLY_LAST_RESET = :currentTime";
                    using (OracleCommand updateCommand = new OracleCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.Add("currentTime", OracleDbType.Date).Value = currentTime;

                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while resetting MONTHLY Column in Table " + ex.Message);
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string recipientEmail = "jetherhaniel.deleon@denso-ten.com";

                string subject = "OSS Knowledge Library Support";
                string body = "Hi, I have encountered a problem with Knowledge Library. I would like to ask for a support.";

                string mailtoUri = $"mailto:{recipientEmail}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(body)}";
                Process.Start(mailtoUri);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Found: " + ex.Message);
            }
        }
    }
}
