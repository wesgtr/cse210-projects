namespace FarmManagement
{
    public abstract class Animal
    {
        private int quantity;

        public Animal(int quantity)
        {
            this.quantity = quantity;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public void SetQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public abstract double CalculateRequiredSpace();
    }
}