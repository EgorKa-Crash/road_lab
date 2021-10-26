using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road_Lap1.Configuration.Intensity
{
    public class NormalIntensity : IIntensity
    {
        [Intensity("Введите MX:")] public double? FirstParam { get; set; }
        [Intensity("Введите DX:")] public double? SecondParam { get; set; }
        public Random Random { get; }

        public NormalIntensity(double? firstParam, double? secondParam)
        {
            FirstParam = firstParam;
            SecondParam = secondParam;
            Random = new NormalRandom();
        }

        #region Check-methods

        public bool CheckParamDX(double param) => param >= 0 && CheckParam(param);

        public bool CheckParamMX(double param) => CheckParam(param);

        public bool CheckParam(double param)
        {
            return (param >= 0
                 && !double.IsNaN(param)
                 && !double.IsInfinity(param));
        }

        /// <summary>
        /// Проверка, что МХ и DX имеют такие значение, что СВ не принимает(с вероятностью 0.997) значения меньше нуля
        /// </summary>
        public bool CheckThreeSigmaRule() => FirstParam.Value - (3 * Math.Sqrt(SecondParam.Value)) > 0;

        #endregion

        public double NextValue() => (Random.NextDouble() * Math.Sqrt(SecondParam.Value)) + FirstParam.Value;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (!CheckParamMX(FirstParam.Value))
            {
                errors.Add(new ValidationResult("Неверно заданное мат.ожидание!"));
            }

            if (!CheckParamDX(SecondParam.Value))
            {
                errors.Add(new ValidationResult("Дисперсия нормального распределения должна быть неотрицательной!"));
            }

            if(!CheckThreeSigmaRule())
            {
                errors.Add(new ValidationResult("Из правила 3 сигм вытекает, что СВ будет принимать значения меньше нуля!"));
            }

            return errors;
        }

        #region NormalRandom / Метод Марсальи

        private class NormalRandom : Random
        {
            // сохранённое предыдущее значение
            double prevSample = double.NaN;

            /// <summary>
            /// Переопределение метода Sample для задания СВ с нормальным распределением 
            /// используется в методе NextDouble()
            /// </summary>
            /// <returns></returns>
            protected override double Sample()
            {
                // есть предыдущее значение? возвращаем его
                if (!double.IsNaN(prevSample))
                {
                    double result = prevSample;
                    prevSample = double.NaN;
                    return result;
                }

                double u, v, s;

                do
                {
                    u = 2 * base.Sample() - 1;
                    v = 2 * base.Sample() - 1; // [-1, 1)
                    s = u * u + v * v;
                }
                while (u <= -1 || v <= -1 || s >= 1 || s == 0);

                double r = Math.Sqrt(-2 * Math.Log(s) / s);

                prevSample = r * v;
                return r * u;
            }
        }

        #endregion
    }
}
