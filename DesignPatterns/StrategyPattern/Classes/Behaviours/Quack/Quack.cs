using StrategyPattern.Interfaces;

namespace StrategyPattern.Classes.Behaviours.Quack
{
    public class Quack : IQuackBehaviour
    {
        public void quack()
        {
            Console.WriteLine("This duck quacks!");
        }
    }
}
