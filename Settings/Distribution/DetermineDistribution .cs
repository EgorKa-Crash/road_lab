using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Road_Lap1.Settings.Distribution
{
    public class DetermineDistribution  : IDistribution
    {
        [DistributionAttribute("Введите константу:")] public double? FirstParam { get; set; }

        public double? SecondParam { get; set; }

        public Random Random { get; }

        public DetermineDistribution (double? firstParam)
        {
            FirstParam = firstParam;
        }

        public double NextValue() => FirstParam.Value;

        public bool CheckParam(double param)
        {
            return (param > 0
                 && !double.IsNaN(param)
                 && !double.IsInfinity(param));
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (!CheckParam(FirstParam.Value))
            {
                errors.Add(new ValidationResult("Константа должна быть больше нуля!"));
            }

            return errors;
        }
    }
}
