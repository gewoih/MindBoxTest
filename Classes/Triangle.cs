using MindBoxLib.Interfaces;
using System;

namespace MindBoxLib
{
	public class Triangle : IGeometricShape
	{
		private readonly double A;
		private readonly double B;
		private readonly double C;
		public bool IsRight
		{
			get
			{
				//Сначала ищем самую большую сторону треугольника
				if (Math.Max(this.A, this.B) == this.A)
				{
					if (Math.Max(this.A, this.C) == this.A)
					{
						//А - максимум
						if (Math.Pow(this.B, 2) + Math.Pow(this.C, 2) == Math.Pow(this.A, 2))
							return true;
					}
					//C - максимум
					if (Math.Pow(this.A, 2) + Math.Pow(this.B, 2) == Math.Pow(this.C, 2))
						return true;
				}
				else if (Math.Max(this.B, this.C) == this.B)
				{
					//B - максимум
					if (Math.Pow(this.A, 2) + Math.Pow(this.C, 2) == Math.Pow(this.B, 2))
						return true;
				}
				//С - максимум
				else if (Math.Pow(this.A, 2) + Math.Pow(this.B, 2) == Math.Pow(this.C, 2))
					return true;

				return false;
			}
		}

		/// <summary>
		/// Конструктор для создания треугольника
		/// </summary>
		/// <param name="a">Сторона треугольника A</param>
		/// <param name="b">Сторона треугольника B</param>
		/// <param name="c">Сторона треугольника C</param>
		public Triangle(double a, double b, double c)
		{
			if (a <= 0 || b <= 0 || c <= 0)
				throw new ArgumentException("Все строны треугольника должны быть больше нуля!");
			if (a + b < c || a + c < b || b + c < a)
				throw new ArithmeticException("Заданные стороны не образуют треугольник!");

			this.A = a;
			this.B = b;
			this.C = c;
		}

		//Расчет площади треугольника по формуле Герона
		public double GetArea()
		{
			//Полупериметр
			double perimeter = (this.A + this.B + this.C) / 2;

			return Math.Sqrt(perimeter * (perimeter - this.A) * (perimeter - this.B) * (perimeter - this.C));
		}
	}
}
