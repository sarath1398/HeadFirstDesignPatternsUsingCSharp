using static VisitorPatternDependencies.AbstractClasses;
using static VisitorPatternDependencies.Classes;
using static VisitorPatternDependencies.Interfaces;

namespace VisitorPatternDependencies
{
    public class Classes
    {

        // Node/Composite Class
        public class Menu(string name, string description) : MenuComponent
        {
            private readonly List<MenuComponent> _menuComponents = [];
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

            public override void Accept(IVisitor visitor)
            {
                visitor.VisitMenu(this);

                foreach (MenuComponent component in _menuComponents)
                {
                    component.Accept(visitor);
                }
            }
        }

        // Leaf Class
        public class MenuItem(string name, string description, bool isVegetarian, double price,
            int calories, double protein, double carbs) : MenuComponent
        {
            private readonly string _name = name;
            private readonly string _description = description;
            private readonly bool _isVegetarian = isVegetarian;
            private readonly double _price = price;
            private readonly int _calories = calories;
            private readonly double _protein = protein;
            private readonly double _carbs = carbs;

            public override string GetName() => _name;

            public override string GetDescription() => _description;

            public override bool IsVegetarian() => _isVegetarian;

            public override double GetPrice() => _price;

            public override int GetCalories() => _calories;

            public override double GetProtein() => _protein;

            public override double GetCarbs() => _carbs;

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

            public override void Accept(IVisitor visitor)
            {
                visitor.VisitMenuItem(this);
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

        // Since the book mentions addititonal health information to the existing composite pattern,
        // we are having HealthInspector as our visitor
        public class HealthInspector : IVisitor
        {
            public int TotalCalories { get; set; } = 0;
            public double TotalCarbs { get; set; } = 0;
            public double TotalProtein { get; set; } = 0;

            private int _menuCount = 0;

            public void VisitMenuItem(MenuItem item)
            {
                Console.WriteLine($"Visiting Item: {item.GetName()}");
                TotalCalories += item.GetCalories();
                TotalCarbs += item.GetCarbs();
                TotalProtein += item.GetProtein();
                _menuCount++;
            }

            public void VisitMenu(Menu menu)
            {
                Console.WriteLine($"Visiting Menu: {menu.GetName()}");
            }

            public string GetHealthRating()
            {
                if (_menuCount == 0)
                {
                    return "N/A";
                }
                else
                {
                    double nutritionQuotient = (double)((TotalCalories+TotalCarbs+TotalProtein)/_menuCount);
                    return nutritionQuotient switch
                    {
                        <600 => "A Grade - Very Healthy",
                        <1200 => "B Grade - Consider reducing carbs",
                        _ => "C Grade - High Carbs, totally unhealthy"
                    };
                }
            }
        }
    }
}
