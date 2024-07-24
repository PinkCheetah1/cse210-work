public class Player
{
    // Attributes
    private string _name;
    private int _points;
    private Stat _energy;
    private Stat _work;
    private Stat _health;
    private Stat _fun;

    // Constructors
    public Player(string name, int points, Stat energy, Stat work, Stat health, Stat fun)
    {
        _name = name;
        _points = points;
        _energy = energy;
        _work = work;
        _health = health;
        _fun = fun;
    }

    // Methods

    // Method to save user data to a file
    // Save and load written by ChatGPT
    // Very complicated, but I do understand
    // after getting help from ChatGPT :D
    public void Save(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(_name);
            writer.WriteLine(_points);

            // Save each stat's data using RenderSave
            writer.WriteLine(_energy.RenderSave());
            writer.WriteLine(_work.RenderSave());
            writer.WriteLine(_health.RenderSave());
            writer.WriteLine(_fun.RenderSave());
        }
    }

    // Method to load user data from a file
    public static Player Load(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string name = reader.ReadLine();
            int points = int.Parse(reader.ReadLine());

            // Load each stat's data
            Stat energy = LoadStat(reader.ReadLine());
            Stat work = LoadStat(reader.ReadLine());
            Stat health = LoadStat(reader.ReadLine());
            Stat fun = LoadStat(reader.ReadLine());

            return new Player(name, points, energy, work, health, fun);
        }
    }

    // Helper method to load individual Stat data from a saved string
    private static Stat LoadStat(string data)
    {
        string[] parts = data.Split(',');

        // Parse the data
        string name = parts[0];
        double level = double.Parse(parts[1]);
        double decayRate = double.Parse(parts[2]);
        DateTime lastUpdateTime = DateTime.Parse(parts[3]);

        // Create and return a new Stat object
        return new Stat(name, level, decayRate, lastUpdateTime);
    }   

    public void IncreaseStats(int energyIncrease, int workIncrease, int healthIncrease, int funIncrease)
    {
        // This method increases all stats by respective amounts
        _energy.Increase(energyIncrease);
        _work.Increase(workIncrease);
        _health.Increase(healthIncrease);
        _fun.Increase(funIncrease);
    }

    public void DecayStats()
    {
        _energy.Decay();
        _work.Decay();
        _health.Decay();
        _fun.Decay();
    }

    public string RenderStatsDisplay()
    {
        return $"--- | ENERGY: {_energy.GetLevel()} | WORK: {_work.GetLevel()} | HEALTH: {_health.GetLevel()} | FUN: {_fun.GetLevel()} | POINTS: {_points} | ---";
    }

    public int GetPoints()
    {
        return _points;
    }

    public void AddPoints(int newPoints)
    {
        _points += newPoints;
    }
}
