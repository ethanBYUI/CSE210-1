public class Circle : Shape
{
    //attributes
    private double _radius;
    
    //behaviors
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }
    public override double GetArea()
    {
        return _radius * _radius * Math.PI;
    }
}