
namespace ChocolateFactory.Classes
{
    public class ChocolateBoilerWithSingletonDoubleCheck
    {
        private bool empty;
        private bool boiled;
        private static volatile ChocolateBoilerWithSingletonDoubleCheck _instance;
        private static readonly object _lock = new();

        private ChocolateBoilerWithSingletonDoubleCheck()
        {
            empty = true;
            boiled = false;
        }

        // Ensures that after the only instance is created, no additional thread locks are created,
        // thereby reducing performance overhead.
        // Double-checked locking Singleton pattern
        public static ChocolateBoilerWithSingletonDoubleCheck GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new ChocolateBoilerWithSingletonDoubleCheck();
                    return _instance;
                }
            }

            return _instance;
        }

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
