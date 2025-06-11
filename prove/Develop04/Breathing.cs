class Breathing : Activity
{
    public Breathing() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") {}

    public void Breathe()
    {
    Start();
    BreathAnimation("Breathe in", _duration);
    Stop();
}


    private void BreathAnimation(string message, int durationSeconds)
{
    Console.Clear();
    int interval = 2; // Seconds for expanding/contracting each phase
    int cycleDuration = interval * 2 + 2; // in + hold + out + hold
    int cycles = durationSeconds / cycleDuration;

    for (int i = 0; i < cycles; i++)
    {
        // Breathe In
        for (int j = 1; j <= 5; j++)
        {
            Console.Clear();
            Console.WriteLine($"{message} " + new string('.', j));
            Thread.Sleep(interval * 100);
        }

        Console.WriteLine("Hold...");
        Thread.Sleep(1000);

        // Breathe Out
        for (int j = 5; j >= 1; j--)
        {
            Console.Clear();
            Console.WriteLine("Breathe out" + new string('.', j));
            Thread.Sleep(interval * 100);
        }

        Console.WriteLine("Hold...");
        Thread.Sleep(1000);
    }
}

}
