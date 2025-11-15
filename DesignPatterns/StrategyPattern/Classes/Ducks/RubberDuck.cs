using StrategyPattern.Interfaces;

namespace StrategyPattern.Classes.Ducks
{
    public class RubberDuck(IFlyBehaviour flyBehaviour, IQuackBehaviour quackBehaviour) : Duck(flyBehaviour, quackBehaviour)
    {
        public override void Display()
        {
            Console.WriteLine("This is a Rubber Duck!");
        }

        // Since this is a virtual method, this can be even removed and the code won't break
        public override void Swim()
        {
            Console.WriteLine("This duck cannot swim but can float!");
        }
    }
}
