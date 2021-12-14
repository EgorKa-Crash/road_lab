using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Road_Lap1.Extensions;
using Road_Lap1.Settings.Distribution;

namespace Road_Lap1.Settings
{
    public class SystemSettingsView
    {
        public SystemSettings _settings;

        public string RoadType => _settings.RoadType.GetDescription();

        public int CountRoadsOn => _settings.Traffic.CountPasssingLine;
        public int CountRoadsAgainst => _settings.Traffic.CountOppositeLine;

        public string DirectionDescription => _settings.Traffic.Direction.GetDescription();

        public string CountRoadsOnDescription => $"Количество полос в одном направлении: {CountRoadsOn}";
        public string CountRoadsAgainstDescription => CountRoadsAgainst == 0 ? string.Empty : $"Количество полос в обратном направлении: {CountRoadsAgainst}";

        public string SemaphoreDescription
        {
            get => _settings.RoadType == Roads.RoadType.Tunnel
                 ? $"Длительность светофорной фазы: {_settings.Semaphore?.TimeMilliseconds * 1000} c"
                 : string.Empty;
        }

        public string FlowDescription => GetDistibutionDescription(_settings.FlowDistribution);
        public string SpeedDescription => GetDistibutionDescription(_settings.SpeedDistribution);

        public SystemSettingsView(SystemSettings settings) => _settings = settings;

        public string GetDistributionFirstParamDescription(IDistribution distribution, DistributionType distributionType)
        {
            var result = GetDistributionFirstParamPrefix(distribution);

            result += distributionType == DistributionType.Flow
                   ? $"{(!(distribution is ExponentialDistribution) ? distribution.FirstParam.Value / 1000 : distribution.FirstParam.Value)}" +
                     $" {(distribution is ExponentialDistribution ? "1/c" : "c")}"
                   : $"{_settings.SpeedDistribution.FirstParam} {(distribution is ExponentialDistribution ? "(1/(км/ч))" : "км/ч")}";

            return result;
        }

        public string GetDistributionSecondParamDescription(IDistribution distribution, DistributionType distributionType)
        {
            if (distribution is ExponentialDistribution || distribution is DetermineDistribution)
            {
                return string.Empty;
            }

            var result = GetDistributionSecondParamPrefix(distribution);

            result += distributionType == DistributionType.Flow
                   ? $"{(!(distribution is ExponentialDistribution) ? distribution.SecondParam.Value / 1000 : distribution.FirstParam.Value)}" +
                     $" {GetFlowMeasureUnitSecondParam(distribution)}"
                   : $"{_settings.SpeedDistribution.SecondParam} {GetSpeedMeasureUnitSecondParam(distribution)}";

            return result;
        }

        private string GetDistributionFirstParamPrefix(IDistribution distribution)
        {
            var result = "Константа: ";

            if (distribution is NormalDistribution)
            {
                result = "MX: ";
            }
            else if (distribution is UniformDistribution)
            {
                result = "a: ";
            }
            else if (distribution is ExponentialDistribution)
            {
                result = "Показатель: ";
            }

            return result;
        }

        private string GetDistributionSecondParamPrefix(IDistribution distribution)
        {
            var result = string.Empty;

            if (distribution is NormalDistribution)
            {
                result = "DX: ";
            }
            else if (distribution is UniformDistribution)
            {
                result = " b: ";
            }

            return result;
        }

        private string GetFlowMeasureUnitSecondParam(IDistribution distribution)
        {
            if (distribution is NormalDistribution)
            {
                return "c²";
            }
            else if (distribution is ExponentialDistribution
                  || distribution is DetermineDistribution)
            {
                return string.Empty;
            }

            return "c";
        }

        private string GetSpeedMeasureUnitSecondParam(IDistribution distribution)
        {
            if (distribution is NormalDistribution)
            {
                return "(км/ч)²";
            }
            else if (distribution is ExponentialDistribution
                  || distribution is DetermineDistribution)
            {
                return string.Empty;
            }

            return "км/ч";
        }

        private string GetDistibutionDescription(IDistribution distribution)
        {
            var result = string.Empty;

            if (distribution is NormalDistribution)
            {
                result = "Нормальный";
            }
            else if (distribution is UniformDistribution)
            {
                result = "Равномерный";
            }
            else if (distribution is ExponentialDistribution)
            {
                result = "Экспоненциальный";
            }
            else
            {
                result = "Детерминированный";
            }

            return result;
        }
    }
}
