using StrategyPattern.Interfaces;

namespace StrategyPattern.Classes.Behaviours.Fly
{
    public class FlyNoWay : IFlyBehaviour
    {
        public void fly()
        {
            Console.WriteLine("Can't Fly");
        }
    }
}
