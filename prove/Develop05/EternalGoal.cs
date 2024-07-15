// Derived class for eternal goals
class EternalGoal : Goal
{
    // Constructor to initialize eternal goal
    public EternalGoal(string name, string description, string pointsValue) : base(name, description, pointsValue)
    {

    }

    // Override CheckOff method to add points without marking the goal as complete

        public override int CheckOff()
    {
        base.SetIsComplete(true);
        return base.GetPointsValue();
    }
}