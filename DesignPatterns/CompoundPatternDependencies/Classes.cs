using static CompoundPatternDependencies.Interfaces;

namespace CompoundPatternDependencies
{
    public class Classes
    {
        public class Observable(IQuackObservable duck) : IQuackObservable
        {
            private readonly List<IObserver> _observers = new();
            private readonly IQuackObservable _duck = duck;

            public void RegisterObserver(IObserver observer) => _observers.Add(observer);

            public void NotifyObservers()
            {
                IEnumerator<IObserver> enumerator = _observers.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    IObserver observer = enumerator.Current;
                    observer.Update(_duck);
                }
            }
        }

        public class Quackologist : IObserver
        {
            public void Update(IQuackObservable duck) => Console.WriteLine("Quackologist: " + duck + " just quacked.");
        }

        public class MallardDuck : IQuackable
        {

            private readonly IQuackObservable _observable;

            public MallardDuck() => _observable = new Observable(this);

            public void Quack()
            {
                Console.WriteLine("Quack");
                NotifyObservers();
            }

            public void RegisterObserver(IObserver observer)
            {
                _observable.RegisterObserver(observer);
            }
            public void NotifyObservers()
            {
                _observable.NotifyObservers();
            }

            public override string ToString() => "Mallard Duck";
        }

        public class RedHeadDuck : IQuackable
        {
            private readonly IQuackObservable _observable;

            public RedHeadDuck() => _observable = new Observable(this);

            public void Quack()
            {
                Console.WriteLine("Quack");
                NotifyObservers();
            }

            public void RegisterObserver(IObserver observer)
            {
                _observable.RegisterObserver(observer);
            }
            public void NotifyObservers()
            {
                _observable.NotifyObservers();
            }

            public override string ToString() => "Red Head Duck";
        }

        public class RubberDuck : IQuackable
        {
            private readonly IQuackObservable _observable;

            public RubberDuck() => _observable = new Observable(this);

            public void Quack()
            {
                Console.WriteLine("Squeak");
                NotifyObservers();
            }

            public void RegisterObserver(IObserver observer)
            {
                _observable.RegisterObserver(observer);
            }
            public void NotifyObservers()
            {
                _observable.NotifyObservers();
            }

            public override string ToString() => "Rubber Duck"; 
        }

        public class DuckCall : IQuackable
        {
            private readonly IQuackObservable _observable;

            public DuckCall() => _observable = new Observable(this);

            public void Quack()
            {
                Console.WriteLine("Kwak");
                NotifyObservers();
            }

            public void RegisterObserver(IObserver observer)
            {
                _observable.RegisterObserver(observer);
            }
            public void NotifyObservers()
            {
                _observable.NotifyObservers();
            }

            public override string ToString() => "Duck Call";
        }

        #region Adapter pattern

        public class Geese
        {
            public void Honk() => Console.WriteLine("Honk");
        }

        public class GooseAdapter : IQuackable
        {
            private readonly Geese _geese;
            private readonly IQuackObservable _observable;

            public GooseAdapter(Geese geese)
            {
                _geese = geese;
                _observable = new Observable(this);
            }

            public void Quack()
            {
                _geese.Honk();
                NotifyObservers();
            }

            public void RegisterObserver(IObserver observer)
            {
                _observable.RegisterObserver(observer);
            }
            public void NotifyObservers()
            {
                _observable.NotifyObservers();
            }

            public override string ToString() => "Geese pretending to be a Duck";
        }

        #endregion

        #region Decorator pattern

        public class QuackCounterDecorator : IQuackable
        {
            private readonly IQuackable _quackable;
            private readonly IQuackObservable _observable;
            private static int _numberOfQuacks = 0;

            public QuackCounterDecorator(IQuackable quackable)
            {
                _quackable = quackable;
                _observable = new Observable(this);
            }

            public void Quack()
            {
                _quackable.Quack();
                _numberOfQuacks++;
                NotifyObservers();
            }

            public static int GetQuacks() => _numberOfQuacks;

            public void RegisterObserver(IObserver observer)
            {
                _observable.RegisterObserver(observer);
            }
            public void NotifyObservers()
            {
                _observable.NotifyObservers();
            }

            public override string ToString() => _quackable.ToString() ?? String.Empty;
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

        #region Composite + Iterator pattern

        public class Flock : IQuackable
        {
            private List<IQuackable> _flock = [];
            private IQuackObservable _observable;

            public void Add(IQuackable quackable) => _flock.Add(quackable);

            public void Quack()
            {
                var iterator = _flock.GetEnumerator();

                while (iterator.MoveNext())
                {
                    var quacker = iterator.Current;
                    quacker.Quack();
                }
            }

            public void RegisterObserver(IObserver observer)
            {
                IEnumerator<IQuackable> iterator = _flock.GetEnumerator();
                while (iterator.MoveNext())
                {
                    IQuackable duck = iterator.Current;
                    duck.RegisterObserver(observer);
                }
            }
            public void NotifyObservers() { }
        }

        #endregion
    }
}
