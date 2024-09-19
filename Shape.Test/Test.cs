using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Shapes.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestClosestShape()
        {
            Point testPoint = new Point(1, 1);
            List<Shape> shapes = new List<Shape>
            {
                new Circle(new Point(0, 0), 2),
                new Square(new Point(3, 3), 2),
                new RegularTriangle(new Point(0, 4), 2),
                new RegularHexagon(new Point(5, 5), 2)
            };

            Shape closestShape = null;
            double minDistance = double.MaxValue;

            foreach (var shape in shapes)
            {
                double distance = shape.DistanceToPoint(testPoint);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestShape = shape;
                }
            }

            Assert.IsNotNull(closestShape);
            Assert.IsTrue(closestShape is Circle);
        }

        [TestMethod]
        public void TestNoShapes()
        {

            List<Shape> shapes = new List<Shape>();
            Point testPoint = new Point(0, 0);


            Shape closestShape = null;
            double minDistance = double.MaxValue;

            foreach (var shape in shapes)
            {
                double distance = shape.DistanceToPoint(testPoint);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestShape = shape;
                }
            }


            Assert.IsNull(closestShape);
        }

        [TestMethod]
        public void TestMultipleShapesSameDistance()
        {

            Point testPoint = new Point(1, 1);
            Circle circle = new Circle(new Point(0, 0), 1);
            Square square = new Square(new Point(2, 2), 2);
            RegularTriangle triangle = new RegularTriangle(new Point(0, 3), 2);

            List<Shape> shapes = new List<Shape> { circle, square, triangle };


            List<Shape> closestShapes = new List<Shape>();
            double minDistance = double.MaxValue;

            foreach (var shape in shapes)
            {
                double distance = shape.DistanceToPoint(testPoint);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestShapes.Clear();
                    closestShapes.Add(shape);
                }
                else if (distance == minDistance)
                {
                    closestShapes.Add(shape);
                }
            }


            Assert.AreEqual(1, closestShapes.Count);
        }

        [TestMethod]
        public void TestSingleShape()
        {

            Point testPoint = new Point(1, 1);
            Circle circle = new Circle(new Point(0, 0), 2);

            List<Shape> shapes = new List<Shape> { circle };


            Shape closestShape = null;
            double minDistance = double.MaxValue;

            foreach (var shape in shapes)
            {
                double distance = shape.DistanceToPoint(testPoint);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestShape = shape;
                }
            }


            Assert.IsNotNull(closestShape);
            Assert.IsTrue(closestShape is Circle);
        }
    }
}
