using static BuilderPatternDependencies.Classes;
using static BuilderPatternDependencies.AbstractClasses;

namespace VacationPlanner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AbstractBuilder builder = new VacationBuilder();
            AbstractFluentBuilder fluentBuilder = new FluentVacationBuilder();

            Client.ConstructPlanner(builder);

            Client.ConstructFluentPlanner(fluentBuilder);

            var myVacation = builder.GetVacationPlanner();
            Console.WriteLine(myVacation.ToString() + "\n");

            myVacation = fluentBuilder.GetVacationPlanner();
            Console.WriteLine(myVacation);
            
        }
    }
}
