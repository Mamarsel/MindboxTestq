using MindboxTest.Enums;
using MindboxTest.Interfaces;

namespace MindboxTest.Models
{
    /// <summary>
    /// Класс, отвечающий за логику прямоугольника. Сделал для проверки удобности и гибкости добавления новых фигур
    /// </summary>
    public class RectangleStrategy : IFigure
    {
        public TypesFigure Type { get; set; } = TypesFigure.Rectangle;
        public double Width { get; set; }
        public double Height { get; set; }
        public RectangleStrategy(double width, double height)
        {
            if (width < 0 || height < 0) 
                throw new ArgumentOutOfRangeException("Аргументы не могут быть меньше нуля");
            Width = width;
            Height = height;
        }
        public double GetArea()
        {
            return Width * Height;
        }
    }
}
