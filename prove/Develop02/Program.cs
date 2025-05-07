using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    // attributes
    static List<string> Prompts = new List<string>
    {
        "Any new theories about the JFK assassination?",
        "What was the best thing you ate today?",
        "How did you fight against femenism today?",
        "What was the strongest emotion I felt today? Was it wrath?",
        "Who has made the list today?",
        "Any new challengers arisen today?",
        "Who challenged me today?"
    };

    static Journal journal = new Journal();
    static Random random = new Random();

    // behaviors
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save to: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load from: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void WriteEntry()
    {
        string prompt = Prompts[random.Next(Prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        Entry entry = new Entry(date, prompt, response);
        journal.AddEntry(entry);
        Console.WriteLine("Entry added.");
    }
}
