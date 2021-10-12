namespace Road_Lap1.ConfigurationForms
{
    partial class TypeSettingsForm
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
            this.button_next = new System.Windows.Forms.Button();
            this.radioButton_road = new System.Windows.Forms.RadioButton();
            this.radioButton_highway = new System.Windows.Forms.RadioButton();
            this.radioButton_tunnel = new System.Windows.Forms.RadioButton();
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
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(190, 74);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(91, 23);
            this.button_next.TabIndex = 2;
            this.button_next.Text = "Далее";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
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
            // TypeRoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 109);
            this.Controls.Add(this.radioButton_tunnel);
            this.Controls.Add(this.radioButton_highway);
            this.Controls.Add(this.radioButton_road);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.lbl_roadType);
            this.Name = "TypeRoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор дороги";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TypeRoadForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_roadType;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.RadioButton radioButton_road;
        private System.Windows.Forms.RadioButton radioButton_highway;
        private System.Windows.Forms.RadioButton radioButton_tunnel;
    }
}