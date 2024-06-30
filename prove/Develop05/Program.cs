class Program
{
    static void Main(string[] args)
    {
        EternalQuest quest = new EternalQuest();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine($"\nYou have {quest.CurrentScore} points.\n");
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateNewGoal(quest);
                    break;
                case 2:
                    quest.DisplayGoals();
                    break;
                case 3:
                    quest.Save("goals.txt");
                    Console.WriteLine("Goals saved successfully.");
                    break;
                case 4:
                    quest.Load("goals.txt");
                    Console.WriteLine("Goals loaded successfully.");
                    break;
                case 5:
                    RecordEvent(quest);
                    break;
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    static void CreateNewGoal(EternalQuest quest)
    {
        Console.WriteLine("Enter goal name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter description:");
        string description = Console.ReadLine();
        Console.WriteLine("Enter points for completing the goal:");
        int points = int.Parse(Console.ReadLine());

        var goal = new SimpleGoal(name, description, points);
        quest.AddGoal(goal);
        Console.WriteLine("Goal added successfully.");
    }

    static void RecordEvent(EternalQuest quest)
    {
        Console.WriteLine("Enter the name of the goal to record:");
        string name = Console.ReadLine();
        quest.RecordGoalEvent(name);
        Console.WriteLine("Event recorded successfully.");
    }
}
