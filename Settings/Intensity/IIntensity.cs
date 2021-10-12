using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Road_Lap1.Configuration.Intensity
{
    public interface IIntensity : IValidatableObject
    {
        double? FirstParam { get; set; }
        double? SecondParam { get; set; }

        IEnumerable<double> NextSample();

        bool CheckParam(double param);
    }
}
