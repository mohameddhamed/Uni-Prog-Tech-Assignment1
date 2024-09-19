using System;

namespace Shapes
{
    public class RegularTriangle : Shape
    {
        public RegularTriangle(Point center, double length) : base(center, length) { }

        public override double DistanceToPoint(Point point)
        {

            double height = (Math.Sqrt(3) / 2) * length;


            Point vertex1 = new Point(center.X - length / 2, center.Y - height / 3);
            Point vertex2 = new Point(center.X + length / 2, center.Y - height / 3);
            Point vertex3 = new Point(center.X, center.Y + (2 * height) / 3);


            if (IsPointInsideTriangle(point, vertex1, vertex2, vertex3))
            {
                return 0;
            }


            double distanceToEdge1 = point.DistanceToLineSegment(vertex1, vertex2);
            double distanceToEdge2 = point.DistanceToLineSegment(vertex2, vertex3);
            double distanceToEdge3 = point.DistanceToLineSegment(vertex3, vertex1);


            return Math.Min(distanceToEdge1, Math.Min(distanceToEdge2, distanceToEdge3));
        }





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
