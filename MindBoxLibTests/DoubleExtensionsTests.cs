using MindBoxLib.Extensions;

namespace MindBoxLibTests
{
    public class DoubleExtensionsTests
    {
        [TestCase(1, 1, -1)]
        public void IsEqualsWithPrecision_PrecisionLessThanOne_ThrowsArgumentException(double leftValue, double rightValue, int precision)
        {
            TestDelegate actual = () =>
            {
                leftValue.EqualsWithPrecision(rightValue, precision);
            };

            Assert.Throws<ArgumentException>(actual);
        }

        [TestCase(1.4, 1.2, 0, true)]
        [TestCase(1.5431, 1.543412, 3, true)]
        [TestCase(Math.PI, 3.145415, 6, false)]
        [TestCase(1.13, 1.14, 2, false)]
        public void IsEqualsWithPrecision_FinitePositiveValues_ExpectedResult(double leftValue, double rightValue, int precision, bool expected)
        {
            var actual = leftValue.EqualsWithPrecision(rightValue, precision);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
