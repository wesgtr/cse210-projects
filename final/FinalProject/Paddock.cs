public class Paddock
{
    public int ID { get; private set; }
    public int Capacity { get; private set; }
    public int CurrentCowCount { get; private set; }

    public Paddock(int id, int capacity)
    {
        ID = id;
        Capacity = capacity;
        CurrentCowCount = 0;
    }

    public void AddCow()
    {
        if (CurrentCowCount < Capacity)
        {
            CurrentCowCount++;
        }
    }

    public void RemoveCow()
    {
        if (CurrentCowCount > 0)
        {
            CurrentCowCount--;
        }
    }

    public bool IsFull()
    {
        return CurrentCowCount >= Capacity;
    }

    public void DisplayStatus() // Certificar-se que este método é público
    {
        Console.WriteLine($"Paddock {ID}: {CurrentCowCount}/{Capacity} cows");
    }
}
