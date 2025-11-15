using StrategyPattern.Classes.Ducks;

namespace StrategyPatternApp
{
    public class DuckSimulator
    {
        private Duck _duck;
        public DuckSimulator(Duck duck) 
        {
            _duck = duck;
        }
        public void performDuckActions()
        {
            _duck.PerformFly();
            _duck.PerformQuack();
            _duck.Display();
            _duck.Swim();
        }
    }
}
