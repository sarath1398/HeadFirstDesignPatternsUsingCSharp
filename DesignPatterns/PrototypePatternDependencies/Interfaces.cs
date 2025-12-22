namespace PrototypePatternDependencies
{
    public class Interfaces
    {
        public interface IMonster
        {
            public IMonster Clone();

            public void ShowStats();
        }
    }
}
