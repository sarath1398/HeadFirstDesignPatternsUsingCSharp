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

        // Adapter Pattern starts

        public class Geese
        {
            public void Honk() => Console.WriteLine("Honk");
        }

        public class GooseAdapter(Geese geese) : IQuackable
        {
            private readonly Geese _geese = geese;

            public void Quack() => _geese.Honk();
        }
    }
}
