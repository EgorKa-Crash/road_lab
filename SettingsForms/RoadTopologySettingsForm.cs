using Road_Lap1.Configuration;
using Road_Lap1.Configuration.Roads;
using Road_Lap1.SettingsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace Road_Lap1.ConfigurationForms
{
    public partial class RoadTopologySettingsForm : Form
    {
        /// <summary>
        /// Предыдущая форма
        /// </summary>
        public Form PrevForm { get; set; }

        /// <summary>
        /// Конфигурационный объект
        /// </summary>
        public SystemSettings Settings { get; set; }

        /// <summary>
        /// Тип формы
        /// </summary>
        public SettingsForm SettingType => SettingsForm.RoadTopology;

        public RoadTopologySettingsForm(Form form, SystemSettings settings)
        {
            InitializeComponent();
            PrevForm = form;
            Settings = settings;
            SettingsFormDictionary.Instance.Add(SettingType, this);
        }

        private void radioButton_twoDirection_CheckedChanged(object sender, EventArgs e)
        {
            textBox_countLineOnSecondDirection.Visible = radioButton_twoDirection.Checked;
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if(!UpdateRoad())
            {
                return;
            }

            this.Hide();
            var form = new IntensitySettingsForm(this, Settings);
            form.Show();
        }

        private bool UpdateRoad()
        {
            var countLine1 = int.Parse(textBox_countLineOnFirstDirection.Text);
            var countLine2 = int.Parse(textBox_countLineOnSecondDirection.Text);

            Settings.Traffic = radioButton_oneDirection.Checked
                              ? new Traffic(countLine1) 
                              : (Traffic)new Traffic(countLine1, countLine2);

            return ValidateModel(Settings.Traffic);
        }

        private bool ValidateModel(object obj)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(obj);

            if (!Validator.TryValidateObject(obj, context, results, validateAllProperties: true))
            {
                foreach (var error in results)
                {
                    MessageBox.Show(error.ErrorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return false;
            }

            return true;
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            PrevForm.Show();
            SettingsFormDictionary.Instance.Remove(SettingType);
            Dispose();
        }

        private void RoadConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CloseAll();
        }

        public void ChangeBehavior()
        {
            throw new NotImplementedException();
        }
    }
}
