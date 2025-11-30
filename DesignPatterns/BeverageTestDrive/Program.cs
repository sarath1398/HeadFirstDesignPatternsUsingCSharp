using static TemplateMethodDependencies.TemplateMethodClasses;

namespace BeverageTestDrive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Tea tea = new();
            Coffee coffee = new();

            tea.PrepareRecipe();
            coffee.PrepareRecipe();
        }
    }
}
