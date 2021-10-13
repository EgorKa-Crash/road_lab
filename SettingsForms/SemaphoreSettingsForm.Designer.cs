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
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.lbl_leftSemaphoreDescription = new System.Windows.Forms.Label();
            this.trackBar_leftSemaphore = new System.Windows.Forms.TrackBar();
            this.lbl_rightSemaphoreDescription = new System.Windows.Forms.Label();
            this.trackBar_rightSemaphore = new System.Windows.Forms.TrackBar();
            this.lbl_leftValue = new System.Windows.Forms.Label();
            this.lbl_rightValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_leftSemaphore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_rightSemaphore)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(170, 174);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 35);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "Сохранить";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(12, 174);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(75, 35);
            this.btn_back.TabIndex = 1;
            this.btn_back.Text = "Назад";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // lbl_leftSemaphoreDescription
            // 
            this.lbl_leftSemaphoreDescription.AutoSize = true;
            this.lbl_leftSemaphoreDescription.Location = new System.Drawing.Point(7, 9);
            this.lbl_leftSemaphoreDescription.Name = "lbl_leftSemaphoreDescription";
            this.lbl_leftSemaphoreDescription.Size = new System.Drawing.Size(210, 13);
            this.lbl_leftSemaphoreDescription.TabIndex = 3;
            this.lbl_leftSemaphoreDescription.Text = "Длительность фазы левого светофора:";
            // 
            // trackBar_leftSemaphore
            // 
            this.trackBar_leftSemaphore.Location = new System.Drawing.Point(3, 34);
            this.trackBar_leftSemaphore.Minimum = 2;
            this.trackBar_leftSemaphore.Name = "trackBar_leftSemaphore";
            this.trackBar_leftSemaphore.Size = new System.Drawing.Size(255, 45);
            this.trackBar_leftSemaphore.TabIndex = 4;
            this.trackBar_leftSemaphore.Value = 2;
            this.trackBar_leftSemaphore.Scroll += new System.EventHandler(this.trackBar_leftSemaphore_Scroll);
            // 
            // lbl_rightSemaphoreDescription
            // 
            this.lbl_rightSemaphoreDescription.AutoSize = true;
            this.lbl_rightSemaphoreDescription.Location = new System.Drawing.Point(7, 92);
            this.lbl_rightSemaphoreDescription.Name = "lbl_rightSemaphoreDescription";
            this.lbl_rightSemaphoreDescription.Size = new System.Drawing.Size(216, 13);
            this.lbl_rightSemaphoreDescription.TabIndex = 5;
            this.lbl_rightSemaphoreDescription.Text = "Длительность фазы правого светофора:";
            // 
            // trackBar_rightSemaphore
            // 
            this.trackBar_rightSemaphore.Location = new System.Drawing.Point(3, 123);
            this.trackBar_rightSemaphore.Minimum = 2;
            this.trackBar_rightSemaphore.Name = "trackBar_rightSemaphore";
            this.trackBar_rightSemaphore.Size = new System.Drawing.Size(255, 45);
            this.trackBar_rightSemaphore.TabIndex = 6;
            this.trackBar_rightSemaphore.Value = 2;
            this.trackBar_rightSemaphore.Scroll += new System.EventHandler(this.trackBar_rightSemaphore_Scroll);
            // 
            // lbl_leftValue
            // 
            this.lbl_leftValue.AutoSize = true;
            this.lbl_leftValue.Location = new System.Drawing.Point(223, 9);
            this.lbl_leftValue.Name = "lbl_leftValue";
            this.lbl_leftValue.Size = new System.Drawing.Size(22, 13);
            this.lbl_leftValue.TabIndex = 7;
            this.lbl_leftValue.Text = "2 c";
            // 
            // lbl_rightValue
            // 
            this.lbl_rightValue.AutoSize = true;
            this.lbl_rightValue.Location = new System.Drawing.Point(223, 92);
            this.lbl_rightValue.Name = "lbl_rightValue";
            this.lbl_rightValue.Size = new System.Drawing.Size(22, 13);
            this.lbl_rightValue.TabIndex = 8;
            this.lbl_rightValue.Text = "2 c";
            // 
            // SemaphoreSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 218);
            this.Controls.Add(this.lbl_rightValue);
            this.Controls.Add(this.lbl_leftValue);
            this.Controls.Add(this.trackBar_rightSemaphore);
            this.Controls.Add(this.lbl_rightSemaphoreDescription);
            this.Controls.Add(this.trackBar_leftSemaphore);
            this.Controls.Add(this.lbl_leftSemaphoreDescription);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_save);
            this.Name = "SemaphoreSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка фазы светофора";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SemaphoreConfigurationForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_leftSemaphore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_rightSemaphore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label lbl_leftSemaphoreDescription;
        private System.Windows.Forms.TrackBar trackBar_leftSemaphore;
        private System.Windows.Forms.Label lbl_rightSemaphoreDescription;
        private System.Windows.Forms.TrackBar trackBar_rightSemaphore;
        private System.Windows.Forms.Label lbl_leftValue;
        private System.Windows.Forms.Label lbl_rightValue;
    }
}