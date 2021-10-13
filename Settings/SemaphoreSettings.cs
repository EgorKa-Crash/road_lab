using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Road_Lap1.Configuration
{
    public class Semaphore : IValidatableObject
    {
        public const int MinTimeMilliseconds = 2000;
        public const int MaxTimeMilliseconds = 10000;

        public int TimeMilliseconds { get; set; }

        public Semaphore()
        {
            TimeMilliseconds = MinTimeMilliseconds;
        }

        public Semaphore(int timeMilliseconds)
        {
            TimeMilliseconds = timeMilliseconds;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (TimeMilliseconds < MinTimeMilliseconds)
            {
                errors.Add(new ValidationResult($"Длительность светофорной фазы должна превышать {MinTimeMilliseconds / 1000}"));
            }

            if (TimeMilliseconds > MaxTimeMilliseconds)
            {
                errors.Add(new ValidationResult($"Длительность светофорной фазы не должна превышать {MaxTimeMilliseconds / 1000}"));
            }

            return errors;
        }

        
    }
}
