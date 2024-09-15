namespace Shapes

public class Shape
{
    protected Point center;
    protected double length;
    public Shape(double centerX, double centerY, double length)
    {
        this.Point = new Point(centerX, centerY);
        this.length = length;
    }
    public abstract double distanceToPoint(Point point);
}