using static TemplateMethodDependencies.TemplateMethodClasses;

namespace DuckExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Duck> ducksList = [ new Duck("Daffy", 8), new Duck("Dewey", 2),
                                     new Duck("Howard", 7), new Duck("Louie", 2),
                                     new Duck("Donald", 10), new Duck("Huey", 2)
                                   ];
            ducksList.Sort();

            foreach (Duck d in ducksList)
            {
                Console.WriteLine(d.ToString());
            }
        }
    }
}
