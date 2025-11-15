using StrategyPattern.Interfaces;

namespace StrategyPattern.Classes.Behaviours.Quack
{
    public class MuteQuack : IQuackBehaviour
    {
        public void quack()
        {
            Console.WriteLine("This duck cannot make sounds");
        }
    }
}
