using System.Collections.Generic;
using System.Linq;

public class Farm
{
    public List<Cow> Cows { get; private set; }
    public List<Calf> Calves { get; private set; }
    public List<Paddock> Paddocks { get; set; } // Alterado para permitir set externo

    public Farm(List<Cow> cows)
    {
        Cows = cows;
        Calves = new List<Calf>();
        Paddocks = new List<Paddock>();
    }

    public double CalculateTotalMilkProduction()
    {
        return Cows.Sum(cow => cow.CalculateDailyMilkProduction());
    }

    public int DetermineReplacementNeeds()
    {
        return Cows.Count(cow => cow.NeedsReplacement());
    }

    public void AllocatePaddocks()
    {
        PaddockAllocator allocator = new PaddockAllocator();
        allocator.AllocatePaddocks(this);
    }
}
