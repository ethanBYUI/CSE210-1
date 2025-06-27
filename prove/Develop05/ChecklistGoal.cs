public class ChecklistGoal : Goal
    {
        public int TargetCount { get; set; }
        public int TimesCompleted { get; set; }
        public int BonusPoints { get; set; }

        public override void RecordEvent(GoalManager manager)
        {
            if (!IsComplete)
            {
                TimesCompleted++;
                manager.AddPoints(Points);
                Console.WriteLine($"Progress: {TimesCompleted}/{TargetCount}. Earned {Points} points.");

                if (TimesCompleted >= TargetCount)
                {
                    IsComplete = true;
                    manager.AddPoints(BonusPoints);
                    Console.WriteLine($"Checklist goal complete! Bonus {BonusPoints} points awarded.");
                    manager.CheckForBadge();
                }
            }
            else
            {
                Console.WriteLine("This checklist goal is already complete.");
            }
        }

        public override string ToCSV()
        {
            return $"ChecklistGoal|{Name}|{Description}|{Points}|{IsComplete}|{TimesCompleted}|{TargetCount}|{BonusPoints}";
        }

        public static ChecklistGoal FromCSV(string csv)
        {
            string[] parts = csv.Split('|');
            return new ChecklistGoal
            {
                Name = parts[1],
                Description = parts[2],
                Points = int.Parse(parts[3]),
                IsComplete = bool.Parse(parts[4]),
                TimesCompleted = int.Parse(parts[5]),
                TargetCount = int.Parse(parts[6]),
                BonusPoints = int.Parse(parts[7])
            };
        }
    }
