namespace ChocolateFactory.Classes
{
    public class ChocolateBoilerWithEagerLoading
    {
        private bool empty;
        private bool boiled;
        
        // instance created during class load time.
        // new instance created even if the class is never used.
        // adv - No need of explicit thread check mechanism since the object is created during load time.
        private static ChocolateBoilerWithEagerLoading _instance = new();

        private ChocolateBoilerWithEagerLoading()
        {
            empty = true;
            boiled = false;
        }

        // Not thread safe. Needs more thread safe functionalities.
        public static ChocolateBoilerWithEagerLoading GetInstance() => _instance;

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
