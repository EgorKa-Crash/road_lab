using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1.Settings.Roads
{
    public enum Direction
    {
        /// <summary>
        /// Одностороннее движение
        /// </summary>
        [Description("Однонаправленное")]OneWay,
        /// <summary>
        /// Двустороннее движение
        /// </summary>
        [Description("Двунаправленное")] TwoWay
    }
}
