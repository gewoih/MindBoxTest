using MindBoxLib.Classes;
using MindBoxLib.Extensions;
using MindBoxLib.Interfaces;

namespace MindBoxLibTests
{
    public class CircleTests
    {
        [TestCase(0.1, 0.031416, 6)]
        [TestCase(1, Math.PI, 6)]
        [TestCase(5.782, 105.02823, 5)]
        public void GetCircleAreaWithPositiveRadius(double radius, double expectedArea, int precision)
        {
            IGeometricShape circle = new Circle(radius);

            double circleArea = circle.GetArea();

            Assert.That(circleArea.IsEqualsWithPrecision(expectedArea, precision), Is.EqualTo(true));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TryCreateCircleWithNonPositiveRadius(double radius)
        {
            try
            {
                IGeometricShape circle = new Circle(radius);
            }
            catch (ArgumentException)
            {
                Assert.True(true);
                return;
            }

            Assert.True(false);
        }

        [TestCase(double.NaN)]
        [TestCase(double.NegativeInfinity)]
        [TestCase(double.PositiveInfinity)]
        public void TryCreateCircleWithNonFiniteRadius(double radius)
        {
            try
            {
                IGeometricShape circle = new Circle(radius);
            }
            catch (ArgumentException)
            {
                Assert.True(true);
                return;
            }

            Assert.True(false);
        }
    }
}
