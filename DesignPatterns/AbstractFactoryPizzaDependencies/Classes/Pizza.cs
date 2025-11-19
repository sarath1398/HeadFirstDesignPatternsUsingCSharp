namespace AbstractFactoryPizzaDependencies.Classes
{
    public abstract class Pizza
    {
        public string Name = "Pizza";

        public IDough dough;
        public ISauce sauce;
        public ICheese cheese;
        public IClams clams;

        public abstract void PreparePizza();

        public void Bake()
        {
            Console.WriteLine("Bake for 25 minutes at 350");
        }

        public void Cut()
        {
            Console.WriteLine("Cutting the pizza into diagonal slices");
        }

        public void Box()
        {
            Console.WriteLine("Place Pizza in official PizzaStore Box");
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        public override string ToString()
        {
            return this.Name + "is prepared successfully";
        }
    }

    public class CheesePizza(IPizzaIngredientFactory pizzaIngredientFactory) : Pizza
    {
        readonly IPizzaIngredientFactory _ingredientFactory = pizzaIngredientFactory;

        public override void PreparePizza()
        {
            Console.WriteLine("Preparing" + base.GetName());
            dough = _ingredientFactory.CreateDough();
            sauce = _ingredientFactory.CreateSauce();
            cheese = _ingredientFactory.CreateCheese();
            Bake();
            Cut();
            Box();
        }

        public new void SetName(string Name)
        {
            base.SetName(Name);
        }
    }

    public class ClamPizza(IPizzaIngredientFactory pizzaIngredientFactory) : Pizza
    {
        readonly IPizzaIngredientFactory _ingredientFactory = pizzaIngredientFactory;

        public override void PreparePizza()
        {
            Console.WriteLine("Preparing" + base.GetName());
            dough = _ingredientFactory.CreateDough();
            sauce = _ingredientFactory.CreateSauce();
            cheese = _ingredientFactory.CreateCheese();
            clams = _ingredientFactory.CreateClams();
            Bake();
            Cut();
            Box();
        }

        public new void SetName(string Name)
        {
            base.SetName(Name);
        }
    }
}
