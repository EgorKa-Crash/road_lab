using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1.Configuration
{
    /// <summary>
    /// Скоростной режим
    /// </summary>
    public class SpeedLimits
    {
        /// <summary>
        /// Минимальная разрешенная скорость
        /// </summary>
        public int MinSpeed { get; set; }

        /// <summary>
        /// Максимальная разрешенная скорость
        /// </summary>
        public int MaxSpeed { get; set; }

        public SpeedLimits(int minSpeed, int maxSpeed)
        {
            MinSpeed = minSpeed;
            MaxSpeed = maxSpeed;
        }
    }
}
