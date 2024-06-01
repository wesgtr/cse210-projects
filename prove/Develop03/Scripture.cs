public class Scripture
{
    public ScriptureReference Reference { get; private set; }
    private List<Word> _words;

    public Scripture(ScriptureReference reference, string text)
    {
        Reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(Reference);
        foreach (var word in _words)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords(int count)
    {
        var random = new Random();
        var wordsToHide = _words.Where(word => !word.IsHidden).OrderBy(x => random.Next()).Take(count).ToList();
        foreach (var word in wordsToHide)
        {
            word.Hide();
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHidden);
    }
}
