/// ProgressiveGoal outline:
/// Inherited from ChecklistGoal
/// 

// Derived class for checklist goals
public class ProgressiveGoal : ChecklistGoal
{
    // Properties specific to Progressive goals: completion goal, progress, bonus points, list of tasks
    private List<string> _steps;

    // Constructor to initialize goal
    public ProgressiveGoal(string name, string description, string pointsValue, int maxComplete, int bonus, int energyValue, int workValue, int healthValue, int funValue, List<string> steps) 
    : base(name, description, pointsValue, maxComplete, bonus, energyValue, workValue, healthValue, funValue)
    {
        _steps = steps;
    }

    // Constructor for loading from file
    public ProgressiveGoal(string name, string description, int pointsValue, int energyValue, int workValue, int healthValue, int funValue, bool isComplete, int maxComplete, int numComplete, int bonus, List<string> steps)
    : base(name, description, pointsValue, energyValue, workValue, healthValue, funValue, isComplete,  maxComplete, numComplete, bonus)
    {
        _steps = steps;
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
            SetDescription($"STEP {_numComplete}: {_steps[_numComplete]}");
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

    public override string RenderString()
    {
        string stepsString = string.Join(";;", _steps); // Join steps with a unique delimiter
        return $"ProgressiveGoal||{base.GetName()}||{base.GetDescription()}||{base.GetPointsValue()}||{base.GetEnergyValue()}||{base.GetWorkValue()}||{base.GetHealthValue()}||{base.GetFunValue()}||{base.GetIsComplete()}||{_maxComplete}||{_numComplete}||{_bonus}||{stepsString}";
    }
}