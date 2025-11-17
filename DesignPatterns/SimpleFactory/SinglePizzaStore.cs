using PizzaStoreDependencies.Classes;

namespace SimpleFactory
{
    public class SinglePizzaStore
    {
        public static void Main()
        {
            SimplePizzaFactory factory = new();
            PizzaStore store = new(factory);

            store.OrderPizza("ClamPizza");

        }
    }
}
