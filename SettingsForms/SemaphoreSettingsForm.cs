using Road_Lap1.Extensions;
using Road_Lap1.Settings;
using Road_Lap1.Settings.Distribution;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
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

            _settings.Semaphore = _semaphoreToChange;

            new DistributionSettingsForm(this, _settings, DistributionType.Flow).Show();
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
            lbl_rightValue.Text = SetLabelValue(trackBar_semaphore);
            _semaphoreToChange.TimeMilliseconds = trackBar_semaphore.Value * _millisecondsFactor;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            _prevForm.Show();
            Dispose();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if DEBUG
            var path = @"..\..\Resources\UserGuides\trafficLightsSettings.html";
#else
            var path = @"Resources\UserGuides\trafficLightsSettings.html";
#endif

            if (File.Exists(path))
            {
                try
                {
                    Process.Start(path);
                }
                catch (Exception)
                {
                    MessageBox.Show("Файл справки поврежден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Отсутствует файл справки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SetLabelValue(TrackBar trackBar) => trackBar.Value + " c";

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => this.CloseAll();

        private void aboutSystemToolStripMenuItem_Click(object sender, EventArgs e) => this.ShowSystemInfo();

        private void SemaphoreConfigurationForm_FormClosing(object sender, FormClosingEventArgs e) => this.CloseAll();
    }
}
