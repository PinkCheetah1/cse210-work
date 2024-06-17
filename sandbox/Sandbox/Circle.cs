
class Circle
{
    private double _radius;

    // Constructor of your class MUST be the same
    // as the name of your class
    public Circle(double radius = 0.0) // Zero out value if no value (good thing to do)
    {
        _radius = radius; // Take radius passed in, set to local radius
    }

    public double GetArea()
    {
        return Math.PI * _radius * _radius;
    }

    public double GetDiameter()
    {
        return _radius * 2;
    }

    public double GetCircumference()
    {
        return 2 * _radius * Math.PI;
    }

    public double GetRadius()
    {
        return _radius;
    }

    public void SetRadius(double radius)
    {
        _radius = radius;
    }


}