using System;

namespace Shapes
{
    class Square : Shape
    {
        public Square(Point center, double length) : base(center, length) { }
        public override double DistanceToPoint(Point point)
        {
            // Calculate half side length to determine the boundaries of the square
            double halfSide = length / 2;

            // Determine the square's bounds
            double left = center.X - halfSide;
            double right = center.X + halfSide;
            double top = center.Y + halfSide;
            double bottom = center.Y - halfSide;

            // Check if the point is inside the square
            if (point.X >= left && point.X <= right && point.Y >= bottom && point.Y <= top)
            {
                return 0; // Point is inside the square
            }

            // Calculate the horizontal and vertical distances
            double dx = Math.Max(left - point.X, 0, point.X - right);
            double dy = Math.Max(bottom - point.Y, 0, point.Y - top);

            // Return the Euclidean distance from the point to the nearest edge
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
