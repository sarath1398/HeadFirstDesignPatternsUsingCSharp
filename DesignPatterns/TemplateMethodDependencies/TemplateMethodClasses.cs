using System.Reflection.Metadata.Ecma335;

namespace TemplateMethodDependencies
{
    public class TemplateMethodClasses
    {
        #region Abstract Classes

        public abstract class CaffeineBeverage
        {
            public void BoilWater() => Console.WriteLine("Boiling water");

            public abstract void Brew();

            public void PourInCup() => Console.WriteLine($"Pouring {this.GetType().Name} into cup");

            public abstract void AddCondiments();

            // Do not add any Condiments unless customer wants.
            // This is the hook
            public virtual bool UserWantsCondiments()
            {
                return false;
            }

            // The template method that defines the algorithm
            public void PrepareRecipe()
            {
                Console.WriteLine($"Making {this.GetType().Name}...");
                BoilWater();
                Brew();
                PourInCup();
                if (UserWantsCondiments())
                {
                    AddCondiments();
                }
            }
        }

        #endregion

        #region Classes

        public class Tea : CaffeineBeverage
        {
            public override void AddCondiments() => Console.WriteLine("Adding Lemon");

            public override void Brew() => Console.WriteLine("Steeping the tea");

            public override bool UserWantsCondiments()
            {
                Console.WriteLine("Would you like lemon with your tea (y/n)? ");
                var answer = Console.ReadLine();
                if (answer?.ToUpperInvariant() == "Y")
                {
                    return true;
                }
                return false;
            }
        }

        public class Coffee : CaffeineBeverage
        {
            public override void AddCondiments() => Console.WriteLine("Adding Milk and Sugar");

            public override void Brew() => Console.WriteLine("Dripping Coffee through filter");

            public override bool UserWantsCondiments()
            {
                Console.WriteLine("Would you like milk and sugar with your coffee (y/n)? ");
                var answer = Console.ReadLine();
                if (answer?.ToUpperInvariant() == "Y")
                {
                    return true;
                }
                return false;
            }
        }

        public class Duck(string name, int weight) : IComparable<Duck>
        {
            private string _name = name;
            private int _weight = weight;

            public override string ToString() => $"{_name} weighs {_weight}";

            public int CompareTo(Duck? otherDuck)
            {
                return otherDuck switch
                {
                    null => 1,
                    _ when this._weight < otherDuck._weight => -1,
                    _ when this._weight == otherDuck._weight => 0,
                    _ => 1
                };
            }
        }

        #endregion
    }
}