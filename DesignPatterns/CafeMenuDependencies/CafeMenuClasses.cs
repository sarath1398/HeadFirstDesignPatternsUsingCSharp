namespace CafeMenuDependencies
{
    public class CafeMenuClasses
    {
        #region Interfaces

        // TODO: Add Remove method
        public interface IIterator
        {
            public bool HasNext();

            public MenuItem Next();
        }

        public interface IMenu
        {
            public IIterator CreateIterator();
        }

        #endregion

        #region Classes

        public class MenuItem(string name, string description, bool isVegetarian, double price)
        {
            private readonly string _name = name;
            private readonly string _description = description;
            private readonly bool _isVegetarian = isVegetarian;
            private readonly double _price = price;

            public string GetName() => _name;

            public string GetDescription() => _description;

            public bool IsVegetarian() => _isVegetarian;

            public double GetPrice() => _price;
        }

        public class PancakeHouseMenu : IMenu
        {
            private List<MenuItem> _menuItems;

            public PancakeHouseMenu()
            {
                _menuItems = [];
                AddItem("K&B's Pancake Breakfast", "Pancakes with scrambled eggs and toast", true, 2.99);
                AddItem("Regular Pancake Breakfast", "Pancakes with fried eggs, sausage", false, 2.99);
                AddItem("Blueberry Pancakes", "Pancakes made with fresh blueberries", true, 3.49);
                AddItem("Waffles", "Waffles with your choice of blueberries or strawberries", true, 3.59);
            }

            public void AddItem(string name, string description, bool isVegetarian, double price)
            {
                MenuItem newItem = new(name, description, isVegetarian, price);
                _menuItems.Add(newItem);
            }

            public IIterator CreateIterator() => new PancakeHouseMenuIterator(_menuItems);
        }

        public class DinerMenu : IMenu
        {
            public readonly static int MAX_ITEMS = 6;
            private int _numberOfItems = 0;
            private MenuItem[] _menuItems;

            public DinerMenu()
            {
                _menuItems = new MenuItem[MAX_ITEMS];

                AddItem("Vegetarian BLT", "(Fakin') Bacon with lettuce & tomato on whole wheat", true, 2.99);
                AddItem("BLT", "Bacon with lettuce & tomato on whole wheat", false, 2.99);
                AddItem("Soup of the day", "Soup of the day, with a side of potato salad", false, 3.29);
                AddItem("Hotdog", "A hot dog, with sauerkraut, relish, onions, topped with cheese", false, 3.05);
            }

            public void AddItem(string name, string description, bool vegetarian, double price)
            {
                MenuItem menuItem = new(name, description, vegetarian, price);
                if (_numberOfItems >= MAX_ITEMS)
                {
                    Console.WriteLine("Sorry, menu is full!  Can't add item to menu");
                }
                else
                {
                    _menuItems[_numberOfItems] = menuItem;
                    _numberOfItems++;
                }
            }

            public IIterator CreateIterator() => new DinerMenuIterator(_menuItems);
        }

        public class PancakeHouseMenuIterator(List<MenuItem> menuItems) : IIterator
        {
            private readonly List<MenuItem> _items = menuItems;
            private int _position = 0;

            public MenuItem Next()
            {
                MenuItem menuItem = _items[_position];
                _position++;
                return menuItem;
            }

            public bool HasNext() => !(_position >= _items.Count || _items[_position] == null);

        }

        public class DinerMenuIterator(MenuItem[] menuItems) : IIterator
        {
            private readonly MenuItem[] _items = menuItems;
            private int _position = 0;

            public MenuItem Next()
            {
                MenuItem menuItem = _items[_position];
                _position++;
                return menuItem;
            }

            public bool HasNext() => !(_position >= DinerMenu.MAX_ITEMS || _items[_position] == null);
        }

        public class Waitress(PancakeHouseMenu pancakeHouseMenu, DinerMenu dinerMenu)
        {
            private readonly PancakeHouseMenu pancakeHouseMenu = pancakeHouseMenu;
            private readonly DinerMenu dinerMenu = dinerMenu;

            public void PrintMenu()
            {
                IIterator pancakeIterator = pancakeHouseMenu.CreateIterator();
                IIterator dinerIterator = dinerMenu.CreateIterator();

                Console.WriteLine("MENU\n----\nBREAKFAST");
                PrintMenu(pancakeIterator);
                Console.WriteLine("\nLUNCH");
                PrintMenu(dinerIterator);
            }

            private void PrintMenu(IIterator iterator)
            {
                while (iterator.HasNext())
                {
                    MenuItem menuItem = iterator.Next();
                    Console.WriteLine(menuItem.GetName() + ", ");
                    Console.WriteLine(menuItem.GetPrice() + " -- ");
                    Console.WriteLine(menuItem.GetDescription());
                }
            }
        }

        #endregion
    }
}
