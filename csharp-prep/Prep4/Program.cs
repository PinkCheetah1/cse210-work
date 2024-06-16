using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int newNumber;
        int sum = 0;
        double average;
        int biggest;

        do
        {
            // Ask the user for a number :D 
            Console.Write("Enter number: ");
            string userInputNumber = Console.ReadLine();
            newNumber = int.Parse(userInputNumber);


            // Ensure 0 does not get added to list
            if (newNumber != 0)
            {
                numbers.Add(newNumber);
            }
        }
        while (newNumber != 0); // End loop when user enters 0


        // Assign first number as "biggest value"
        biggest = numbers[0];


        // When user has finished entering numbers, compute total value
        foreach (int number in numbers)
        {
            sum += number;

            if (biggest < number)
            {
                biggest = number;
            }

        }

        average = sum / (double)numbers.Count;

        Console.WriteLine($"The Sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The biggest number is: {biggest}");

    }
}