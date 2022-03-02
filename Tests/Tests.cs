using MindBoxLib;
using System;
using Xunit;

namespace MindBoxTests
{
	public class Tests
	{
		[Fact]
		public void CircleAreaTests()
		{
			Assert.Equal(Math.PI, new Circle(1).GetArea());
			Assert.Equal(314.159265, Math.Round(new Circle(10).GetArea(), 6));
			Assert.Equal(706.858347, Math.Round(new Circle(15).GetArea(), 6));
			Assert.Equal(533266.503391, Math.Round(new Circle(412).GetArea(), 6));
			Assert.Equal(0.785398, Math.Round(new Circle(0.5).GetArea(), 6));

			Assert.Throws<ArgumentException>(() => new Circle(0).GetArea());
			Assert.Throws<ArgumentException>(() => new Circle(-1).GetArea());
			Assert.Throws<ArgumentException>(() => new Circle(-0.5).GetArea());
			Assert.Throws<ArgumentException>(() => new Circle(double.NaN).GetArea());
		}

		[Fact]
		public void TriangleAreaTests()
		{
			Assert.Equal(0.4330127018922193, new Triangle(1, 1, 1).GetArea());
			Assert.Equal(0, new Triangle(1, 1, 2).GetArea());
			Assert.Equal(19.81003533565753, new Triangle(10, 5, 8).GetArea());
			Assert.Equal(1082.5317547305483, new Triangle(50, 50, 50).GetArea());
			Assert.Equal(6, new Triangle(3, 4, 5).GetArea());

			Assert.Throws<ArithmeticException>(() => new Triangle(500, 300, 1000).GetArea());
			Assert.Throws<ArithmeticException>(() => new Triangle(1, 1, 3).GetArea());

			Assert.Throws<ArgumentException>(() => new Triangle(1, 1, -1).GetArea());
		}

		[Fact]
		public void TriangleIsRightTests()
		{
			Assert.True(new Triangle(3, 4, 5).IsRight);
			Assert.True(new Triangle(5, 12, 13).IsRight);
			Assert.True(new Triangle(15, 112, 113).IsRight);

			Assert.False(new Triangle(3, 4, 4).IsRight);
			Assert.False(new Triangle(4, 5, 9).IsRight);

			Assert.Throws<ArithmeticException>(() => new Triangle(5, 23, 10).IsRight);
		}
	}
}
