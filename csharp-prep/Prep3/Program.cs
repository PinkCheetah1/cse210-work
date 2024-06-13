using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int randomNumber = randomGenerator.Next(1, 100);
        
        bool numberIsGuessed = false;
        while (numberIsGuessed == false)
        {

            // Guess the input from the user
            Console.Write("What is your guess? ");
            string input = Console.ReadLine();
            int guess = int.Parse(input);

            if (guess == randomNumber)
            {
                numberIsGuessed = true;
                Console.WriteLine("You guessed it!");
            }
            else if (guess < randomNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }
        }

    }
}