using static InterpreterPatternDependencies.Classes;

namespace DuckInterpreter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Context context = new();

            // Equivalent to right;
            RightCommand rightCommand = new();

            FlyCommand flyCommand = new();
            Variable daylightVariable = new("daylight");
            context.SetVariable(daylightVariable.Name, true);

            // Evaluates to while (daylight) fly;
            Repetition repetition = new(daylightVariable, flyCommand);

            // Sequence 1 - Combining rightCommand and repetition
            // right; while (daylight) fly;

            Sequence sequence1 = new(rightCommand, repetition);
            QuackCommand quackCommand = new();

            // Sequence 2 - Combining result of sequence1 and quackCommand
            // Combines sequence 1 - right; while (daylight) fly; with quack;

            Sequence sequence2 = new(sequence1, quackCommand);

            // This recursively Interprets all the expressions
            sequence2.Interpret(context);

        }
    }
}
