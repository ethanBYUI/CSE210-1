public class Rectangle : Shape
{
    //attributes
    private double _length;
    private double _width;
    
    //behaviors
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    public override double GetArea()
    {
        return _length * _width;
    }
}