public class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private int _currentScriptureIndex;

    public ScriptureLibrary(string filePath)
    {
        _scriptures = new List<Scripture>();
        _currentScriptureIndex = -1;
        LoadScripturesFromFile(filePath);
    }

    private void LoadScripturesFromFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;

                var reference = ParseReference(lines[i]);
                if (i + 1 < lines.Length && !string.IsNullOrWhiteSpace(lines[i + 1]))
                {
                    var text = lines[i + 1];
                    _scriptures.Add(new Scripture(reference, text));
                    i++;
                }
                else
                {
                    Console.WriteLine($"Error: Missing text for the scripture reference '{lines[i]}'");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading scripture from file. Line {i + 1}: {lines[i]}");
                Console.WriteLine(ex.Message);
            }
        }
    }

    private ScriptureReference ParseReference(string reference)
    {
        try
        {
            var parts = reference.Split(' ');
            if (parts.Length < 2)
            {
                throw new FormatException($"Invalid scripture reference format: '{reference}'");
            }

            var book = parts[0];
            var chapterAndVerses = parts[1].Split(':');
            if (chapterAndVerses.Length < 2)
            {
                throw new FormatException($"Invalid chapter and verse format: '{reference}'");
            }

            var chapter = int.Parse(chapterAndVerses[0]);
            var verses = chapterAndVerses[1].Split('-');
            var verseStart = int.Parse(verses[0]);
            int? verseEnd = verses.Length > 1 ? (int?)int.Parse(verses[1]) : null;

            return verseEnd == null ? new ScriptureReference(book, chapter, verseStart) : new ScriptureReference(book, chapter, verseStart, verseEnd);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing reference: {reference}");
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public Scripture GetNextScripture()
    {
        _currentScriptureIndex++;
        if (_currentScriptureIndex < _scriptures.Count)
        {
            return _scriptures[_currentScriptureIndex];
        }
        return null;
    }

    public bool HasMoreScriptures()
    {
        return _currentScriptureIndex + 1 < _scriptures.Count;
    }
}
