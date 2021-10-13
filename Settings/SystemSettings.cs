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
        public TypeRoad TypeRoad { get; }

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

        /// <summary>
        /// Левый светофор
        /// </summary>
        public Lazy<Semaphore> LeftSemaphore { get; set; }

        /// <summary>
        /// Правый светофор
        /// </summary>
        public Lazy<Semaphore> RightSemaphore { get; set; }

        public Lazy<(Semaphore Left, Semaphore Right)> Semaphores { get; set; }


        private SystemSettings(TypeRoad nameRoad, 
                               SpeedLimits speedLimits)
        {
            TypeRoad = nameRoad;
            SpeedLimit = speedLimits;

            LeftSemaphore = new Lazy<Semaphore>(() => new Semaphore());
            RightSemaphore = new Lazy<Semaphore>(() => new Semaphore());

            Semaphores = new Lazy<(Semaphore Left, Semaphore Right)>(() => (new Semaphore(),
                                                                           new Semaphore()));
        }

        private SystemSettings(TypeRoad nameRoad,
                               SpeedLimits speedLimits,
                               Traffic traffic) : this(nameRoad, speedLimits)
        {
            Traffic = traffic;
        }


        public static class Factory
        {
            public static SystemSettings CreateHighway()
            {
                return new SystemSettings(TypeRoad.Higway,
                                          new SpeedLimits(minSpeed: 40, maxSpeed: 110));
            }

            public static SystemSettings CreateRoad()
            {
                return new SystemSettings(TypeRoad.Road,
                                          new SpeedLimits(minSpeed: 0, maxSpeed: 60));
            }

            public static SystemSettings CreateTunnel()
            {
                return new SystemSettings(TypeRoad.Tunnel,
                                          new SpeedLimits(minSpeed: 0, maxSpeed: 60),
                                          new Traffic(countLineOn: 1,
                                                      countLineAgainst: 1));
            }
        }
    }
}
