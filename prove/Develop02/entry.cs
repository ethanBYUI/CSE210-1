using System;

class Entry
{
    private string Date { get; set; }  //{ get; set; } gets the value and then sets a value. According to stackoverflow logic can be placed here
    public string Prompt { get; set; } // we use public so that the other files can see it
    public string Response { get; set; }

    public Entry(string date, string prompt, string response)
    {
        // attributes
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    // behaviors
    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine(new string('-', 40));
    }
}
