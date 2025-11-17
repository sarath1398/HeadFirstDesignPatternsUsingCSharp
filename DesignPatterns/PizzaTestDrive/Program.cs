using FactoryMethodPatternDependencies.Classes;

namespace PizzaTestDrive
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            PizzaStore store = new NYPizzaStore();
            store.OrderPizza("Cheese");
            PizzaStore chicagoStore = new ChicagoPizzaStore();
            chicagoStore.OrderPizza("Cheese");
        }
    }
}
