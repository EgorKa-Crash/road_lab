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
            this.textBox_countLineOnFirstDirection = new System.Windows.Forms.TextBox();
            this.textBox_countLineOnSecondDirection = new System.Windows.Forms.TextBox();
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
            this.button_back.Location = new System.Drawing.Point(11, 165);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(75, 23);
            this.button_back.TabIndex = 3;
            this.button_back.Text = "Назад";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(206, 165);
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
            this.label_countLine.Location = new System.Drawing.Point(12, 84);
            this.label_countLine.Name = "label_countLine";
            this.label_countLine.Size = new System.Drawing.Size(155, 13);
            this.label_countLine.TabIndex = 8;
            this.label_countLine.Text = "Количество полос движения:";
            // 
            // textBox_countLineOnFirstDirection
            // 
            this.textBox_countLineOnFirstDirection.Location = new System.Drawing.Point(11, 100);
            this.textBox_countLineOnFirstDirection.MaxLength = 2;
            this.textBox_countLineOnFirstDirection.Name = "textBox_countLineOnFirstDirection";
            this.textBox_countLineOnFirstDirection.Size = new System.Drawing.Size(156, 20);
            this.textBox_countLineOnFirstDirection.TabIndex = 9;
            this.textBox_countLineOnFirstDirection.Text = "3";
            // 
            // textBox_countLineOnSecondDirection
            // 
            this.textBox_countLineOnSecondDirection.Location = new System.Drawing.Point(11, 126);
            this.textBox_countLineOnSecondDirection.MaxLength = 2;
            this.textBox_countLineOnSecondDirection.Name = "textBox_countLineOnSecondDirection";
            this.textBox_countLineOnSecondDirection.Size = new System.Drawing.Size(156, 20);
            this.textBox_countLineOnSecondDirection.TabIndex = 10;
            this.textBox_countLineOnSecondDirection.Text = "2";
            this.textBox_countLineOnSecondDirection.Visible = false;
            // 
            // RoadConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 198);
            this.Controls.Add(this.textBox_countLineOnSecondDirection);
            this.Controls.Add(this.textBox_countLineOnFirstDirection);
            this.Controls.Add(this.label_countLine);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.label_countDirection);
            this.Controls.Add(this.radioButton_twoDirection);
            this.Controls.Add(this.radioButton_oneDirection);
            this.Name = "RoadConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка дороги";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoadConfigurationForm_FormClosing);
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
        private System.Windows.Forms.TextBox textBox_countLineOnFirstDirection;
        private System.Windows.Forms.TextBox textBox_countLineOnSecondDirection;
    }
}