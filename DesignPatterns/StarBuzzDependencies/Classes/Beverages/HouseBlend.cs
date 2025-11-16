namespace StarBuzzDependencies.Classes.Beverages
{
    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            _description = "HouseBlend";
        }
        public override double Cost() => 0.89;
    }
}
