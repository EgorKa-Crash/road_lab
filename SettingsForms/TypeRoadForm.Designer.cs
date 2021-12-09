namespace Road_Lap1.ConfigurationForms
{
    partial class TypeRoadForm
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
            this.radioButton_tunnel = new System.Windows.Forms.RadioButton();
            this.lbl_road = new System.Windows.Forms.Label();
            this.lbl_tunnel = new System.Windows.Forms.Label();
            this.lbl_highway = new System.Windows.Forms.Label();
            this.radioButton_highway = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_roadType
            // 
            this.lbl_roadType.AutoSize = true;
            this.lbl_roadType.Location = new System.Drawing.Point(9, 29);
            this.lbl_roadType.Name = "lbl_roadType";
            this.lbl_roadType.Size = new System.Drawing.Size(118, 13);
            this.lbl_roadType.TabIndex = 0;
            this.lbl_roadType.Text = "Выберите тип дороги:";
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(219, 293);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(100, 23);
            this.button_next.TabIndex = 2;
            this.button_next.Text = "Далее";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // radioButton_road
            // 
            this.radioButton_road.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_road.BackColor = System.Drawing.SystemColors.Menu;
            this.radioButton_road.BackgroundImage = global::Road_Lap1.Properties.Resources.CarRoad;
            this.radioButton_road.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.radioButton_road.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton_road.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioButton_road.Location = new System.Drawing.Point(12, 50);
            this.radioButton_road.Name = "radioButton_road";
            this.radioButton_road.Size = new System.Drawing.Size(85, 85);
            this.radioButton_road.TabIndex = 3;
            this.radioButton_road.UseVisualStyleBackColor = false;
            this.radioButton_road.CheckedChanged += new System.EventHandler(this.radioButton_road_CheckedChanged);
            // 
            // radioButton_tunnel
            // 
            this.radioButton_tunnel.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_tunnel.BackColor = System.Drawing.SystemColors.Menu;
            this.radioButton_tunnel.BackgroundImage = global::Road_Lap1.Properties.Resources.Tunnel;
            this.radioButton_tunnel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.radioButton_tunnel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton_tunnel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioButton_tunnel.Location = new System.Drawing.Point(12, 141);
            this.radioButton_tunnel.Name = "radioButton_tunnel";
            this.radioButton_tunnel.Size = new System.Drawing.Size(85, 85);
            this.radioButton_tunnel.TabIndex = 5;
            this.radioButton_tunnel.UseVisualStyleBackColor = false;
            this.radioButton_tunnel.CheckedChanged += new System.EventHandler(this.radioButton_tunnel_CheckedChanged);
            // 
            // lbl_road
            // 
            this.lbl_road.AutoSize = true;
            this.lbl_road.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_road.Location = new System.Drawing.Point(106, 86);
            this.lbl_road.Name = "lbl_road";
            this.lbl_road.Size = new System.Drawing.Size(55, 16);
            this.lbl_road.TabIndex = 6;
            this.lbl_road.Text = "Дорога";
            // 
            // lbl_tunnel
            // 
            this.lbl_tunnel.AutoSize = true;
            this.lbl_tunnel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_tunnel.Location = new System.Drawing.Point(106, 177);
            this.lbl_tunnel.Name = "lbl_tunnel";
            this.lbl_tunnel.Size = new System.Drawing.Size(64, 16);
            this.lbl_tunnel.TabIndex = 7;
            this.lbl_tunnel.Text = "Тоннель";
            // 
            // lbl_highway
            // 
            this.lbl_highway.AutoSize = true;
            this.lbl_highway.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_highway.Location = new System.Drawing.Point(106, 268);
            this.lbl_highway.Name = "lbl_highway";
            this.lbl_highway.Size = new System.Drawing.Size(86, 16);
            this.lbl_highway.TabIndex = 8;
            this.lbl_highway.Text = "Автострада";
            // 
            // radioButton_highway
            // 
            this.radioButton_highway.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButton_highway.BackColor = System.Drawing.SystemColors.Menu;
            this.radioButton_highway.BackgroundImage = global::Road_Lap1.Properties.Resources.Highway;
            this.radioButton_highway.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.radioButton_highway.Checked = true;
            this.radioButton_highway.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton_highway.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radioButton_highway.Location = new System.Drawing.Point(12, 232);
            this.radioButton_highway.Name = "radioButton_highway";
            this.radioButton_highway.Size = new System.Drawing.Size(85, 85);
            this.radioButton_highway.TabIndex = 9;
            this.radioButton_highway.TabStop = true;
            this.radioButton_highway.UseVisualStyleBackColor = false;
            this.radioButton_highway.CheckedChanged += new System.EventHandler(this.radioButton_highway_CheckedChanged);
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
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.infoToolStripMenuItem.Text = "Справка";
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
            // TypeRoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 323);
            this.Controls.Add(this.radioButton_highway);
            this.Controls.Add(this.lbl_highway);
            this.Controls.Add(this.lbl_tunnel);
            this.Controls.Add(this.lbl_road);
            this.Controls.Add(this.radioButton_tunnel);
            this.Controls.Add(this.radioButton_road);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.lbl_roadType);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TypeRoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор дороги";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TypeRoadForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_roadType;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.RadioButton radioButton_road;
        private System.Windows.Forms.RadioButton radioButton_tunnel;
        private System.Windows.Forms.Label lbl_road;
        private System.Windows.Forms.Label lbl_tunnel;
        private System.Windows.Forms.Label lbl_highway;
        private System.Windows.Forms.RadioButton radioButton_highway;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSystemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}