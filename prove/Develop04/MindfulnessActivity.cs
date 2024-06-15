public abstract class MindfulnessActivity
{
    protected string Name { get; set; }
    protected string Description { get; set; }
    protected int Duration { get; set; }

    public void Start()
    {
        ShowStartingMessage();
        RunActivity();
        ShowEndingMessage();
    }

    protected void ShowStartingMessage()
    {
        Console.WriteLine($"Starting {Name} activity.");
        Console.WriteLine(Description);
        Console.Write("Enter the duration of the activity in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowPause(3);
    }

    protected void ShowEndingMessage()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        ShowPause(3);
    }

    protected void ShowPause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected abstract void RunActivity();
}
