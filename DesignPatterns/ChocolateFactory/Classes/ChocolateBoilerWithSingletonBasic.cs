namespace ChocolateFactory.Classes
{
    public class ChocolateBoilerWithSingletonBasic
    {
        private bool empty;
        private bool boiled;
        private static ChocolateBoilerWithSingletonBasic _instance;

        private ChocolateBoilerWithSingletonBasic()
        {
            empty = true;
            boiled = false;
        }

        // Not thread safe. Needs more thread safe functionalities.
        public static ChocolateBoilerWithSingletonBasic GetInstance()
        {
            if (_instance == null)
            {
                return new ChocolateBoilerWithSingletonBasic();
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
