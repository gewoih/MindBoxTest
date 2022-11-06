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
    }
}
