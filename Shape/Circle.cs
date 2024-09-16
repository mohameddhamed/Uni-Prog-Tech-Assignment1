using System;

namespace Shapes
{
    class Circle : Shape
    {
        public Circle(Point center, double length) : base(center, length) { }
        public override double DistanceToPoint(Point point)
        {
            // Calculate the distance between the point and the center of the circle
            double distanceToCenter = center.Distance(point);

            // If the point is inside or on the circle, the distance is 0
            if (distanceToCenter <= length)
            {
                return 0;
            }

            // If the point is outside the circle, the distance is the difference between
            // the distance to the center and the radius (length)
            return distanceToCenter - length;
        }
    }
}
