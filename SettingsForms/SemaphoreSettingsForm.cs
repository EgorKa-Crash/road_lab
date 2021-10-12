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
        /// Предыдущая форма
        /// </summary>
        private Form _prevForm;

        /// <summary>
        /// Первичный объект, который должен быть в корректном состоянии
        /// </summary>
        private SystemSettings _settings;

        /// <summary>
        /// Объект-болванка для изменений
        /// </summary>
        private SemaphoreSettings _semaphoreConfigurationToChange;
        

        public SemaphoreSettingsForm(Form prevForm, SystemSettings settings)
        {
            InitializeComponent();
            _prevForm = prevForm;
            _settings = settings;
            _semaphoreConfigurationToChange = new SemaphoreSettings(_settings.SemaphoreConfiguration.Value.TimeMilliseconds);
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
            _semaphoreConfigurationToChange.TimeMilliseconds = ParseInput();

            if(ValidateModel(_semaphoreConfigurationToChange))
            {
                if (_prevForm is RoadWindow)
                {
                    _settings.SemaphoreConfiguration.Value.TimeMilliseconds = _semaphoreConfigurationToChange.TimeMilliseconds;
                    Dispose();
                }
                else
                {
                    var form = new RoadWindow(this, _settings);
                    form.Show();
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

        private int ParseInput()
        {
            var param = -1;

            var result = int.TryParse(tb_timeInSeconds.Text, out param);

            if (!result)
            {
                MessageBox.Show("Введите целое положительное число!",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

            }

            return param * 1000;
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
    }
}
