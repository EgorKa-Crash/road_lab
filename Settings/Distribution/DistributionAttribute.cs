using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1.Configuration.Distribution
{
    public class DistributionAttribute : Attribute
    {
        /// <summary>
        /// Описание члена класса
        /// </summary>
        public string Description { get; set; }

        public DistributionAttribute(string description)
        {
            Description = description;
        }
    }
}
