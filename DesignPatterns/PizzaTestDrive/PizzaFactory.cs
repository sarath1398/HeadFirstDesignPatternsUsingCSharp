using FactoryMethodPatternDependencies.Classes;

namespace PizzaTestDrive
{
    public static class PizzaFactory
    {
        public static void Main(string[] args)
        {
            PizzaStore store = new NYPizzaStore();
            store.OrderPizza("Cheese");
            PizzaStore chicagoStore = new ChicagoPizzaStore();
            chicagoStore.OrderPizza("Clam");
        }
    }
}
