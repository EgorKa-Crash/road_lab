﻿using Road_Lap1.Extensions;
using Road_Lap1.Settings;
using Road_Lap1.Settings.Distribution;
using Road_Lap1.Settings.Roads;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
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

        private void button_next_Click(object sender, EventArgs e)
        {
            if(!UpdateRoad())
            {
                return;
            }

            this.Hide();

            new DistributionSettingsForm(this, _settings, DistributionType.Flow).Show();
        }

        private bool UpdateRoad()
        {
            var countLineOn = trackBar_oneDirection.Value;
            var countLineAgainst = trackBar_twoDirection.Value;

            _settings.Traffic = radioButton_oneDirection.Checked
                              ? new Traffic(countLineOn)
                              : (Traffic)new Traffic(countLineOn, countLineAgainst);

            return ValidateModel(_settings.Traffic);
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
            _prevForm.Show();
            Container<Form>.Instance.Unregister(this);
            Dispose();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if DEBUG
            var path = @"..\..\Resources\UserGuides\countOfRoadsInfo.html";
#else
            var path = @"Resources\UserGuides\countOfRoadsInfo.html";
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => this.CloseAll();

        private void aboutSystemToolStripMenuItem_Click(object sender, EventArgs e) => this.ShowSystemInfo();

        private void RoadConfigurationForm_FormClosing(object sender, FormClosingEventArgs e) => this.CloseAll();

        private void radioButton_twoDirection_CheckedChanged(object sender, EventArgs e) => panel_countLine.Visible = radioButton_twoDirection.Checked;
    }
}
