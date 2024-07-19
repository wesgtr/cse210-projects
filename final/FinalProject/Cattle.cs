namespace FarmManagement
{
    public class Cattle : Animal
    {
        private const double CattlePerHectare = 6.0;
        private string breed;

        public Cattle(int quantity, string breed) : base(quantity)
        {
            this.breed = breed;
        }

        public string GetBreed()
        {
            return breed;
        }

        public void SetBreed(string breed)
        {
            this.breed = breed;
        }

        public override double CalculateRequiredSpace()
        {
            return GetQuantity() / CattlePerHectare;
        }
    }
}