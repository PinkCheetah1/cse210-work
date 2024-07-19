// Parent class:
// A
// - name of activity
// - description of activity
// - time for activity

// M
// - open message
// - close message
// - spinner (length)
// - prompt time
// - countdown (length)
using System;
using System.Threading;
public class Activity
{
    // Attributes:
    protected string _name;
    protected string _description;
    protected int _time;

    // Constructor:
    // public Activity(string name, string description)
    // {
    //     _name = name;
    //     _description = description;
    // }

    // Methods
    public void OpenMessage()
    {
        /// ChatGPT with prompt: 
        /// Please write the opening message method. 
        /// The method will display, "Welcome to the [activity name]", 
        /// a new line, and then the description of the activity
        Console.WriteLine($"Welcome to the {_name}. ");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    public void CloseMessage()
    {
        Console.WriteLine($"You have completed another {_time} seconds of the {_name}!");
    }

    public void PromptForTime()
    {
        /// ChatGPT with prompt: 
        /// Please write the method that prompts the user for the length of their activity. 
        /// It should ask, "How long, in seconds, would you like for your session?" 
        /// and save it as an int. 
        /// 

        Console.Write("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        int duration;
        while (!int.TryParse(input, out duration) || duration <= 0)
        {
            Console.Write("Please enter a valid positive integer for the duration in seconds: ");
            input = Console.ReadLine();
        }
        _time = duration;
    }

    public void Spinner(int duration = 5)
    {
        for (int i = 0; i <= (duration/2); i++)
        {
            Console.Write("|");
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(200);
            Console.Write("\b \b");
        }
    }

    public void Countdown(int duration)
    {
        for (int i = duration; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            string numString = i.ToString();
            foreach (char character in numString)
            {
                Console.Write("\b \b");
            }
        }
    }

    public int GetTime()
    {
        return _time;
    }

}

