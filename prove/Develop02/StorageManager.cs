using System;

public static class StorageManager
{
    public static void SaveJournalToFile(string filename, List<Entry> entries)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                outputFile.WriteLine(entry.ToString());
            }
        }
    }

    public static List<Entry> LoadJournalFromFile(string filename)
    {
        List<Entry> entries = new List<Entry>();
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    try
                    {
                        entries.Add(Entry.FromString(line));
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Skipped invalid entry: {line}. Error: {ex.Message}");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine($"File {filename} not found.");
        }
        return entries;
    }
}
