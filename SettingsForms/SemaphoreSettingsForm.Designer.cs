namespace Road_Lap1.ConfigurationForms
{
    partial class SemaphoreSettingsForm
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
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.lbl_rightSemaphoreDescription = new System.Windows.Forms.Label();
            this.trackBar_rightSemaphore = new System.Windows.Forms.TrackBar();
            this.lbl_rightValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_rightSemaphore)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(219, 293);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(100, 23);
            this.btn_next.TabIndex = 0;
            this.btn_next.Text = "Далее";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(8, 293);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(100, 23);
            this.btn_back.TabIndex = 1;
            this.btn_back.Text = "Назад";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // lbl_rightSemaphoreDescription
            // 
            this.lbl_rightSemaphoreDescription.AutoSize = true;
            this.lbl_rightSemaphoreDescription.Location = new System.Drawing.Point(12, 134);
            this.lbl_rightSemaphoreDescription.Name = "lbl_rightSemaphoreDescription";
            this.lbl_rightSemaphoreDescription.Size = new System.Drawing.Size(172, 13);
            this.lbl_rightSemaphoreDescription.TabIndex = 5;
            this.lbl_rightSemaphoreDescription.Text = "Длительность фазы светофора:";
            // 
            // trackBar_rightSemaphore
            // 
            this.trackBar_rightSemaphore.LargeChange = 1;
            this.trackBar_rightSemaphore.Location = new System.Drawing.Point(8, 160);
            this.trackBar_rightSemaphore.Minimum = 2;
            this.trackBar_rightSemaphore.Name = "trackBar_rightSemaphore";
            this.trackBar_rightSemaphore.Size = new System.Drawing.Size(316, 45);
            this.trackBar_rightSemaphore.TabIndex = 6;
            this.trackBar_rightSemaphore.Value = 2;
            this.trackBar_rightSemaphore.Scroll += new System.EventHandler(this.trackBar_rightSemaphore_Scroll);
            // 
            // lbl_rightValue
            // 
            this.lbl_rightValue.AutoSize = true;
            this.lbl_rightValue.Location = new System.Drawing.Point(190, 134);
            this.lbl_rightValue.Name = "lbl_rightValue";
            this.lbl_rightValue.Size = new System.Drawing.Size(22, 13);
            this.lbl_rightValue.TabIndex = 8;
            this.lbl_rightValue.Text = "2 c";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.aboutSystemToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(336, 24);
            this.menuStrip1.TabIndex = 17;
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
            // SemaphoreSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 323);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_rightValue);
            this.Controls.Add(this.trackBar_rightSemaphore);
            this.Controls.Add(this.lbl_rightSemaphoreDescription);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_next);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SemaphoreSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка фазы светофора";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SemaphoreConfigurationForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_rightSemaphore)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label lbl_rightSemaphoreDescription;
        private System.Windows.Forms.TrackBar trackBar_rightSemaphore;
        private System.Windows.Forms.Label lbl_rightValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}