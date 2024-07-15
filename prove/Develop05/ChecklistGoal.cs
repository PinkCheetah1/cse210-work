// Derived class for checklist goals
class ChecklistGoal : Goal
{
    // Properties specific to checklist goals: completion goal, progress, bonus points
    private int _maxComplete;
    private int _numComplete;
    private int _bonus;

    // Constructor to initialize checklist goal
    public ChecklistGoal(string name, string description, string pointsValue, int maxComplete, int bonus) : base(name, description, pointsValue)
    {
        _maxComplete = maxComplete;
        _bonus = bonus;
        _numComplete = 0;
    }

    // Override CheckOff method to add points, increment progress, check for completion, and add bonus points if complete
    public override int CheckOff()
    {
        // TODO
        base.SetIsComplete(true);
        return base.GetPointsValue();
    }

    // Override Display method to show progress and completion goal

    public override void Display()
    {
        // TODO: update to be for Checklistfff
        string checkbox = "[ ]";
        if (GetIsComplete())
        {
            checkbox = "[x]";
        }
        Console.WriteLine($"{checkbox} {GetName()}, Description: {GetDescription()}, Points: {GetPointsValue()}");
    }
}