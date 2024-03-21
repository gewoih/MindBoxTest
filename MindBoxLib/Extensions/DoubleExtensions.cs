using System;

namespace MindBoxLib.Extensions
{
    public static class DoubleExtensions
    {
        /// <summary>
        /// Determines whether the <paramref name="value"/> is finite number
        /// </summary>
        public static bool IsFiniteNumber(this double value)
        {
            return !double.IsInfinity(value) && !double.IsNaN(value);
        }

        /// <summary>
        /// Determines whether the <paramref name="value"/> is positive number
        /// </summary>
        public static bool IsPositive(this double value)
        {
            return value > 0;
        }

        /// <summary>
        /// Determines whether the <paramref name="leftValue"/> 
        /// equals to <paramref name="rightValue"/> 
        /// with <paramref name="precision"/> digits after floating point
        /// </summary>
        /// <param name="precision">Precision of double values comparison</param>
        /// <exception cref="ArgumentException"></exception>
        public static bool EqualsWithPrecision(this double leftValue, double rightValue, int precision)
        {
            if (precision < 0)
                throw new ArgumentException("Precision value must be greater or equal than 0.");

            var precisionValue = 1 / Math.Pow(10, precision);
            return Math.Abs(leftValue - rightValue) < precisionValue;
        }
    }
}
