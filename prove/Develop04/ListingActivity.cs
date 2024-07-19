// Listing Activity 
// A 
// - List of prompts (?)
// - List of reflections (?)

// M 
// - Constructor
// - Start 
// - DisplayItemCount (ChatGPT suggestion)


using System.ComponentModel;
using Microsoft.VisualBasic;

public class ListingActivity : Activity
{
    // Attributes (none?)
    private int listingCount;

    // Constructor
    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }


    // Methods

    public void Start()
    {
        Console.Clear();
        OpenMessage();
        PromptForTime();
        Spinner();
        Console.Clear();
        Console.WriteLine("Get Ready... ");
        Spinner();
        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt: ");
        Console.WriteLine($" --- {GetRandomPrompt()} --- ");
        Console.Write("You may begin in: ");
        Countdown(5);
        Console.WriteLine();

        // Set timer to end activity
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_time);

        DateTime currentTime = DateTime.Now;
        listingCount = 0;
        while (currentTime < futureTime)
        {
            Console.Write("> ");
            Console.ReadLine(); 
            listingCount += 1;
            currentTime = DateTime.Now;
        }

        Console.WriteLine($"You listed {listingCount} items!!" );
        Console.WriteLine();
        Console.WriteLine("Well done!! ");
        Console.WriteLine();
        CloseMessage();
        Spinner();
        


    }


    public string GetRandomPrompt()
    {
        // Prompt list to choose from
        // List made by ChatGPT
        List<string> promptList = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        Random rand = new Random();
        int randomIndex = rand.Next(4);

        return promptList[randomIndex];
    }
}