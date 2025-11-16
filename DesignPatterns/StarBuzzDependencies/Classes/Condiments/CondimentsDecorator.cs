using StarBuzzDependencies.Classes.Beverages;

namespace StarBuzzDependencies.Classes.Condiments
{
    public abstract class CondimentsDecorator(Beverage beverage) : Beverage
    {
        public Beverage beverage = beverage;

        public abstract override string GetDescription();
    }


}
