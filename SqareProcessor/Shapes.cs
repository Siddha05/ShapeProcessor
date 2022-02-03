using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public interface IShape
    {
        /// <summary>
        /// Имя фигуры
        /// </summary>
        string Name => this.GetType().Name;
        /// <summary>
        /// Площадь фигуры
        /// </summary>
        /// <returns></returns>
        double Square();
        /// <summary>
        /// Периметр фигуры 
        /// </summary>
        /// <returns></returns>
        double Perimeter() => throw new NotImplementedException();
    }

    // расширяем, наследуя от IShape требуемые фигуры (прямоугольник, трапеции и т.д.) 

    /// <summary>
    /// Используем координаты, а не длины, как более гибкий вариант
    /// </summary>
    public struct Point
    {
        private double _x;
        private double _y;

        public double Y => _y;
        public double X => _x;

        public Point(double x, double y)
        {
            if (double.IsNaN(x)) throw new ArgumentException($"Argument {nameof(x)} was Nan");
            if (double.IsNaN(y)) throw new ArgumentException($"Argument {nameof(y)} was Nan");
            _y = y; _x = x;
        }
        public override string ToString() => $"({_x},{_y})";
        public static double Distance(Point p1, Point p2) => Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));

    }

    public record Circle(double Radius) : IShape
    {
        public Point Center { get; init; }
        public double Square() => Math.PI * Radius * Radius;
    }

    public record Triangle : IShape
    {
        public Point A { get; init; }
        public Point B { get; init; }
        public Point C { get; init; }

        private double SideA() => Point.Distance(A, B);
        private double SideB() => Point.Distance(B, C);
        private double SideC() => Point.Distance(C, A);
        public double Square()
        {
            var side1 = SideA();
            var side2 = SideB();
            var side3 = SideC();
            return 0.25 * Math.Sqrt((side1 + side2 + side3) * (side1 + side2 - side3)
                                    * (side1 + side3 - side2) * (side2 + side3 - side1));
        }
        /// <summary>
        /// Может ли существовать треугольник с вершинами в точках <paramref name="a"/>, <paramref name="b"/>, <paramref name="c"/>?
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsValidTriangle(Point a, Point b, Point c)
        {
            var side1 = Point.Distance(a, b);
            var side2 = Point.Distance(b, c);
            var side3 = Point.Distance(a, c);
            if (side1 + side2 <= side3 || side2 + side3 <= side1 || side1 + side3 <= side2) return false;
            return true;
        }
        /// <summary>
        /// Прямоугольный ли треугольник?
        /// <para>Немного грешим против истины, т.к. возможны ошибки округления double</para>
        /// </summary>
        /// <returns></returns>
        public bool IsRectangular()
        {
            var sides = SidesLenght();
            return Math.Round(sides.max * sides.max, 14) == Math.Round(sides.min * sides.min + sides.mid * sides.mid, 14);
        }
        /// <summary>
        /// Длины сторон по ранжиру
        /// </summary>
        /// <returns></returns>
        public (double max, double mid, double min) SidesLenght()
        {
            double ma = SideA(); double md = SideB(); double mi = SideC();
            if (ma < md) Swap(ref ma, ref md);
            if (ma < mi) Swap(ref ma, ref mi);
            if (md < mi) Swap(ref md, ref mi);
            return (ma, md, mi);
        }
        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b; b = temp;
        }
    
        public Triangle(Point a, Point b, Point c)
        {
            if (!IsValidTriangle(a, b, c)) throw new ArgumentException("Impossible triangle");
            A = a; B = b; C = c;
        }
    }
}
