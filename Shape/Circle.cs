using System;

namespace Shapes
{
    class Circle : Shapes
    {
        public class WrongRadiusException : Exception { }

        public Circle(Point center, double length) : base(center, length) { }
        public bool distanceToPoint(Point point)
        {
            return center.Distance(point) <= length;
        }
    }
}
