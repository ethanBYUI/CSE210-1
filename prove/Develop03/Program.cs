class Program
{
    static void Main(string[] args)
    {
        var library = new ScriptureLibrary();

        // Add multiple scriptures
        library.AddScripture(new Scripture(
            new Reference("Micah", 3, 14),
            new List<string> {
                "Therefore shall Zion for your sake be plowed as a field,",
                "and Jerusalem shall become heaps,"
            }));

        library.AddScripture(new Scripture(
            new Reference("John", 3, 16),
            new List<string> {
                "For God so loved the world, that he gave his only begotten Son,",
                "that whosoever believeth in him should not perish, but have everlasting life."
            }));
        
        library.AddScripture(new Scripture(
            new Reference("Doctrine and Covenants", 1, 30),
            new List<string> {
                "And also those to whom these commandments were given, might have power to lay the foundation of this church, and to bring it forth out of obscurity and out of darkness, the only true and living church upon the face of the whole earth, with which I, the Lord, am well pleased, speaking unto the church collectively and not individually"
            }));

        library.AddScripture(new Scripture(
            new Reference("Doctrine and Covenants", 56, 3),
            new List<string> {
                "Behold, I, the Lord, command; and he that will not obey shall be cut off in mine own due time, after I have commanded and the commandment is broken."
            }));

        var rand = new Random();
        var scripture = library.GetRandomScripture();

        while (true)
        {
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit") break;

            scripture.HideRandomWords(rand, 3);

            if (scripture.AllWordsHidden())
            {
                scripture.Display();
                Console.WriteLine("\nAll words hidden. Goodbye!");
                break;
            }
        }
    }
}
