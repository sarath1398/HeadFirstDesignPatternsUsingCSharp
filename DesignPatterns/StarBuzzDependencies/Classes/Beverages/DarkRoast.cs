namespace StarBuzzDependencies.Classes.Beverages
{
    public class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            _description = "DarkRoast";
        }
        public override double Cost() => 0.99;
    }
}
