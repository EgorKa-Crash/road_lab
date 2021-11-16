using Road_Lap1.Configuration.Intensity;
using Road_Lap1.Configuration.Roads;
using System;

namespace Road_Lap1.Configuration
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
        public SpeedLimits SpeedLimit { get; }

        /// <summary>
        /// Данные о топологии дороги
        /// </summary>
        public Traffic Traffic { get; set; }

        /// <summary>
        /// Закон распределения формирования автопотока
        /// </summary>
        public IIntensity FlowIntensity { get; set; }

        /// <summary>
        /// Закон распределения скоростей автопотока
        /// </summary>
        public IIntensity CarSpeedIntensity { get; set; }

        private Lazy<Semaphore> _semaphoresLazy;

        /// <summary>
        /// Настройки светофора
        /// </summary>
        public Semaphore Semaphore => _semaphoresLazy.Value;
        
        private SystemSettings(RoadType nameRoad, SpeedLimits speedLimits)
        {
            RoadType = nameRoad;
            SpeedLimit = speedLimits;

            _semaphoresLazy = new Lazy<Semaphore>(() => ( new Semaphore()));
        }

        private SystemSettings(RoadType nameRoad,
                               SpeedLimits speedLimits,
                               Traffic traffic) : this(nameRoad, speedLimits)
        {
            Traffic = traffic;
        }


        public static class Factory
        {
            public static SystemSettings CreateHighway()
            {
                return new SystemSettings(RoadType.Higway, new SpeedLimits(minSpeed: 40, maxSpeed: 110));
            }

            public static SystemSettings CreateRoad()
            {
                return new SystemSettings(RoadType.Road, new SpeedLimits(minSpeed: 20, maxSpeed: 60));
            }

            public static SystemSettings CreateTunnel()
            {
                return new SystemSettings(RoadType.Tunnel,
                                          new SpeedLimits(minSpeed: 20, maxSpeed: 60),
                                          new Traffic(countLineOn: 1,
                                                      countLineAgainst: 1)
                                          );
            }
        }
    }
}
