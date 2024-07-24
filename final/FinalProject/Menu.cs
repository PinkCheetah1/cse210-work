// Menu class to handle user interactions and manage goals
class Menu
{
    // List to store goals
    // Variable to store user score

    // Method to create a new simple goal

    // New___Goal methods and Load method 
    // updated by ChatGPT and reviewed by me
    // to save time writing mundane code <3


    public Goal NewSimpleGoal()
    {
        Console.Write("Please enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Please enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Please enter goal points value: ");
        string points = Console.ReadLine();
        Console.Write("Please enter energy value: ");
        int energy = int.Parse(Console.ReadLine());
        Console.Write("Please enter work value: ");
        int work = int.Parse(Console.ReadLine());
        Console.Write("Please enter health value: ");
        int health = int.Parse(Console.ReadLine());
        Console.Write("Please enter fun value: ");
        int fun = int.Parse(Console.ReadLine());
        Goal goal = new SimpleGoal(name, description, points, energy, work, health, fun);
        return goal;
    }

    // Method to create a new checklist goal
    public Goal NewChecklistGoal()
    {
        Console.Write("Please enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Please enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Please enter goal points value: ");
        string points = Console.ReadLine();
        Console.Write("Please enter the number of times to complete this goal: ");
        int maxComplete = int.Parse(Console.ReadLine());
        Console.Write("Please enter completion bonus: ");
        int bonus = int.Parse(Console.ReadLine());
        Console.Write("Please enter energy value: ");
        int energy = int.Parse(Console.ReadLine());
        Console.Write("Please enter work value: ");
        int work = int.Parse(Console.ReadLine());
        Console.Write("Please enter health value: ");
        int health = int.Parse(Console.ReadLine());
        Console.Write("Please enter fun value: ");
        int fun = int.Parse(Console.ReadLine());
        Goal goal = new ChecklistGoal(name, description, points, maxComplete, bonus, energy, work, health, fun);
        return goal;
    }

    // Method to create a new eternal goal
    public Goal NewEternalGoal()
    {
        Console.Write("Please enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Please enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Please enter goal points value: ");
        int points = int.Parse(Console.ReadLine());
        Console.Write("Please enter energy value: ");
        int energy = int.Parse(Console.ReadLine());
        Console.Write("Please enter work value: ");
        int work = int.Parse(Console.ReadLine());
        Console.Write("Please enter health value: ");
        int health = int.Parse(Console.ReadLine());
        Console.Write("Please enter fun value: ");
        int fun = int.Parse(Console.ReadLine());
        Goal goal = new EternalGoal(name, description, points, energy, work, health, fun);
        return goal;
    }

    public Goal NewProgressiveGoal()
    {
        bool hasPressedEnter = false;
        List<string> steps = new List<string>();
        Console.Write("Please enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Please enter a step for this task: ");
        string step = Console.ReadLine();
        steps.Add(step);
        while (!hasPressedEnter)
        {
            Console.Write("Please enter a step, or press ENTER to finish adding steps: ");
            step = Console.ReadLine();
            if (step != "")
            {
            steps.Add(step);
            }
        }
        Console.Write("Please enter goal points value: ");
        string points = Console.ReadLine();
        Console.Write("Please enter completion bonus: ");
        int bonus = int.Parse(Console.ReadLine());
        Console.Write("Please enter energy value: ");
        int energy = int.Parse(Console.ReadLine());
        Console.Write("Please enter work value: ");
        int work = int.Parse(Console.ReadLine());
        Console.Write("Please enter health value: ");
        int health = int.Parse(Console.ReadLine());
        Console.Write("Please enter fun value: ");
        int fun = int.Parse(Console.ReadLine());
        int maxComplete = steps.Count;
        string description = $"STEP 1: {steps[0]}";
        Goal goal = new ProgressiveGoal(name, description, points, maxComplete, bonus, energy, work, health, fun, steps);
        return goal;
    }

    // Method to list all goals
    public void DisplayGoals(List<Goal> goals)
    {
        int i = 0;
        foreach (Goal goal in goals)
        {
            i += 1;
            Console.WriteLine($"{i}. {goal.RenderDisplay()}");
        }
    }

    // Method to load goals from file
    // Method to load goals from file
    public List<Goal> ReadGoalsFromFile(string filePath)
    {
        List<Goal> goals = new List<Goal>();

        // Read all lines from the file
        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            // Split the line into parts using the delimiter "||"
            string[] parts = line.Split(new[] { "||" }, StringSplitOptions.None);

            // Ensure the line has data
            if (parts.Length == 0)
                continue;

            string goalType = parts[0];
            switch (goalType)
            {
                case "SimpleGoal":
                    // Check for the correct number of parts for SimpleGoal
                    if (parts.Length == 9)
                    {
                        goals.Add(new SimpleGoal(
                            parts[1], // Name
                            parts[2], // Description
                            int.Parse(parts[3]), // Points
                            int.Parse(parts[4]), // Energy
                            int.Parse(parts[5]), // Work
                            int.Parse(parts[6]), // Health
                            int.Parse(parts[7]), // Fun
                            bool.Parse(parts[8]) // IsCompleted
                        ));
                    }
                    break;

                case "EternalGoal":
                    // Check for the correct number of parts for EternalGoal
                    if (parts.Length == 8)
                    {
                        goals.Add(new EternalGoal(
                            parts[1], // Name
                            parts[2], // Description
                            int.Parse(parts[3]), // Points
                            int.Parse(parts[4]), // Energy
                            int.Parse(parts[5]), // Work
                            int.Parse(parts[6]), // Health
                            int.Parse(parts[7]) // Fun
                        ));
                    }
                    break;

                case "ChecklistGoal":
                    // Check for the correct number of parts for ChecklistGoal
                    if (parts.Length == 12)
                    {
                        goals.Add(new ChecklistGoal(
                            parts[1], // Name
                            parts[2], // Description
                            int.Parse(parts[3]), // Points
                            int.Parse(parts[4]), // Energy
                            int.Parse(parts[5]), // Work
                            int.Parse(parts[6]), // Health
                            int.Parse(parts[7]), // Fun
                            bool.Parse(parts[8]), // IsCompleted
                            int.Parse(parts[9]), // MaxComplete
                            int.Parse(parts[10]), // NumComplete
                            int.Parse(parts[11]) // Bonus
                        ));
                    }
                    break;

                case "ProgressiveGoal":
                    // Check for the correct number of parts for ProgressiveGoal
                    if (parts.Length == 13)
                    {
                        string[] stepsArray = parts[12].Split(new[] { ";;" }, StringSplitOptions.None);
                        List<string> steps = new List<string>(stepsArray);
                        goals.Add(new ProgressiveGoal(
                            parts[1], // Name
                            parts[2], // Description
                            int.Parse(parts[3]), // Points
                            int.Parse(parts[4]), // Energy
                            int.Parse(parts[5]), // Work
                            int.Parse(parts[6]), // Health
                            int.Parse(parts[7]), // Fun
                            bool.Parse(parts[8]), // IsCompleted
                            int.Parse(parts[9]), // MaxComplete
                            int.Parse(parts[10]), // Bonus
                            int.Parse(parts[11]), // NumComplete
                            steps // Steps
                        ));
                    }
                    break;

                default:
                    throw new InvalidOperationException($"Unknown goal type: {goalType}");
            }
        }

        return goals;
    }


    // Method to save goals to file
    public void WriteGoalsToFile(string filePath, List<Goal> goals)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.RenderString());
            }
        }
    }

    // Method to record an event (check off a goal)


}
