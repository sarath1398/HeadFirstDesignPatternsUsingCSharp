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
            Flock flockOfDucks = new();

            Console.WriteLine("\nDuck Simulator: With Composite - Flocks");

            IQuackable mallardDuck = duckFactory.CreateMallardDuck();
            IQuackable redHeadDuck = duckFactory.CreateRedheadDuck();
            IQuackable duckCall = duckFactory.CreateDuckCall();
            IQuackable rubberDuck = duckFactory.CreateRubberDuck();
            IQuackable gooseDuck = new GooseAdapter(new Geese());

            flockOfDucks.Add(redHeadDuck);
            flockOfDucks.Add(duckCall);
            flockOfDucks.Add(rubberDuck);
            flockOfDucks.Add(gooseDuck);

            Flock flockOfMallardDucks = new();

            IQuackable mallardDuck1 = duckFactory.CreateMallardDuck();
            IQuackable mallardDuck2 = duckFactory.CreateMallardDuck();
            IQuackable mallardDuck3 = duckFactory.CreateMallardDuck();

            flockOfMallardDucks.Add(mallardDuck);
            flockOfMallardDucks.Add(mallardDuck1);
            flockOfMallardDucks.Add(mallardDuck2);
            flockOfMallardDucks.Add(mallardDuck3);

            flockOfDucks.Add(flockOfMallardDucks);

            Quackologist quackologist = new Quackologist();
            flockOfDucks.RegisterObserver(quackologist);

            Console.WriteLine("\nDuck Simulator: Whole Flock Simulation");
            Simulate(flockOfDucks);
            Console.WriteLine("\nDuck Simulator: Mallard Flock Simulation");
            Simulate(flockOfMallardDucks);

            Console.WriteLine("\nThe ducks quacked " + QuackCounterDecorator.GetQuacks() + " times");
        }

        void Simulate(IQuackable quackable) => quackable.Quack();
    }
}
