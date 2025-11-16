namespace StarBuzzDependencies.Classes.Beverages
{
    public class Decaf : Beverage
    {
        public Decaf()
        {
            _description = "Decaf";
        }
        public override double Cost() => 1.05;
    }
}
