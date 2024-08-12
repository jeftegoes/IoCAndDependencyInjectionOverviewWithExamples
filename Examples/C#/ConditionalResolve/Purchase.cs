namespace ExampleConditionalResolve
{
    public class Purchase
    {
        private readonly Func<UserLocations, ITaxCalculator> _accessor;

        public Purchase(Func<UserLocations, ITaxCalculator> accessor)
        {
            _accessor = accessor;
        }

        public int CheckOut(UserLocations userLocations)
        {
            var tax = _accessor(userLocations).Calculator();
            var total = tax + 100;
            return total;
        }
    }
}