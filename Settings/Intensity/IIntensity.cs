using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Road_Lap1.Configuration.Intensity
{
    public interface IIntensity : IValidatableObject
    {
        Random Random { get; }

        double? FirstParam { get; set; }
        double? SecondParam { get; set; }

        double NextValue();

        bool CheckParam(double param);
    }
}
