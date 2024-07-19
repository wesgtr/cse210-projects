namespace FarmManagement
{
    public class ReplacementCalculation
    {
        private const double ReplacementRate = 0.2;
        private int quantity;

        public ReplacementCalculation(int quantity)
        {
            this.quantity = quantity;
        }

        public int CalculateReplacementHeifers()
        {
            return (int)Math.Ceiling(quantity * ReplacementRate);
        }

        public int GetQuantity()
        {
            return quantity;
        }
    }
}