using Road_Lap1.Settings.Distribution;
using Road_Lap1.Settings.Roads;
using System;
using System.Collections.Generic;

namespace Road_Lap1.Settings
{
    /// <summary>
    /// Данные о конфигурации системы
    /// </summary>
    public class SystemSettings
    {
        /// <summary>
        /// Тип трассы
        /// </summary>
        public RoadType RoadType { get; }

        /// <summary>
        /// Ограничение по скорости
        /// </summary>
        public Limit<int> Speed { get; }

        /// <summary>
        /// Данные о топологии дороги
        /// </summary>
        public Traffic Traffic { get; set; }

        /// <summary>
        /// Закон распределения формирования автопотока
        /// </summary>
        public IDistribution FlowDistribution { get; set; }

        /// <summary>
        /// Закон распределения скоростей автопотока
        /// </summary>
        public IDistribution SpeedDistribution { get; set; }

        /// <summary>
        /// Настройки светофора
        /// </summary>
        public Semaphore Semaphore { get; set; }

        private SystemSettings(RoadType roadType, Limit<int> speedLimits)
        {
            RoadType = roadType;
            Speed = speedLimits;
        }

        private SystemSettings(RoadType roadType,
                               Limit<int> speedLimits,
                               Traffic traffic) : this(roadType, speedLimits) => Traffic = traffic;


        public static class Factory
        {
            public static SystemSettings CreateHighway() => new SystemSettings(RoadType.Highway, new Limit<int>(min: 40, max: 110));

            public static SystemSettings CreateRoad() => new SystemSettings(RoadType.Road, new Limit<int>(min: 20, max: 60));

            public static SystemSettings CreateTunnel() => new SystemSettings(RoadType.Tunnel, 
                                                                              new Limit<int>(min: 20, max: 60), 
                                                                              new Traffic(countLineOn: 1, countLineAgainst: 1)
                                                                             );
        }
    }
}
