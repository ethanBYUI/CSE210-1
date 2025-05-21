using System;

class Fraction

{
    // attributes
    private int _top;
    private int _bottom;

    // behaviors

    public Fraction() //default to the number 1
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber) // default to whole number if bottom not given
    {
        wholeNumber = _top;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        this._top = top;
        this._bottom = bottom;
    }

    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        if (bottom == 0)
        {
            Console.WriteLine("Bottom cannot be zero.");
        }
        else
        {
            _bottom = bottom;
        }
    }

    public string getFractionString()
    {
        string text = $"{_top}/{_bottom}";
        return text;
    }

    public double getFractionDecimal()
    {
        return (double)_top / (double)_bottom;
    }

}