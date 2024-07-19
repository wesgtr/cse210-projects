namespace FarmManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Farm farm = new Farm();
            var breeds = farm.LoadBreeds("cattle_breeds.txt");

            Console.WriteLine("Enter the number of cattle:");
            int numberOfCattle = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Select the breed of cattle:");
            foreach (var breed in breeds)
            {
                Console.WriteLine($"{breed.Key}. {breed.Value.Item1}");
            }
            int selectedBreedId = int.Parse(Console.ReadLine());

            Console.WriteLine();

            if (breeds.ContainsKey(selectedBreedId))
            {
                var selectedBreed = breeds[selectedBreedId];
                Cattle cattle = new Cattle(numberOfCattle, selectedBreed.Item1);
                farm.AddAnimal(cattle);

                double totalSpace = farm.CalculateTotalSpace();
                Console.WriteLine($"Total space required: {totalSpace} hectares");

                MilkProduction milkProduction = new MilkProduction(selectedBreed.Item1, selectedBreed.Item2, numberOfCattle);
                double totalMilkProduction = milkProduction.CalculateDailyMilkProduction();
                Console.WriteLine($"Total milk production per day: {totalMilkProduction} liters");

                ReplacementCalculation replacementCalculation = new ReplacementCalculation(numberOfCattle);
                int replacementHeifers = replacementCalculation.CalculateReplacementHeifers();
                Console.WriteLine($"Number of replacement heifers needed: {replacementHeifers}");
            }
            else
            {
                Console.WriteLine("Breed not found.");
            }
        }
    }
}
