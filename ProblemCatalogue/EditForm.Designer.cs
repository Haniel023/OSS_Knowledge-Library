namespace ProblemCatalogue
{
    partial class EditForm
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
            this.tb_CauseP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.cBox_Grp = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tB_PIC = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tB_Resolution = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tB_Description = new System.Windows.Forms.TextBox();
            this.tB_Line = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tB_System = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tB_Title = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tBox_Ref = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_CauseP
            // 
            this.tb_CauseP.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_CauseP.Location = new System.Drawing.Point(238, 343);
            this.tb_CauseP.Multiline = true;
            this.tb_CauseP.Name = "tb_CauseP";
            this.tb_CauseP.Size = new System.Drawing.Size(308, 83);
            this.tb_CauseP.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 346);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 32);
            this.label10.TabIndex = 42;
            this.label10.Text = "Cause of the Problem:\r\n(If its a problem)\r\n";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(747, 211);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(134, 20);
            this.txtFilePath.TabIndex = 41;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(672, 208);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(69, 23);
            this.btnUpload.TabIndex = 40;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(713, 578);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(83, 29);
            this.btn_Save.TabIndex = 39;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // cBox_Grp
            // 
            this.cBox_Grp.FormattingEnabled = true;
            this.cBox_Grp.Items.AddRange(new object[] {
            "SMART",
            "DEV",
            "NETWORK"});
            this.cBox_Grp.Location = new System.Drawing.Point(743, 153);
            this.cBox_Grp.Name = "cBox_Grp";
            this.cBox_Grp.Size = new System.Drawing.Size(133, 21);
            this.cBox_Grp.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(675, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 16);
            this.label9.TabIndex = 37;
            this.label9.Text = "Group:";
            // 
            // tB_PIC
            // 
            this.tB_PIC.BackColor = System.Drawing.SystemColors.Control;
            this.tB_PIC.Enabled = false;
            this.tB_PIC.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_PIC.Location = new System.Drawing.Point(727, 94);
            this.tB_PIC.Name = "tB_PIC";
            this.tB_PIC.ReadOnly = true;
            this.tB_PIC.Size = new System.Drawing.Size(149, 22);
            this.tB_PIC.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(675, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 16);
            this.label8.TabIndex = 34;
            this.label8.Text = "PIC:";
            // 
            // tB_Resolution
            // 
            this.tB_Resolution.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_Resolution.Location = new System.Drawing.Point(239, 449);
            this.tB_Resolution.Multiline = true;
            this.tB_Resolution.Name = "tB_Resolution";
            this.tB_Resolution.Size = new System.Drawing.Size(308, 171);
            this.tB_Resolution.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 449);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 32;
            this.label7.Text = "Solution:";
            // 
            // tB_Description
            // 
            this.tB_Description.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_Description.Location = new System.Drawing.Point(238, 260);
            this.tB_Description.Multiline = true;
            this.tB_Description.Name = "tB_Description";
            this.tB_Description.Size = new System.Drawing.Size(308, 65);
            this.tB_Description.TabIndex = 31;
            // 
            // tB_Line
            // 
            this.tB_Line.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_Line.Location = new System.Drawing.Point(238, 198);
            this.tB_Line.Name = "tB_Line";
            this.tB_Line.Size = new System.Drawing.Size(308, 22);
            this.tB_Line.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "Production Line:";
            // 
            // tB_System
            // 
            this.tB_System.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_System.Location = new System.Drawing.Point(238, 143);
            this.tB_System.Name = "tB_System";
            this.tB_System.Size = new System.Drawing.Size(308, 22);
            this.tB_System.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "System:";
            // 
            // tB_Title
            // 
            this.tB_Title.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_Title.Location = new System.Drawing.Point(238, 88);
            this.tB_Title.Name = "tB_Title";
            this.tB_Title.Size = new System.Drawing.Size(308, 22);
            this.tB_Title.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Title:";
            // 
            // tBox_Ref
            // 
            this.tBox_Ref.BackColor = System.Drawing.SystemColors.Control;
            this.tBox_Ref.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBox_Ref.Enabled = false;
            this.tBox_Ref.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBox_Ref.Location = new System.Drawing.Point(771, 50);
            this.tBox_Ref.Name = "tBox_Ref";
            this.tBox_Ref.ReadOnly = true;
            this.tBox_Ref.Size = new System.Drawing.Size(105, 22);
            this.tBox_Ref.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkCyan;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(675, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Reference No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modify the Entry";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 30;
            this.label6.Text = "Description:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkCyan;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 79);
            this.panel1.TabIndex = 21;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(813, 578);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(83, 29);
            this.btn_Close.TabIndex = 43;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 619);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.tb_CauseP);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.cBox_Grp);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tB_PIC);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tB_Resolution);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tB_Description);
            this.Controls.Add(this.tB_Line);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tB_System);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tB_Title);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tBox_Ref);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Name = "EditForm";
            this.Text = "Modifying an Entry";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditForm_FormClosed);
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_CauseP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.ComboBox cBox_Grp;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox tB_PIC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tB_Resolution;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tB_Description;
        private System.Windows.Forms.TextBox tB_Line;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tB_System;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tB_Title;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBox_Ref;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Close;
    }
}