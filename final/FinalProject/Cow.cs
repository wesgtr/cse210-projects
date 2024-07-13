public class Cow
{
    private Breed _breed;
    private int _age;

    public Cow(Breed breed, int age)
    {
        _breed = breed;
        _age = age;
    }

    public double CalculateDailyMilkProduction()
    {
        return _breed.AverageMilkProduction;
    }

    public bool NeedsReplacement()
    {
        return _age >= 5; // Exemplo: substituir vacas com 5 anos ou mais
    }
}
