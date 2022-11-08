using MindBoxLib.Extensions;
using MindBoxLib.Interfaces;
using System;

namespace MindBoxLib.Classes
{
    public sealed class Circle : IGeometricShape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;

            ValidateRadius();
        }

        /// <summary>
        /// Returns an area of Circle
        /// </summary>
        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        private void ValidateRadius()
        {
            ValidateRadiusIsFiniteNumber();
            ValidateRadiusIsPositiveNumber();
        }

        private void ValidateRadiusIsFiniteNumber()
        {
            if (!Radius.IsFiniteNumber())
            {
                throw new ArgumentException("Radius of the circle must be finite number.");
            }
        }

        private void ValidateRadiusIsPositiveNumber()
        {
            if (!Radius.IsPositive())
            {
                throw new ArgumentException("Radius of the circle must be positive number.");
            }
        }
    }
}
