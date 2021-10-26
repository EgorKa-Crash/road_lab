using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1.Configuration.Intensity
{
    public class ExponentialIntensity : IIntensity
    {
        [Intensity("Введите показатель:")] public double? FirstParam { get; set; }
        public double? SecondParam { get; set; }
        public Random Random { get; }

        public ExponentialIntensity(double? firstParam)
        {
            FirstParam = firstParam;
            Random = new Random();
        }

        public  bool CheckParam(double param)
        {
            return (param > 0
                 && !double.IsNaN(param)
                 && !double.IsInfinity(param));
        }

        public double NextValue() => -1 / FirstParam.Value * Math.Log(Random.NextDouble());

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
