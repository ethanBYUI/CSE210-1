using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square s1 = new Square("Yellow", 9);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Red", 10, 2);
        shapes.Add(s2);

        Circle s3 = new Circle("Sloppy Orange", 5);
        shapes.Add(s3);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();

            Console.WriteLine($"The {color} has {area} area.");
        }
    }
}