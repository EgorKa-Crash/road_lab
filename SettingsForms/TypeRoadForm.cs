using Road_Lap1.Extensions;
using Road_Lap1.Settings;
using Road_Lap1.Settings.Roads;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Road_Lap1.ConfigurationForms
{
    public partial class TypeRoadForm : Form
    {
        /// <summary>
        /// Настройки системы
        /// </summary>
        SystemSettings _settings;

        /// <summary>
        /// Конструктор для SystemSettings _settings
        /// </summary>
        Func<SystemSettings> _constructor;

        public TypeRoadForm()
        {
            InitializeComponent();
            _constructor = () => SystemSettings.Factory.CreateHighway();
            ChangeBackColorRadioButtons();
            Container<Form>.Instance.Register(this);
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            _settings = _constructor();

            var form = _settings.RoadType == RoadType.Tunnel
                     ? new SemaphoreSettingsForm(this, _settings)
                     : (Form)new RoadSettingsForm(this, _settings);

            form.Show();

            this.Hide();
        }

        private void radioButton_road_CheckedChanged(object sender, EventArgs e)
        {
            _constructor = () => SystemSettings.Factory.CreateRoad();
            ChangeBackColorRadioButtons();
        }

        private void radioButton_tunnel_CheckedChanged(object sender, EventArgs e)
        {
            _constructor = () => SystemSettings.Factory.CreateTunnel();
            ChangeBackColorRadioButtons();
        }

        private void radioButton_highway_CheckedChanged(object sender, EventArgs e)
        {
            _constructor = () => SystemSettings.Factory.CreateHighway();
            ChangeBackColorRadioButtons();
        }

        private void ChangeBackColorRadioButtons()
        {
            foreach (var control in Controls.OfType<RadioButton>())
            {
                control.BackColor = control.Checked
                                  ? Color.Blue
                                  : Control.DefaultBackColor;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => this.CloseAll();

        private void TypeRoadForm_FormClosing(object sender, FormClosingEventArgs e) => this.CloseAll();

        private void aboutSystemToolStripMenuItem_Click(object sender, EventArgs e) => this.ShowSystemInfo();

        private void infoToolStripMenuItem_Click(object sender, EventArgs e) => Process.Start(@"..\..\Resources\UserGuides\roadTypeInfo.html");
    }
}
