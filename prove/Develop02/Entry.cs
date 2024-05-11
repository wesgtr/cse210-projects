using System;

public class Entry
{
    public string Date { get; set; }
    public string Time { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Location { get; set; }

    public Entry(string prompt, string response, string location)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Time = DateTime.Now.ToString("HH:mm:ss");
        Prompt = prompt;
        Response = response;
        Location = location;
    }

    public override string ToString()
    {
        return $"{Date},{Time},{Prompt},{Response},{Location}";
    }

    public static Entry FromString(string line)
    {
        string[] parts = line.Split(',');
        if (parts.Length < 5) throw new FormatException("Invalid entry format");
        return new Entry(parts[2], parts[3], parts[4])
        {
            Date = parts[0],
            Time = parts[1]
        };
    }
}
