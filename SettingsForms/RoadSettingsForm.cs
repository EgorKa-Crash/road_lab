using Road_Lap1.Configuration;
using Road_Lap1.Configuration.Roads;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace Road_Lap1.ConfigurationForms
{
    public partial class RoadSettingsForm : Form
    {
        /// <summary>
        /// Предыдущая форма
        /// </summary>
        private Form _prevForm;

        /// <summary>
        /// Конфигурационный объект
        /// </summary>
        private SystemSettings _settings;

        public RoadSettingsForm(Form form, SystemSettings settings)
        {
            InitializeComponent();
            _prevForm = form;
            _settings = settings;

            Container<Form>.Instance.Register(this);
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
            var form = new IntensitySettingsForm(this, _settings);
            form.Show();
        }

        private bool UpdateRoad()
        {
            var countLine1 = int.Parse(textBox_countLineOnFirstDirection.Text);
            var countLine2 = int.Parse(textBox_countLineOnSecondDirection.Text);

            _settings.Traffic = radioButton_oneDirection.Checked
                              ? new Traffic(countLine1) 
                              : (Traffic)new Traffic(countLine1, countLine2);

            return Validate(_settings.Traffic);
        }

        private bool Validate(object obj)
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
            _prevForm.Show();
            Container<Form>.Instance.Unregister(this);
            Dispose();
        }

        private void RoadConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CloseAll();
        }
    }
}
