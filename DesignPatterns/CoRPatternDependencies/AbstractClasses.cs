using static CoRPatternDependencies.Classes;

namespace CoRPatternDependencies
{
    public class AbstractClasses
    {
        public abstract class Handler
        {
            protected Handler? successor;

            public void SetSuccessor(Handler successor) => this.successor = successor;

            public abstract void HandleRequest(Email email);

            // Additional method deviating from the book to handle fallback scenario
            public virtual void HandleFallback() => Console.WriteLine("Mail moved to snooze folder");
        }
    }
}
