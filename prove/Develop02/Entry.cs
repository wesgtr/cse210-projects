using System;

public class Entry
{
    private string _date;
    private string _time;
    private string _prompt;
    private string _response;
    private string _location;
    public bool IsSaved { get; set; }

    public Entry(string prompt, string response, string location)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd");
        _time = DateTime.Now.ToString("HH:mm");
        _prompt = prompt;
        _response = response;
        _location = location;
    }

    public override string ToString()
    {
        return $"{_date};{_time};{_prompt};{_response};{_location}";
    }

    public static Entry FromString(string line)
    {
        string[] parts = line.Split(';');
        if (parts.Length < 5) throw new FormatException("Invalid entry format");
        return new Entry(parts[2], parts[3], parts[4])
        {
            _date = parts[0],
            _time = parts[1]
        };
    }
}
