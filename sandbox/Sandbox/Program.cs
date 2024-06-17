using System;
// using System.Security.Cryptography;
// System.Collections.Generic;

class Program
{

    // Data is private
    // Private says, "u cannot look at this from outside ):<"
    static void Main(string[] args)
    {
        Console.WriteLine("Bonjour Tout Le Monde");

        Circle myCircle = new Circle(10);
        Console.WriteLine($"{myCircle.GetArea()}");

        Circle unitCircle = new Circle(1);
        Console.WriteLine($"{unitCircle.GetCircumference()}");
    }
}
