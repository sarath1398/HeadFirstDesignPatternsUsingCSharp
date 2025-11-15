using StrategyPattern.Interfaces;

namespace StrategyPattern.Classes.Ducks
{
    public class RedheadDuck(IFlyBehaviour flyBehaviour, IQuackBehaviour quackBehaviour) : Duck(flyBehaviour, quackBehaviour)
    {
        public override void Display()
        {
            Console.WriteLine("This is a Redhead duck!");
        }
    }
}
