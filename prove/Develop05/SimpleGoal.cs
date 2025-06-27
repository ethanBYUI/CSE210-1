public class SimpleGoal : Goal
    {
        public override void RecordEvent(GoalManager manager)
        {
            if (!IsComplete)
            {
                IsComplete = true;
                Console.WriteLine($"Simple Goal Complete! You earned {Points} points.");
                manager.AddPoints(Points);
                manager.CheckForBadge();
            }
            else
            {
                Console.WriteLine("This goal is already complete.");
            }
        }

        public override string ToCSV()
        {
            return $"SimpleGoal|{Name}|{Description}|{Points}|{IsComplete}";
        }

        public static SimpleGoal FromCSV(string csv)
        {
            string[] parts = csv.Split('|');
            return new SimpleGoal
            {
                Name = parts[1],
                Description = parts[2],
                Points = int.Parse(parts[3]),
                IsComplete = bool.Parse(parts[4])
            };
        }
    }
