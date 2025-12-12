namespace CompoundPatternDependencies
{
    public class Interfaces
    {
        public interface IQuackable
        {
            // C# 8.0 allows default method implementation
            public void Quack() => Console.WriteLine("Quack");
        }
    }
}
