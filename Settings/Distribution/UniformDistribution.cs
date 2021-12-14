using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Road_Lap1.Settings.Distribution
{
    public class UniformDistribution : IDistribution
    {
        [DistributionAttribute("Введите a:")] public double? FirstParam { get; set; }
        [DistributionAttribute("Введите b:")] public double? SecondParam { get; set; }

        public Random Random { get; }

        public string FirstParamDescription { get; set; }
        public string SecondParamDescription { get; set; }

        public UniformDistribution(double? firstParam, double? secondParam)
        {
            FirstParam = firstParam;
            SecondParam = secondParam;
            Random = new Random();
        }

        public double NextValue() => (Random.NextDouble() * (SecondParam.Value - FirstParam.Value)) + FirstParam.Value;

        public bool CheckParams(double param1, double param2) => param1 <= param2;

        public bool CheckParam(double param)
        {
            return (param > 0 &&
                    !double.IsNaN(param) &&
                    !double.IsInfinity(param));
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (!CheckParam(FirstParam.Value))
            {
                errors.Add(new ValidationResult("Левая граница интервала должна быть больше нуля!"));
            }

            if (!CheckParam(SecondParam.Value))
            {
                errors.Add(new ValidationResult("Правая граница интервала должна быть больше нуля!"));
            }

            if (!CheckParams(FirstParam.Value, SecondParam.Value))
            {
                errors.Add(new ValidationResult("Правая граница интервала должна быть больше левой!"));
            }

            return errors;
        }
    }
}
