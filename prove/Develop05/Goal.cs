public abstract class Goal
{
    /// <summary>
    /// Used ChatGPT to create comments outline based on
    /// my program design 
    /// 
    /// Attributes:
    /// _name string (tracks name)
    /// _description string ()
    /// </summary>

    // Attributes
    private string _name;
    private string _description;
    private int _pointsValue;
    private bool _isComplete;

    // Constructor to initialize common attributes ):<
    public Goal(string name, string description, int pointsValue)
    {
        _name = name;
        _description = description;
        _pointsValue = pointsValue;
        _isComplete = false;
    }

    // In case they send me a string for pointsValue
    public Goal(string name, string description, string pointsValue)
    {
        _name = name;
        _description = description;
        _pointsValue = int.Parse(pointsValue);
        _isComplete = false;
    }

    // Getter and setter methods
    // Getters and Setters written by ChatGPT
    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public int GetPointsValue()
    {
        return _pointsValue;
    }

    public void SetPointsValue(int pointsValue)
    {
        _pointsValue = pointsValue;
    }

    public bool GetIsComplete()
    {
        return _isComplete;
    }

    public void SetIsComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }

    // Abstract method for checking off a goal
    public abstract int CheckOff();

    // Virtual method to display goal details
    public virtual void Display()
    {
        string checkbox = "[ ]";
        if (GetIsComplete())
        {
            checkbox = "[x]";
        }
        Console.WriteLine($"{checkbox} {GetName()}, Description: {GetDescription()}, Points: {GetPointsValue()}");
    }
}
