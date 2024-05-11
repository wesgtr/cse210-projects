using System;

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry()
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What am I most grateful for at this moment?",
            "What did I accomplish today that I'm proud of?",
            "What lesson did I learn today?",
            "What made me laugh today?",
            "What was the most challenging part of my day?",
            "Who did I help today and how?",
            "What is something beautiful I saw today?",
            "What am I looking forward to tomorrow?",
            "How have I grown or changed today?",
            "What was unexpected about today?",
            "What kind of person was I today?",
            "What am I worried about and why?",
            "What can I do better tomorrow?",
            "Who or what inspired me today?",
            "What was the main feeling of my day and why?"
        };

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine(prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Console.Write("Where did this happen (location or city)? ");
        string location = Console.ReadLine();

        Entry newEntry = new Entry(prompt, response, location);
        entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}, Time: {entry.Time}, Prompt: {entry.Prompt}, Response: {entry.Response}, Location: {entry.Location}");
        }
    }

    public List<Entry> GetEntries() => entries;

    public void SetEntries(List<Entry> newEntries)
    {
        entries = newEntries;
    }
}
