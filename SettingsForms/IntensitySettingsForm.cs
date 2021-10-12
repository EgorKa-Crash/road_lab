using Road_Lap1.Configuration;
using Road_Lap1.Configuration.Intensity;
using Road_Lap1.Configuration.Intesity;
using Road_Lap1.Configuration.Roads;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Road_Lap1.ConfigurationForms
{
    public partial class IntensitySettingsForm : Form
    {
        /// <summary>
        /// Количество открытых форм)0)))0)
        /// </summary>
        private static int _countForms;

        /// <summary>
        /// Выбранный тип интенсивности
        /// </summary>
        private IIntensity _intensity;

        /// <summary>
        /// Конструктор для объектов IIntensity
        /// </summary>
        Func<double?, double?, IIntensity> _intensityConstructor;

        /// <summary>
        /// Настройки системы
        /// </summary>
        private SystemSettings _settings;

        /// <summary>
        /// Предыдущая форма
        /// </summary>
        private Form _form;

        public IntensitySettingsForm(Form form, SystemSettings settings)
        {
            InitializeComponent();

            _form = form;
            _countForms = 1;
            _settings = settings;
            Container<Form>.Instance.Register(this);
        }

        private void radioButton_uniformIntensity_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton_uniformIntensity.Checked)
            {
                _intensityConstructor = (a, b) => IntensityFactory.CreateUniformIntensity(a, b);

                UpdateControls(typeof(UniformIntensity));
            }
        }

        private void radioButton_normalIntenisty_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_normalIntenisty.Checked)
            {
                _intensityConstructor = (mx, dx) => IntensityFactory.CreateNormalIntensity(mx, dx);

                UpdateControls(typeof(NormalIntensity)); 
            }
        }

        private void radioButton_exponentialIntensity_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_exponentialIntensity.Checked)
            {
                _intensityConstructor = (x, _) => IntensityFactory.CreateExponentialIntensity(x);

                UpdateControls(typeof(ExponentialIntensity)); 
            }
        }

        private void radioButton_determineIntensity_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_determineIntensity.Checked)
            {
                _intensityConstructor = (x, _) => IntensityFactory.CreateDetermineIntensity(x);

                UpdateControls(typeof(DetermineIntensity)); 
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            _form.Show();
            _countForms--;
            Container<Form>.Instance.Unregister(this);
            Dispose();
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if(UpdateConfiguration())
            {
                if (_countForms == 1)
                {
                    // Откроется это же окошко для настройки распределения скоростей машинок

                    var form = new IntensitySettingsForm(this, _settings)
                    {
                        Name = "Настройка закона распределения"
                        
                    };
                    form.textBox_intesityFirstParam.Text = "50";
                    form.textBox_intesitySecondParam.Text = "80";
                    form.label_intensityType.Text = "Выберите тип распределения скорости машин: ";
                    _countForms++;
                    form.Show();
                    this.Hide();
                }
                else
                {
                    var form = _settings.TypeRoad == TypeRoad.Tunnel
                             ? new SemaphoreSettingsForm(this, _settings) 
                             : (Form)new RoadWindow(this, _settings);

                    form.Show();
                    this.Hide();
                }
            }
        }

        private void UpdateControls(Type intesity)
        {        
            var attributes = intesity.GetProperties()
                                     .Select(prop => (IntensityAttribute)prop.GetCustomAttribute(typeof(IntensityAttribute)))
                                     .Where(attribute => attribute != null);

            var descriptions =  attributes.Where(x => x != null)
                                          .Select(x => x.Description)
                                          .ToList();

            if (descriptions.Count > 1)
            {
                label_intesity2.Text = descriptions[1];
                label_intesity2.Visible = true;
                textBox_intesitySecondParam.Visible = true;
            }
            else
            {
                label_intesity2.Visible = false;
                textBox_intesitySecondParam.Visible = false;
            }

            label_intesity1.Text = descriptions[0];
        }

        private bool UpdateConfiguration()
        {
            UpdateIntensity();

            if (_countForms == 1)
            {
                _settings.FlowIntensity = _intensity;
            }
            else
            {
                _settings.CarSpeedIntensity = _intensity;
            }

            return ValidateModel(_intensity);
        }

        private void UpdateIntensity()
        {
            var rbName = Controls.OfType<RadioButton>()
                                 .First(x => x.Checked)
                                 .Name + "_CheckedChanged";

            var method = this.GetType()
                             .GetMethod(rbName, BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(this, new object[2] { null, null });

            _intensity = _intensityConstructor(ParamParse(textBox_intesityFirstParam),
                                               ParamParse(textBox_intesitySecondParam));
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

        private double ParamParse(TextBox textBox)
        {
            var text = textBox.Text.Replace('.', ',');

            var result = double.TryParse(text, out double param);

            if (!result)
            {
                MessageBox.Show("Неверно введены данные",
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

            }

            return param;
        }

        private void IntensityConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CloseAll();
        }
    }
}
