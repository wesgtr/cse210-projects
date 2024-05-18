using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        string fileName = "journal.csv";

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();
            int option;
            if (!int.TryParse(input, out option))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            switch (option)
            {
                case 1:
                    myJournal.AddEntry();
                    break;
                case 2:
                    myJournal.DisplayEntries();
                    break;
                case 3:
                    myJournal.SaveJournalToFile(fileName);
                    Console.WriteLine("Journal saved successfully.");
                    break;
                case 4:
                    myJournal.LoadJournalFromFile(fileName);
                    Console.WriteLine("Journal loaded successfully.");
                    break;
                case 5:
                    Console.WriteLine("Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}