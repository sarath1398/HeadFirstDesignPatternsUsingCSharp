namespace ChocolateFactory.Classes
{
    public class ChocolateBoilerWithSingletonThreadSafe
    {
        private bool empty;
        private bool boiled;
        private static volatile ChocolateBoilerWithSingletonThreadSafe _instance;
        private static readonly object _lock = new();

        private ChocolateBoilerWithSingletonThreadSafe()
        {
            empty = true;
            boiled = false;
        }

        // Adds overhead since we need to lock a thread everytime even after only instantiation of the class.
        // Single-checked locking Singleton pattern (thread-safe)
        public static ChocolateBoilerWithSingletonThreadSafe GetInstance()
        {
            lock (_lock)
            {
                _instance ??= new ChocolateBoilerWithSingletonThreadSafe();
                return _instance;
            }
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
