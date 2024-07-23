// Menu class to handle user interactions and manage goals
class Menu
{
    // List to store goals
    // Variable to store user score
    private int score;

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
        string points = Console.ReadLine();
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
    public List<Goal> ReadGoalsFromFile(string filePath)
    {
        List<Goal> goals = new List<Goal>();

        string[] lines = File.ReadAllLines(filePath);

        int totalPoints = 0;
        if (int.TryParse(lines[0], out int points))
        {
            totalPoints = points;
        }

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(new[] { "||" }, StringSplitOptions.None);
            if (parts.Length == 0)
                continue;

            string goalType = parts[0];
            switch (goalType)
            {
                case "SimpleGoal":
                    if (parts.Length == 9)
                    {
                        goals.Add(new SimpleGoal(parts[1], parts[2], parts[3], bool.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]), int.Parse(parts[8])));
                    }
                    break;

                case "EternalGoal":
                    if (parts.Length == 8)
                    {
                        goals.Add(new EternalGoal(parts[1], parts[2], parts[3], int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7])));
                    }
                    break;

                case "ChecklistGoal":
                    if (parts.Length == 12)
                    {
                        goals.Add(new ChecklistGoal(parts[1], parts[2], parts[3], bool.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]), int.Parse(parts[8]), int.Parse(parts[9]), int.Parse(parts[10]), int.Parse(parts[11])));
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
            writer.WriteLine(score);
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.RenderString());
            }
        }
    }

    // Method to record an event (check off a goal)
    public void CheckOffGoal(int index, List<Goal> goals)
    {
        int pointsEarned = goals[index].CheckOff();
        score += pointsEarned;
        Console.WriteLine();
        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        Console.WriteLine($"You now have {score} points. ");
        Console.WriteLine();
    }

    public void PrintMenuOptions()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("    1. Create New Goal");
        Console.WriteLine("    2. List Goals");
        Console.WriteLine("    3. Save");
        Console.WriteLine("    4. Open Shop");
        Console.WriteLine("    5. Record Event");
        Console.WriteLine("    6. Quit");
    }

    public void DisplayPoints()
    {
        Console.WriteLine($"You have {score} points. ");
    }
}
