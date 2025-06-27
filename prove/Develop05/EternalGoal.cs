
    public class EternalGoal : Goal
    {
        public override void RecordEvent(GoalManager manager)
        {
            Console.WriteLine($"Eternal Goal Recorded! You earned {Points} points.");
            manager.AddPoints(Points);
        }

        public override string ToCSV()
        {
            return $"EternalGoal|{Name}|{Description}|{Points}";
        }

        public static EternalGoal FromCSV(string csv)
        {
            string[] parts = csv.Split('|');
            return new EternalGoal
            {
                Name = parts[1],
                Description = parts[2],
                Points = int.Parse(parts[3])
            };
        }
    }
