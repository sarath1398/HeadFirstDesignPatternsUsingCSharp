using static AdapterPatternDependencies.Classes.AdapterPatternClasses;

namespace DuckTestDrive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IDuck mallardDuck = new MallardDuck();

            ITurkey wildTurkey = new WildTurkey();

            IDuck turkeyAdapter = new TurkeyAdapter(wildTurkey);

            turkeyAdapter.Quack();
            turkeyAdapter.Fly();
            turkeyAdapter.Swim();
        }
    }
}
