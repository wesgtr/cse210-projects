public class ReplacementCalculator
{
    public int CalculateCalvesNeeded(List<Cow> cows)
    {
        return cows.Count(cow => cow.NeedsReplacement());
    }
}
