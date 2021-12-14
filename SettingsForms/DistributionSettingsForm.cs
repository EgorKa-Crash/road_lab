using Road_Lap1.Extensions;
using Road_Lap1.Settings;
using Road_Lap1.Settings.Distribution;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Road_Lap1.ConfigurationForms
{
    public partial class DistributionSettingsForm : Form
    {
        #region Поля

        /// <summary>
        /// Множитель для перевода в секунды
        /// </summary>
        private const int _millisecondsFactor = 1000;

        /// <summary>
        /// Количество открытых форм)0)))0)
        /// </summary>
        private static int _countForms;

        /// <summary>
        /// Выбранный тип интенсивности
        /// </summary>
        private IDistribution _distribution;

        /// <summary>
        /// Конструктор для объектов IDistribution
        /// </summary>
        Func<double?, double?, IDistribution> _distributionConstructor;

        /// <summary>
        /// Настройки системы
        /// </summary>
        private SystemSettings _settings;

        /// <summary>
        /// Предыдущая форма
        /// </summary>
        private Form _form;

        /// <summary>
        /// Настройки отображения контролов
        /// </summary>
        private Dictionary<Type, DistributionSettingsView> _views;

        /// <summary>
        /// Текущие настройки отображения контролов
        /// </summary>
        private DistributionSettingsView _view;

        /// <summary>
        /// Транспортный поток / скоростной режим
        /// </summary>
        private DistributionType _formType;

        private int _countStringDescription;

        #endregion

        /// <summary>
        /// Является ли форма формой для настройки транспортного потока
        /// </summary>
        private bool IsFlowForm => _countForms == 0;

        public DistributionSettingsForm(Form form, SystemSettings settings, DistributionType distributionType)
        {
            InitializeComponent();

            _form = form;
            _formType = distributionType;
            _settings = settings;
            CreateViews();
            UpdateControls<DetermineDistribution>();
            Container<Form>.Instance.Register(this);

            radioButton_determineDistribution_CheckedChanged(null, null);
        }

        #region RadioButton Handlers

        private void radioButton_uniformDistribution_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton_uniformDistribution.Checked)
            {
                _distributionConstructor = (a, b) => DistributionFactory.Create<UniformDistribution>(a, b);
                _view = _views[typeof(UniformDistribution)];
                UpdateControls<UniformDistribution>();
                trackBar_firstParam_Scroll(null, null);
            }
        }

        private void radioButton_normalDistribution_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_normalDistribution.Checked)
            {
                _distributionConstructor = (mx, dx) => DistributionFactory.Create<NormalDistribution>(mx, dx);
                _view = _views[typeof(NormalDistribution)];
                UpdateControls<NormalDistribution>(); 
            }
        }

        private void radioButton_exponentialDistribution_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_exponentialDistribution.Checked)
            {
                _distributionConstructor = (x, _) => DistributionFactory.Create<ExponentialDistribution>(x);
                _view = _views[typeof(ExponentialDistribution)];
                UpdateControls<ExponentialDistribution>();
            }
        }

        private void radioButton_determineDistribution_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_determineDistribution.Checked)
            {
                _distributionConstructor = (x, _) => DistributionFactory.Create<DetermineDistribution>(x);
                _view = _views[typeof(DetermineDistribution)];
                UpdateControls<DetermineDistribution>(); 
            }
        }

        #endregion

        private void button_back_Click(object sender, EventArgs e)
        {
            _form.Show();

            _countForms = !IsFlowForm
                        ? _countForms - 1
                        : 0;

            Container<Form>.Instance.Unregister(this);
            Dispose();
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if(!UpdateDistribution())
            {
                return;
            }

            if (IsFlowForm)
            {
                _countForms++;
                var form = new DistributionSettingsForm(this, _settings, DistributionType.Speed)
                {
                    Text = "Настройка скоростного режима"
                };
                form.label_intensityType.Text = "Выберите тип распределения скорости машин: ";

                form.Show();
                this.Hide();
            }
            else
            {
                new RoadWindow(this, _settings).Show();

                this.Hide();
            }
        }

        #region View

        private void CreateViews()
        {
            _views = new Dictionary<Type, DistributionSettingsView>
            {
                [typeof(NormalDistribution)] = DistributionSettingsView.Factory.Create<NormalDistribution>(_formType, _settings),
                [typeof(UniformDistribution)] = DistributionSettingsView.Factory.Create<UniformDistribution>(_formType, _settings),
                [typeof(ExponentialDistribution)] = DistributionSettingsView.Factory.Create<ExponentialDistribution>(_formType, _settings),
                [typeof(DetermineDistribution)] = DistributionSettingsView.Factory.Create<DetermineDistribution>(_formType, _settings)
            };

            _view = _views[typeof(DetermineDistribution)];
        }

        private void UpdateControls<T>() where T : IDistribution
        {
            var descriptions = typeof(T).GetProperties()
                                        .Select(prop => (DistributionAttribute)prop.GetCustomAttribute<DistributionAttribute>())
                                        .Where(attribute => attribute != null)
                                        .Select(x => x.Description)
                                        .ToArray();
            UpdateTrackBars(_view);
            UpdateLimitLabels(_view);

            if (descriptions.Length > 1)
            {
                lbl_intesitySecondParamDescription.Text = descriptions[1];
                panel_secondParam.Visible = true;
                lbl_intesityFirstParamDescription.Text = descriptions[0];
                UpdateValueLabel(lbl_secondParamValue,
                                 trackBar_secondParam,
                                 lbl_intesitySecondParamDescription,
                                 _view.MeasurementUnitSecondParam);
            }
            else if (descriptions.Length > 0)
            {
                panel_secondParam.Visible = false;
                lbl_intesityFirstParamDescription.Text = descriptions[0];
            }

            UpdateValueLabel(lbl_firstParamValue,
                             trackBar_firstParam,
                             lbl_intesityFirstParamDescription,
                             _view.MeasurementUnitFirstParam);
        }

        private void UpdateTrackBars(DistributionSettingsView view)
        {
            trackBar_firstParam.Minimum = (int)(_view.FirstParamLimit.Min * _view.FirstParamScale);
            trackBar_firstParam.Maximum = (int)(_view.FirstParamLimit.Max * _view.FirstParamScale);
            trackBar_firstParam.Value = (int)(_view.FirstParamLimit.Min * _view.FirstParamScale);

            if (_view.SecondParamLimit == null)
            {
                return;
            }

            trackBar_secondParam.Minimum = (int)(_view.SecondParamLimit.Min * _view.SecondParamScale);
            trackBar_secondParam.Maximum = (int)(_view.SecondParamLimit.Max * _view.SecondParamScale);
            trackBar_secondParam.Value = (int)(_view.SecondParamLimit.Min * _view.SecondParamScale);
        }

        private void UpdateLimitLabels(DistributionSettingsView view)
        {
            lbl_firstParamMin.Text = _view.FirstParamView.Min;
            lbl_firstParamMax.Text = _view.FirstParamView.Max;
            lbl_firstParamValue.Text = _view.FirstParamView.Min;

            if (_view.SecondParamLimit == null)
            {
                return;
            }

            lbl_secondParamMin.Text = _view.SecondParamView.Min;
            lbl_secondParamMax.Text = _view.SecondParamView.Max;
            lbl_secondParamValue.Text = _view.SecondParamView.Min;
        }

        private void UpdateValueLabel(Label value, TrackBar tbValue, Label description, string measurement)
        {
            value.Text = $"{1.0 * tbValue.Value / _view.FirstParamScale} {measurement}";
            value.Location = new System.Drawing.Point(description.Location.X + description.Size.Width,
                                                      description.Location.Y);
        }

        #endregion

        private bool UpdateDistribution()
        {
            _distribution = _distributionConstructor(1.0 * trackBar_firstParam.Value / _view.FirstParamScale,
                                                     1.0 * trackBar_secondParam.Value / _view.SecondParamScale);

            if (IsFlowForm)
            {
                if (_distribution.GetType() != typeof(ExponentialDistribution))
                {
                    _distribution.FirstParam *= _millisecondsFactor; //лень переделывать, пусть так
                    _distribution.SecondParam *= _millisecondsFactor;
                }
                _settings.FlowDistribution = _distribution;
            }
            else
            {
                _settings.SpeedDistribution = _distribution;
            }

            if (_distribution is ExponentialDistribution exp)
            {
                exp.AxisX = _view.ExponentialDistributionAxisX;
            }

            return ValidateModel(_distribution);
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

        private void trackBar_firstParam_Scroll(object sender, EventArgs e)
        {
            var value = 1.0 * trackBar_firstParam.Value / _view.FirstParamScale;

            lbl_firstParamValue.Text = $"{value} {_view.MeasurementUnitFirstParam}";

            ScrollUniformIntensity(trackBar_firstParam, 
                                   trackBar_secondParam, 
                                   lbl_secondParamValue, 
                                   _view.MeasurementUnitFirstParam);

            ScrollNormalntensity(_view.FirstParamLimit, sender);
        }

        private void trackBar_secondParam_Scroll(object sender, EventArgs e)
        {
            var value = IsFlowForm
                      ? 1.0 * trackBar_secondParam.Value / _view.SecondParamScale
                      : trackBar_secondParam.Value;

            lbl_secondParamValue.Text = $"{value} {_view.MeasurementUnitSecondParam}";

            ScrollUniformIntensity(trackBar_secondParam,
                                   trackBar_firstParam,
                                   lbl_firstParamValue,
                                   _view.MeasurementUnitSecondParam);

            ScrollNormalntensity(_view.FirstParamLimit, sender);
        }

        private void ScrollUniformIntensity(TrackBar master, TrackBar slave, Label slaveValue, string measurement)
        {
            if(radioButton_uniformDistribution.Checked && trackBar_firstParam.Value > trackBar_secondParam.Value)
            {
                slave.Value = master.Value;

                var value = IsFlowForm
                          ? 1.0 * slave.Value / 10
                          : slave.Value;

               slaveValue.Text = $"{value} {measurement}";
            }
        }

        private void ScrollNormalntensity(Limit<double> limit, object sender)
        {
            if (!radioButton_normalDistribution.Checked)
            {
                return;
            }

            double min(double mx, double dx) => (mx / _view.FirstParamScale) - (3 * Math.Sqrt(dx / _view.SecondParamScale));
            double max(double mx, double dx) => (mx / _view.FirstParamScale) + (3 * Math.Sqrt(dx / _view.SecondParamScale));

            var minDX = 0;

            if (min(trackBar_firstParam.Value, trackBar_secondParam.Value) < limit.Min)
            {
                if(sender == trackBar_secondParam && trackBar_firstParam.Value < trackBar_firstParam.Maximum)
                {
                    trackBar_firstParam.Value++;
                }

                minDX = FindMinDX(min, dx => dx <= limit.Min, trackBar_secondParam.Value);

                trackBar_secondParam.Value = minDX <= trackBar_secondParam.Minimum
                                           ? trackBar_secondParam.Minimum
                                           : minDX;

                UpdateLabelValue(trackBar_secondParam, lbl_secondParamValue, _view.MeasurementUnitSecondParam, _view.SecondParamScale);
            }
            else if (max(trackBar_firstParam.Value, trackBar_secondParam.Value) > limit.Max)
            {
                if (sender == trackBar_secondParam && trackBar_firstParam.Value > trackBar_firstParam.Minimum)
                {
                    trackBar_firstParam.Value--;
                }

                minDX = FindMinDX(max, dx => dx >= limit.Max, trackBar_secondParam.Value);

                trackBar_secondParam.Value = minDX <= trackBar_secondParam.Minimum
                                           ? trackBar_secondParam.Minimum
                                           : minDX;

                UpdateLabelValue(trackBar_secondParam, lbl_secondParamValue, _view.MeasurementUnitSecondParam, _view.SecondParamScale);
            }

            UpdateLabelValue(trackBar_firstParam, lbl_firstParamValue, _view.MeasurementUnitFirstParam, _view.FirstParamScale);
        }

        private void UpdateLabelValue(TrackBar trackBar, Label label, string measurement, int divider)
        {
            var value = IsFlowForm
                      ? 1.0 * trackBar.Value / divider
                      : trackBar.Value;

            label.Text = $"{value} {measurement}";
        }

        private int FindMinDX(Func<double, double, double> getThreeSigmaRuleValue, Func<double, bool> condition, int trackBarValue)
        {
            while (condition(getThreeSigmaRuleValue(trackBar_firstParam.Value, trackBarValue)))
            {
                trackBarValue--;
            }

            return trackBarValue;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(_view.GuidePath))
            {
                Process.Start(_view.GuidePath);
            }
            else
            {
                MessageBox.Show("Не удалось открыть файл справки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => this.CloseAll();

        private void aboutSystemToolStripMenuItem_Click(object sender, EventArgs e) => this.ShowSystemInfo();

        private void DistributionSettingsForm_FormClosing(object sender, FormClosingEventArgs e) => this.CloseAll();
    }
}
