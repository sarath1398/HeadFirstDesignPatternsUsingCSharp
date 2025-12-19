using static InterpreterPatternDependencies.Interfaces;

namespace InterpreterPatternDependencies
{
    public class Classes
    {
        public class Context
        {
            private readonly Dictionary<string, bool> _context = [];

            public void SetVariable(string key, bool value) => _context[key] = value;

            public bool GetValue(string key) => _context.ContainsKey(key) ? _context[key] : false;
        }

        public class Variable(string name) : IExpression
        {
            public string Name { get; init; } = name;

            public void Interpret(Context context) 
                => Console.WriteLine($"Variable name is {Name} with value {context.GetValue(Name)}");
        }

        public class Repetition(Variable variable, IExpression expression) : IExpression
        {
            private readonly Variable _variable = variable;
            private readonly IExpression _expression = expression;
            private const int MAX_ITERATIONS = 5;

            public void Interpret(Context context)
            {
                // Fly for 5 times
                int counter = 0;
                _variable.Interpret(context);

                while (context.GetValue(_variable.Name))
                {
                    _expression.Interpret(context);
                    counter++;
                    if (counter == MAX_ITERATIONS)
                    {
                        context.SetVariable(_variable.Name, false);
                    }
                }

                _variable.Interpret(context);
            }
        }

        public class Sequence(IExpression expression1, IExpression expression2) : IExpression
        {
            private readonly IExpression _expression1 = expression1;
            private readonly IExpression _expression2 = expression2;

            public void Interpret(Context context)
            {
                _expression1.Interpret(context);
                _expression2.Interpret(context);
            }
        }

        public class QuackCommand : IExpression
        {
            public void Interpret(Context context) => Console.WriteLine("Quack!");
        }

        public class RightCommand : IExpression
        {
            public void Interpret(Context context) => Console.WriteLine("Duck turned right");
        }

        public class FlyCommand : IExpression
        {
            public void Interpret(Context context) => Console.WriteLine("Fly");
        }
    }
}
