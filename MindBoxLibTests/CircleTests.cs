using MindBoxLib.Classes;
using MindBoxLib.Extensions;

namespace MindBoxLibTests
{
    public class CircleTests
    {
        [TestCase(0.1, 0.031416, 6)]
        [TestCase(1, Math.PI, 6)]
        [TestCase(5.782, 105.02823, 5)]
        public void GetCircleAreaWithPositiveRadius(double radius, double expectedArea, int precision)
        {
            Circle circle = new(radius);

            double circleArea = circle.GetArea();

            Assert.That(circleArea.IsEqualsWithPrecision(expectedArea, precision), Is.EqualTo(true));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TryCreateCircleWithNonPositiveRadius(double radius)
        {
            Assert.Throws<ArgumentException>(() =>
                {
                    Circle circle = new Circle(radius);
                });
        }

        [TestCase(double.NaN)]
        [TestCase(double.NegativeInfinity)]
        [TestCase(double.PositiveInfinity)]
        public void TryCreateCircleWithNonFiniteRadius(double radius)
        {
            Assert.Throws<ArgumentException>(() =>
                {
                    Circle circle = new(radius);
                });
        }
    }
}
