using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1.Configuration.Intensity
{
    public class IntensityAttribute : Attribute
    {
        /// <summary>
        /// Описание члена класса
        /// </summary>
        public string Description { get; set; }

        public IntensityAttribute(string description)
        {
            Description = description;
        }
    }
}
