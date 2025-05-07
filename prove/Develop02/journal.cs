using System;
using System.Text.Json;

class Journal
{
    // attributes
    public List<Entry> Entries { get; private set; } = new List<Entry>();

    // behaviors
    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (Entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }
        foreach (var entry in Entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        var json = JsonSerializer.Serialize(Entries);
        File.WriteAllText(filename, json);
        Console.WriteLine($"Journal saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            var json = File.ReadAllText(filename);
            Entries = JsonSerializer.Deserialize<List<Entry>>(json);
            Console.WriteLine($"Journal loaded from {filename}");
        }
        else
        {
            Console.WriteLine($"File {filename} not found.");
        }
    }
}
