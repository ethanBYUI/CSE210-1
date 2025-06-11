class Reflection : Activity
{
    private List<string> _prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string> {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself through this experience?",
        "How did you feel when it was complete?",
        "What could you learn from this experience that applies to other situations?"
    };

    public Reflection() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience.") {}

    public void Reflect()
    {
        Start();
        Console.WriteLine(_prompts[new Random().Next(_prompts.Count)]);
        ShowAnimation(3);

        int interval = _duration / _questions.Count;
        foreach (var question in _questions)
        {
            Console.WriteLine(question);
            ShowAnimation(interval);
        }

        Stop();
    }
}
