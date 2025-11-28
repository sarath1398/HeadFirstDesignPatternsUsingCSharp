namespace AdapterPatternDependencies.Classes
{
   
    public class AdapterPatternClasses
    {
        #region Interfaces

        public interface IDuck
        {
            public void Quack();
            public void Fly();

            //Adding another method to show the limitation of adapter pattern
            public void Swim();
        }

        public interface ITurkey
        {
            public void Gobble();

            public void ShortFly();
        }

        #endregion

        #region Classes

        public class MallardDuck : IDuck
        {
            public void Quack() => Console.WriteLine("Mallard duck quacks!");

            public void Fly() => Console.WriteLine("Mallard Duck is flying");

            public void Swim() => Console.WriteLine(" Mallard Duck is swimming");
        }

        public class WildTurkey : ITurkey
        {
            public void Gobble() => Console.WriteLine("Turkey is gobbling!");

            public void ShortFly() => Console.WriteLine("Turkey is flying for a small distance");
        }

        public class TurkeyAdapter(ITurkey turkey) : IDuck
        {
            private readonly ITurkey _turkey = turkey;

            public void Quack() => _turkey.Gobble();

            public void Fly()
            {
                for (int i = 0; i < 5; i++)
                {
                    _turkey.ShortFly();
                }
            }

            public void Swim()
            { 
                throw new NotImplementedException("Turkey cannot swim");
            }

        }

        #endregion
    }

}
