// Derived class for eternal goals
class EternalGoal : Goal
{
    // Constructor to initialize eternal goal
    public EternalGoal(string name, int pointsValue, int energyValue, int workValue, int healthValue, int funValue) 
    : base(name, pointsValue, energyValue, workValue, healthValue, funValue)
    {

    }

    // Override CheckOff method to add points without marking the goal as complete

    public override int CheckOff(Player player)
    {
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
        return $"EternalGoal||{base.GetName()}||{base.GetPointsValue()}||{base.GetEnergyValue()}||{base.GetWorkValue()}||{base.GetHealthValue()}||{base.GetFunValue()}";
    }
}