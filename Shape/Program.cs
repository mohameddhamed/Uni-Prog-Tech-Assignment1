using System;
using System.Collections.Generic;
using TextFile;

namespace Shapes
{
    class Program
    {
        static void Main()
        {
            try
            {

                TextFileReader reader = new TextFileReader("input.txt");


                reader.ReadInt(out int numberOfShapes);
                List<Shape> shapes = new List<Shape>();


                for (int i = 0; i < numberOfShapes; i++)
                {
                    reader.ReadChar(out char shapeType);
                    reader.ReadDouble(out double centerX);
                    reader.ReadDouble(out double centerY);
                    reader.ReadDouble(out double length);


                    switch (shapeType)
                    {
                        case 'C':
                            shapes.Add(new Circle(new Point(centerX, centerY), length));
                            break;
                        case 'T':
                            shapes.Add(new RegularTriangle(new Point(centerX, centerY), length));
                            break;
                        case 'S':
                            shapes.Add(new Square(new Point(centerX, centerY), length));
                            break;
                        case 'H':
                            shapes.Add(new RegularHexagon(new Point(centerX, centerY), length));
                            break;
                        default:
                            Console.WriteLine($"Unknown shape type: {shapeType}");
                            break;
                    }
                }


                reader.ReadDouble(out double pointX);
                reader.ReadDouble(out double pointY);
                Point targetPoint = new Point(pointX, pointY);


                Shape closestShape = null;
                double closestDistance = double.MaxValue;

                foreach (var shape in shapes)
                {
                    double distance = shape.DistanceToPoint(targetPoint);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestShape = shape;
                    }
                }


                if (closestShape != null)
                {
                    Console.WriteLine($"The closest shape to the point ({pointX}, {pointY}) is a {closestShape.GetType().Name} with a distance of {closestDistance}.");
                }
                else
                {
                    Console.WriteLine("No shapes found.");
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("The input file 'input.txt' does not exist.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
