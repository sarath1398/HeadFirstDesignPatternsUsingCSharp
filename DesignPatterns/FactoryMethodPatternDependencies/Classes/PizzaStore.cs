namespace FactoryMethodPatternDependencies.Classes
{
    public abstract class PizzaStore
    {
        public abstract Pizza CreatePizza(string type);

        public virtual void OrderPizza(string type)
        {
            Pizza pizza = CreatePizza(type);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
        }
    }

    public class NYPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            return type switch
            {
                "Cheese" => new NYStyleCheesePizza(),
                "Veggie" => new NYStyleVeggiePizza(),
                "Clam" => new NYStyleClamPizza(),
                "Pepperoni" => new NYStylePepperoniPizza(),
                _ => throw new ArgumentException("Invalid Pizza Name")
            };
        }
    }

    public class ChicagoPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            return type switch
            {
                "Cheese" => new ChicagoStyleCheesePizza(),
                "Veggie" => new ChicagoStyleVeggiePizza(),
                "Clam" => new ChicagoStyleClamPizza(),
                "Pepperoni" => new ChicagoStylePepperoniPizza(),
                _ => throw new ArgumentException("Invalid Pizza Name")
            };
        }
    }
}
