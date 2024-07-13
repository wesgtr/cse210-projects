public class Breed
{
    public string Name { get; private set; }
    public double AverageMilkProduction { get; private set; }
    public double ReplacementRate { get; private set; }

    public Breed(string name, double averageMilkProduction, double replacementRate)
    {
        Name = name;
        AverageMilkProduction = averageMilkProduction;
        ReplacementRate = replacementRate;
    }
}
