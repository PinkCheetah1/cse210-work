// Derived class for simple goals
class SimpleGoal : Goal
{
    // Constructor to initialize simple goal
    public SimpleGoal(string name, string description, string pointsValue, int energyValue, int workValue, int healthValue, int funValue) 
    : base(name, description, pointsValue, energyValue, workValue, healthValue, funValue)
    {
    }
    // Constructor for loading from file
    public SimpleGoal(string name, string description, int pointsValue, int energyValue, int workValue, int healthValue, int funValue, bool isComplete) 
    : base(name, description, pointsValue, energyValue, workValue, healthValue, funValue)
    {
        base.SetIsComplete(isComplete);
    }
    // Override CheckOff method to mark the goal as complete and add points
    public override int CheckOff(Player player)
    {
        base.SetIsComplete(true);
        player.AddPoints(base.GetPointsValue());
        player.IncreaseStats(
            base.GetEnergyValue(),
            base.GetWorkValue(),
            base.GetHealthValue(),
            base.GetFunValue()
        );
        return base.GetPointsValue();
        
    }

    public override string RenderString()
    {
        return $"SimpleGoal||{GetName()}||{GetDescription()}||{GetPointsValue()}||{base.GetEnergyValue()}||{base.GetWorkValue()}||{base.GetHealthValue()}||{base.GetFunValue()}||{GetIsComplete()}";
    }

}
