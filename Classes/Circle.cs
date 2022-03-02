using MindBoxLib.Interfaces;
using System;

namespace MindBoxLib
{
	public class Circle : IGeometricShape
	{
		private readonly double Radius;

		/// <summary>
		/// Конструктор для создания окружности
		/// </summary>
		/// <param name="radius">Радиус окружности</param>
		public Circle(double radius)
		{
			if (radius <= 0)
				throw new ArgumentException("Радиус окружности не может быть меньше 0!");
			if (Double.IsNaN(radius))
				throw new ArgumentException("Радиус окружности должен быть числом!");

			this.Radius = radius;
		}

		public double GetArea()
		{
			return Math.PI * Math.Pow(Radius, 2);
		}
	}
}
