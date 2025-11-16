using StarBuzzDependencies.Classes.Beverages;
using StarBuzzDependencies.Classes.Condiments;

namespace StarBuzzApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Beverage beverage = new HouseBlend();
            beverage = new Mocha(beverage);
            beverage = new Mocha(beverage);
            beverage = new Whip(beverage);
            Console.WriteLine($"Description : {beverage.GetDescription()}\nCost : ${beverage.Cost():F2}");
        }
    }
}
