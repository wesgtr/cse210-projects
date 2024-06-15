public class ListingActivity : MindfulnessActivity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        Name = "Listing";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override void RunActivity()
    {
        Random random = new Random();
        string prompt = Prompts[random.Next(Prompts.Count)];
        Console.WriteLine(prompt);
        ShowPause(3);

        Console.WriteLine("Start listing...");
        ShowPause(3);

        int itemCounter = 0;
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.WriteLine("Enter an item: ");
            Console.ReadLine(); // Simulate user input
            itemCounter++;
            elapsed += 3; // Assume each item takes about 3 seconds
        }

        Console.WriteLine($"You have listed {itemCounter} items.");
    }
}
