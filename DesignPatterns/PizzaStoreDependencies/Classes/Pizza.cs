namespace PizzaStoreDependencies.Classes
{
    public abstract class Pizza
    {
        public string PizzaType = "Pizza";

        public Pizza() { }

        public Pizza(string pizzaType) => this.PizzaType = pizzaType;
        public virtual void Prepare() => Console.WriteLine($"Preparing {PizzaType}");

        public virtual void Bake() => Console.WriteLine($"Baking {PizzaType}");

        public virtual void Cut() => Console.WriteLine($"Cutting {PizzaType} Diagonally");

        public virtual void Box() => Console.WriteLine($"Boxing {PizzaType}");
    }

    public class CheesePizza(string PizzaType) : Pizza(PizzaType) { }

    public class VeggiePizza(string PizzaType) : Pizza(PizzaType) { }

    public class ClamPizza(string PizzaType) : Pizza(PizzaType) { }

    public class PepperoniPizza(string PizzaType) : Pizza(PizzaType) { }
}
