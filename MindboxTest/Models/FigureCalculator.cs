using MindboxTest.Enums;
using MindboxTest.Interfaces;
namespace MindboxTest.Models
{
    /// <summary>
    /// Класс, вызывающий метод выбранной стратегии
    /// </summary>
    public class FigureCalculator : IFigure
    {
        private readonly IFigure _figure;
        public TypesFigure Type { get; set; } = TypesFigure.None;
        public FigureCalculator(IFigure figure)
        {
            _figure = figure;
        }
        public double GetArea()
        {
           return _figure.GetArea();
        }
    }
}
