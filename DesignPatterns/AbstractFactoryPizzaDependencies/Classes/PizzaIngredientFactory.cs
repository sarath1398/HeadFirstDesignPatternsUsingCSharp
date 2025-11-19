namespace AbstractFactoryPizzaDependencies.Classes
{

    public interface IPizzaIngredientFactory
    {
        public IDough CreateDough();

        public ISauce CreateSauce();

        public ICheese CreateCheese();

        public IClams CreateClams();

    }

    public class NYPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public IDough CreateDough()
        {
            return new ThinCrustDough();
        }

        public ISauce CreateSauce()
        {
            return new MarinaraSauce();
        }

        public ICheese CreateCheese()
        {
            return new ReggianoCheese();
        }

        public IClams CreateClams()
        {
            return new FreshClams();
        }
    }

    public class ChicagoPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public IDough CreateDough()
        {
            return new ThickCrustDough();
        }

        public ISauce CreateSauce()
        {
            return new PlumTomatoSauce();
        }

        public ICheese CreateCheese()
        {
            return new MozzarellaCheese();
        }

        public IClams CreateClams()
        {
            return new FrozenClams();
        }
    }

    public interface IDough
    {

    }

    public class ThickCrustDough : IDough
    {

    }

    public class ThinCrustDough : IDough
    {

    }

    public interface ISauce
    {

    }

    public class PlumTomatoSauce : ISauce
    {

    }

    public class MarinaraSauce : ISauce
    {

    }

    public interface ICheese
    {

    }

    public class MozzarellaCheese : ICheese
    {

    }

    public class ReggianoCheese : ICheese
    {

    }

    public interface IClams
    {

    }

    public class FrozenClams : IClams
    {

    }

    public class FreshClams : IClams
    {

    }
}
