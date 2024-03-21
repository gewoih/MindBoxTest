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
            ValidateRadius(radius);
            Radius = radius;
        }

        /// <summary>
        /// Returns an area of Circle
        /// </summary>
        public double CalculateArea() => Math.PI * Math.Pow(Radius, 2);

        private static void ValidateRadius(double radius)
        {
            if (!radius.IsFiniteNumber() || !radius.IsPositive())
                throw new ArgumentException("Radius of the circle must be finite positive number.");
        }
    }
}
