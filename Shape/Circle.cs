using System;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(Point center, double length) : base(center, length) { }
        public override double DistanceToPoint(Point point)
        {
            double distanceToCenter = center.Distance(point);

            if (distanceToCenter <= length)
            {
                return 0;
            }

            return distanceToCenter - length;
        }
    }
}
