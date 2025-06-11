class Listing : Activity
{
    private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public Listing() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") {}

    public void Count()
    {
        Start();
        Console.WriteLine(_prompts[new Random().Next(_prompts.Count)]);
        Console.WriteLine("Start listing. Press Enter after each item.");
        ShowAnimation(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            if (!string.IsNullOrWhiteSpace(Console.ReadLine()))
                count++;
        }

        Console.WriteLine($"You listed {count} items.");
        Stop();
    }
}
