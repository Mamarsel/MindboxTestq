using MindboxTest.Enums;
using MindboxTest.Interfaces;
using MindboxTest.Models;

namespace MindboxTest
{
    /*
     Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. 
      Дополнительно к работоспособности оценим:
     * Юнит-тесты - done
     * Легкость добавления других фигур - Реализовал с помощью паттерна стрататегии, гибкость и легкость присутствует. Но стоит учесть, что это геометрические фигуры и под них все равно приходится подстраиваться и прорабатывать условия
     * Вычисление площади фигуры без знания типа фигуры в compile-time - Не совсем додумал как это сделать грамотно и правильно, представил вариант, где по углам программа сама подбирает стратегию для вычисления
     * Проверку на то, является ли треугольник прямоугольным - done*/

    /*Второе задание прикреплю в гитхабе*/

    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                List<float> points = GetPointFromClient();
                CalculateArea(points);
            }
        }
        /// <summary>
        /// Метод, определяющий тип фигуры и подбирает под вводимые данные алгоритм вычисления площади фигуры без знания о типе самой фигуры.
        /// </summary>
        /// <param name="points">Список введенных параметров пользователем</param>
        private static void CalculateArea(List<float> points)
        {
            switch (points.Count)
            {
                case (int)TypesFigure.Circle:
                    CalculateAndDisplayArea(new CircleStrategy(points[0]));
                    break;

                case (int)TypesFigure.None:
                    Console.WriteLine("Введите числа");
                    break;

                case (int)TypesFigure.Rectangle:
                    CalculateAndDisplayArea(new RectangleStrategy(points[0], points[1]));
                    break;

                case (int)TypesFigure.Triangle:
                    {
                        var triangle = new TriangleStrategy(points[0], points[1], points[2]);
                        if (triangle.IsRightTriangle())
                        {
                            Console.WriteLine("Это прямоугольный треугольник!");
                        }
                        CalculateAndDisplayArea(new TriangleStrategy(points[0], points[1], points[2]));
                        break;
                    }
                default:
                    Console.WriteLine("В ТЗ не было указано такого случая!( \n");
                    break;
            }

        }
        /// <summary>
        /// Ввод данных через консоль
        /// </summary>
        private static List<float> GetPointFromClient()
        {
            Console.WriteLine("Введите стороны через пробел или радиус фигуры:");
            var input = Console.ReadLine();
            CheckInput(input);

            var points = input.Split(' ')
                              .Select(s => float.TryParse(s, out var value) ? value : (float?)null)
                              .Where(value => value.HasValue)
                              .Select(value => value.Value)
                              .ToList();
            return points;

        }
        /// <summary>
        /// Проверка на пустые вводимые данные
        /// </summary>
        /// <param name="input">Вводимая строка</param>
        private static void CheckInput(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Пустой ввод. Попробуйте снова.");
                GetPointFromClient();
                return;
            }
        }
        /// <summary>
        /// Метод, получения вычисленных данных и его вывод
        /// </summary>
        /// <param name="shapeStrategy">Класс с реализацией алгоритма вычисления площади</param>
        static void CalculateAndDisplayArea(IFigure shapeStrategy)
        {
            var calculator = new FigureCalculator(shapeStrategy);
            var area = calculator.GetArea();

            if (area > 0)
            {
                Console.WriteLine($"Площадь {shapeStrategy.Type}: {area}");
            }
            else
            {
                Console.WriteLine("Введены некорректные значения или фигура не может существовать.");
                area = 0;
            }
        }
    }
}
