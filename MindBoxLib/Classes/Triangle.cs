using MindBoxLib.Extensions;
using MindBoxLib.Interfaces;
using System;

namespace MindBoxLib.Classes
{
    public class Triangle : IGeometricShape
    {
        private readonly double firstSide;
        private readonly double secondSide;
        private readonly double thirdSide;

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            this.firstSide = firstSide;
            this.secondSide = secondSide;
            this.thirdSide = thirdSide;

            ValidateTriangleSides();
        }

        /// <summary>
        /// Returns an area of Triangle
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            double triangleSemiperimeter = (firstSide + secondSide + thirdSide) / 2;
            double circleArea = Math.Sqrt(triangleSemiperimeter *
                                    (triangleSemiperimeter - firstSide) *
                                    (triangleSemiperimeter - secondSide) *
                                    (triangleSemiperimeter - thirdSide));

            return circleArea;
        }

        /// <summary>
        /// Determines whether the Triangle is right
        /// </summary>
        /// <returns></returns>
        public bool IsRight()
        {
            double firstSideSquared = Math.Pow(firstSide, 2);
            double secondSideSquared = Math.Pow(secondSide, 2);
            double thirdSideSquared = Math.Pow(thirdSide, 2);

            if (firstSideSquared + secondSideSquared != thirdSideSquared &&
                secondSideSquared + thirdSideSquared != firstSideSquared &&
                thirdSideSquared + firstSideSquared != secondSideSquared)
            {
                return false;
            }

            return true;
        }

        private void ValidateTriangleSides()
        {
            ValidateSidesAreFiniteNumbers();
            ValidateSidesArePositiveNumbers();
            ValidateSidesFormTriangle();
        }

        private void ValidateSidesAreFiniteNumbers()
        {
            if (!firstSide.IsFiniteNumber() || !firstSide.IsFiniteNumber() || !firstSide.IsFiniteNumber())
            {
                throw new ArgumentException("All sides of the triangle must be numbers.");
            }
        }

        private void ValidateSidesArePositiveNumbers()
        {
            if (!firstSide.IsPositive() || !secondSide.IsPositive() || !thirdSide.IsPositive())
            {
                throw new ArgumentException("All sides of the triangle must be positive numbers.");
            }
        }

        private void ValidateSidesFormTriangle()
        {

            if (firstSide + secondSide < thirdSide || firstSide + thirdSide < secondSide || secondSide + thirdSide < firstSide)
            {
                throw new ArithmeticException("The given sides don't form a triangle.");
            }
        }
    }
}
