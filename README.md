# Task Description

## Common Requirements:

- Use a Collection to store the objects of classes derived from the same super class.
- Use `foreach` to process the elements of a Collection.
- Validate the data you get from the user; throw an Exception for invalid data and handle the thrown Exceptions.

### The documentation should contain:

- The description of the exercise
- The class diagram
- A short description of each method
- The testing (white box / black box)

---

Choose a point on the plane, and fill a collection with several regular shapes (circle, regular triangle, square, regular hexagon). Which shapes lie the closest to the point?

In the case of the circle, the distance is measured from the line of the circle, if the point lies outside of the circle. If a point lies inside of a circle, their distance is considered as zero.

Each shape can be represented by its center and side length (or radius), assuming that one side of the polygons is parallel with the x-axis, and its nodes lie on or above this side.

Load and create the shapes from a text file. The first line of the file contains the number of shapes, and each following line contains a shape. The first character will identify the type of the shape, followed by the center coordinate and the side length or radius.

Manage the shapes uniformly, so derive them from the same superclass.

---

# Usage

cd Shape/
dotnet run

## Testing

The project includes unit tests to ensure the correctness of the Shape class. to run tests:

cd Shape.Test/
dotnet test

## Documentation

A detailed documentation for this project exists in the file documentation.pdf
