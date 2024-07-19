namespace FarmManagement
{
    public class Farm
    {
        private List<Animal> animals;

        public Farm()
        {
            animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        public double CalculateTotalSpace()
        {
            double totalSpace = 0;
            foreach (var animal in animals)
            {
                totalSpace += animal.CalculateRequiredSpace();
            }
            return Math.Round(totalSpace, 2);
        }

        public Dictionary<int, (string, double)> LoadBreeds(string filePath)
        {
            var breeds = new Dictionary<int, (string, double)>();
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(' ');
                if (parts.Length == 3)
                {
                    int id = int.Parse(parts[0]);
                    var breed = parts[1];
                    var milkProduction = double.Parse(parts[2]);
                    breeds.Add(id, (breed, milkProduction));
                }
            }
            return breeds;
        }
    }
}