using StrategyPattern.Classes.Behaviours.Fly;
using StrategyPattern.Classes.Behaviours.Quack;
using StrategyPattern.Classes.Ducks;

namespace StrategyPatternApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Duck mallardDuck = new MallardDuck(new FlyWithWings(), new Quack());
            DuckSimulator duckSimulator = new DuckSimulator(mallardDuck);
            duckSimulator.performDuckActions();
            // Changable Behaviour
            mallardDuck.SetQuackBehaviour(new MuteQuack());
            duckSimulator.performDuckActions();
        }
    }
}
