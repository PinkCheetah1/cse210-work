// Breathing activity
// A 
// - List of prompts (?)
// - List of reflections (?)

// M 
// - Constructor
// - Start activity


public class BreathingActivity : Activity
{
    // Attributes: none ._.

    // Constructor
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Start()
    {
        Console.Clear();
        OpenMessage();
        PromptForTime();
        int timesToLoop = _time/10;

        Console.WriteLine("Get ready... ");
        Spinner();

        Console.WriteLine();
        for (int i = 0; i < timesToLoop; i++)
        {
            Console.Write("Breath in... ");
            Countdown(4);
            Console.WriteLine();
            Console.Write("Now breath out... ");
            Countdown(6);
            Console.WriteLine();
            Console.WriteLine();
        }
        Console.WriteLine("Well Done!!");
        Spinner();
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_time} seconds of the {_name}!");
        Spinner();
        Console.Clear();
    }

    
}