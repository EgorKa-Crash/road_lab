using Road_Lap1.Configuration;
using Road_Lap1.Configuration.Roads;
using Road_Lap1.SettingsForms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Road_Lap1.ConfigurationForms
{
    public partial class TypeRoadSettingsForm : Form
    {
        /// <summary>
        /// Конструктор для SystemSettings _settings
        /// </summary>
        private Func<SystemSettings> _constructor;

        /// <summary>
        /// Настройки системы
        /// </summary>
        public SystemSettings _settings { get; set; }

        /// <summary>
        /// Предыдущая форма
        /// </summary>
        public Form _prevForm { get; set; }

        public TypeRoadSettingsForm()
        {
            InitializeComponent();
            _constructor = () => SystemSettings.Factory.CreateHighway();

            _newBtnNextHandler += ButtonNextClick;
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

        private void button_next_Click(object sender, EventArgs e)
        {
            _newBtnNextHandler?.Invoke();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
