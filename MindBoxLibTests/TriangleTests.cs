using MindBoxLib.Classes;
using MindBoxLib.Extensions;

namespace MindBoxLibTests
{
    public class TriangleTests
    {
        private static IEnumerable<TestCaseData> Constructor_ExceptionCases()
        {
            //Negative sides
            yield return new TestCaseData(-1, 1, 1).SetName("Constructor_NegativeFirstSide_ThrowsArgumentException");
            yield return new TestCaseData(1, -1, 1).SetName("Constructor_NegativeSecondSide_ThrowsArgumentException");
            yield return new TestCaseData(1, 1, -1).SetName("Constructor_NegativeThirdSide_ThrowsArgumentException");

            //Infinite sides
            yield return new TestCaseData(double.PositiveInfinity, 1, 1).SetName("Constructor_InfiniteFirstSide_ThrowsArgumentException");
            yield return new TestCaseData(1, double.PositiveInfinity, 1).SetName("Constructor_InfiniteSecondSide_ThrowsArgumentException");
            yield return new TestCaseData(1, 1, double.PositiveInfinity).SetName("Constructor_InfiniteThirdSide_ThrowsArgumentException");

            //NaN sides
            yield return new TestCaseData(double.NaN, 1, 1).SetName("Constructor_NaNFirstSide_ThrowsArgumentException");
            yield return new TestCaseData(1, double.NaN, 1).SetName("Constructor_NaNSecondSide_ThrowsArgumentException");
            yield return new TestCaseData(1, 1, double.NaN).SetName("Constructor_NaNThirdSide_ThrowsArgumentException");

            //Non-existent triangle
            yield return new TestCaseData(0.5, 1, 2).SetName("Constructor_NonExistentSides_ThrowsArgumentException");
            yield return new TestCaseData(2, 0.5, 1).SetName("Constructor_NonExistentSides_ThrowsArgumentException");
            yield return new TestCaseData(1, 2, 0.5).SetName("Constructor_NonExistentSides_ThrowsArgumentException");
        }

        [TestCase(1, 1, 1, 0.433013, 6)]
        [TestCase(3, 4, 5, 6, 1)]
        public void GetArea_FinitePositiveSides_ExpectedResult(double firstSide, double secondSide, double thirdSide, double expectedArea, int precision)
        {
            Triangle triangle = new(firstSide, secondSide, thirdSide);

            var triangleArea = triangle.CalculateArea();

            Assert.That(triangleArea.EqualsWithPrecision(expectedArea, precision), Is.True);
        }

        [TestCase(3, 4, 5, true)]
        [TestCase(4.5, 4.36, 5.54, false)]
        [TestCase(1, 1, 1, false)]
        public void IsRight_FinitePositiveSides_ExpectedResult(double firstSide, double secondSide, double thirdSide, bool expectedResult)
        {
            Triangle triangle = new(firstSide, secondSide, thirdSide);

            var isRightActual = triangle.IsRightAngled();

            Assert.That(isRightActual, Is.EqualTo(expectedResult));
        }

        [Test, TestCaseSource(nameof(Constructor_ExceptionCases))]
        public void Constructor_NegativeSides_ThrowsArgumentException(double firstSide, double secondSide, double thirdSide)
        {
            TestDelegate actual = () =>
            {
                _ = new Triangle(firstSide, secondSide, thirdSide);
            };

            Assert.Throws<ArgumentException>(actual);
        }
    }
}
