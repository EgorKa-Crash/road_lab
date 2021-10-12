namespace Road_Lap1
{
    partial class RoadWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackPictureBox = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.resumeButton = new System.Windows.Forms.Button();
            this.selectedCarPanel = new System.Windows.Forms.Panel();
            this.selCarLable = new System.Windows.Forms.Label();
            this.dynamicSpeed = new System.Windows.Forms.TrackBar();
            this.speedLimitPanel = new System.Windows.Forms.Panel();
            this.notLimRadioButton = new System.Windows.Forms.RadioButton();
            this.delLimRadioButton = new System.Windows.Forms.RadioButton();
            this.addLimRadioButton = new System.Windows.Forms.RadioButton();
            this.speedLimitTrackBar = new System.Windows.Forms.TrackBar();
            this.speedLimitLabel = new System.Windows.Forms.Label();
            this.addLimitButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackPictureBox)).BeginInit();
            this.selectedCarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dynamicSpeed)).BeginInit();
            this.speedLimitPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedLimitTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // trackPictureBox
            // 
            this.trackPictureBox.Location = new System.Drawing.Point(12, 12);
            this.trackPictureBox.Name = "trackPictureBox";
            this.trackPictureBox.Size = new System.Drawing.Size(1067, 715);
            this.trackPictureBox.TabIndex = 0;
            this.trackPictureBox.TabStop = false;
            this.trackPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrackPictureBox_MouseClick);
            this.trackPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TrackPictureBox_MouseMove);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(1111, 13);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(150, 40);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(1111, 58);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(150, 40);
            this.pauseButton.TabIndex = 2;
            this.pauseButton.Text = "Пауза";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // resumeButton
            // 
            this.resumeButton.Location = new System.Drawing.Point(1111, 104);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(150, 40);
            this.resumeButton.TabIndex = 3;
            this.resumeButton.Text = "Остановить";
            this.resumeButton.UseVisualStyleBackColor = true;
            this.resumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
            // 
            // selectedCarPanel
            // 
            this.selectedCarPanel.Controls.Add(this.selCarLable);
            this.selectedCarPanel.Controls.Add(this.dynamicSpeed);
            this.selectedCarPanel.Location = new System.Drawing.Point(1111, 198);
            this.selectedCarPanel.Name = "selectedCarPanel";
            this.selectedCarPanel.Size = new System.Drawing.Size(150, 122);
            this.selectedCarPanel.TabIndex = 6;
            // 
            // selCarLable
            // 
            this.selCarLable.AutoSize = true;
            this.selCarLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selCarLable.Location = new System.Drawing.Point(13, 28);
            this.selCarLable.Name = "selCarLable";
            this.selCarLable.Size = new System.Drawing.Size(24, 25);
            this.selCarLable.TabIndex = 2;
            this.selCarLable.Text = "0";
            // 
            // dynamicSpeed
            // 
            this.dynamicSpeed.Location = new System.Drawing.Point(3, 72);
            this.dynamicSpeed.Maximum = 110;
            this.dynamicSpeed.Name = "dynamicSpeed";
            this.dynamicSpeed.Size = new System.Drawing.Size(144, 45);
            this.dynamicSpeed.TabIndex = 0;
            this.dynamicSpeed.Scroll += new System.EventHandler(this.DynamicSpeed_Scroll);
            // 
            // speedLimitPanel
            // 
            this.speedLimitPanel.Controls.Add(this.notLimRadioButton);
            this.speedLimitPanel.Controls.Add(this.delLimRadioButton);
            this.speedLimitPanel.Controls.Add(this.addLimRadioButton);
            this.speedLimitPanel.Controls.Add(this.speedLimitTrackBar);
            this.speedLimitPanel.Controls.Add(this.speedLimitLabel);
            this.speedLimitPanel.Controls.Add(this.addLimitButton);
            this.speedLimitPanel.Location = new System.Drawing.Point(1111, 373);
            this.speedLimitPanel.Name = "speedLimitPanel";
            this.speedLimitPanel.Size = new System.Drawing.Size(150, 252);
            this.speedLimitPanel.TabIndex = 7;
            // 
            // notLimRadioButton
            // 
            this.notLimRadioButton.AutoSize = true;
            this.notLimRadioButton.Location = new System.Drawing.Point(4, 165);
            this.notLimRadioButton.Name = "notLimRadioButton";
            this.notLimRadioButton.Size = new System.Drawing.Size(129, 17);
            this.notLimRadioButton.TabIndex = 5;
            this.notLimRadioButton.TabStop = true;
            this.notLimRadioButton.Text = "отмена ограничения";
            this.notLimRadioButton.UseVisualStyleBackColor = true;
            // 
            // delLimRadioButton
            // 
            this.delLimRadioButton.AutoSize = true;
            this.delLimRadioButton.Location = new System.Drawing.Point(3, 129);
            this.delLimRadioButton.Name = "delLimRadioButton";
            this.delLimRadioButton.Size = new System.Drawing.Size(132, 17);
            this.delLimRadioButton.TabIndex = 4;
            this.delLimRadioButton.TabStop = true;
            this.delLimRadioButton.Text = "удалить ограничение";
            this.delLimRadioButton.UseVisualStyleBackColor = true;
            // 
            // addLimRadioButton
            // 
            this.addLimRadioButton.AutoSize = true;
            this.addLimRadioButton.Checked = true;
            this.addLimRadioButton.Location = new System.Drawing.Point(4, 95);
            this.addLimRadioButton.Name = "addLimRadioButton";
            this.addLimRadioButton.Size = new System.Drawing.Size(139, 17);
            this.addLimRadioButton.TabIndex = 3;
            this.addLimRadioButton.TabStop = true;
            this.addLimRadioButton.Text = "добавить ограничение";
            this.addLimRadioButton.UseVisualStyleBackColor = true;
            // 
            // speedLimitTrackBar
            // 
            this.speedLimitTrackBar.LargeChange = 1;
            this.speedLimitTrackBar.Location = new System.Drawing.Point(3, 43);
            this.speedLimitTrackBar.Maximum = 11;
            this.speedLimitTrackBar.Name = "speedLimitTrackBar";
            this.speedLimitTrackBar.Size = new System.Drawing.Size(144, 45);
            this.speedLimitTrackBar.TabIndex = 2;
            this.speedLimitTrackBar.Scroll += new System.EventHandler(this.SpeedLimitTrackBar_Scroll);
            // 
            // speedLimitLabel
            // 
            this.speedLimitLabel.AutoSize = true;
            this.speedLimitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.speedLimitLabel.Location = new System.Drawing.Point(13, 11);
            this.speedLimitLabel.Name = "speedLimitLabel";
            this.speedLimitLabel.Size = new System.Drawing.Size(24, 25);
            this.speedLimitLabel.TabIndex = 1;
            this.speedLimitLabel.Text = "0";
            // 
            // addLimitButton
            // 
            this.addLimitButton.Location = new System.Drawing.Point(3, 199);
            this.addLimitButton.Name = "addLimitButton";
            this.addLimitButton.Size = new System.Drawing.Size(144, 48);
            this.addLimitButton.TabIndex = 0;
            this.addLimitButton.Text = "Осуществить изменения дорожных знаков";
            this.addLimitButton.UseVisualStyleBackColor = true;
            this.addLimitButton.Click += new System.EventHandler(this.AddLimitButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1111, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // RoadWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 733);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.speedLimitPanel);
            this.Controls.Add(this.selectedCarPanel);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.trackPictureBox);
            this.Name = "RoadWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.RoadWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackPictureBox)).EndInit();
            this.selectedCarPanel.ResumeLayout(false);
            this.selectedCarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dynamicSpeed)).EndInit();
            this.speedLimitPanel.ResumeLayout(false);
            this.speedLimitPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedLimitTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox trackPictureBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button resumeButton;
        private System.Windows.Forms.Panel selectedCarPanel;
        private System.Windows.Forms.TrackBar dynamicSpeed;
        private System.Windows.Forms.Label selCarLable;
        private System.Windows.Forms.Panel speedLimitPanel;
        private System.Windows.Forms.TrackBar speedLimitTrackBar;
        private System.Windows.Forms.Label speedLimitLabel;
        private System.Windows.Forms.Button addLimitButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton notLimRadioButton;
        private System.Windows.Forms.RadioButton delLimRadioButton;
        private System.Windows.Forms.RadioButton addLimRadioButton;
    }
}

