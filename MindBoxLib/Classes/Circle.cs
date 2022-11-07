using MindBoxLib.Extensions;
using MindBoxLib.Interfaces;
using System;

namespace MindBoxLib.Classes
{
    public class Circle : IGeometricShape
    {
        private readonly double radius;

        public Circle(double radius)
        {
            this.radius = radius;

            ValidateRadius();
        }

        /// <summary>
        /// Returns an area of Circle
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        private void ValidateRadius()
        {
            ValidateRadiusIsFiniteNumber();
            ValidateRadiusIsPositiveNumber();
        }

        private void ValidateRadiusIsFiniteNumber()
        {
            if (!radius.IsFiniteNumber())
            {
                throw new ArgumentException("Radius of the circle must be finite number.");
            }
        }

        private void ValidateRadiusIsPositiveNumber()
        {
            if (!radius.IsPositive())
            {
                throw new ArgumentException("Radius of the circle must be positive number.");
            }
        }
    }
}
