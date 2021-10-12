using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1.Configuration.Intensity
{
    public class UniformIntensity : IIntensity
    {
        [Intensity("Введите a:")] public double? FirstParam { get; set; }
        [Intensity("Введите b:")] public double? SecondParam { get; set; }
        
        public UniformIntensity(double? firstParam, double? secondParam)
        {
            FirstParam = firstParam;
            SecondParam = secondParam;   
        }

        public bool CheckParam(double param)
        {
            return (param > 0
                 && !double.IsNaN(param)
                 && !double.IsInfinity(param));
        }

        public bool CheckParams(double param1, double param2)
        {
            return !(param1 < param2);
        }

        public IEnumerable<double> NextSample()
        {
            var rnd = new Random();

            while (true)
            {
                yield return (rnd.NextDouble() * (SecondParam.Value - FirstParam.Value)) + FirstParam.Value;
            }
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

            if (CheckParams(FirstParam.Value, SecondParam.Value))
            {
                errors.Add(new ValidationResult("Правая граница интервала не может быть меньше или равна левой!"));
            }

            return errors;
        }
    }
}
