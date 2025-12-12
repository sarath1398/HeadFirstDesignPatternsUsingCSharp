using static CompoundPatternDependencies.Interfaces;

namespace CompoundPatternDependencies
{
    public class Classes
    {
        public class MallardDuck : IQuackable
        {
            // Using default implementation of IQuackable.Quack method
        }

        public class RedHeadDuck : IQuackable
        {
            // Using default implementation of IQuackable.Quack method
        }

        public class RubberDuck : IQuackable
        {
            public void Quack() => Console.WriteLine("Squeak");
        }

        public class DuckCall : IQuackable
        {
            public void Quack() => Console.WriteLine("Kwak");
        }

        #region Adapter pattern

        public class Geese
        {
            public void Honk() => Console.WriteLine("Honk");
        }

        public class GooseAdapter(Geese geese) : IQuackable
        {
            private readonly Geese _geese = geese;

            public void Quack() => _geese.Honk();
        }

        #endregion

        #region Decorator pattern

        public class QuackCounterDecorator(IQuackable quackable) : IQuackable
        {
            private readonly IQuackable _quackable = quackable;
            private static int _numberOfQuacks = 0;

            public void Quack()
            {
                _quackable.Quack();
                _numberOfQuacks++;
            }

            public static int GetQuacks() => _numberOfQuacks;
        }

        #endregion

        #region Abstract Factory pattern

        public abstract class AbstractDuckFactory
        {
            public abstract IQuackable CreateMallardDuck();
            public abstract IQuackable CreateRedheadDuck();
            public abstract IQuackable CreateDuckCall();
            public abstract IQuackable CreateRubberDuck();
        }

        public class DuckFactory : AbstractDuckFactory
        {
            public override IQuackable CreateMallardDuck()
            {
                return new MallardDuck();
            }

            public override IQuackable CreateRedheadDuck()
            {
                return new RedHeadDuck();
            }

            public override IQuackable CreateDuckCall()
            {
                return new DuckCall();
            }

            public override IQuackable CreateRubberDuck()
            {
                return new RubberDuck();
            }
        }

        public class CountingDuckFactory : AbstractDuckFactory
        {
            public override IQuackable CreateMallardDuck()
            {
                return new QuackCounterDecorator(new MallardDuck());
            }

            public override IQuackable CreateRedheadDuck()
            {
                return new QuackCounterDecorator(new RedHeadDuck());
            }

            public override IQuackable CreateDuckCall()
            {
                return new QuackCounterDecorator(new DuckCall());
            }

            public override IQuackable CreateRubberDuck()
            {
                return new QuackCounterDecorator(new RubberDuck());
            }
        }

        #endregion
    }
}
