using MindboxTest.Enums;
using MindboxTest.Interfaces;

namespace MindboxTest.Models
{
    /// <summary>
    /// Класс, отвечающий за логику круга
    /// </summary>
    public class CircleStrategy : IFigure
    {
        public double Radius { get; set; }
        public TypesFigure Type { get; set; } = TypesFigure.Circle;

    
        public CircleStrategy(double radius) 
        {
            if (radius < 0)
               throw new Exception("Радиус не может быть меньше или равен 0");

            Radius = radius;
        }
        public double GetArea() => Math.PI * Math.Pow(Radius, 2);
    }
}
