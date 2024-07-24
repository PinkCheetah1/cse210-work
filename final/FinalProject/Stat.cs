
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;

/// Statistic class
/// Holds a value for one of 
/// each of the player's stats
/// 
public class Stat
{
    // Attributes
    // Name, level, decay rate
    private string _name;
    private double _level;
    private double _decayRate;
    private DateTime _lastUpdateTime;

    // Constructors
    public Stat(string name, double level, double decayRate, DateTime lastUpdateTime)
    {
        _name = name;
        _level = level;
        _decayRate = decayRate;
        _lastUpdateTime = lastUpdateTime;
    }

    // Methods

    // Method to update the level based on the time elapsed
    public void Decay()
    {
        // Code written by ChatGPT with
        // lots of guidance
        DateTime now = DateTime.Now;
        TimeSpan elapsed = now - _lastUpdateTime;

        // Calculate the total hours elapsed
        double hoursElapsed = elapsed.TotalHours;

        // Apply decay
        _level = Math.Max(0.0, _level - (_decayRate * hoursElapsed));
        _level = Math.Min(100.0, _level);

        // Update the last update time
        _lastUpdateTime = now;
    }

    public void Increase(int increase)
    {
        _level = Math.Min(100.0, _level + increase);
        _level = Math.Max(0.0, _level);
    }

    public int GetLevel()
    {
        // Rounding to int to display a pretty number
        return (int)Math.Round(_level);
    }

    public string RenderSave()
    {
        // Small changes proposed by ChatGPT
        return $"{_name},{_level},{_decayRate},{_lastUpdateTime}";
    }
}