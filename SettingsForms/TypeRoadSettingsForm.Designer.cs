namespace Road_Lap1.ConfigurationForms
{
    partial class TypeRoadSettingsForm
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
            this.lbl_roadType = new System.Windows.Forms.Label();
            this.btn_next = new System.Windows.Forms.Button();
            this.radioButton_road = new System.Windows.Forms.RadioButton();
            this.radioButton_highway = new System.Windows.Forms.RadioButton();
            this.radioButton_tunnel = new System.Windows.Forms.RadioButton();
            this.btn_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_roadType
            // 
            this.lbl_roadType.AutoSize = true;
            this.lbl_roadType.Location = new System.Drawing.Point(35, 13);
            this.lbl_roadType.Name = "lbl_roadType";
            this.lbl_roadType.Size = new System.Drawing.Size(118, 13);
            this.lbl_roadType.TabIndex = 0;
            this.lbl_roadType.Text = "Выберите тип дороги:";
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(198, 102);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(91, 23);
            this.btn_next.TabIndex = 2;
            this.btn_next.Text = "Далее";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // radioButton_road
            // 
            this.radioButton_road.AutoSize = true;
            this.radioButton_road.Location = new System.Drawing.Point(38, 34);
            this.radioButton_road.Name = "radioButton_road";
            this.radioButton_road.Size = new System.Drawing.Size(63, 17);
            this.radioButton_road.TabIndex = 3;
            this.radioButton_road.Text = "Дорога";
            this.radioButton_road.UseVisualStyleBackColor = true;
            this.radioButton_road.CheckedChanged += new System.EventHandler(this.radioButton_road_CheckedChanged);
            // 
            // radioButton_highway
            // 
            this.radioButton_highway.AutoSize = true;
            this.radioButton_highway.Checked = true;
            this.radioButton_highway.Location = new System.Drawing.Point(38, 80);
            this.radioButton_highway.Name = "radioButton_highway";
            this.radioButton_highway.Size = new System.Drawing.Size(84, 17);
            this.radioButton_highway.TabIndex = 4;
            this.radioButton_highway.TabStop = true;
            this.radioButton_highway.Text = "Автострада";
            this.radioButton_highway.UseVisualStyleBackColor = true;
            this.radioButton_highway.CheckedChanged += new System.EventHandler(this.radioButton_highway_CheckedChanged);
            // 
            // radioButton_tunnel
            // 
            this.radioButton_tunnel.AutoSize = true;
            this.radioButton_tunnel.Location = new System.Drawing.Point(38, 57);
            this.radioButton_tunnel.Name = "radioButton_tunnel";
            this.radioButton_tunnel.Size = new System.Drawing.Size(68, 17);
            this.radioButton_tunnel.TabIndex = 5;
            this.radioButton_tunnel.Text = "Тоннель";
            this.radioButton_tunnel.UseVisualStyleBackColor = true;
            this.radioButton_tunnel.CheckedChanged += new System.EventHandler(this.radioButton_tunnel_CheckedChanged);
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(31, 103);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(91, 23);
            this.btn_back.TabIndex = 6;
            this.btn_back.Text = "Назад";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Visible = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // TypeSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 137);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.radioButton_tunnel);
            this.Controls.Add(this.radioButton_highway);
            this.Controls.Add(this.radioButton_road);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.lbl_roadType);
            this.Name = "TypeSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор дороги";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TypeRoadForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_roadType;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.RadioButton radioButton_road;
        private System.Windows.Forms.RadioButton radioButton_highway;
        private System.Windows.Forms.RadioButton radioButton_tunnel;
        private System.Windows.Forms.Button btn_back;
    }
}