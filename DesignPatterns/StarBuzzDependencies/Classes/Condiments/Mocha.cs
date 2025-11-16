using StarBuzzDependencies.Classes.Beverages;

namespace StarBuzzDependencies.Classes.Condiments
{
    public class Mocha(Beverage beverage) : CondimentsDecorator(beverage)
    {
        public override string GetDescription() => beverage.GetDescription() + ", Mocha";

        public override double Cost() => beverage.Cost() + 0.2;
    }
}
