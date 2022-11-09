using MindBoxLib.Extensions;
using MindBoxLib.Interfaces;
using System;

namespace MindBoxLib.Classes
{
    public sealed class Triangle : IGeometricShape
    {
        public double FirstSide { get; }
        public double SecondSide { get; }
        public double ThirdSide { get; }

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;

            ValidateTriangleSides();
        }

        /// <summary>
        /// Returns an area of Triangle
        /// </summary>
        public double GetArea()
        {
            double triangleSemiperimeter = (FirstSide + SecondSide + ThirdSide) / 2;
            double triangleArea = Math.Sqrt(triangleSemiperimeter *
                                    (triangleSemiperimeter - FirstSide) *
                                    (triangleSemiperimeter - SecondSide) *
                                    (triangleSemiperimeter - ThirdSide));

            return triangleArea;
        }

        /// <summary>
        /// Determines whether the Triangle is right
        /// </summary>
        public bool IsRight()
        {
            double firstSideSquared = Math.Pow(FirstSide, 2);
            double secondSideSquared = Math.Pow(SecondSide, 2);
            double thirdSideSquared = Math.Pow(ThirdSide, 2);

            return firstSideSquared + secondSideSquared == thirdSideSquared
                   || secondSideSquared + thirdSideSquared == firstSideSquared
                   || thirdSideSquared + firstSideSquared == secondSideSquared;
        }

        private void ValidateTriangleSides()
        {
            ValidateSidesAreFiniteNumbers();
            ValidateSidesArePositiveNumbers();
            ValidateSidesFormTriangle();
        }

        private void ValidateSidesAreFiniteNumbers()
        {
            if (!FirstSide.IsFiniteNumber() || !SecondSide.IsFiniteNumber() || !ThirdSide.IsFiniteNumber())
            {
                throw new ArgumentException("All sides of the triangle must be numbers.");
            }
        }

        private void ValidateSidesArePositiveNumbers()
        {
            if (!FirstSide.IsPositive() || !SecondSide.IsPositive() || !ThirdSide.IsPositive())
            {
                throw new ArgumentException("All sides of the triangle must be positive numbers.");
            }
        }

        private void ValidateSidesFormTriangle()
        {
            if (FirstSide + SecondSide < ThirdSide || FirstSide + ThirdSide < SecondSide || SecondSide + ThirdSide < FirstSide)
            {
                throw new ArgumentException("The given sides don't form a triangle.");
            }
        }
    }
}
