using StarBuzzDependencies.Classes.Beverages;

namespace StarBuzzDependencies.Classes.Condiments
{
    public class SteamedMilk(Beverage beverage) : CondimentsDecorator(beverage)
    {
        public override string GetDescription() => beverage.GetDescription() + ", Steamed Milk";

        public override double Cost() => beverage.Cost() + 0.1;
    }
}
