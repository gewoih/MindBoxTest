using MindBoxLib.Classes;
using MindBoxLib.Extensions;

namespace MindBoxLibTests
{
    public class TriangleTests
    {
        [TestCase(1, 1, 1, 0.433013, 6)]
        [TestCase(3, 4, 5, 6, 1)]
        public void GetArea_FinitePositiveSides_ExpectedResult(double firstSide, double secondSide, double thirdSide, double expectedArea, int precision)
        {
            Triangle triangle = new(firstSide, secondSide, thirdSide);

            double triangleArea = triangle.GetArea();

            Assert.That(triangleArea.EqualsWithPrecision(expectedArea, precision), Is.True);
        }


        [TestCase(3, 4, 5, true)]
        [TestCase(4.5, 4.36, 5.54, false)]
        [TestCase(1, 1, 1, false)]
        public void IsRight_FinitePositiveSides_ExpectedResult(double firstSide, double secondSide, double thirdSide, bool expectedResult)
        {
            Triangle triangle = new(firstSide, secondSide, thirdSide);

            bool isRightActual = triangle.IsRight();

            Assert.That(Is.Equals(isRightActual, expectedResult), Is.True);
        }

        [TestCase(-1, 1, 1)]
        [TestCase(1, -1, 1)]
        [TestCase(1, 1, -1)]
        public void Constructor_NegativeSides_ThrowsArgumentException(double firstSide, double secondSide, double thirdSide)
        {
            TestDelegate actual = () =>
            {
                Triangle triangle = new(firstSide, secondSide, thirdSide);
            };

            Assert.Throws<ArgumentException>(actual);
        }

        [TestCase(double.PositiveInfinity, 1, 1)]
        [TestCase(1, double.PositiveInfinity, 1)]
        [TestCase(1, 1, double.PositiveInfinity)]
        public void Constructor_InfiniteSides_ThrowsArgumentException(double firstSide, double secondSide, double thirdSide)
        {
            TestDelegate actual = () =>
            {
                Triangle triangle = new(firstSide, secondSide, thirdSide);
            };

            Assert.Throws<ArgumentException>(actual);
        }

        [TestCase(double.NaN, 1, 1)]
        [TestCase(1, double.NaN, 1)]
        [TestCase(1, 1, double.NaN)]
        public void Constructor_NaNSides_ThrowsArgumentException(double firstSide, double secondSide, double thirdSide)
        {
            TestDelegate actual = () =>
            {
                Triangle triangle = new(firstSide, secondSide, thirdSide);
            };

            Assert.Throws<ArgumentException>(actual); ;
        }

        [TestCase(0.5, 1, 2)]
        [TestCase(2, 0.5, 1)]
        [TestCase(1, 2, 0.5)]
        public void Constructor_NonExistentSides_ThrowsArgumentException(double firstSide, double secondSide, double thirdSide)
        {
            TestDelegate actual = () =>
            {
                Triangle triangle = new(firstSide, secondSide, thirdSide);
            };

            Assert.Throws<ArgumentException>(actual);
        }
    }
}
