namespace AbstractFactoryPizzaDependencies.Classes
{
    public abstract class PizzaStore
    {
        public abstract Pizza CreatePizza(string pizzaType);
    }

    public class NYPizzaStore : PizzaStore
    {
        readonly IPizzaIngredientFactory factory = new NYPizzaIngredientFactory();

        Pizza pizza;
        public override Pizza CreatePizza(string pizzaType)
        {
            if (pizzaType == "Cheese")
            {
                pizza = new CheesePizza(factory);
                pizza.SetName("NY Styled Cheese Pizza");
                pizza.PreparePizza();
            }
            else if (pizzaType == "Clam")
            {
                pizza = new ClamPizza(factory);
                pizza.SetName("NY Styled Clam Pizza");
                pizza.PreparePizza();
            }
            else
            {
                throw new ArgumentException("Invalid Pizza Type");
            }
            return pizza;
        }
    }

    public class ChicagoPizzaStore : PizzaStore
    {
        Pizza pizza;

        readonly IPizzaIngredientFactory factory = new ChicagoPizzaIngredientFactory();
        public override Pizza CreatePizza(string pizzaType)
        {
            if (pizzaType == "Cheese")
            {
                pizza = new CheesePizza(factory);
                pizza.SetName("Chicago Styled Cheese Pizza");
                pizza.PreparePizza();
            }
            else if (pizzaType == "Clam")
            {
                pizza = new ClamPizza(factory);
                pizza.SetName("Chicago Styled Clam Pizza");
                pizza.PreparePizza();
            }
            else
            {
                throw new ArgumentException("Invalid Pizza Type");
            }
            return pizza;
        }
    }
}
