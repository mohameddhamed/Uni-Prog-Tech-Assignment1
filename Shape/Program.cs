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
                // Initialize the TextFileReader with the input file
                TextFileReader reader = new TextFileReader("input.txt");

                // Read the number of shapes from the file
                reader.ReadInt(out int numberOfShapes);
                List<Shape> shapes = new List<Shape>();

                // Read each shape's data and create the corresponding shape
                for (int i = 0; i < numberOfShapes; i++)
                {
                    reader.ReadChar(out char shapeType);  // Shape type is a single character
                    reader.ReadDouble(out double centerX);
                    reader.ReadDouble(out double centerY);
                    reader.ReadDouble(out double length);

                    // Instantiate shapes based on their type
                    switch (shapeType)
                    {
                        case 'C':  // Circle
                            shapes.Add(new Circle(new Point(centerX, centerY), length));
                            break;
                        case 'T':  // Regular Triangle
                            shapes.Add(new RegularTriangle(new Point(centerX, centerY), length));
                            break;
                        case 'S':  // Square
                            shapes.Add(new Square(new Point(centerX, centerY), length));
                            break;
                        case 'H':  // Regular Hexagon
                            shapes.Add(new RegularHexagon(new Point(centerX, centerY), length));
                            break;
                        default:
                            Console.WriteLine($"Unknown shape type: {shapeType}");
                            break;
                    }
                }

                // Read the point to calculate the distance from
                reader.ReadDouble(out double pointX);
                reader.ReadDouble(out double pointY);
                Point targetPoint = new Point(pointX, pointY);

                // Find the closest shape to the given point
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

                // Output the result
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
