// Menu class to handle user interactions and manage goals
class Menu
{
    // List to store goals
    private List<Goal> goals;
    // Variable to store user score
    private int score;

    // Method to create a new goal
    public Goal NewSimple()
    {
        Console.Write("Please enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Please enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Please enter goal points value: ");
        string points = Console.ReadLine();
        Goal goal = new SimpleGoal(name, description, points);
        return goal;
    }
    
        public void NewChecklist()
    {
        
    }

        public void NewEternal()
    {
        
    }

    // Method to list all goals
    // Method to save goals to a file
    // Method to load goals from a file
    // Method to record an event (check off a goal)
    // Method to quit the application
}