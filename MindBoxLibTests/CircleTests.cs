using MindBoxLib.Classes;
using MindBoxLib.Extensions;

namespace MindBoxLibTests
{
    public class CircleTests
    {
        private static IEnumerable<TestCaseData> Constructor_ExceptionCases()
        {
            //Not positive radius
            yield return new TestCaseData(0).SetName("Constructor_RadiusZero_ThrowsArgumentException");
            yield return new TestCaseData(-1).SetName("Constructor_NegativeRadius_ThrowsArgumentException");

            //NaN radius
            yield return new TestCaseData(double.NaN).SetName("Constructor_NaNRadius_ThrowsArgumentException");
            
            //Infinite radius
            yield return new TestCaseData(double.NegativeInfinity).SetName("Constructor_NegativeInfinity_ThrowsArgumentException");
            yield return new TestCaseData(double.PositiveInfinity).SetName("Constructor_PositiveInfinity_ThrowsArgumentException");
        }

        [TestCase(0.1, 0.031416, 6)]
        [TestCase(1, Math.PI, 6)]
        [TestCase(5.782, 105.02823, 5)]
        public void GetArea_FinitePositiveRadius_CorrectArea(double radius, double expectedArea, int precision)
        {
            Circle circle = new(radius);

            var circleArea = circle.CalculateArea();

            Assert.That(circleArea.EqualsWithPrecision(expectedArea, precision), Is.EqualTo(true));
        }

        [Test, TestCaseSource(nameof(Constructor_ExceptionCases))]
        public void Constructor_NonFinitePositiveRadius_ThrowsArgumentException(double radius)
        {
            TestDelegate actual = () =>
            {
                _ = new Circle(radius);
            };

            Assert.Throws<ArgumentException>(actual);
        }
    }
}
