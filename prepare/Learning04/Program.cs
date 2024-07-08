using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("purple", 2.0);
        // Console.WriteLine($"Square: {square.GetColor()}, {square.GetArea()}");
        Circle circle = new Circle("pink", 2.0);
        Rectangle rectangle = new Rectangle("orange", 2.0, 3.0);

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(circle);
        shapes.Add(rectangle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"shape: {shape.GetColor()}, {shape.GetArea()}");
        }
    }
}