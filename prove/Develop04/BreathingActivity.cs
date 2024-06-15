public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        Name = "Breathing";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void RunActivity()
    {
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.WriteLine("Breathe in...");
            ShowPause(3);
            elapsed += 3;

            Console.WriteLine("Breathe out...");
            ShowPause(3);
            elapsed += 3;
        }
    }
}
