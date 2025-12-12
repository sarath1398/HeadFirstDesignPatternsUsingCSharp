using static CompoundPatternDependencies.Interfaces;

namespace CompoundPatternDependencies
{
    public class Interfaces
    {

        public interface IObserver
        {
            public void Update(IQuackObservable duck);
        }

        public interface IQuackObservable
        {

            public void RegisterObserver(IObserver observer);

            public void NotifyObservers();
        }

        public interface IQuackable : IQuackObservable
        {
            // C# 8.0 allows default method implementation
            public void Quack() => Console.WriteLine("Quack");
        }
    }
}
