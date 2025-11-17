namespace PizzaStoreDependencies.Classes
{
    public class PizzaStore(SimplePizzaFactory simplePizzaFactory)
    {
        private readonly SimplePizzaFactory _pizzaFactory = simplePizzaFactory;

        public void OrderPizza(string type)
        {
            Pizza pizza = _pizzaFactory.CreatePizza(type);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
        }
    }
}
