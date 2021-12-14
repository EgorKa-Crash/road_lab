using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Road_Lap1.Settings.Distribution
{
    public class ExponentialDistribution : IDistribution
    {
        [DistributionAttribute("Введите показатель:")] public double? FirstParam { get; set; }
        public double? SecondParam { get; set; }

        public Limit<double> AxisX { get; set; }

        public Random Random { get; }

        public string FirstParamDescription { get; set; }
        public string SecondParamDescription { get; set; }

        public ExponentialDistribution(double? firstParam)
        {
            FirstParam = firstParam;
            SecondParam = 10;
            AxisX = new Limit<double>(0, 1);
            Random = new Random();
        }

        public double NextValue() =>(-1 / FirstParam.Value * Math.Log(1 - Random.NextDouble()) / 10  * (AxisX.Max - AxisX.Min)) + AxisX.Min;

        public  bool CheckParam(double param)
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
                errors.Add(new ValidationResult("Параметр показательного распределения должен быть больше нуля!"));
            }

            return errors;
        }
    }
}
