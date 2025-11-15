using StrategyPattern.Interfaces;

namespace StrategyPattern.Classes.Ducks
{
    public class WoodenDecoyDuck(IFlyBehaviour flyBehaviour, IQuackBehaviour quackBehaviour) : Duck(flyBehaviour, quackBehaviour)
    {
        public override void Display()
        {
            Console.WriteLine("This is a decoy duck");
        }

        public override void Swim()
        {
            Console.WriteLine("This duck cannot swim!");
        }
    }
}
