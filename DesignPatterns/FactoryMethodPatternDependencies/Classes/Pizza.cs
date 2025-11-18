using System.Reflection.Metadata.Ecma335;

namespace FactoryMethodPatternDependencies.Classes
{
    public abstract class Pizza
    {
        public string name = "Pizza";
        public string dough = "Dough";
        public string sauce = "Sauce";
        public List<string> toppings = [];

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

    /* Not going much into the implementation part of other Pizzas */
    public class NYStyleVeggiePizza : Pizza
    {
        public NYStyleVeggiePizza()
        {
            name = "NY Styled Veggie Pizza";
            dough = "Thin Crust Dough";
            sauce = "Marinara Sauce";
            toppings = ["Grated Reggiano Cheese"];
        }
    }

    public class NYStyleClamPizza : Pizza
    {
        public NYStyleClamPizza()
        {
            name = "NY Styled Clam Pizza";
            dough = "Thin Crust Dough";
            sauce = "Marinara Sauce";
            toppings = ["Grated Reggiano Cheese"];
        }
    }

    public class NYStylePepperoniPizza : Pizza
    {
        public NYStylePepperoniPizza()
        {
            name = "NY Styled Pepperoni Pizza";
            dough = "Thin Crust Dough";
            sauce = "Marinara Sauce";
            toppings = ["Grated Reggiano Cheese"];
        }
    }

    public class ChicagoStyleVeggiePizza : Pizza
    {
        public ChicagoStyleVeggiePizza()
        {
            name = "Chicago Style Deep Dish Veggie Pizza";
            dough = "Extra Thick Crust Dough";
            sauce = "Plum Tomato Sauce";
            toppings = ["Shredded Mozzarella Cheese"];
        }

        public override void Cut() => Console.WriteLine($"Cutting the {name} into square slices");
    }

    public class ChicagoStyleClamPizza : Pizza
    {
        public ChicagoStyleClamPizza()
        {
            name = "Chicago Style Deep Dish Clam Pizza";
            dough = "Extra Thick Crust Dough";
            sauce = "Plum Tomato Sauce";
            toppings = ["Shredded Mozzarella Cheese"];
        }

        public override void Cut() => Console.WriteLine($"Cutting the {name} into square slices");
    }

    public class ChicagoStylePepperoniPizza : Pizza
    {
        public ChicagoStylePepperoniPizza()
        {
            name = "Chicago Style Deep Dish Peppeproni Pizza";
            dough = "Extra Thick Crust Dough";
            sauce = "Plum Tomato Sauce";
            toppings = ["Shredded Mozzarella Cheese"];
        }

        public override void Cut() => Console.WriteLine($"Cutting the {name} into square slices");
    }
}
