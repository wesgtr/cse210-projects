public class EternalQuest
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public int CurrentScore
    {
        get { return _score; }
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{goal.Name}: {goal.Description} - Completed: {goal.IsCompleted}");
        }
    }


    public void RecordGoalEvent(string goalName)
    {
        bool goalFound = false;
        foreach (Goal goal in _goals)
        {
            if (goal.Name == goalName)
            {
                goal.RecordEvent();
                _score += goal.Points;
                if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted)
                {
                    _score += checklistGoal.BonusPoints;
                }
                Console.WriteLine($"Event recorded for {goalName}. Current score: {_score}");
                goalFound = true;
                break;
            }
        }

        if (goalFound)
        {
            Save("goals.txt");
            Console.WriteLine("Changes saved to goals.txt.");
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }


    public void Save(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Description},{goal.Points},{goal.IsCompleted}");
            }
        }
    }


    public void Load(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            _score = int.Parse(reader.ReadLine());
            _goals.Clear();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                if (parts.Length < 5) continue;

                bool isCompleted = bool.Parse(parts[4]);
                switch (parts[0])
                {
                    case "SimpleGoal":
                        var simpleGoal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        if (isCompleted) simpleGoal.RecordEvent();
                        _goals.Add(simpleGoal);
                        break;
                    case "EternalGoal":
                        var eternalGoal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                        if (isCompleted) eternalGoal.RecordEvent();
                        _goals.Add(eternalGoal);
                        break;
                    case "ChecklistGoal":
                        var checklistGoal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6]));
                        _goals.Add(checklistGoal);
                        if (isCompleted) 
                        {
                            for (int i = 0; i < int.Parse(parts[5]); i++) checklistGoal.RecordEvent();
                        }
                        break;
                }
            }
        }
    }

}
