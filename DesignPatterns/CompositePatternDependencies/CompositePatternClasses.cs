namespace CompositePatternDependencies
{
    public class CompositePatternClasses
    {
        // Component Class
        public abstract class MenuComponent
        {
            public virtual string GetName() => throw new InvalidOperationException();

            public virtual string GetDescription() => throw new InvalidOperationException();

            public virtual double GetPrice() => throw new InvalidOperationException();

            public virtual bool IsVegetarian() => throw new InvalidOperationException();

            public virtual void Print() => throw new InvalidOperationException();

            public virtual void Add(MenuComponent menuComponent) => throw new InvalidOperationException();

            public virtual void Remove(MenuComponent menuComponent) => throw new InvalidOperationException();

            public virtual MenuComponent GetChild(int index) => throw new InvalidOperationException();
        }

        // Node/Composite Class
        public class Menu(string name, string description) : MenuComponent
        {
            private List<MenuComponent> _menuComponents = [];
            private readonly string _name = name;
            private readonly string _description = description;

            public override string GetName() => _name;

            public override string GetDescription() => _description;

            public override void Add(MenuComponent component) => _menuComponents.Add(component);

            public override MenuComponent GetChild(int index) => _menuComponents[index - 1];

            public override void Remove(MenuComponent menuComponent) => _menuComponents.Remove(menuComponent);

            public override void Print()
            {
                Console.Write("\n" + _name);
                Console.WriteLine(", " + _description);
                Console.WriteLine("---------------------");

                foreach (MenuComponent component in _menuComponents)
                {
                    component.Print();
                }
            }
        }

        // Leaf Class
        public class MenuItem(string name,string description,bool isVegetarian, double price) : MenuComponent
        {
            private readonly string _name = name;
            private readonly string _description = description;
            private readonly bool _isVegetarian = isVegetarian;
            private readonly double _price = price;

            public override string GetName() => _name;

            public override string GetDescription() => _description;

            public override bool IsVegetarian() => _isVegetarian;

            public override double GetPrice() => _price;

            public override void Print()
            {
                Console.Write($" {_name}");
                if (IsVegetarian())
                {
                    Console.Write(" (V) ");
                }
                Console.WriteLine(", " + _price);
                Console.WriteLine("\t--" + _description);
            }
        }

        // Here, the Waitress class handles only the root MenuComponent. 
        // The root MenuComponent will be responsible for
        // recursively printing the Menu and the MenuItems
        public class Waitress(MenuComponent allMenus)
        {
            private readonly MenuComponent allMenus = allMenus;

            public void PrintMenu()
            {
                allMenus.Print();
            }
        }
    }
}
