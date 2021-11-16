using Road_Lap1.Configuration;
using Road_Lap1.Configuration.Roads;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// Объект-болванка для изменений   светофора
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            if(!(_prevForm is RoadWindow))
            {
                _prevForm.Show();
            }

            Dispose();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(   ValidateModel(_semaphoreToChange))
            {
                
                _settings.Semaphore.TimeMilliseconds = _semaphoreToChange.TimeMilliseconds;

                if (_prevForm is RoadWindow)
                {
                    Dispose();
                }
                else
                {
                    new IntensitySettingsForm(this, _settings).Show();
                    this.Hide();
                }
            }
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

        private void SemaphoreConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_prevForm is RoadWindow)
            {
                Dispose();
            }
            else
            {
                this.CloseAll();
            }
        }

        private void trackBar_rightSemaphore_Scroll(object sender, EventArgs e)
        {
            lbl_rightValue.Text = SetLabelValue(trackBar_rightSemaphore);
            _semaphoreToChange.TimeMilliseconds = trackBar_rightSemaphore.Value * _millisecondsFactor;
        }

        

        private string SetLabelValue(TrackBar trackBar)
        {
            return trackBar.Value + " c";
        }
    }
}
