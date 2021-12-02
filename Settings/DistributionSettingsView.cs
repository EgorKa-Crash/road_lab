using Road_Lap1.Settings;
using Road_Lap1.Settings.Roads;
using Road_Lap1.Settings.Distribution;
using System;

namespace Road_Lap1.Settings
{
    public enum DistributionFormType
    {
        Flow,
        Speed
    }

    public class DistributionSettingsView
    {
        public Limit<double> FirstParamLimit { get; set; }
        public Limit<double> SecondParamLimit { get; set; }

        public (string Min, string Max) FirstParamView => (FirstParamLimit?.Min.ToString(), FirstParamLimit?.Max.ToString());
        public (string Min, string Max) SecondParamView => (SecondParamLimit?.Min.ToString(), SecondParamLimit?.Max.ToString());

        public string MeasurementUnitFirstParam { get; private set; }
        public string MeasurementUnitSecondParam { get; private set; }

        public int FirstParamScale { get; private set; } 
        public int SecondParamScale { get; private set; }

        public Limit<double> ExponentialDistributionAxisX { get; set; }

        private DistributionSettingsView(DistributionFormType distributionTypeEnum, Type distributionType, SystemSettings systemSettings)
        {
            switch (distributionTypeEnum)
            {
                case DistributionFormType.Flow:
                {
                    FillFlowView(distributionTypeEnum, distributionType, systemSettings);
                    break;
                }
                case DistributionFormType.Speed:
                {
                    FillSpeedView(distributionType, systemSettings);
                    break;
                }
            }
        }

        private void FillSpeedView(Type distributionType, SystemSettings systemSettings)
        {
            FirstParamLimit = new Limit<double>(systemSettings.Speed.Min, systemSettings.Speed.Max);
            FirstParamScale = 1;
            SecondParamScale = 1;
            MeasurementUnitFirstParam = "км/ч";
            if (distributionType == typeof(NormalDistribution))
            {
                SecondParamLimit = systemSettings.RoadType == RoadType.Higway
                                 ? new Limit<double>(0, 136)
                                 : new Limit<double>(0, 44);

                MeasurementUnitSecondParam = "(км/ч)²";
            }
            else if (distributionType == typeof(UniformDistribution))
            {
                SecondParamLimit = new Limit<double>(systemSettings.Speed.Min, systemSettings.Speed.Max);
                MeasurementUnitSecondParam = "км/ч";
            }
            else if (distributionType == typeof(ExponentialDistribution))
            {
                FirstParamScale = 10;
                FirstParamLimit = new Limit<double>(0.5, 1);
                MeasurementUnitFirstParam = "(1/(км/ч))";
                ExponentialDistributionAxisX = new Limit<double>(systemSettings.Speed.Min, systemSettings.Speed.Max);
            }
        }

        private void FillFlowView(DistributionFormType distributionTypeEnum, Type distributionType, SystemSettings systemSettings)
        {
            FirstParamScale = 10;
            SecondParamScale = 10;
            MeasurementUnitFirstParam = "с";
            if (distributionType == typeof(NormalDistribution))
            {
                FirstParamLimit = new Limit<double>(0.2, 1);
                SecondParamLimit = new Limit<double>(0, 0.0177);
                SecondParamScale = 10000;
                MeasurementUnitSecondParam = "c²";
            }
            else if (distributionType == typeof(UniformDistribution))
            {
                FirstParamLimit = new Limit<double>(0.2, 1);
                SecondParamLimit = new Limit<double>(0.2, 1);
                MeasurementUnitSecondParam = "c";
            }
            else if (distributionType == typeof(ExponentialDistribution))
            {
                FirstParamLimit = new Limit<double>(0.7, 2);
                ExponentialDistributionAxisX = new Limit<double>(200, 1000);
                FirstParamScale = 10;
                SecondParamScale = 1;
                MeasurementUnitFirstParam = "(1/с)";
            }
            else
            {
                FirstParamLimit = new Limit<double>(0.2, 1);
            }
        }

        public static class Factory
        {
            public static DistributionSettingsView Create<T>(DistributionFormType disctributionType, 
                                                             SystemSettings systemSettings) where T : IDistribution
                                                             => new DistributionSettingsView(disctributionType, 
                                                                                             typeof(T),
                                                                                             systemSettings);
        }
    }
}
