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
    private int _pointsValue;
    private bool _isComplete;
    private int _energyValue;
    private int _workValue;
    private int _healthValue;
    private int _funValue;

    // Constructor to initialize common attributes ):<
    public Goal(string name, int pointsValue, int energyValue, int workValue, int healthValue, int funValue)
    {
        _name = name;
        _pointsValue = pointsValue;
        _isComplete = false;
        _energyValue = energyValue;
        _workValue = workValue;
        _healthValue = healthValue;
        _funValue = funValue;
    }

    // In case they send me a string for pointsValue
    public Goal(string name, string pointsValue, int energyValue, int workValue, int healthValue, int funValue)
    {
        _name = name;
        _pointsValue = int.Parse(pointsValue);
        _isComplete = false;
        _energyValue = energyValue;
        _workValue = workValue;
        _healthValue = healthValue;
        _funValue = funValue;
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

    public int GetEnergyValue()
    {
        return _energyValue;
    }
    public void SetEnergyValue(int energyValue)
    {
        _energyValue = energyValue;
    }

        public int GetWorkValue()
    {
        return _workValue;
    }
    public void SetWorkValue(int workValue)
    {
        _workValue = workValue;
    }

        public int GetFunValue()
    {
        return _funValue;
    }
    public void SetFunValue(int funValue)
    {
        _funValue = funValue;
    }

        public int GetHealthValue()
    {
        return _healthValue;
    }
    public void SetHealthValue(int healthValue)
    {
        _healthValue = healthValue;
    }


    // Abstract method for checking off a goal
    public abstract int CheckOff(Player player);

    // Abstract method to return string for saving to file
    public abstract string RenderString();

    // Virtual method to display goal details
    public virtual string RenderDisplay()
    {
        string checkbox = "[ ]";
        if (GetIsComplete())
        {
            checkbox = "[x]";
        }
        return $"{checkbox} {GetName()} | E: {_energyValue} | W: {_workValue} | H: {_healthValue} | F: {_funValue} |";
    }

}
