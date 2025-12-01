using static CafeMenuDependencies.CafeMenuClasses;

namespace CafeMenuDrive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PancakeHouseMenu pancakeHouseMenu = new();
            DinerMenu dinerMenu = new();
            CafeMenu cafeMenu = new();

            Waitress waitress = new(pancakeHouseMenu, dinerMenu,cafeMenu);

            waitress.PrintMenu();
        }
    }
}
