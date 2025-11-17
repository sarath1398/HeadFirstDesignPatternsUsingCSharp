using System.Reflection.Metadata.Ecma335;

namespace FactoryMethodPatternDependencies.Classes
{
    public abstract class Pizza
    {
        public string name;
        public string dough;
        public string sauce;
        public List<string> toppings;

        public Pizza() { }
        public virtual void Prepare() => Console.WriteLine($"Preparing {name}...\nAdding {dough}\n" +
            $"Adding {sauce}\nAdding Toppings: {string.Join(", ",toppings)}");

        public virtual void Bake() => Console.WriteLine($"Baking {name}");

        public virtual void Cut() => Console.WriteLine($"Cutting {name} Diagonally");

        public virtual void Box() => Console.WriteLine($"Boxing {name}");

        public virtual string GetName() => name;
    }

    public class NYStyleCheesePizza : Pizza
    {
        public NYStyleCheesePizza()
        {
            name = "NY Styled Sauce and Cheese Pizza";
            dough = "Thin Crust Dough";
            sauce = "Marinara Sauce";
            toppings = ["Grated Reggiano Cheese"];
        }
    }

    public class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza()
        {
            name = "Chicago Style Deep Dish Cheese Pizza";
            dough = "Extra Thick Crust Dough";
            sauce = "Plum Tomato Sauce";
            toppings = ["Shredded Mozzarella Cheese"];
        }

        public override void Cut() => Console.WriteLine($"Cutting the {name} into square slices");
    }
}
