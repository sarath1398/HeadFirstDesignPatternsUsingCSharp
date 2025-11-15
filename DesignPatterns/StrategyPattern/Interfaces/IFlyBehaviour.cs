namespace StrategyPattern.Interfaces
{
    public interface IFlyBehaviour
    {
        //naming this method in smallcase to avoid confusion between method and the class
        #pragma warning disable IDE1006 // Naming Styles
        void fly();
        #pragma warning restore IDE1006 // Naming Styles
    }
}
