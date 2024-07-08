public class ConstructionWorker : Employee
{
    public ConstructionWorker(string name, double hours, double wage) : base(name, hours, wage)
    {

    }

    public override double GetPay()
    {
        return base.GetPay() + 1000;
    }
}