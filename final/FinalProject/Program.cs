class Program
{
    static void Main(string[] args)
    {
        List<Breed> breeds = LoadBreedsFromFile("breeds.txt");
        List<Cow> cows = GetCowsFromInput(breeds);

        List<Paddock> paddocks = CreatePaddocks();
        Farm farm = new Farm(cows) { Paddocks = paddocks };

        double totalMilkProduction = farm.CalculateTotalMilkProduction();
        Console.WriteLine($"Total Milk Production: {totalMilkProduction} liters");

        int calvesNeeded = farm.DetermineReplacementNeeds();
        Console.WriteLine($"Calves Needed for Replacement: {calvesNeeded}");

        farm.AllocatePaddocks();
        DisplayPaddockStatus(farm.Paddocks);
    }

    static List<Breed> LoadBreedsFromFile(string filePath)
    {
        List<Breed> breeds = new List<Breed>();
        foreach (var line in File.ReadLines(filePath))
        {
            var parts = line.Split(',');
            string name = parts[0];
            double avgMilkProduction = double.Parse(parts[1]);
            double replacementRate = double.Parse(parts[2]);
            breeds.Add(new Breed(name, avgMilkProduction, replacementRate));
        }
        return breeds;
    }

    static List<Cow> GetCowsFromInput(List<Breed> breeds)
    {
        List<Cow> cows = new List<Cow>();
        Console.WriteLine("Enter number of cows:");
        int numberOfCows = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCows; i++)
        {
            int breedChoice = -1;
            while (breedChoice < 0 || breedChoice >= breeds.Count)
            {
                Console.WriteLine("Choose a breed:");
                for (int j = 0; j < breeds.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {breeds[j].Name}");
                }
                bool isValidBreed = int.TryParse(Console.ReadLine(), out breedChoice);
                breedChoice--;

                if (!isValidBreed || breedChoice < 0 || breedChoice >= breeds.Count)
                {
                    Console.WriteLine("Invalid choice. Please choose a valid breed.");
                    breedChoice = -1;
                }
            }

            Console.WriteLine("Enter age of cow:");
            bool isValidAge = int.TryParse(Console.ReadLine(), out int age);
            while (!isValidAge || age < 0)
            {
                Console.WriteLine("Invalid age. Please enter a valid age:");
                isValidAge = int.TryParse(Console.ReadLine(), out age);
            }

            cows.Add(new Cow(breeds[breedChoice], age));
        }
        return cows;
    }

    static List<Paddock> CreatePaddocks()
    {
        List<Paddock> paddocks = new List<Paddock>();
        Console.WriteLine("Enter number of paddocks:");
        int numberOfPaddocks = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPaddocks; i++)
        {
            Console.WriteLine($"Enter capacity for paddock {i + 1}:");
            int capacity = int.Parse(Console.ReadLine());
            paddocks.Add(new Paddock(i + 1, capacity));
        }
        return paddocks;
    }

    static void DisplayPaddockStatus(List<Paddock> paddocks)
    {
        foreach (var paddock in paddocks)
        {
            paddock.DisplayStatus();
        }
    }
}
