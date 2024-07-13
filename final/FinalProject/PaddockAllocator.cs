public class PaddockAllocator
{
    public void AllocatePaddocks(Farm farm)
    {
        foreach (var cow in farm.Cows)
        {
            bool allocated = false;
            foreach (var paddock in farm.Paddocks)
            {
                if (!paddock.IsFull())
                {
                    paddock.AddCow();
                    allocated = true;
                    break;
                }
            }
            if (!allocated)
            {
                Console.WriteLine("Not enough paddock capacity to allocate all cows.");
                break;
            }
        }
    }
}
