using System;

namespace Shapes
{
    public class Shape
    {
        protected Point center;
        protected double length;
        public Shape(Point center, double length)
        {
            this.center = center;
            this.length = length;
        }
        public virtual double DistanceToPoint(Point point)
        {
            return center.Distance(point);
        }
    }
}