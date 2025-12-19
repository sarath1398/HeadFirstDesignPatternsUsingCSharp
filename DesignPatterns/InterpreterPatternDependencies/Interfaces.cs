using static InterpreterPatternDependencies.Classes;

namespace InterpreterPatternDependencies
{
    public class Interfaces
    {
        public interface IExpression
        {
            public void Interpret(Context context);
        }
    }
}
