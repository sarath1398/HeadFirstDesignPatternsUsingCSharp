using static VisitorPatternDependencies.AbstractClasses;
using static VisitorPatternDependencies.Classes;

namespace ObjectvilleVisitorDiner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MenuComponent pancakeHouseMenu = new Menu("PANCAKE HOUSE MENU", "Breakfast");
            MenuComponent dinerMenu = new Menu("DINER MENU", "Lunch");
            MenuComponent cafeMenu = new Menu("CAFE MENU", "Dinner");
            MenuComponent dessertMenu = new Menu("DESSERT MENU", "Dessert of course!");

            MenuComponent allMenus = new Menu("ALL MENUS", "All Menus Combined");

            allMenus.Add(pancakeHouseMenu);
            allMenus.Add(dinerMenu);
            allMenus.Add(cafeMenu);

            pancakeHouseMenu.Add(new MenuItem("K&B's Pancake Breakfast", "Pancakes with scrambled eggs and toast", true, 2.99, 400, 15, 250));
            pancakeHouseMenu.Add(new MenuItem("Regular Pancake Breakfast", "Pancakes with fried eggs, sausage", false, 2.99, 300, 30, 350));
            pancakeHouseMenu.Add(new MenuItem("Blueberry Pancakes", "Pancakes made with fresh blueberries", true, 3.49, 600, 20, 400));
            pancakeHouseMenu.Add(new MenuItem("Waffles", "Waffles with your choice of blueberries or strawberries", true, 3.59, 750, 10, 600));

            dinerMenu.Add(new MenuItem("Vegetarian BLT", "(Fakin') Bacon with lettuce & tomato on whole wheat", true, 2.99, 250, 15, 200));
            dinerMenu.Add(new MenuItem("BLT", "Bacon with lettuce & tomato on whole wheat", false, 2.99, 300, 25, 250));
            dinerMenu.Add(new MenuItem("Soup of the day", "Soup of the day, with a side of potato salad", false, 3.29, 100, 5, 250));
            dinerMenu.Add(new MenuItem("Hotdog", "A hot dog, with sauerkraut, relish, onions, topped with cheese", false, 3.05, 400, 25, 200));

            cafeMenu.Add(new MenuItem("Veggie Burger and Air Fries", "Veggie burger on a whole wheat bun, lettuce, tomato, and fries",
                true, 3.99, 700, 10, 500));
            cafeMenu.Add(new MenuItem("Soup of the day", "A cup of the soup of the day, with a side salad", false, 3.69, 150, 5, 200));
            cafeMenu.Add(new MenuItem("Burrito", "A large burrito, with whole pinto beans, salsa, guacamole", true, 4.29, 250, 10, 200));

            dinerMenu.Add(new MenuItem("Pasta", "Spaghetti with Marinara Sauce, and a slice of sourdough bread", true, 3.89, 500, 10, 350));

            dinerMenu.Add(dessertMenu);

            dessertMenu.Add(new MenuItem("Apple Pie", "Apple pie with a flakey crust, topped with vanilla ice cream", true, 1.59, 600, 3, 550));
            dessertMenu.Add(new MenuItem("Cheesecake", " Creamy New York cheesecake, with a chocolate graham crust", true, 1.99, 650, 2, 850));
            dessertMenu.Add(new MenuItem("Sorbet", " A scoop of raspberry and a scoop of lime", true, 1.89, 450, 5, 550));

            Waitress waitress = new(allMenus);
            waitress.PrintMenu();

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            HealthInspector visitor = new();
            allMenus.Accept(visitor);

            // We are not having get methods related to carbs, proteins and calories since this example
            // defines the role of a visitor better
            Console.WriteLine("\n--- Nutritional Report ---");
            Console.WriteLine($"Total Calories: {visitor.TotalCalories}");
            Console.WriteLine($"Total Protein:  {visitor.TotalProtein}g");
            Console.WriteLine($"Total Carbs:    {visitor.TotalCarbs}g");
            Console.WriteLine($"Health Rating:  {visitor.GetHealthRating()}");
        }
    }
}
