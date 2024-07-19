namespace FarmManagement
{
    public class Cattle : Animal
    {
        private const double CattlePerHectare = 6.0;
        private string _breed;

        public Cattle(int quantity, string breed) : base(quantity)
        {
            _breed = breed;
        }

        public string GetBreed()
        {
            return _breed;
        }

        public void SetBreed(string breed)
        {
            _breed = breed;
        }

        public override double CalculateRequiredSpace()
        {
            return GetQuantity() / CattlePerHectare;
        }
    }
}
