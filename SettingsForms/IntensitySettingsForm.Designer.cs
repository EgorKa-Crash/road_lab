namespace Road_Lap1.ConfigurationForms
{
    partial class IntensitySettingsForm
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
            this.radioButton_uniformIntensity = new System.Windows.Forms.RadioButton();
            this.label_intensityType = new System.Windows.Forms.Label();
            this.radioButton_normalIntenisty = new System.Windows.Forms.RadioButton();
            this.radioButton_exponentialIntensity = new System.Windows.Forms.RadioButton();
            this.radioButton_determineIntensity = new System.Windows.Forms.RadioButton();
            this.textBox_intesityFirstParam = new System.Windows.Forms.TextBox();
            this.label_intesity1 = new System.Windows.Forms.Label();
            this.label_intesity2 = new System.Windows.Forms.Label();
            this.textBox_intesitySecondParam = new System.Windows.Forms.TextBox();
            this.button_back = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButton_uniformIntensity
            // 
            this.radioButton_uniformIntensity.AutoSize = true;
            this.radioButton_uniformIntensity.Location = new System.Drawing.Point(12, 48);
            this.radioButton_uniformIntensity.Name = "radioButton_uniformIntensity";
            this.radioButton_uniformIntensity.Size = new System.Drawing.Size(96, 17);
            this.radioButton_uniformIntensity.TabIndex = 0;
            this.radioButton_uniformIntensity.Text = "Равномерный";
            this.radioButton_uniformIntensity.UseVisualStyleBackColor = false;
            this.radioButton_uniformIntensity.CheckedChanged += new System.EventHandler(this.radioButton_uniformIntensity_CheckedChanged);
            // 
            // label_intensityType
            // 
            this.label_intensityType.AutoSize = true;
            this.label_intensityType.Location = new System.Drawing.Point(12, 9);
            this.label_intensityType.Name = "label_intensityType";
            this.label_intensityType.Size = new System.Drawing.Size(221, 13);
            this.label_intensityType.TabIndex = 1;
            this.label_intensityType.Text = "Тип распределения интесивности потока:";
            // 
            // radioButton_normalIntenisty
            // 
            this.radioButton_normalIntenisty.AutoSize = true;
            this.radioButton_normalIntenisty.Location = new System.Drawing.Point(12, 71);
            this.radioButton_normalIntenisty.Name = "radioButton_normalIntenisty";
            this.radioButton_normalIntenisty.Size = new System.Drawing.Size(91, 17);
            this.radioButton_normalIntenisty.TabIndex = 2;
            this.radioButton_normalIntenisty.Text = "Нормальный";
            this.radioButton_normalIntenisty.UseVisualStyleBackColor = true;
            this.radioButton_normalIntenisty.CheckedChanged += new System.EventHandler(this.radioButton_normalIntenisty_CheckedChanged);
            // 
            // radioButton_exponentialIntensity
            // 
            this.radioButton_exponentialIntensity.AutoSize = true;
            this.radioButton_exponentialIntensity.Location = new System.Drawing.Point(12, 94);
            this.radioButton_exponentialIntensity.Name = "radioButton_exponentialIntensity";
            this.radioButton_exponentialIntensity.Size = new System.Drawing.Size(106, 17);
            this.radioButton_exponentialIntensity.TabIndex = 3;
            this.radioButton_exponentialIntensity.Text = "Показательный";
            this.radioButton_exponentialIntensity.UseVisualStyleBackColor = true;
            this.radioButton_exponentialIntensity.CheckedChanged += new System.EventHandler(this.radioButton_exponentialIntensity_CheckedChanged);
            // 
            // radioButton_determineIntensity
            // 
            this.radioButton_determineIntensity.AutoSize = true;
            this.radioButton_determineIntensity.Checked = true;
            this.radioButton_determineIntensity.Location = new System.Drawing.Point(12, 25);
            this.radioButton_determineIntensity.Name = "radioButton_determineIntensity";
            this.radioButton_determineIntensity.Size = new System.Drawing.Size(133, 17);
            this.radioButton_determineIntensity.TabIndex = 4;
            this.radioButton_determineIntensity.TabStop = true;
            this.radioButton_determineIntensity.Text = "Детерминированный";
            this.radioButton_determineIntensity.UseVisualStyleBackColor = true;
            this.radioButton_determineIntensity.CheckedChanged += new System.EventHandler(this.radioButton_determineIntensity_CheckedChanged);
            // 
            // textBox_intesityFirstParam
            // 
            this.textBox_intesityFirstParam.Location = new System.Drawing.Point(15, 159);
            this.textBox_intesityFirstParam.Name = "textBox_intesityFirstParam";
            this.textBox_intesityFirstParam.Size = new System.Drawing.Size(100, 20);
            this.textBox_intesityFirstParam.TabIndex = 5;
            this.textBox_intesityFirstParam.Text = "500";
            // 
            // label_intesity1
            // 
            this.label_intesity1.AutoSize = true;
            this.label_intesity1.Location = new System.Drawing.Point(12, 143);
            this.label_intesity1.Name = "label_intesity1";
            this.label_intesity1.Size = new System.Drawing.Size(118, 13);
            this.label_intesity1.TabIndex = 6;
            this.label_intesity1.Text = "Левый конец отрезка";
            // 
            // label_intesity2
            // 
            this.label_intesity2.AutoSize = true;
            this.label_intesity2.Location = new System.Drawing.Point(12, 182);
            this.label_intesity2.Name = "label_intesity2";
            this.label_intesity2.Size = new System.Drawing.Size(118, 13);
            this.label_intesity2.TabIndex = 7;
            this.label_intesity2.Text = "Левый конец отрезка";
            // 
            // textBox_intesitySecondParam
            // 
            this.textBox_intesitySecondParam.Location = new System.Drawing.Point(15, 198);
            this.textBox_intesitySecondParam.Name = "textBox_intesitySecondParam";
            this.textBox_intesitySecondParam.Size = new System.Drawing.Size(100, 20);
            this.textBox_intesitySecondParam.TabIndex = 8;
            this.textBox_intesitySecondParam.Text = "800";
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(15, 238);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(100, 23);
            this.button_back.TabIndex = 9;
            this.button_back.Text = "Назад";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(168, 238);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(100, 23);
            this.button_next.TabIndex = 10;
            this.button_next.Text = "Далее";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // IntensitySettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 273);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.textBox_intesitySecondParam);
            this.Controls.Add(this.label_intesity2);
            this.Controls.Add(this.label_intesity1);
            this.Controls.Add(this.textBox_intesityFirstParam);
            this.Controls.Add(this.radioButton_determineIntensity);
            this.Controls.Add(this.radioButton_exponentialIntensity);
            this.Controls.Add(this.radioButton_normalIntenisty);
            this.Controls.Add(this.label_intensityType);
            this.Controls.Add(this.radioButton_uniformIntensity);
            this.Name = "IntensitySettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор распределения интесиновности потока";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IntensityConfigurationForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_uniformIntensity;
        private System.Windows.Forms.Label label_intensityType;
        private System.Windows.Forms.RadioButton radioButton_normalIntenisty;
        private System.Windows.Forms.RadioButton radioButton_exponentialIntensity;
        private System.Windows.Forms.RadioButton radioButton_determineIntensity;
        private System.Windows.Forms.TextBox textBox_intesityFirstParam;
        private System.Windows.Forms.Label label_intesity1;
        private System.Windows.Forms.Label label_intesity2;
        private System.Windows.Forms.TextBox textBox_intesitySecondParam;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_next;
    }
}