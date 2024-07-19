namespace FarmManagement
{
    public abstract class Animal
    {
        private int _quantity;

        public Animal(int quantity)
        {
            _quantity = quantity;
        }

        public int GetQuantity()
        {
            return _quantity;
        }

        public void SetQuantity(int quantity)
        {
            _quantity = quantity;
        }

        public abstract double CalculateRequiredSpace();
    }
}
