using MindboxTest.Models;

namespace MSTestFigures
{
    /// <summary>
    /// Тест реализован на MSTest
    /// </summary>
    [TestClass]
    public class FigureTests
    {
        /// <summary>
        /// Тест круга с корректными данными
        /// </summary>
        [TestMethod]
        public void CircleStrategy_CalculateArea_ValidRadius() 
        {
            var radius = 5;
            var circle = new CircleStrategy(radius);
            var calculator = new FigureCalculator(circle);

            var area = calculator.GetArea();

            Assert.AreEqual(Math.PI * radius * radius, area, 0.001);
        }
        /// <summary>
        /// Треугольник с корректными данными
        /// </summary>
        [TestMethod]
        public void TriangleStrategy_CalculateArea_ValidSides()
        {
            var sides = new float[] { 3f, 4f, 5f };
            var triangle = new TriangleStrategy(sides[0], sides[1], sides[2]);
            var calculator = new FigureCalculator(triangle);

            var area = calculator.GetArea();

            Assert.AreEqual(6, area, 0.001);
        }
        /// <summary>
        /// Тест проверки на треугольник с неправильными сторонами
        /// </summary>
        [TestMethod]
        public void TriangleStrategy_CalculateArea_InvalidSides_ShouldReturnError()
        {
            var sides = new float[] { 1f, 1f, 3f }; // Не может образовать треугольник
            Assert.ThrowsException<ArgumentException>(() => new TriangleStrategy(sides[0], sides[1], sides[2]));
        }
        /// <summary>
        /// Тест вычисления площади круга с отрицательным радиусом
        /// </summary>
        [TestMethod]
        public void CircleStrategy_CalculateArea_NegativeRadius_ShouldThrowException()
        {
            var radius = -5f;

            Assert.ThrowsException<Exception>(() => new CircleStrategy(radius));
        }
        /// <summary>
        /// Тест вычисления площади треугольника с отрицательной длиной стороны.
        /// </summary>
        [TestMethod]
        public void TriangleStrategy_CalculateArea_NegativeSides_ShouldThrowException()
        {
            var sides = new float[] { -3f, 4f, 5f };

            Assert.ThrowsException<ArgumentException>(() => new TriangleStrategy(sides[0], sides[1], sides[2]));
        }
    }
}
