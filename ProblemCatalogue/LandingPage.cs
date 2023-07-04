using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProblemCatalogue
{
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
            lblSystemDate.Text = DateTime.Now.ToShortDateString();
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblSystemTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
