// Derived class for eternal goals
class EternalGoal : Goal
{
    // Constructor to initialize eternal goal
    public EternalGoal(string name, string description, string pointsValue, int energyValue, int workValue, int healthValue, int funValue) 
    : base(name, description, pointsValue, energyValue, workValue, healthValue, funValue)
    {

    }

    // Override CheckOff method to add points without marking the goal as complete

    public override int CheckOff()
    {
        base.SetIsComplete(true);
        return base.GetPointsValue();
    }

    public override string RenderString()
    {
        return $"EternalGoal||{base.GetName()}||{base.GetDescription()}||{base.GetPointsValue()}||{base.GetEnergyValue}||{base.GetWorkValue}||{base.GetHealthValue}||{base.GetFunValue}";
    }
}