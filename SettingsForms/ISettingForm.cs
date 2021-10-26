using Road_Lap1.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Road_Lap1.SettingsForms
{
    public interface ISettingForm
    {
        /// <summary>
        /// Настройки системы
        /// </summary>
        SystemSettings Settings { get; set; }

        Form PrevForm { get; set; }

        SettingsForm SettingType { get; }

        void ChangeBehavior();

        void Show();

        void Dispose();
    }
}
