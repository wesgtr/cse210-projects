public class MilkProductionCalculator
{
    public double CalculateAverageMilkProduction(List<Cow> cows)
    {
        return cows.Average(cow => cow.CalculateDailyMilkProduction());
    }
}
