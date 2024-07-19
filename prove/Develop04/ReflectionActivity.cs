// Reflection activity
// A 

// M 
// - Constructor
// - Start 
// - Select Prompt from list
// - Select Reflection from list 

public class ReflectionActivity : Activity
{
    // Constructor

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }


    // Methods

    public void Start()
    {
        Console.Clear();
        OpenMessage();
        PromptForTime();
        Console.Clear();
        Spinner();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($" --- {GetRandomPrompt()} --- ");
        Console.WriteLine("When you have something in mind, press ENTER to continue. ");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience. ");
        Console.Write("You may begin in: ");
        Countdown(5);
        Console.Clear();

        // The following runs the program till it has reached the time limit
        for (int i = 0; i < _time/10; i++)
        {
            Console.Write(GetRandomReflection());
            Spinner(10);
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("Well done!! ");
        Spinner();
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
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        Random rand = new Random();
        int randomIndex = rand.Next(4);

        return promptList[randomIndex];
    }

    public string GetRandomReflection()
    {
        // Prompt list to choose from
        // List made by ChatGPT 
        List<string> reflectionsList = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        Random rand = new Random();
        int randomIndex = rand.Next(4);

        return reflectionsList[randomIndex];
    }

}
