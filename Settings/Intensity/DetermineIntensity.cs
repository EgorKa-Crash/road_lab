using Road_Lap1.Configuration.Intensity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Road_Lap1.Configuration.Intesity
{
    public class DetermineIntensity : IIntensity
    {
        [Intensity("Введите константу:")] public double? FirstParam { get; set; }

        public double? SecondParam { get; set; }

        public DetermineIntensity(double? firstParam)
        {
            FirstParam = firstParam; 
        }

        public bool CheckParam(double param)
        {
            return (param > 0
                 && !double.IsNaN(param)
                 && !double.IsInfinity(param));
        }

        public IEnumerable<double> NextSample()
        {
            while(true)
            {
                yield return FirstParam.Value;
            }
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
