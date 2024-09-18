using System;

namespace Shapes
{
    class Point
    {
        public readonly double X;
        public readonly double Y;
        public Point(double a, double b) { X = a; Y = b; }
        public double Distance(Point p)
        {
            return Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));
        }
        public double DistanceToLineSegment(Point v1, Point v2)
        {
            double x1 = v1.X, y1 = v1.Y, x2 = v2.X, y2 = v2.Y;

            double A = X - x1;
            double B = Y - y1;
            double C = x2 - x1;
            double D = y2 - y1;

            double dot = A * C + B * D;
            double len_sq = C * C + D * D;
            double param = -1;
            if (len_sq != 0) // in case of 0 length line
                param = dot / len_sq;

            double xx, yy;

            if (param < 0)
            {
                xx = x1;
                yy = y1;
            }
            else if (param > 1)
            {
                xx = x2;
                yy = y2;
            }
            else
            {
                xx = x1 + param * C;
                yy = y1 + param * D;
            }

            double dx = X - xx;
            double dy = Y - yy;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
