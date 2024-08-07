// Derived class for checklist goals
public class ChecklistGoal : Goal
{
    // Properties specific to checklist goals: completion goal, progress, bonus points
    protected int _maxComplete;
    protected int _numComplete;
    protected int _bonus;

    // Constructor to initialize checklist goal
    public ChecklistGoal(string name, string pointsValue, int maxComplete, int bonus, int energyValue, int workValue, int healthValue, int funValue) 
    : base(name, pointsValue, energyValue, workValue, healthValue, funValue)
    {
        _maxComplete = maxComplete;
        _bonus = bonus;
        _numComplete = 0;
    }

    // Constructor for loading from file
    public ChecklistGoal(string name, int pointsValue, int energyValue, int workValue, int healthValue, int funValue, bool isComplete,int maxComplete, int numComplete, int bonus)
    : base(name, pointsValue, energyValue, workValue, healthValue, funValue)
    {
        _maxComplete = maxComplete;
        _bonus = bonus;
        _numComplete = numComplete;
        base.SetIsComplete(isComplete);
    }

    // Override CheckOff method to add points, increment progress, check for completion, and add bonus points if complete
    public override int CheckOff(Player player)
    {
        // TODO
        int pointsEarned = 0;
        pointsEarned += GetPointsValue();
        if (_numComplete == _maxComplete)
        {
            SetIsComplete(true);
            pointsEarned += _bonus;
            Console.WriteLine($"Congrats! You get a bonus of {_bonus} for completing this task! ");
        }
        else
        {
            _numComplete += 1;
        }
        
        player.AddPoints(pointsEarned);
        player.IncreaseStats(
            base.GetEnergyValue(),
            base.GetWorkValue(),
            base.GetHealthValue(),
            base.GetFunValue()
        );
        return pointsEarned;
    }

    // Override Display method to show progress and completion goal

    public override string RenderDisplay()
    {
        string checkbox = "[ ]";
        if (GetIsComplete())
        {
            checkbox = "[x]";
        }
        return $"{checkbox} {GetName()} ({_numComplete}/{_maxComplete}), Points: {GetPointsValue()} | E: {base.GetEnergyValue()} | W: {base.GetWorkValue()} | H: {base.GetHealthValue()} | F: {base.GetFunValue()} |";
    }

    public override string RenderString()
    {
        return $"ChecklistGoal||{base.GetName()}||{base.GetPointsValue()}||{base.GetEnergyValue()}||{base.GetWorkValue()}||{base.GetHealthValue()}||{base.GetFunValue()}||{base.GetIsComplete()}||{_maxComplete}||{_numComplete}||{_bonus}";
    }
}