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
            this.pb_CarSpeed = new System.Windows.Forms.ProgressBar();
            this.selCarLable = new System.Windows.Forms.Label();
            this.dynamicSpeed = new System.Windows.Forms.TrackBar();
            this.speedLimitLabel = new System.Windows.Forms.Label();
            this.roadMarkPanel = new System.Windows.Forms.Panel();
            this.notLimRB = new System.Windows.Forms.RadioButton();
            this.setLimitRB = new System.Windows.Forms.RadioButton();
            this.delLimRB = new System.Windows.Forms.RadioButton();
            this.speedLimitTB = new System.Windows.Forms.TrackBar();
            this.setLimitButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.trackPictureBox)).BeginInit();
            this.selectedCarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dynamicSpeed)).BeginInit();
            this.roadMarkPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedLimitTB)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackPictureBox
            // 
            this.trackPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.trackPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trackPictureBox.Location = new System.Drawing.Point(12, 34);
            this.trackPictureBox.Name = "trackPictureBox";
            this.trackPictureBox.Size = new System.Drawing.Size(1067, 653);
            this.trackPictureBox.TabIndex = 0;
            this.trackPictureBox.TabStop = false;
            this.trackPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrackPictureBox_MouseClick);
            this.trackPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TrackPictureBox_MouseMove);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(1109, 39);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(150, 40);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(1109, 84);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(150, 40);
            this.pauseButton.TabIndex = 2;
            this.pauseButton.Text = "Пауза";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // resumeButton
            // 
            this.resumeButton.Location = new System.Drawing.Point(1109, 130);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(150, 40);
            this.resumeButton.TabIndex = 3;
            this.resumeButton.Text = "Остановить";
            this.resumeButton.UseVisualStyleBackColor = true;
            this.resumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
            // 
            // selectedCarPanel
            // 
            this.selectedCarPanel.Controls.Add(this.pb_CarSpeed);
            this.selectedCarPanel.Controls.Add(this.selCarLable);
            this.selectedCarPanel.Controls.Add(this.dynamicSpeed);
            this.selectedCarPanel.Location = new System.Drawing.Point(1106, 462);
            this.selectedCarPanel.Name = "selectedCarPanel";
            this.selectedCarPanel.Size = new System.Drawing.Size(150, 143);
            this.selectedCarPanel.TabIndex = 6;
            this.selectedCarPanel.Visible = false;
            // 
            // pb_CarSpeed
            // 
            this.pb_CarSpeed.Location = new System.Drawing.Point(18, 22);
            this.pb_CarSpeed.Name = "pb_CarSpeed";
            this.pb_CarSpeed.Size = new System.Drawing.Size(115, 23);
            this.pb_CarSpeed.Step = 1;
            this.pb_CarSpeed.TabIndex = 3;
            // 
            // selCarLable
            // 
            this.selCarLable.AutoSize = true;
            this.selCarLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selCarLable.Location = new System.Drawing.Point(13, 57);
            this.selCarLable.Name = "selCarLable";
            this.selCarLable.Size = new System.Drawing.Size(24, 25);
            this.selCarLable.TabIndex = 2;
            this.selCarLable.Text = "0";
            // 
            // dynamicSpeed
            // 
            this.dynamicSpeed.Location = new System.Drawing.Point(4, 95);
            this.dynamicSpeed.Maximum = 110;
            this.dynamicSpeed.Name = "dynamicSpeed";
            this.dynamicSpeed.Size = new System.Drawing.Size(144, 45);
            this.dynamicSpeed.TabIndex = 0;
            this.dynamicSpeed.Scroll += new System.EventHandler(this.DynamicSpeed_Scroll);
            // 
            // speedLimitLabel
            // 
            this.speedLimitLabel.BackColor = System.Drawing.Color.Transparent;
            this.speedLimitLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.speedLimitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.speedLimitLabel.Location = new System.Drawing.Point(15, 32);
            this.speedLimitLabel.Name = "speedLimitLabel";
            this.speedLimitLabel.Size = new System.Drawing.Size(45, 25);
            this.speedLimitLabel.TabIndex = 1;
            this.speedLimitLabel.Text = "000";
            this.speedLimitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.speedLimitLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.speedLimitLabel_MouseClick);
            // 
            // roadMarkPanel
            // 
            this.roadMarkPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.roadMarkPanel.Controls.Add(this.speedLimitLabel);
            this.roadMarkPanel.Controls.Add(this.notLimRB);
            this.roadMarkPanel.Controls.Add(this.setLimitRB);
            this.roadMarkPanel.Controls.Add(this.delLimRB);
            this.roadMarkPanel.Controls.Add(this.speedLimitTB);
            this.roadMarkPanel.Location = new System.Drawing.Point(1109, 229);
            this.roadMarkPanel.Name = "roadMarkPanel";
            this.roadMarkPanel.Size = new System.Drawing.Size(148, 227);
            this.roadMarkPanel.TabIndex = 8;
            // 
            // notLimRB
            // 
            this.notLimRB.Appearance = System.Windows.Forms.Appearance.Button;
            this.notLimRB.BackColor = System.Drawing.SystemColors.Menu;
            this.notLimRB.BackgroundImage = global::Road_Lap1.Properties.Resources.NoLimit;
            this.notLimRB.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.notLimRB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.notLimRB.Location = new System.Drawing.Point(6, 83);
            this.notLimRB.Name = "notLimRB";
            this.notLimRB.Size = new System.Drawing.Size(63, 63);
            this.notLimRB.TabIndex = 11;
            this.notLimRB.UseVisualStyleBackColor = false;
            this.notLimRB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton3_MouseClick);
            // 
            // setLimitRB
            // 
            this.setLimitRB.Appearance = System.Windows.Forms.Appearance.Button;
            this.setLimitRB.BackColor = System.Drawing.SystemColors.Menu;
            this.setLimitRB.BackgroundImage = global::Road_Lap1.Properties.Resources.Limit;
            this.setLimitRB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.setLimitRB.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.setLimitRB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.setLimitRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setLimitRB.Location = new System.Drawing.Point(6, 13);
            this.setLimitRB.Name = "setLimitRB";
            this.setLimitRB.Size = new System.Drawing.Size(63, 63);
            this.setLimitRB.TabIndex = 10;
            this.setLimitRB.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.setLimitRB.UseVisualStyleBackColor = false;
            this.setLimitRB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton1_MouseClick);
            // 
            // delLimRB
            // 
            this.delLimRB.Appearance = System.Windows.Forms.Appearance.Button;
            this.delLimRB.BackColor = System.Drawing.SystemColors.Menu;
            this.delLimRB.BackgroundImage = global::Road_Lap1.Properties.Resources.Cross;
            this.delLimRB.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.delLimRB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.delLimRB.Location = new System.Drawing.Point(6, 152);
            this.delLimRB.Name = "delLimRB";
            this.delLimRB.Size = new System.Drawing.Size(63, 63);
            this.delLimRB.TabIndex = 7;
            this.delLimRB.UseVisualStyleBackColor = false;
            this.delLimRB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton2_MouseClick);
            // 
            // speedLimitTB
            // 
            this.speedLimitTB.LargeChange = 1;
            this.speedLimitTB.Location = new System.Drawing.Point(69, 21);
            this.speedLimitTB.Maximum = 11;
            this.speedLimitTB.Name = "speedLimitTB";
            this.speedLimitTB.Size = new System.Drawing.Size(78, 45);
            this.speedLimitTB.TabIndex = 6;
            this.speedLimitTB.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // setLimitButton
            // 
            this.setLimitButton.Location = new System.Drawing.Point(1109, 175);
            this.setLimitButton.Name = "setLimitButton";
            this.setLimitButton.Size = new System.Drawing.Size(148, 48);
            this.setLimitButton.TabIndex = 9;
            this.setLimitButton.Text = "Изменить дорожные знаки";
            this.setLimitButton.UseVisualStyleBackColor = true;
            this.setLimitButton.Click += new System.EventHandler(this.setLimitButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.aboutSystemToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1292, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.infoToolStripMenuItem.Text = "Справка";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // aboutSystemToolStripMenuItem
            // 
            this.aboutSystemToolStripMenuItem.Name = "aboutSystemToolStripMenuItem";
            this.aboutSystemToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.aboutSystemToolStripMenuItem.Text = "О системе";
            this.aboutSystemToolStripMenuItem.Click += new System.EventHandler(this.aboutSystemToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // RoadWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1292, 688);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.setLimitButton);
            this.Controls.Add(this.roadMarkPanel);
            this.Controls.Add(this.selectedCarPanel);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.trackPictureBox);
            this.MaximizeBox = false;
            this.Name = "RoadWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackPictureBox)).EndInit();
            this.selectedCarPanel.ResumeLayout(false);
            this.selectedCarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dynamicSpeed)).EndInit();
            this.roadMarkPanel.ResumeLayout(false);
            this.roadMarkPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedLimitTB)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox trackPictureBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button resumeButton;
        private System.Windows.Forms.Panel selectedCarPanel;
        private System.Windows.Forms.TrackBar dynamicSpeed;
        private System.Windows.Forms.Label selCarLable;
        private System.Windows.Forms.Label speedLimitLabel;
        private System.Windows.Forms.ProgressBar pb_CarSpeed;
        private System.Windows.Forms.Panel roadMarkPanel;
        private System.Windows.Forms.Button setLimitButton;
        private System.Windows.Forms.RadioButton delLimRB;
        private System.Windows.Forms.TrackBar speedLimitTB;
        private System.Windows.Forms.RadioButton notLimRB;
        private System.Windows.Forms.RadioButton setLimitRB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

