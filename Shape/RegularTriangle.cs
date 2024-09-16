using System;

namespace Shapes
{
    class RegularTriangle : Shape
    {
        public RegularTriangle(Point center, double length) : base(center, length) { }

        public override double DistanceToPoint(Point point)
        {
            // Calculate the height of the equilateral triangle
            double height = (Math.Sqrt(3) / 2) * length;

            // Calculate the three vertices of the triangle assuming it's aligned with the x-axis
            Point vertex1 = new Point(center.X - length / 2, center.Y - height / 3);
            Point vertex2 = new Point(center.X + length / 2, center.Y - height / 3);
            Point vertex3 = new Point(center.X, center.Y + (2 * height) / 3);

            // Check if the point is inside the triangle using barycentric coordinates
            if (IsPointInsideTriangle(point, vertex1, vertex2, vertex3))
            {
                return 0;
            }

            // Calculate the shortest distance to the triangle's edges
            double distanceToEdge1 = point.DistanceToLineSegment(vertex1, vertex2);
            double distanceToEdge2 = point.DistanceToLineSegment(vertex2, vertex3);
            double distanceToEdge3 = point.DistanceToLineSegment(vertex3, vertex1);

            // Return the minimum distance to the edges
            return Math.Min(distanceToEdge1, Math.Min(distanceToEdge2, distanceToEdge3));
        }

        // Helper method to calculate the distance from a point to a line segment


        // Helper method to check if a point is inside a triangle using barycentric coordinates
        private bool IsPointInsideTriangle(Point p, Point v1, Point v2, Point v3)
        {
            double denominator = ((v2.Y - v3.Y) * (v1.X - v3.X) + (v3.X - v2.X) * (v1.Y - v3.Y));
            double a = ((v2.Y - v3.Y) * (p.X - v3.X) + (v3.X - v2.X) * (p.Y - v3.Y)) / denominator;
            double b = ((v3.Y - v1.Y) * (p.X - v3.X) + (v1.X - v3.X) * (p.Y - v3.Y)) / denominator;
            double c = 1 - a - b;

            return a >= 0 && b >= 0 && c >= 0;
        }

    }
}
