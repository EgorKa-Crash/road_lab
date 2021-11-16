namespace Road_Lap1.ConfigurationForms
{
    partial class RoadSettingsForm
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
            this.radioButton_oneDirection = new System.Windows.Forms.RadioButton();
            this.radioButton_twoDirection = new System.Windows.Forms.RadioButton();
            this.label_countDirection = new System.Windows.Forms.Label();
            this.button_back = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.label_countLine = new System.Windows.Forms.Label();
            this.trackBar_oneDirection = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_countLine = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar_twoDirection = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_oneDirection)).BeginInit();
            this.panel_countLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_twoDirection)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton_oneDirection
            // 
            this.radioButton_oneDirection.AutoSize = true;
            this.radioButton_oneDirection.Checked = true;
            this.radioButton_oneDirection.Location = new System.Drawing.Point(11, 28);
            this.radioButton_oneDirection.Name = "radioButton_oneDirection";
            this.radioButton_oneDirection.Size = new System.Drawing.Size(31, 17);
            this.radioButton_oneDirection.TabIndex = 0;
            this.radioButton_oneDirection.TabStop = true;
            this.radioButton_oneDirection.Text = "1";
            this.radioButton_oneDirection.UseVisualStyleBackColor = true;
            // 
            // radioButton_twoDirection
            // 
            this.radioButton_twoDirection.AutoSize = true;
            this.radioButton_twoDirection.Location = new System.Drawing.Point(11, 51);
            this.radioButton_twoDirection.Name = "radioButton_twoDirection";
            this.radioButton_twoDirection.Size = new System.Drawing.Size(31, 17);
            this.radioButton_twoDirection.TabIndex = 1;
            this.radioButton_twoDirection.Text = "2";
            this.radioButton_twoDirection.UseVisualStyleBackColor = true;
            this.radioButton_twoDirection.CheckedChanged += new System.EventHandler(this.radioButton_twoDirection_CheckedChanged);
            // 
            // label_countDirection
            // 
            this.label_countDirection.AutoSize = true;
            this.label_countDirection.Location = new System.Drawing.Point(12, 9);
            this.label_countDirection.Name = "label_countDirection";
            this.label_countDirection.Size = new System.Drawing.Size(191, 13);
            this.label_countDirection.TabIndex = 2;
            this.label_countDirection.Text = "Количество направлений движения:";
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(11, 230);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(75, 23);
            this.button_back.TabIndex = 3;
            this.button_back.Text = "Назад";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(178, 230);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(75, 23);
            this.button_next.TabIndex = 4;
            this.button_next.Text = "Далее";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // label_countLine
            // 
            this.label_countLine.AutoSize = true;
            this.label_countLine.Location = new System.Drawing.Point(15, 83);
            this.label_countLine.Name = "label_countLine";
            this.label_countLine.Size = new System.Drawing.Size(155, 13);
            this.label_countLine.TabIndex = 8;
            this.label_countLine.Text = "Количество полос движения:";
            // 
            // trackBar_oneDirection
            // 
            this.trackBar_oneDirection.LargeChange = 1;
            this.trackBar_oneDirection.Location = new System.Drawing.Point(9, 103);
            this.trackBar_oneDirection.Maximum = 4;
            this.trackBar_oneDirection.Minimum = 1;
            this.trackBar_oneDirection.Name = "trackBar_oneDirection";
            this.trackBar_oneDirection.Size = new System.Drawing.Size(248, 45);
            this.trackBar_oneDirection.TabIndex = 11;
            this.trackBar_oneDirection.Value = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Location = new System.Drawing.Point(16, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "1                       2                      3                       4";
            // 
            // panel_countLine
            // 
            this.panel_countLine.Controls.Add(this.label2);
            this.panel_countLine.Controls.Add(this.trackBar_twoDirection);
            this.panel_countLine.Location = new System.Drawing.Point(6, 154);
            this.panel_countLine.Name = "panel_countLine";
            this.panel_countLine.Size = new System.Drawing.Size(251, 70);
            this.panel_countLine.TabIndex = 15;
            this.panel_countLine.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "1                       2                      3                       4";
            // 
            // trackBar_twoDirection
            // 
            this.trackBar_twoDirection.LargeChange = 1;
            this.trackBar_twoDirection.Location = new System.Drawing.Point(3, 11);
            this.trackBar_twoDirection.Maximum = 4;
            this.trackBar_twoDirection.Minimum = 1;
            this.trackBar_twoDirection.Name = "trackBar_twoDirection";
            this.trackBar_twoDirection.Size = new System.Drawing.Size(248, 45);
            this.trackBar_twoDirection.TabIndex = 16;
            this.trackBar_twoDirection.Value = 1;
            // 
            // RoadSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 259);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_countLine);
            this.Controls.Add(this.trackBar_oneDirection);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.label_countLine);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.label_countDirection);
            this.Controls.Add(this.radioButton_twoDirection);
            this.Controls.Add(this.radioButton_oneDirection);
            this.Name = "RoadSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка дороги";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoadConfigurationForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_oneDirection)).EndInit();
            this.panel_countLine.ResumeLayout(false);
            this.panel_countLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_twoDirection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_oneDirection;
        private System.Windows.Forms.RadioButton radioButton_twoDirection;
        private System.Windows.Forms.Label label_countDirection;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Label label_countLine;
        private System.Windows.Forms.TrackBar trackBar_oneDirection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_countLine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar_twoDirection;
    }
}