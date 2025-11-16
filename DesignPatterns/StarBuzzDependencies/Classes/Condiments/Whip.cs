using StarBuzzDependencies.Classes.Beverages;

namespace StarBuzzDependencies.Classes.Condiments
{
    public class Whip(Beverage beverage) : CondimentsDecorator(beverage)
    {
        public override string GetDescription() => beverage.GetDescription() + ", Whip";
        public override double Cost() => beverage.Cost() + 0.1;
    }
}
