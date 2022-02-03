using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shape;
using System;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTriangleLenght()
        {
            var triangle = new Triangle(new Point(), new Point(0, 4), new Point(3, 0));
            var res = triangle.SidesLenght();
            Assert.AreEqual(5, res.max);
            Assert.AreEqual(4, res.mid);
            Assert.AreEqual(3, res.min);
        }
        [TestMethod]
        public void TestValidTriangle()
        {
            Assert.IsTrue(Triangle.IsValidTriangle(new Point(), new Point(0, 4), new Point(3, 0)));
        }
        [TestMethod]
        public void TestIsRectangular()
        {
            var triangle = new Triangle(new Point(), new Point(0, 161), new Point(240, 0));
            Assert.IsTrue(triangle.IsRectangular());
        }
        [TestMethod]
        public void TestIsNotRectangular()
        {
            var triangle = new Triangle(new Point(), new Point(0, 161.1), new Point(240, 0));
            Assert.IsFalse(triangle.IsRectangular());
        }
        [TestMethod]
        public void TestIsNotRectangular2()
        {
            var triangle = new Triangle(new Point(), new Point(0, 161.1), new Point(240, 0));
            Assert.IsFalse(triangle.IsRectangular());
        }
        [TestMethod]
        public void TestIsNotRectangular3()
        {
            var triangle = new Triangle(new Point(), new Point(0, 161.01), new Point(240, 0));
            Assert.IsFalse(triangle.IsRectangular());
        }
        [TestMethod]
        public void TestSqaureTriangle()
        {
            var triangle = new Triangle(new Point(), new Point(0, 4), new Point(3, 0));
            Assert.AreEqual(6, triangle.Square());
        }
        [TestMethod]
        public void TestSquareCircle()
        {
            var circle = new Circle(3) { Center = new Point(0, 0) };
            Assert.AreEqual(Math.PI * 9, circle.Square());
        }
    }
}
