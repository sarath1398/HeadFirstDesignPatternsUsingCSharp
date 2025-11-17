using PizzaStoreDependencies.Enums;

namespace PizzaStoreDependencies.Classes
{

    public class SimplePizzaFactory
    {
        public Pizza CreatePizza(string pizzaType)
        {
            var type = Enum.Parse<PizzaType>(pizzaType);

            return type switch
            {
                PizzaType.CheesePizza => new CheesePizza("Cheese Pizza"),
                PizzaType.VeggiePizza => new VeggiePizza("Veggie Pizza"),
                PizzaType.ClamPizza => new ClamPizza("Clam Pizza"),
                PizzaType.PepperoniPizza => new PepperoniPizza("Pepperoni Pizza"),
                _ => throw new ArgumentException("Invalid Pizza Type")
            };
        }
    }

}
