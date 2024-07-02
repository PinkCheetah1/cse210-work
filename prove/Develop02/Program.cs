using System;

class Program
{
    static void Main(string[] args)
    {


        //Variables
        bool isRunning = true;
        string userInput;

        //Write instructions

        //Loop printing 
        do
        {
        Console.WriteLine("Please select one of the following choices: ");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");

        Console.Write("What would you like to do? ");
        userInput = Console.ReadLine();
        if (userInput == "1")
        {
            //MENU ITEM: Write
        }
        else if (userInput == "2")
        {
            //MENU ITEM: Display
        }

        else if (userInput == "3")
        {
            //MENU ITEM: Load
        }

        else if (userInput == "4")
        {
            //MENU ITEM: Save
        }

        else if (userInput == "5")
        {
            isRunning = false;
            Console.WriteLine("Bye bye!");
        }
        



        } while (isRunning);
    }
}