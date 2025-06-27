public abstract class Goal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public bool IsComplete { get; set; }

        public abstract void RecordEvent(GoalManager manager);
        public abstract string ToCSV();
    }