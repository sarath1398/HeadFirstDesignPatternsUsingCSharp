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
            IQuackable mallardDuck = new QuackCounterDecorator(new MallardDuck());
            IQuackable redHeadDuck = new QuackCounterDecorator(new RedHeadDuck());
            IQuackable duckCall = new QuackCounterDecorator(new DuckCall());
            IQuackable rubberDuck = new QuackCounterDecorator(new RubberDuck());
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
