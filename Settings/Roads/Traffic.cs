using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Road_Lap1.Configuration.Roads
{
    public class Traffic : IValidatableObject
    {
        private IDictionary<Direction, int?> _lines { get; set; }

        public const int MaxLines = 4;

        /// <summary>
        /// Направление движения
        /// </summary>
        public Direction Direction { get; }

        public Traffic(int? countLineOn)
        {
            _lines = new Dictionary<Direction, int?>
            {
                { Direction.OneWay, countLineOn },
                { Direction.TwoWay, null }
            };

            Direction = Direction.OneWay;
        }

        public Traffic(int? countLineOn, int? countLineAgainst)
        {
            _lines = new Dictionary<Direction, int?>
            {
                { Direction.OneWay, countLineOn },
                { Direction.TwoWay, countLineAgainst }
            };

            Direction = Direction.TwoWay;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var isExist1 = _lines.TryGetValue(Direction.OneWay, out var countOn);
            var isExist2 =_lines.TryGetValue(Direction.TwoWay, out var countAgainst);

            if (countOn > MaxLines || countAgainst > MaxLines)
            {
                errors.Add(new ValidationResult("Количество полос в любом направлении не может быть больше 4!"));
            }

            if ((countOn.HasValue && countOn.Value <= 0) || (countAgainst.HasValue && countAgainst.Value <= 0))
            {
                errors.Add(new ValidationResult("Количество полос в обоих направлениях должно быть больше нуля!"));
            }

            return errors;
        }

        public int GetCountLine(Direction direction)
        {
            _lines.TryGetValue(direction, out var lines);

            return lines ?? 0;
        }
    }
}
