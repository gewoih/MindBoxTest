using MindBoxLib.Extensions;
using MindBoxLib.Interfaces;
using System;

namespace MindBoxLib.Classes
{
    public class Triangle : IGeometricShape
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
            double circleArea = Math.Sqrt(triangleSemiperimeter *
                                    (triangleSemiperimeter - FirstSide) *
                                    (triangleSemiperimeter - SecondSide) *
                                    (triangleSemiperimeter - ThirdSide));

            return circleArea;
        }

        /// <summary>
        /// Determines whether the Triangle is right
        /// </summary>
        public bool IsRight()
        {
            double FirstSideSquared = Math.Pow(FirstSide, 2);
            double secondSideSquared = Math.Pow(SecondSide, 2);
            double thirdSideSquared = Math.Pow(ThirdSide, 2);

            if (FirstSideSquared + secondSideSquared != thirdSideSquared &&
                secondSideSquared + thirdSideSquared != FirstSideSquared &&
                thirdSideSquared + FirstSideSquared != secondSideSquared)
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
