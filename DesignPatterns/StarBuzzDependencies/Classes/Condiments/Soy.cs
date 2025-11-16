using StarBuzzDependencies.Classes.Beverages;

namespace StarBuzzDependencies.Classes.Condiments
{
    public class Soy(Beverage beverage) : CondimentsDecorator(beverage)
    {
        public override string GetDescription() => beverage.GetDescription() + ", Soy";
        public override double Cost() => beverage.Cost() + 0.15;
    }
}
