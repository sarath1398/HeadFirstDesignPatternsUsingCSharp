namespace ChocolateFactory.Classes
{
    public class ChocolateBoilerWithLazyLoading
    {
        private bool empty;
        private bool boiled;

        // Created only when first accessed.
        // Thread safe and efficient than eager loading.
        private static readonly Lazy<ChocolateBoilerWithLazyLoading> _instance =
        new(() => new ChocolateBoilerWithLazyLoading());

        private ChocolateBoilerWithLazyLoading()
        {
            empty = true;
            boiled = false;
        }

        // Not thread safe. Needs more thread safe functionalities.
        public static ChocolateBoilerWithLazyLoading GetInstance() => _instance.Value;

        public void Fill()
        {
            if (IsEmpty())
            {
                boiled = false;
                empty = false;

                // fill the boiler with a milk/chocolate mixture
            }
        }

        public void Drain()
        {
            if (!IsEmpty() && IsBoiled())
            {
                // drain the boiled milk and chocolate
                empty = true;
            }
        }

        public void Boil()
        {
            if (!IsEmpty() && !IsBoiled())
            {
                // bring the contents to a boil
                boiled = true;
            }
        }

        public bool IsEmpty()
        {
            return empty;
        }

        public bool IsBoiled()
        {
            return boiled;
        }
    }
}
