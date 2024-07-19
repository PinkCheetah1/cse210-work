using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathing = new BreathingActivity();
        ReflectionActivity reflection = new ReflectionActivity();
        ListingActivity listing = new ListingActivity();
        bool isRunning = true;
        int totalSeconds = 0;


        while (isRunning)
        {
            // Menu produced by ChatGPT
            Console.Clear();
            Console.WriteLine($"Total Seconds Completed: {totalSeconds} ");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Call the method to start breathing activity
                    breathing.Start();
                    totalSeconds += breathing.GetTime();
                    break;
                case "2":
                    // Call the method to start reflecting activity
                    reflection.Start();
                    totalSeconds += reflection.GetTime();
                    break;
                case "3":
                    // Call the method to start listing activity
                    listing.Start();
                    totalSeconds += listing.GetTime();
                    break;
                case "4":
                    isRunning = false;
                    Console.WriteLine($"Thank you for completing {totalSeconds} seconds of activities today. ");
                    Console.WriteLine("Quitting the program...");
                    breathing.Spinner();
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }

    }
}