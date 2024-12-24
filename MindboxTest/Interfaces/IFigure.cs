using MindboxTest.Enums;

namespace MindboxTest.Interfaces
{
    /// <summary>
    /// Интерфейс фигуры
    /// </summary>
    public interface IFigure
    {
        TypesFigure Type { get; set; }
        double GetArea();
    }
}
