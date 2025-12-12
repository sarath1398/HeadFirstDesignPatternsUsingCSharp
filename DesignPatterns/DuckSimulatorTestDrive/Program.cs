using static CompoundPatternDependencies.Classes;
using static CompoundPatternDependencies.Interfaces;

namespace DuckSimulatorTestDrive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program program = new();
            program.Simulate();
        }
        public void Simulate()
        {
            MallardDuck mallardDuck = new();
            RedHeadDuck redHeadDuck = new();
            DuckCall duckCall = new();
            RubberDuck rubberDuck = new();

            Console.WriteLine("\nDuck Simulator");

            Simulate(mallardDuck);
            Simulate(redHeadDuck);
            Simulate(duckCall);
            Simulate(rubberDuck);

            void Simulate(IQuackable quackable) => quackable.Quack();
        }
    }
}
