using System;

namespace Shape
{
    public static class ShapeProcessor
    {
        public static double ComputeSquare(IShape shape) => shape.Square();
        public static double ComputePerimeter(IShape shape) => shape.Perimeter(); //добавляем если надо другие функции
    }
}
