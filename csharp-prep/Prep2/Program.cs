using System;

class Program
{
    static void Main(string[] args)
    {
        bool validInput = false;
        int percent = 0;

        while (!validInput)
        {
            Console.Write("What is your grade percentage? ");
            string answer = Console.ReadLine();

            if (int.TryParse(answer, out percent))
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }

        string letter = GetLetterGrade(percent);
        Console.WriteLine($"Your grade is: {letter}");

        if (percent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }

    static string GetLetterGrade(int percent)
    {
        if (percent >= 90) return "A";
        if (percent >= 80) return "B";
        if (percent >= 70) return "C";
        if (percent >= 60) return "D";
        return "F";
    }
}
