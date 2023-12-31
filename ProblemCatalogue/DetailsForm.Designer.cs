﻿namespace ProblemCatalogue
{
    partial class DetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Cause = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtSavedPath = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_PIC = new System.Windows.Forms.TextBox();
            this.textBox_title = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.textBox_ref = new System.Windows.Forms.TextBox();
            this.textBox_Reso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Desc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Line = new System.Windows.Forms.TextBox();
            this.textBox_Grp = new System.Windows.Forms.TextBox();
            this.textBox_System = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Cause
            // 
            this.textBox_Cause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Cause.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_Cause.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Cause.Location = new System.Drawing.Point(36, 329);
            this.textBox_Cause.Multiline = true;
            this.textBox_Cause.Name = "textBox_Cause";
            this.textBox_Cause.ReadOnly = true;
            this.textBox_Cause.Size = new System.Drawing.Size(515, 116);
            this.textBox_Cause.TabIndex = 20;
            this.textBox_Cause.Text = "This is a sample Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 24);
            this.label6.TabIndex = 19;
            this.label6.Text = "Cause of the Problem";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(594, 327);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 18;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtSavedPath
            // 
            this.txtSavedPath.Location = new System.Drawing.Point(673, 329);
            this.txtSavedPath.Name = "txtSavedPath";
            this.txtSavedPath.Size = new System.Drawing.Size(167, 20);
            this.txtSavedPath.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox_title);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(928, 104);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(740, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Reference No:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox_PIC
            // 
            this.textBox_PIC.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_PIC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_PIC.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_PIC.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_PIC.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox_PIC.Location = new System.Drawing.Point(730, 187);
            this.textBox_PIC.Multiline = true;
            this.textBox_PIC.Name = "textBox_PIC";
            this.textBox_PIC.ReadOnly = true;
            this.textBox_PIC.Size = new System.Drawing.Size(187, 69);
            this.textBox_PIC.TabIndex = 1;
            this.textBox_PIC.Text = "PIC";
            this.textBox_PIC.TextChanged += new System.EventHandler(this.textBox_PIC_TextChanged);
            // 
            // textBox_title
            // 
            this.textBox_title.BackColor = System.Drawing.Color.DarkCyan;
            this.textBox_title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_title.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_title.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_title.ForeColor = System.Drawing.SystemColors.Control;
            this.textBox_title.Location = new System.Drawing.Point(10, 24);
            this.textBox_title.Multiline = true;
            this.textBox_title.Name = "textBox_title";
            this.textBox_title.ReadOnly = true;
            this.textBox_title.Size = new System.Drawing.Size(834, 70);
            this.textBox_title.TabIndex = 0;
            this.textBox_title.Text = "Title";
            this.textBox_title.TextChanged += new System.EventHandler(this.textBox_title_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(828, 745);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 28);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // textBox_ref
            // 
            this.textBox_ref.BackColor = System.Drawing.Color.DarkCyan;
            this.textBox_ref.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_ref.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_ref.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ref.ForeColor = System.Drawing.SystemColors.Control;
            this.textBox_ref.Location = new System.Drawing.Point(825, 83);
            this.textBox_ref.Name = "textBox_ref";
            this.textBox_ref.ReadOnly = true;
            this.textBox_ref.Size = new System.Drawing.Size(96, 13);
            this.textBox_ref.TabIndex = 11;
            this.textBox_ref.Text = "Reference No";
            // 
            // textBox_Reso
            // 
            this.textBox_Reso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Reso.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_Reso.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Reso.Location = new System.Drawing.Point(36, 485);
            this.textBox_Reso.Multiline = true;
            this.textBox_Reso.Name = "textBox_Reso";
            this.textBox_Reso.ReadOnly = true;
            this.textBox_Reso.Size = new System.Drawing.Size(853, 223);
            this.textBox_Reso.TabIndex = 10;
            this.textBox_Reso.Text = "This is a sample Resolution";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Solution";
            // 
            // textBox_Desc
            // 
            this.textBox_Desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Desc.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_Desc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Desc.Location = new System.Drawing.Point(36, 163);
            this.textBox_Desc.Multiline = true;
            this.textBox_Desc.Name = "textBox_Desc";
            this.textBox_Desc.ReadOnly = true;
            this.textBox_Desc.Size = new System.Drawing.Size(515, 123);
            this.textBox_Desc.TabIndex = 8;
            this.textBox_Desc.Text = "This is a sample Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Description";
            // 
            // textBox_Line
            // 
            this.textBox_Line.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_Line.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Line.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_Line.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Line.Location = new System.Drawing.Point(644, 375);
            this.textBox_Line.Name = "textBox_Line";
            this.textBox_Line.ReadOnly = true;
            this.textBox_Line.Size = new System.Drawing.Size(231, 22);
            this.textBox_Line.TabIndex = 6;
            this.textBox_Line.Text = "Production Line";
            // 
            // textBox_Grp
            // 
            this.textBox_Grp.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_Grp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Grp.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_Grp.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Grp.Location = new System.Drawing.Point(730, 258);
            this.textBox_Grp.Name = "textBox_Grp";
            this.textBox_Grp.ReadOnly = true;
            this.textBox_Grp.Size = new System.Drawing.Size(165, 22);
            this.textBox_Grp.TabIndex = 5;
            this.textBox_Grp.Text = "Support Group";
            // 
            // textBox_System
            // 
            this.textBox_System.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_System.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_System.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox_System.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_System.Location = new System.Drawing.Point(667, 406);
            this.textBox_System.Name = "textBox_System";
            this.textBox_System.ReadOnly = true;
            this.textBox_System.Size = new System.Drawing.Size(235, 22);
            this.textBox_System.TabIndex = 4;
            this.textBox_System.Text = "System Involved";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(16, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(901, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "_________________________________________________________________________________" +
    "____________________________________________________________________";
            // 
            // btn_Edit
            // 
            this.btn_Edit.Location = new System.Drawing.Point(721, 745);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(89, 28);
            this.btn_Edit.TabIndex = 21;
            this.btn_Edit.Text = "Edit";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(594, 170);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 116);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(590, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 23);
            this.label5.TabIndex = 23;
            this.label5.Text = "Line:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(590, 405);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 23);
            this.label7.TabIndex = 24;
            this.label7.Text = "System:";
            // 
            // DetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(930, 792);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.textBox_PIC);
            this.Controls.Add(this.textBox_Cause);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtSavedPath);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.textBox_ref);
            this.Controls.Add(this.textBox_Reso);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Desc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Line);
            this.Controls.Add(this.textBox_Grp);
            this.Controls.Add(this.textBox_System);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "DetailsForm";
            this.Text = "Member Inputs";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Cause;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtSavedPath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_PIC;
        private System.Windows.Forms.TextBox textBox_title;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox textBox_ref;
        private System.Windows.Forms.TextBox textBox_Reso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Desc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Line;
        private System.Windows.Forms.TextBox textBox_Grp;
        private System.Windows.Forms.TextBox textBox_System;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
    }
}