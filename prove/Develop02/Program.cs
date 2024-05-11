using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        string fileName = "journal.csv";

        while (true)
        {
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    myJournal.AddEntry();
                    break;
                case 2:
                    myJournal.DisplayEntries();
                    break;
                case 3:
                    StorageManager.SaveJournalToFile(fileName, myJournal.GetEntries());
                    break;
                case 4:
                    var loadedEntries = StorageManager.LoadJournalFromFile(fileName);
                    myJournal.SetEntries(loadedEntries);
                    myJournal.DisplayEntries();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
