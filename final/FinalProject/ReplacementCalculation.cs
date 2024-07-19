namespace FarmManagement
{
    public class ReplacementCalculation
    {
        private const double ReplacementRate = 0.2; // Fixed replacement rate of 20%
        private int _quantity;

        public ReplacementCalculation(int quantity)
        {
            _quantity = quantity;
        }

        public int CalculateReplacementHeifers()
        {
            return (int)Math.Ceiling(_quantity * ReplacementRate);
        }

        public int GetQuantity()
        {
            return _quantity;
        }
    }
}
