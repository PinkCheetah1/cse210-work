// Derived class for simple goals
class SimpleGoal : Goal
{
    // Constructor to initialize simple goal
    public SimpleGoal(string name, string description, string pointsValue) : base(name, description, pointsValue)
    {
    }
    // Constructor for loading from file
    public SimpleGoal(string name, string description, string pointsValue, bool isComplete) : base(name, description, pointsValue)
    {
        base.SetIsComplete(isComplete);
    }
    // Override CheckOff method to mark the goal as complete and add points
    public override int CheckOff()
    {
        base.SetIsComplete(true);
        return base.GetPointsValue();
    }

    public override string RenderString()
    {
        return $"SimpleGoal||{GetName()}||{GetDescription()}||{GetPointsValue()}||{GetIsComplete()}";
    }

}
