using System;
using System.ComponentModel.DataAnnotations;

namespace Road_Lap1.Settings.Distribution
{
    public interface IDistribution : IValidatableObject
    {
        Random Random { get; }

        double? FirstParam { get; set; }
        double? SecondParam { get; set; }

        string FirstParamDescription { get; set; }
        string SecondParamDescription { get; set; }

        double NextValue();

        bool CheckParam(double param);
    }
}
