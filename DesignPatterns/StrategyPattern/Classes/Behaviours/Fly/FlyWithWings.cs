using StrategyPattern.Interfaces;

namespace StrategyPattern.Classes.Behaviours.Fly
{
    public class FlyWithWings : IFlyBehaviour
    {
        public void fly()
        {
            Console.WriteLine("Flying with wings!");
        }
    }
}
