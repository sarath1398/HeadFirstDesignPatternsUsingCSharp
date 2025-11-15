namespace StrategyPattern.Interfaces
{
    public interface IQuackBehaviour
    {
        //naming this method in smallcase to avoid confusion between method and the class
        #pragma warning disable IDE1006 // Naming Styles
        void quack();
        #pragma warning restore IDE1006 // Naming Styles
    }
}
