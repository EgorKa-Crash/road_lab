namespace Road_Lap1.ConfigurationForms
{
    partial class DistributionSettingsForm
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
            this.radioButton_uniformDistribution = new System.Windows.Forms.RadioButton();
            this.label_intensityType = new System.Windows.Forms.Label();
            this.radioButton_normalDistribution = new System.Windows.Forms.RadioButton();
            this.radioButton_exponentialDistribution = new System.Windows.Forms.RadioButton();
            this.radioButton_determineDistribution = new System.Windows.Forms.RadioButton();
            this.lbl_intesityFirstParamDescription = new System.Windows.Forms.Label();
            this.lbl_intesitySecondParamDescription = new System.Windows.Forms.Label();
            this.button_back = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBar_firstParam = new System.Windows.Forms.TrackBar();
            this.trackBar_secondParam = new System.Windows.Forms.TrackBar();
            this.lbl_firstParamMin = new System.Windows.Forms.Label();
            this.lbl_firstParamMax = new System.Windows.Forms.Label();
            this.lbl_secondParamMax = new System.Windows.Forms.Label();
            this.lbl_firstParamValue = new System.Windows.Forms.Label();
            this.lbl_secondParamValue = new System.Windows.Forms.Label();
            this.panel_secondParam = new System.Windows.Forms.Panel();
            this.lbl_secondParamMin = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_firstParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_secondParam)).BeginInit();
            this.panel_secondParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton_uniformDistribution
            // 
            this.radioButton_uniformDistribution.AutoSize = true;
            this.radioButton_uniformDistribution.Location = new System.Drawing.Point(12, 65);
            this.radioButton_uniformDistribution.Name = "radioButton_uniformDistribution";
            this.radioButton_uniformDistribution.Size = new System.Drawing.Size(96, 17);
            this.radioButton_uniformDistribution.TabIndex = 0;
            this.radioButton_uniformDistribution.Text = "Равномерный";
            this.radioButton_uniformDistribution.UseVisualStyleBackColor = false;
            this.radioButton_uniformDistribution.CheckedChanged += new System.EventHandler(this.radioButton_uniformDistribution_CheckedChanged);
            // 
            // label_intensityType
            // 
            this.label_intensityType.AutoSize = true;
            this.label_intensityType.Location = new System.Drawing.Point(12, 26);
            this.label_intensityType.Name = "label_intensityType";
            this.label_intensityType.Size = new System.Drawing.Size(221, 13);
            this.label_intensityType.TabIndex = 1;
            this.label_intensityType.Text = "Тип распределения интесивности потока:";
            // 
            // radioButton_normalDistribution
            // 
            this.radioButton_normalDistribution.AutoSize = true;
            this.radioButton_normalDistribution.Location = new System.Drawing.Point(12, 88);
            this.radioButton_normalDistribution.Name = "radioButton_normalDistribution";
            this.radioButton_normalDistribution.Size = new System.Drawing.Size(91, 17);
            this.radioButton_normalDistribution.TabIndex = 2;
            this.radioButton_normalDistribution.Text = "Нормальный";
            this.radioButton_normalDistribution.UseVisualStyleBackColor = true;
            this.radioButton_normalDistribution.CheckedChanged += new System.EventHandler(this.radioButton_normalDistribution_CheckedChanged);
            // 
            // radioButton_exponentialDistribution
            // 
            this.radioButton_exponentialDistribution.AutoSize = true;
            this.radioButton_exponentialDistribution.Location = new System.Drawing.Point(12, 111);
            this.radioButton_exponentialDistribution.Name = "radioButton_exponentialDistribution";
            this.radioButton_exponentialDistribution.Size = new System.Drawing.Size(106, 17);
            this.radioButton_exponentialDistribution.TabIndex = 3;
            this.radioButton_exponentialDistribution.Text = "Показательный";
            this.radioButton_exponentialDistribution.UseVisualStyleBackColor = true;
            this.radioButton_exponentialDistribution.CheckedChanged += new System.EventHandler(this.radioButton_exponentialDistribution_CheckedChanged);
            // 
            // radioButton_determineDistribution
            // 
            this.radioButton_determineDistribution.AutoSize = true;
            this.radioButton_determineDistribution.Checked = true;
            this.radioButton_determineDistribution.Location = new System.Drawing.Point(12, 42);
            this.radioButton_determineDistribution.Name = "radioButton_determineDistribution";
            this.radioButton_determineDistribution.Size = new System.Drawing.Size(133, 17);
            this.radioButton_determineDistribution.TabIndex = 4;
            this.radioButton_determineDistribution.TabStop = true;
            this.radioButton_determineDistribution.Text = "Детерминированный";
            this.radioButton_determineDistribution.UseVisualStyleBackColor = true;
            this.radioButton_determineDistribution.CheckedChanged += new System.EventHandler(this.radioButton_determineDistribution_CheckedChanged);
            // 
            // lbl_intesityFirstParamDescription
            // 
            this.lbl_intesityFirstParamDescription.AutoSize = true;
            this.lbl_intesityFirstParamDescription.Location = new System.Drawing.Point(9, 144);
            this.lbl_intesityFirstParamDescription.Name = "lbl_intesityFirstParamDescription";
            this.lbl_intesityFirstParamDescription.Size = new System.Drawing.Size(118, 13);
            this.lbl_intesityFirstParamDescription.TabIndex = 6;
            this.lbl_intesityFirstParamDescription.Text = "Левый конец отрезка";
            // 
            // lbl_intesitySecondParamDescription
            // 
            this.lbl_intesitySecondParamDescription.AutoSize = true;
            this.lbl_intesitySecondParamDescription.Location = new System.Drawing.Point(3, 4);
            this.lbl_intesitySecondParamDescription.Name = "lbl_intesitySecondParamDescription";
            this.lbl_intesitySecondParamDescription.Size = new System.Drawing.Size(118, 13);
            this.lbl_intesitySecondParamDescription.TabIndex = 7;
            this.lbl_intesitySecondParamDescription.Text = "Левый конец отрезка";
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(8, 293);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(100, 23);
            this.button_back.TabIndex = 9;
            this.button_back.Text = "Назад";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(219, 293);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(100, 23);
            this.button_next.TabIndex = 10;
            this.button_next.Text = "Далее";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
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
            // trackBar_firstParam
            // 
            this.trackBar_firstParam.LargeChange = 1;
            this.trackBar_firstParam.Location = new System.Drawing.Point(11, 160);
            this.trackBar_firstParam.Minimum = 2;
            this.trackBar_firstParam.Name = "trackBar_firstParam";
            this.trackBar_firstParam.Size = new System.Drawing.Size(308, 45);
            this.trackBar_firstParam.TabIndex = 12;
            this.trackBar_firstParam.Value = 2;
            this.trackBar_firstParam.Scroll += new System.EventHandler(this.trackBar_firstParam_Scroll);
            // 
            // trackBar_secondParam
            // 
            this.trackBar_secondParam.LargeChange = 1;
            this.trackBar_secondParam.Location = new System.Drawing.Point(3, 20);
            this.trackBar_secondParam.Minimum = 2;
            this.trackBar_secondParam.Name = "trackBar_secondParam";
            this.trackBar_secondParam.Size = new System.Drawing.Size(308, 45);
            this.trackBar_secondParam.TabIndex = 13;
            this.trackBar_secondParam.Value = 2;
            this.trackBar_secondParam.Scroll += new System.EventHandler(this.trackBar_secondParam_Scroll);
            // 
            // lbl_firstParamMin
            // 
            this.lbl_firstParamMin.AutoSize = true;
            this.lbl_firstParamMin.Location = new System.Drawing.Point(19, 191);
            this.lbl_firstParamMin.Name = "lbl_firstParamMin";
            this.lbl_firstParamMin.Size = new System.Drawing.Size(22, 13);
            this.lbl_firstParamMin.TabIndex = 14;
            this.lbl_firstParamMin.Text = "0.2";
            // 
            // lbl_firstParamMax
            // 
            this.lbl_firstParamMax.AutoSize = true;
            this.lbl_firstParamMax.Location = new System.Drawing.Point(299, 191);
            this.lbl_firstParamMax.Name = "lbl_firstParamMax";
            this.lbl_firstParamMax.Size = new System.Drawing.Size(13, 13);
            this.lbl_firstParamMax.TabIndex = 15;
            this.lbl_firstParamMax.Text = "1";
            // 
            // lbl_secondParamMax
            // 
            this.lbl_secondParamMax.AutoSize = true;
            this.lbl_secondParamMax.Location = new System.Drawing.Point(282, 51);
            this.lbl_secondParamMax.Name = "lbl_secondParamMax";
            this.lbl_secondParamMax.Size = new System.Drawing.Size(13, 13);
            this.lbl_secondParamMax.TabIndex = 17;
            this.lbl_secondParamMax.Text = "1";
            // 
            // lbl_firstParamValue
            // 
            this.lbl_firstParamValue.AutoSize = true;
            this.lbl_firstParamValue.Location = new System.Drawing.Point(132, 144);
            this.lbl_firstParamValue.Name = "lbl_firstParamValue";
            this.lbl_firstParamValue.Size = new System.Drawing.Size(13, 13);
            this.lbl_firstParamValue.TabIndex = 18;
            this.lbl_firstParamValue.Text = "0";
            // 
            // lbl_secondParamValue
            // 
            this.lbl_secondParamValue.AutoSize = true;
            this.lbl_secondParamValue.Location = new System.Drawing.Point(127, 4);
            this.lbl_secondParamValue.Name = "lbl_secondParamValue";
            this.lbl_secondParamValue.Size = new System.Drawing.Size(13, 13);
            this.lbl_secondParamValue.TabIndex = 19;
            this.lbl_secondParamValue.Text = "0";
            // 
            // panel_secondParam
            // 
            this.panel_secondParam.Controls.Add(this.lbl_secondParamMin);
            this.panel_secondParam.Controls.Add(this.lbl_intesitySecondParamDescription);
            this.panel_secondParam.Controls.Add(this.lbl_secondParamValue);
            this.panel_secondParam.Controls.Add(this.lbl_secondParamMax);
            this.panel_secondParam.Controls.Add(this.trackBar_secondParam);
            this.panel_secondParam.Location = new System.Drawing.Point(8, 212);
            this.panel_secondParam.Name = "panel_secondParam";
            this.panel_secondParam.Size = new System.Drawing.Size(318, 64);
            this.panel_secondParam.TabIndex = 20;
            // 
            // lbl_secondParamMin
            // 
            this.lbl_secondParamMin.AutoSize = true;
            this.lbl_secondParamMin.Location = new System.Drawing.Point(10, 51);
            this.lbl_secondParamMin.Name = "lbl_secondParamMin";
            this.lbl_secondParamMin.Size = new System.Drawing.Size(22, 13);
            this.lbl_secondParamMin.TabIndex = 20;
            this.lbl_secondParamMin.Text = "0.2";
            // 
            // DistributionSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 323);
            this.Controls.Add(this.panel_secondParam);
            this.Controls.Add(this.lbl_firstParamValue);
            this.Controls.Add(this.lbl_firstParamMax);
            this.Controls.Add(this.lbl_firstParamMin);
            this.Controls.Add(this.trackBar_firstParam);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.lbl_intesityFirstParamDescription);
            this.Controls.Add(this.radioButton_determineDistribution);
            this.Controls.Add(this.radioButton_exponentialDistribution);
            this.Controls.Add(this.radioButton_normalDistribution);
            this.Controls.Add(this.label_intensityType);
            this.Controls.Add(this.radioButton_uniformDistribution);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DistributionSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка транспортного потока";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DistributionSettingsForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_firstParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_secondParam)).EndInit();
            this.panel_secondParam.ResumeLayout(false);
            this.panel_secondParam.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_uniformDistribution;
        private System.Windows.Forms.Label label_intensityType;
        private System.Windows.Forms.RadioButton radioButton_normalDistribution;
        private System.Windows.Forms.RadioButton radioButton_exponentialDistribution;
        private System.Windows.Forms.RadioButton radioButton_determineDistribution;
        private System.Windows.Forms.Label lbl_intesityFirstParamDescription;
        private System.Windows.Forms.Label lbl_intesitySecondParamDescription;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSystemToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar_firstParam;
        private System.Windows.Forms.TrackBar trackBar_secondParam;
        private System.Windows.Forms.Label lbl_firstParamMin;
        private System.Windows.Forms.Label lbl_firstParamMax;
        private System.Windows.Forms.Label lbl_secondParamMax;
        private System.Windows.Forms.Label lbl_firstParamValue;
        private System.Windows.Forms.Label lbl_secondParamValue;
        private System.Windows.Forms.Panel panel_secondParam;
        private System.Windows.Forms.Label lbl_secondParamMin;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}