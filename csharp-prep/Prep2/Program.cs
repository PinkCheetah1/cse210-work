using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade (Num 0-100): ");
        string gradeInput = Console.ReadLine();
        int gradeNumber = int.Parse(gradeInput);

        string gradeLetter = "";

        if (gradeNumber >= 90)
        {
            gradeLetter = "A";
        }
        else if (gradeNumber >= 80)
        {
            gradeLetter = "B";
        }
        else if (gradeNumber >= 70)
        {
            gradeLetter = "C";
        }
        else if (gradeNumber >= 60)
        {
            gradeLetter = "D";
        }
        else
        {
            gradeLetter = "F";
        }


        if (gradeNumber >= 60)
        {
            Console.WriteLine("Contrats! You've passed this class. ");
        }
        else
        {
            Console.WriteLine("You didn't pass this time. Keep working to get that grade up! ");
        }

        Console.WriteLine($"Your grade letter is {gradeLetter}. ");




    }
}