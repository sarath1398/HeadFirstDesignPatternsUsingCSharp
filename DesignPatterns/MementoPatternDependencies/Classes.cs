using System.Threading.Channels;

namespace MementoPatternDependencies
{
    public class Classes
    {
        public class GameMemento(string state)
        {
            public string SavedGameState { get; private set; } = state;
        }

        public class MasterGameObject
        {
            private string _gameState;

            public void SetGameState(string level)
            {
                _gameState = level;
                Console.WriteLine($"Congratulations!\n You advance to {_gameState}");
            }

            // Object return type ensures that the Memento is not accessible by the client
            public object GetCurrentState()
            {
                return new GameMemento(_gameState);
            }

            public void RestoreState(object savedState)
            {
                if (savedState is GameMemento memento)
                {
                    _gameState = memento.SavedGameState;
                    Console.WriteLine($"Last Checkpoint restored. You are at {_gameState}");
                }
            }
        }
    }
}
