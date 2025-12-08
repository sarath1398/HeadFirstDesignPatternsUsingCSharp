using static ProxyPatternDependencies.Classes;

namespace MatchMakingTestDrive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MatchMakingTestDrive matchMakingTestDrive = new();
            matchMakingTestDrive.Drive();
        }
    }

    public class MatchMakingTestDrive
    {
        public void Drive()
        {
            IPerson joe = new PersonImpl();
            joe.SetName("Joe Javabean");
            joe.SetGeekRating(7);

            //Owner Proxy
            IPerson ownerProxy = GetOwnerProxy(joe);
            Console.WriteLine("Name is " + ownerProxy.GetName());
            ownerProxy.SetInterests("bowling, Go");
            Console.WriteLine("Interests set from owner proxy");
            try
            {
                ownerProxy.SetGeekRating(10);
            }
            catch (Exception)
            {
                Console.WriteLine("Can't set rating from owner proxy");
            }
            Console.WriteLine("Rating is " + ownerProxy.GetGeekRating());

            //Non Owner Proxy
            IPerson nonOwnerProxy = GetNonOwnerProxy(joe);
            Console.WriteLine("Name is " + nonOwnerProxy.GetName());
            try
            {
                nonOwnerProxy.SetInterests("bowling, Go");
            }
            catch
            {
                Console.WriteLine("Can't set interests from non owner proxy");
            }
            nonOwnerProxy.SetGeekRating(3);
            Console.WriteLine("Rating set from non owner proxy");
            Console.WriteLine("Rating is " + nonOwnerProxy.GetGeekRating());
        }
    }
}
