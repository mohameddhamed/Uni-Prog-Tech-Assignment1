using System;

namespace Shapes
{
    public class RegularHexagon : Shape
    {
        public RegularHexagon(Point center, double length) : base(center, length) { }

        public override double DistanceToPoint(Point point)
        {

            double height = Math.Sqrt(3) * length;


            Point vertex1 = new Point(center.X - length, center.Y);
            Point vertex2 = new Point(center.X - length / 2, center.Y + height / 2);
            Point vertex3 = new Point(center.X + length / 2, center.Y + height / 2);
            Point vertex4 = new Point(center.X + length, center.Y);
            Point vertex5 = new Point(center.X + length / 2, center.Y - height / 2);
            Point vertex6 = new Point(center.X - length / 2, center.Y - height / 2);


            if (IsPointInsideHexagon(point, vertex1, vertex2, vertex3, vertex4, vertex5, vertex6))
            {
                return 0;
            }


            double distanceToEdge1 = point.DistanceToLineSegment(vertex1, vertex2);
            double distanceToEdge2 = point.DistanceToLineSegment(vertex2, vertex3);
            double distanceToEdge3 = point.DistanceToLineSegment(vertex3, vertex4);
            double distanceToEdge4 = point.DistanceToLineSegment(vertex4, vertex5);
            double distanceToEdge5 = point.DistanceToLineSegment(vertex5, vertex6);
            double distanceToEdge6 = point.DistanceToLineSegment(vertex6, vertex1);


            return Math.Min(distanceToEdge1, Math.Min(distanceToEdge2, Math.Min(distanceToEdge3,
                Math.Min(distanceToEdge4, Math.Min(distanceToEdge5, distanceToEdge6)))));
        }


        private bool IsPointInsideHexagon(Point p, Point v1, Point v2, Point v3, Point v4, Point v5, Point v6)
        {



            return IsPointInsideTriangle(p, v1, v2, v3) ||
                   IsPointInsideTriangle(p, v3, v4, v5) ||
                   IsPointInsideTriangle(p, v5, v6, v1);
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
