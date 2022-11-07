using System;

namespace MindBoxLib.Extensions
{
    public static class DoubleExtensions
    {
        /// <summary>
        /// Determines whether the <paramref name="value"/> is finite number
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsFiniteNumber(this double value)
        {
            if (double.IsInfinity(value) || double.IsNaN(value))
                return false;

            return true;
        }

        /// <summary>
        /// Determines whether the <paramref name="value"/> is positive number
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsPositive(this double value)
        {
            return value > 0;
        }

        /// <summary>
        /// Determines wheter the <paramref name="leftValue"/> 
        /// equals to <paramref name="rightValue"/> 
        /// with <paramref name="precision"/> digits after floating point
        /// </summary>
        /// <param name="leftValue"></param>
        /// <param name="rightValue"></param>
        /// <param name="precision">Precision of double values comparison</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool IsEqualsWithPrecision(this double leftValue, double rightValue, int precision)
        {
            if (precision < 1)
                throw new ArgumentException("Precision value must be greater or equal than 1.");

            double precisionValue = 1 / Math.Pow(10, precision);
            return Math.Abs(leftValue - rightValue) < precisionValue;
        }
    }
}
