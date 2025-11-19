using AbstractFactoryPizzaDependencies.Classes;

namespace ObjectVillePizzaStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PizzaStore pizzaStore = new NYPizzaStore();
            pizzaStore.CreatePizza("Cheese");
            pizzaStore = new ChicagoPizzaStore();
            pizzaStore.CreatePizza("Clam");
        }
    }
}
