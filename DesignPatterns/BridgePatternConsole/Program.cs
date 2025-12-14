using static BridgePatternDependencies.Interfaces;
using static BridgePatternDependencies.Classes;

namespace BridgePatternConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the implementations (The TVs)
            ITV sonyTv = new Sony();
            ITV rcaTv = new RCA();

            // Create the abstraction (The Remote) and bridge it to an implementation (Sony)
            ConcreteRemote remote = new(sonyTv);

            Console.WriteLine("--- Testing Sony TV ---");
            remote.On();
            remote.SetChannel(10);
            remote.NextChannel();
            remote.Off();

            Console.WriteLine("\n--- Testing RCA TV ---");
            // We can vary the implementation (RCA) without changing the abstraction (Remote)
            remote = new ConcreteRemote(rcaTv);
            remote.On();
            remote.SetChannel(50);
            remote.PreviousChannel();
            remote.Off();
        }
    }
}
