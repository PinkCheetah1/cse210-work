using System;



// Program
// A:
// - isRunning (bool)


// Do:
//     Print scripture for user
//     Ask the user to press enter or quit
// if Enter:
//     Run scripture.HideWords
//     Display scripture to user
//     If scripture is all hidden, quit Program
// if quit: 
//     Quit


class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;
        Reference reference = new Reference("John", "14", "27");
        Scripture scripture = new Scripture(reference, "Peace I leave with you; my peace I give you. I do not give to you as the world gives. Do not let your hearts be troubled and do not be afraid.");

        scripture.DisplayRender();
        while (isRunning)
        {
            if (scripture.AllWordsHidden())
            {
                isRunning = false;
            }
            Console.WriteLine("Press ENTER to memorize, or type \"q\" to quit: ");
            string userInput = Console.ReadLine();

            // Menu

            if (userInput == "")
            {
                Console.Clear();
                scripture.HideWords(3);
                scripture.DisplayRender();
            }

            else if (userInput == "q")
            {
                isRunning = false;
            }
        }
        Console.WriteLine("Bye bye!");
    }
}