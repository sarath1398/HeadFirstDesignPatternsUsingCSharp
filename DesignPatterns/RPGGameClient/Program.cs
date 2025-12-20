using static MementoPatternDependencies.Classes;

namespace RPGGameClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MasterGameObject gameObject = new();

            gameObject.SetGameState("Level 12");

            Console.WriteLine("Mission Accomplished!");

            gameObject.SetGameState("Level 13");

            object checkpoint = gameObject.GetCurrentState();

            Console.WriteLine("Mission Failed. You are taken in Ambulance and you lost $100");

            gameObject.RestoreState(checkpoint);

        }
    }
}
