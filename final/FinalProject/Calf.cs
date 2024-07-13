public class Calf
{
    public int Age { get; private set; }
    public bool ReplacementStatus { get; private set; }

    public Calf(int age)
    {
        Age = age;
        ReplacementStatus = false;
    }

    public void CalculateReplacementStatus()
    {
        ReplacementStatus = Age < 2;
    }
}
