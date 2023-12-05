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
using System.IO;

namespace ProblemCatalogue
{
    public partial class LandForm : Form
    {
        public OracleConnection Connection { get; set; }
        public LandForm()
        {
            InitializeComponent();
            string loggedInUsername = lblUserName.Text;
            LandingPage landPage = new LandingPage(loggedInUsername);
            landPage.FormBorderStyle = FormBorderStyle.None;
            landPage.TopLevel = false;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(landPage);
            landPage.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblSection.Parent = splitContainer1.Panel1;
            lblSection.Anchor = AnchorStyles.None;
            lblSection.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Connection.Close();
            Connection.Dispose();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
        //Clicking Landing Button
        private void button3_Click(object sender, EventArgs e)
        {
            string loggedInUsername = lblUserName.Text;
            LandingPage landPage = new LandingPage(loggedInUsername);
            landPage.FormBorderStyle = FormBorderStyle.None;
            landPage.TopLevel = false;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(landPage);
            landPage.Show();
        }

        private void btnCatalogue_Click(object sender, EventArgs e)
        {
            string loggedInUsername = lblUserName.Text;
            CatalogueTable catalogueTable = new CatalogueTable(loggedInUsername);
            catalogueTable.FormBorderStyle = FormBorderStyle.None;
            catalogueTable.TopLevel = false;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(catalogueTable);
            catalogueTable.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string loggedInUsername = lblUserName.Text;
            RegisterForm registerForm = new RegisterForm(loggedInUsername);
            registerForm.FormBorderStyle = FormBorderStyle.None;
            registerForm.TopLevel = false;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(registerForm);
            registerForm.Show();
        }

        private void LandForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loggedInUsername = lblUserName.Text;
            btnUploadPicture profileForm = new btnUploadPicture(loggedInUsername);
            profileForm.FormBorderStyle = FormBorderStyle.None;
            profileForm.TopLevel = false;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(profileForm);
            profileForm.Show();
        }

        private void btn_leaderBoard_Click(object sender, EventArgs e)
        {
            LeaderBoard leaderBoard = new LeaderBoard();
            leaderBoard.FormBorderStyle = FormBorderStyle.None;
            leaderBoard.TopLevel = false;
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(leaderBoard);
            leaderBoard.Show();
        }

        private void LandForm_Load(object sender, EventArgs e)
        {

        }
    }
}

