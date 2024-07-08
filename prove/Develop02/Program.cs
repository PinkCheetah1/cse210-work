using System;
using System.IO; 

class Program
{
    static void Main(string[] args)
    {


        //Variables
        bool isRunning = true;
        string userInput;
        Journal journal = new Journal();

        //Write instructions

        //Loop printing 
        do
        {
        Console.WriteLine("Please select one of the following choices: ");
        Console.WriteLine("1. Write"); // Done
        Console.WriteLine("2. Display"); // Done
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save"); // Done
        Console.WriteLine("5. Quit"); // Done

        Console.Write("What would you like to do? ");
        userInput = Console.ReadLine();
        if (userInput == "1")
        {
            // MENU ITEM: Write
            journal.NewEntry();
        }

        else if (userInput == "2")
        {
            // MENU ITEM: Display
            journal.Display();
        }

        else if (userInput == "3")
        {
            //MENU ITEM: Load
            Console.Write("Please enter file name: ");
            string file = Console.ReadLine();
            journal.Load(file);
        }

        else if (userInput == "4")
        {
            // MENU ITEM: Save
            Console.Write("Please enter file: ");
            string file = Console.ReadLine();
            journal.Save(file);
        }

        else if (userInput == "5")
        {
            // MENU ITEM: Quit
            isRunning = false;
            Console.WriteLine("Bye bye!");
        }
        



        } while (isRunning);
    }
}