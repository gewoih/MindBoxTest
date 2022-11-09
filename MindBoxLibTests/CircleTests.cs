using MindBoxLib.Classes;
using MindBoxLib.Extensions;

namespace MindBoxLibTests
{
    public class CircleTests
    {
        [TestCase(0.1, 0.031416, 6)]
        [TestCase(1, Math.PI, 6)]
        [TestCase(5.782, 105.02823, 5)]
        public void GetArea_FinitePositiveRadius_CorrectArea(double radius, double expectedArea, int precision)
        {
            Circle circle = new(radius);

            double circleArea = circle.GetArea();

            Assert.That(circleArea.EqualsWithPrecision(expectedArea, precision), Is.EqualTo(true));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Constructor_NonPositiveRadius_ThrowsArgumentException(double radius)
        {
            TestDelegate actual = () =>
            {
                Circle circle = new(radius);
            };

            Assert.Throws<ArgumentException>(actual);
        }

        [TestCase(double.NaN)]
        [TestCase(double.NegativeInfinity)]
        [TestCase(double.PositiveInfinity)]
        public void Constructor_NonFiniteRadius_ThrowsArgumentException(double radius)
        {
            TestDelegate actual = () =>
            {
                Circle circle = new(radius);
            };

            Assert.Throws<ArgumentException>(actual);
        }
    }
}
