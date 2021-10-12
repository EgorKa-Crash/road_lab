using Road_Lap1.Configuration;
using Road_Lap1.Configuration.Roads;
using System;
using System.Windows.Forms;

namespace Road_Lap1.ConfigurationForms
{
    public partial class TypeSettingsForm : Form
    {
        /// <summary>
        /// Настройки системы
        /// </summary>
        SystemSettings _settings;

        /// <summary>
        /// Конструктор для SystemSettingsBase _settings
        /// </summary>
        Func<SystemSettings> _constructor;

        public TypeSettingsForm()
        {
            InitializeComponent();
            _constructor = () => SystemSettings.Factory.CreateHighway();
            Container<Form>.Instance.Register(this);
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            _settings = _constructor();

            var form = _settings.TypeRoad == TypeRoad.Tunnel
                     ? new IntensitySettingsForm(this, _settings)
                     : (Form)new RoadSettingsForm(this, _settings);

            form.Show();
            this.Hide();
        }

        private void radioButton_road_CheckedChanged(object sender, EventArgs e)
        {
            _constructor = () => SystemSettings.Factory.CreateRoad();
        }

        private void radioButton_tunnel_CheckedChanged(object sender, EventArgs e)
        {
            _constructor = () => SystemSettings.Factory.CreateTunnel();
        }

        private void radioButton_highway_CheckedChanged(object sender, EventArgs e)
        {
            _constructor = () => SystemSettings.Factory.CreateHighway();
        }

        private void TypeRoadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CloseAll();
        }
    }
}
