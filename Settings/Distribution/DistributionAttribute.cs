using System;

namespace Road_Lap1.Settings.Distribution
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
