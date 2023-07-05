using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProblemCatalogue
{
    public partial class DetailsForm : Form
    {
        private Dictionary<string, string> rowData;
        public DetailsForm(Dictionary<string, string> rowData)
        {
            InitializeComponent();
            this.rowData = rowData;
            this.Load += DetailsForm_Load;
        }
        private void DetailsForm_Load(object sender, EventArgs e)
        {
            textBox_ref.Text = rowData["CCREF"];
            textBox_title.Text = rowData["CCTITLE"];
            textBox_System.Text = rowData["CCSYSTEM"];
            textBox_Line.Text = rowData["CCLINE"];
            textBox_Desc.Text = rowData["CCDESC"];
            textBox_Reso.Text = rowData["CCRESO"];
            textBox_Grp.Text = rowData["CCGRP"];
            textBox_PIC.Text = rowData["CCPIC"];
            txtSavedPath.Text = rowData["CCATTACH"];
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
    }
}

