namespace FileMonitor
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.TextBox();
            this.eMail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Period = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.BrowseFile = new System.Windows.Forms.Button();
            this.Action = new System.Windows.Forms.Button();
            this.Test = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Period)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File to monitor";
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(7, 24);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(384, 20);
            this.FileName.TabIndex = 1;
            // 
            // eMail
            // 
            this.eMail.Location = new System.Drawing.Point(7, 73);
            this.eMail.Name = "eMail";
            this.eMail.Size = new System.Drawing.Size(418, 20);
            this.eMail.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "eMail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Check every";
            // 
            // Period
            // 
            this.Period.Location = new System.Drawing.Point(74, 104);
            this.Period.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.Period.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Period.Name = "Period";
            this.Period.Size = new System.Drawing.Size(36, 20);
            this.Period.TabIndex = 5;
            this.Period.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "minutes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Status";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(48, 135);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(28, 13);
            this.Status.TabIndex = 8;
            this.Status.Text = "Idle";
            // 
            // BrowseFile
            // 
            this.BrowseFile.Location = new System.Drawing.Point(397, 24);
            this.BrowseFile.Name = "BrowseFile";
            this.BrowseFile.Size = new System.Drawing.Size(28, 20);
            this.BrowseFile.TabIndex = 9;
            this.BrowseFile.Text = "...";
            this.BrowseFile.UseVisualStyleBackColor = true;
            this.BrowseFile.Click += new System.EventHandler(this.BrowseFile_Click);
            // 
            // Action
            // 
            this.Action.Location = new System.Drawing.Point(345, 127);
            this.Action.Name = "Action";
            this.Action.Size = new System.Drawing.Size(80, 25);
            this.Action.TabIndex = 10;
            this.Action.Text = "Start";
            this.Action.UseVisualStyleBackColor = true;
            this.Action.Click += new System.EventHandler(this.Action_Click);
            // 
            // Test
            // 
            this.Test.Location = new System.Drawing.Point(260, 127);
            this.Test.Name = "Test";
            this.Test.Size = new System.Drawing.Size(80, 25);
            this.Test.TabIndex = 11;
            this.Test.Text = "Test";
            this.Test.UseVisualStyleBackColor = true;
            this.Test.Click += new System.EventHandler(this.Test_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 162);
            this.Controls.Add(this.Test);
            this.Controls.Add(this.Action);
            this.Controls.Add(this.BrowseFile);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Period);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.eMail);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "File Monitor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Period)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FileName;
        private System.Windows.Forms.TextBox eMail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Period;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Button BrowseFile;
        private System.Windows.Forms.Button Action;
        private System.Windows.Forms.Button Test;
    }
}

