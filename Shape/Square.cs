using System;

namespace Shapes
{
    class Square : Shapes
    {
        public class WrongRadiusException : Exception { }

        private readonly Point center;
        private readonly double radius;
        public Square(Point center, double length) : base(center, length)
        {
        }
        public bool distanceToPoint(Point point)
        {
            return center.Distance(point) <= radius;
        }
    }
}
