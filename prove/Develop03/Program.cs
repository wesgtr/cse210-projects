public class Program
{
    static void Main(string[] args)
    {
        var library = new ScriptureLibrary("scriptures.txt");
        Scripture scripture;

        while ((scripture = library.GetNextScripture()) != null)
        {
            while (true)
            {
                scripture.Display();
                Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
                var input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    return;
                }
                scripture.HideRandomWords(3);
                if (scripture.AllWordsHidden())
                {
                    scripture.Display();
                    Console.WriteLine("\nCongratulations, let's move on to the next scripture!");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                }
            }
        }

        Console.WriteLine("\nAll scriptures have been memorized. Congratulations!");
    }
}
