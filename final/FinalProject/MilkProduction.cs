namespace FarmManagement
{
    public class MilkProduction
    {
        private string breed;
        private double milkProductionPerDay;
        private int quantity;

        public MilkProduction(string breed, double milkProductionPerDay, int quantity)
        {
            this.breed = breed;
            this.milkProductionPerDay = milkProductionPerDay;
            this.quantity = quantity;
        }

        public double CalculateDailyMilkProduction()
        {
            return quantity * milkProductionPerDay;
        }

        public string GetBreed()
        {
            return breed;
        }

        public double GetMilkProductionPerDay()
        {
            return milkProductionPerDay;
        }

        public int GetQuantity()
        {
            return quantity;
        }
    }
}