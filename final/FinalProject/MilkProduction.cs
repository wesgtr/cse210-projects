namespace FarmManagement
{
    public class MilkProduction
    {
        private string _breed;
        private double _milkProductionPerDay;
        private int _quantity;

        public MilkProduction(string breed, double milkProductionPerDay, int quantity)
        {
            _breed = breed;
            _milkProductionPerDay = milkProductionPerDay;
            _quantity = quantity;
        }

        public double CalculateDailyMilkProduction()
        {
            return _quantity * _milkProductionPerDay;
        }

        public string GetBreed()
        {
            return _breed;
        }

        public double GetMilkProductionPerDay()
        {
            return _milkProductionPerDay;
        }

        public int GetQuantity()
        {
            return _quantity;
        }
    }
}
