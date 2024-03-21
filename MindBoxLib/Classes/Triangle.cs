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
            ValidateTriangleSides(firstSide, secondSide, thirdSide);
            
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }

        /// <summary>
        /// Returns an area of Triangle
        /// </summary>
        public double CalculateArea()
        {
            //Using Heron's formula - https://en.wikipedia.org/wiki/Heron%27s_formula

            var triangleSemiperimeter = (FirstSide + SecondSide + ThirdSide) / 2;
            var triangleArea = Math.Sqrt(triangleSemiperimeter *
                                         (triangleSemiperimeter - FirstSide) *
                                         (triangleSemiperimeter - SecondSide) *
                                         (triangleSemiperimeter - ThirdSide));

            return triangleArea;
        }

        /// <summary>
        /// Determines whether the Triangle is right
        /// </summary>
        public bool IsRightAngled()
        {
            //Using Pythagorean theorem - https://en.wikipedia.org/wiki/Pythagorean_theorem

            var firstSideSquared = Math.Pow(FirstSide, 2);
            var secondSideSquared = Math.Pow(SecondSide, 2);
            var thirdSideSquared = Math.Pow(ThirdSide, 2);

            return firstSideSquared + secondSideSquared == thirdSideSquared
                   || secondSideSquared + thirdSideSquared == firstSideSquared
                   || thirdSideSquared + firstSideSquared == secondSideSquared;
        }

        private static void ValidateTriangleSides(double firstSide, double secondSide, double thirdSide)
        {
            if (!firstSide.IsFiniteNumber() || !secondSide.IsFiniteNumber() || !thirdSide.IsFiniteNumber())
                throw new ArgumentException("All sides of the triangle must be finite positive numbers.");

            //Using Triangle inequality theorem - https://en.wikipedia.org/wiki/Triangle_inequality
            if (firstSide + secondSide < thirdSide ||
                firstSide + thirdSide < secondSide ||
                secondSide + thirdSide < firstSide)
                throw new ArgumentException("The given sides don't form a triangle.");
        }
    }
}
