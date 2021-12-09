using Road_Lap1.Extensions;
using Road_Lap1.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace Road_Lap1.ConfigurationForms
{
    public partial class SemaphoreSettingsForm : Form
    {
        /// <summary>
        /// Перевод значения в миллисекунды
        /// </summary>
        private const int _millisecondsFactor = 1000;

        /// <summary>
        /// Предыдущая форма
        /// </summary>
        private Form _prevForm;

        /// <summary>
        /// Первичный объект, который должен быть в корректном состоянии
        /// </summary>
        private SystemSettings _settings;

        /// <summary>
        /// Объект-болванка для изменений светофора
        /// </summary>
        private Semaphore _semaphoreToChange;
        
        public SemaphoreSettingsForm(Form prevForm, SystemSettings settings)
        {
            InitializeComponent();
            _prevForm = prevForm;
            _settings = settings; 
            _semaphoreToChange = new Semaphore();
            Container<Form>.Instance.Register(this);
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if(!ValidateModel(_semaphoreToChange))
            {
                return;
            }

            _settings.Semaphore.TimeMilliseconds = _semaphoreToChange.TimeMilliseconds;

            new DistributionSettingsForm(this, _settings, DistributionFormType.Flow).Show();
            this.Hide();
        }

        private bool ValidateModel(object obj)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(obj);

            if (!Validator.TryValidateObject(obj, context, results, true))
            {
                foreach (var error in results)
                {
                    MessageBox.Show(error.ErrorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return false;
            }

            return true;
        }      
      
        private void trackBar_rightSemaphore_Scroll(object sender, EventArgs e)
        {
            lbl_rightValue.Text = SetLabelValue(trackBar_rightSemaphore);
            _semaphoreToChange.TimeMilliseconds = trackBar_rightSemaphore.Value * _millisecondsFactor;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            _prevForm.Show();
            Dispose();
        }

        private string SetLabelValue(TrackBar trackBar) => trackBar.Value + " c";

        private void aboutSystemToolStripMenuItem_Click(object sender, EventArgs e) => this.ShowSystemInfo();

        private void SemaphoreConfigurationForm_FormClosing(object sender, FormClosingEventArgs e) => this.CloseAll();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => this.CloseAll();

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = @"..\..\Resources\UserGuides\trafficLightsSettings.html";
            System.Diagnostics.Process.Start(path);
        }
    }
}
