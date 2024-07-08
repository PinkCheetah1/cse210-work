// Square child class


public class Square : Shape
{
    private double _side;

    public Square(string color, double side) : base(color)
    {
        _side = side;
        SetColor(color);
    }
    public override double GetArea()
    {
        return _side * _side;
    }
}