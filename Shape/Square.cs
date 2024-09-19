using System;

namespace Shapes
{
    public class Square : Shape
    {
        public Square(Point center, double length) : base(center, length) { }
        public override double DistanceToPoint(Point point)
        {

            double halfSide = length / 2;


            double left = center.X - halfSide;
            double right = center.X + halfSide;
            double top = center.Y + halfSide;
            double bottom = center.Y - halfSide;


            if (point.X >= left && point.X <= right && point.Y >= bottom && point.Y <= top)
            {
                return 0;
            }


            double dx = new[] { left - point.X, 0, point.X - right }.Max();
            double dy = new[] { bottom - point.Y, 0, point.Y - top }.Max();


            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
