/* Fully implemented by CoPilot for MultiThread testing */

using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace ChocolateFactory
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Chocolate Boiler Singleton behavior examples\n");

            // Simple pairwise checks (two calls in same thread)
            CheckPair("Basic", () => Classes.ChocolateBoilerWithSingletonBasic.GetInstance());
            CheckPair("Eager", () => Classes.ChocolateBoilerWithEagerLoading.GetInstance());
            CheckPair("Lazy", () => Classes.ChocolateBoilerWithLazyLoading.GetInstance());
            CheckPair("DoubleCheck", () => Classes.ChocolateBoilerWithSingletonDoubleCheck.GetInstance());
            CheckPair("ThreadSafe", () => Classes.ChocolateBoilerWithSingletonThreadSafe.GetInstance());
            CheckPair("RegularNew", () => new Classes.ChocolateBoiler());

            Console.WriteLine("\nMulti-threaded test (100 parallel calls):\n");

            // Parallel calls - shows whether multiple threads observe the same instance
            await TestParallel("Basic", 100, () => Classes.ChocolateBoilerWithSingletonBasic.GetInstance());
            await TestParallel("Eager", 100, () => Classes.ChocolateBoilerWithEagerLoading.GetInstance());
            await TestParallel("Lazy", 100, () => Classes.ChocolateBoilerWithLazyLoading.GetInstance());
            await TestParallel("DoubleCheck", 100, () => Classes.ChocolateBoilerWithSingletonDoubleCheck.GetInstance());
            await TestParallel("ThreadSafe", 100, () => Classes.ChocolateBoilerWithSingletonThreadSafe.GetInstance());

            Console.WriteLine("\nConclusion:");
            Console.WriteLine("- A correct singleton should always return the same instance (single object) even across threads.");
            Console.WriteLine("- Eager and Lazy patterns usually provide that. Basic or incorrectly implemented patterns will return multiple instances.");
            Console.WriteLine("- Double-checked locking and thread-safe locking are meant to avoid race conditions; validate implementations carefully.");
        }

        static void CheckPair(string name, Func<object> factory)
        {
            var a = factory();
            var b = factory();
            Console.WriteLine($"{name}: ReferenceEquals? {ReferenceEquals(a, b)} (a: {RuntimeHelpers.GetHashCode(a)}, b: {RuntimeHelpers.GetHashCode(b)})");
        }

        static async Task TestParallel(string name, int calls, Func<object> factory)
        {
            var ids = new ConcurrentDictionary<int, byte>();

            var tasks = Enumerable.Range(0, calls).Select(_ => Task.Run(() =>
            {
                var inst = factory();
                ids.TryAdd(RuntimeHelpers.GetHashCode(inst), 0);
            })).ToArray();

            await Task.WhenAll(tasks);

            Console.WriteLine($"{name}: Unique instances observed = {ids.Count}");
        }
    }
}
