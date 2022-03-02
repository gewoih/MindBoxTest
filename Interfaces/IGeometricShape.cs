namespace MindBoxLib.Interfaces
{
	/// <summary>
	/// Интерфейс для геометрических фигур
	/// </summary>
	public interface IGeometricShape
	{
		/// <summary>
		/// Вычисление площади геометрической фигуры
		/// </summary>
		/// <returns>Площадь в квадратичных единицах</returns>
		public double GetArea();
	}
}
