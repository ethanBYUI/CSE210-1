
    public class GoalManager
    {
        private List<Goal> goals = new List<Goal>();
        private int totalScore = 0;
        private int level = 1;
        private int completedGoals = 0;

        public void MainMenu()
        {
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("\nEternal Quest Menu:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Show Score");
                Console.WriteLine("5. Save Goals");
                Console.WriteLine("6. Load Goals");
                Console.WriteLine("7. Quit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        DisplayGoals();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        ShowScore();
                        break;
                    case "5":
                        SaveGoals();
                        break;
                    case "6":
                        LoadGoals();
                        break;
                    case "7":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("\nWhich type of goal?");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            Goal newGoal = null;
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter description: ");
            string desc = Console.ReadLine();
            Console.Write("Enter points: ");
            int points = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case "1":
                    newGoal = new SimpleGoal { Name = name, Description = desc, Points = points };
                    break;
                case "2":
                    newGoal = new EternalGoal { Name = name, Description = desc, Points = points };
                    break;
                case "3":
                    Console.Write("Enter target count: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points: ");
                    int bonus = int.Parse(Console.ReadLine());
                    newGoal = new ChecklistGoal
                    {
                        Name = name,
                        Description = desc,
                        Points = points,
                        TargetCount = target,
                        BonusPoints = bonus
                    };
                    break;
            }

            if (newGoal != null)
            {
                goals.Add(newGoal);
                Console.WriteLine("Goal created!");
            }
        }

        public void DisplayGoals()
        {
            Console.WriteLine("\nGoals List:");
            int i = 1;
            foreach (Goal goal in goals)
            {
                string status = goal.IsComplete ? "[X]" : "[ ]";
                string extra = "";

                if (goal is ChecklistGoal cg)
                {
                    extra = $" (Completed {cg.TimesCompleted}/{cg.TargetCount})";
                }

                Console.WriteLine($"{i}. {status} {goal.Name} - {goal.Description}{extra}");
                i++;
            }
        }

        public void RecordEvent()
        {
            DisplayGoals();
            Console.Write("Which goal did you accomplish? Enter number: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index >= 0 && index < goals.Count)
            {
                goals[index].RecordEvent(this);

                if (goals[index].IsComplete)
                    completedGoals++;
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        public void ShowScore()
        {
            Console.WriteLine($"\nTotal Score: {totalScore}");
            Console.WriteLine($"Level: {level}");
            Console.WriteLine($"Goals Completed: {completedGoals}");
        }

        public void SaveGoals()
        {
            Console.Write("Enter filename: ");
            string file = Console.ReadLine();

            List<string> lines = new List<string>();
            lines.Add(totalScore.ToString());
            lines.Add(level.ToString());
            lines.Add(completedGoals.ToString());

            foreach (Goal goal in goals)
            {
                lines.Add(goal.ToCSV());
            }

            File.WriteAllLines(file, lines);
            Console.WriteLine("Goals saved.");
        }

        public void LoadGoals()
        {
            Console.Write("Enter filename to load: ");
            string file = Console.ReadLine();

            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);
                goals.Clear();
                totalScore = int.Parse(lines[0]);
                level = int.Parse(lines[1]);
                completedGoals = int.Parse(lines[2]);

                for (int i = 3; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (line.StartsWith("SimpleGoal"))
                        goals.Add(SimpleGoal.FromCSV(line));
                    else if (line.StartsWith("EternalGoal"))
                        goals.Add(EternalGoal.FromCSV(line));
                    else if (line.StartsWith("ChecklistGoal"))
                        goals.Add(ChecklistGoal.FromCSV(line));
                }

                Console.WriteLine("Goals loaded.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }

        public void AddPoints(int pts)
        {
            totalScore += pts;

            // Level up logic
            if (totalScore >= level * 1000)
            {
                level++;
                Console.WriteLine($"🎉 You leveled up! Now level {level}!");
            }
        }

        public void CheckForBadge()
        {
            if (completedGoals >= 5)
            {
                Console.WriteLine("🏅 Badge Unlocked: Goal Master!");
            }
        }
    }

