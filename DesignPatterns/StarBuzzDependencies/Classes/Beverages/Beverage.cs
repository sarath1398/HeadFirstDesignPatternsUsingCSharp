namespace StarBuzzDependencies.Classes.Beverages
{
    public abstract class Beverage()
    {
        public string _description = "Overridable Beverage";
        public virtual string GetDescription() => _description;

        public abstract double Cost();
    }
}
