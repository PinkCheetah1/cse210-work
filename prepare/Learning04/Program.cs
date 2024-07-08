using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("purple", 2.0);
        Console.WriteLine($"Square: {square.GetColor}, {square.GetArea}");
    }
}