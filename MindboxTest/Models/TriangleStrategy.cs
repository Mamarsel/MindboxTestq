using MindboxTest.Enums;
using MindboxTest.Interfaces;

namespace MindboxTest.Models
{
    /// <summary>
    /// Класс, отвечающий за логику Треугольника
    /// </summary>
    public class TriangleStrategy : IFigure
    {
        public TypesFigure Type { get; set; } = TypesFigure.Triangle;
        public double SideFirst { get; set; }
        public double SideSecond { get; set; }
        public double SideThird { get; set; }
        public TriangleStrategy(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentException("Стороны должны быть положительными числами.");

            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
                throw new ArgumentException("Треугольник с такими сторонами не существует.");
            
            SideFirst = sideA;
            SideSecond = sideB;
            SideThird = sideC;
        }
        public double GetArea()
        {
            if (SideFirst <= 0 || SideSecond <= 0 || SideThird <= 0 ||
                (SideFirst + SideSecond <= SideThird) ||
                (SideFirst + SideThird <= SideSecond) ||
                (SideSecond + SideThird <= SideFirst))
            {
                return 0;
            }
            double semiPerimeter = (SideFirst + SideSecond + SideThird) / 2;
            return Math.Sqrt(
                semiPerimeter *
                (semiPerimeter - SideFirst) *
                (semiPerimeter - SideSecond) *
                (semiPerimeter - SideThird));
        }
        public bool IsRightFigure() => (SideFirst <= 0 || SideSecond <= 0 || SideThird <= 0) ? false : true;

        public bool IsRightTriangle() => Math.Abs(Math.Pow(SideFirst, 2) + Math.Pow(SideSecond, 2) - Math.Pow(SideThird, 2)) < 1e-10;
        
    }
}
