using StrategyPattern.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace StrategyPattern.Classes.Ducks
{
    public abstract class Duck(IFlyBehaviour flyBehaviour, IQuackBehaviour quackBehaviour)
    {
        private IFlyBehaviour _flyBehaviour = flyBehaviour;
        private IQuackBehaviour _quackBehaviour = quackBehaviour;

        public void PerformFly()
        {
            _flyBehaviour.fly();
        }

        public void PerformQuack()
        {
            _quackBehaviour.quack();
        }

        // This will be an abstract method since display varies for each duck
        public abstract void Display();

        // Made this method virtual since in real life most ducks can swim.
        // So a single implementation will suffice in most cases.
        public virtual void Swim()
        {
            Console.WriteLine("This duck can swim!");   
        }

        public void SetFlyBehaviour(IFlyBehaviour flyBehaviour)
        {
            this._flyBehaviour = flyBehaviour;
        }

        public void SetQuackBehaviour(IQuackBehaviour quackBehaviour)
        {
            this._quackBehaviour = quackBehaviour;
        }
    }
}
