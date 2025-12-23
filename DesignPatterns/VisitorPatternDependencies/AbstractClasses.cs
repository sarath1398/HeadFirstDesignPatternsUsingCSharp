using static VisitorPatternDependencies.Interfaces;

namespace VisitorPatternDependencies
{
    public class AbstractClasses
    {
        // Component Class
        public abstract class MenuComponent
        {
            public virtual string GetName() => throw new InvalidOperationException();

            public virtual string GetDescription() => throw new InvalidOperationException();

            public virtual double GetPrice() => throw new InvalidOperationException();

            public virtual bool IsVegetarian() => throw new InvalidOperationException();

            public virtual void Print() => throw new InvalidOperationException();

            public virtual void Add(MenuComponent menuComponent) => throw new InvalidOperationException();

            public virtual void Remove(MenuComponent menuComponent) => throw new InvalidOperationException();

            public virtual MenuComponent GetChild(int index) => throw new InvalidOperationException();

            // Additional method from existing Composite pattern to pass Visitor object
            public virtual int GetCalories() => throw new InvalidOperationException();

            public virtual double GetProtein() => throw new InvalidOperationException();

            public virtual double GetCarbs() => throw new InvalidOperationException();
            public abstract void Accept(IVisitor visitor);
        }
    }
}
