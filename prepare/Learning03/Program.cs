using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    // attributes

    //behaviors
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.getFractionString());
        Console.WriteLine(f1.getFractionDecimal());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.getFractionString());
        Console.WriteLine(f2.getFractionDecimal());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.getFractionString());
        Console.WriteLine(f3.getFractionDecimal());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.getFractionString());
        Console.WriteLine(f4.getFractionDecimal());
    }
}