using static CompoundPatternDependencies.Classes;
using static CompoundPatternDependencies.Interfaces;

namespace DuckSimulatorTestDrive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program program = new();
            AbstractDuckFactory duckFactory = new CountingDuckFactory();
            program.Simulate(duckFactory);
        }
        public void Simulate(AbstractDuckFactory duckFactory)
        {
            IQuackable mallardDuck = duckFactory.CreateMallardDuck();
            IQuackable redHeadDuck = duckFactory.CreateRedheadDuck();
            IQuackable duckCall = duckFactory.CreateDuckCall();
            IQuackable rubberDuck = duckFactory.CreateRubberDuck();
            IQuackable gooseAdapter = new GooseAdapter(new Geese());

            Console.WriteLine("\nDuck Simulator");

            Simulate(mallardDuck);
            Simulate(redHeadDuck);
            Simulate(duckCall);
            Simulate(rubberDuck);
            Simulate(gooseAdapter);

            Console.WriteLine("The ducks quacked " + QuackCounterDecorator.GetQuacks() + " times");
        }

        void Simulate(IQuackable quackable) => quackable.Quack();
    }
}
