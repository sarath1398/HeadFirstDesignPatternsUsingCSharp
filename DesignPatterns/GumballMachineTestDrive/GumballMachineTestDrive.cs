using static StatePatternDependencies.StatePatternClasses;

namespace GumballMachineTestDrive
{
    public class GumballMachineTestDrive
    {
        public static void Main(string[] args)
        {
            GumballMachine gumballMachine = new(5);

            Console.WriteLine(gumballMachine.ToString());

            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();

            Console.WriteLine(gumballMachine.ToString());

            gumballMachine.InsertQuarter();
            gumballMachine.EjectQuarter();
            gumballMachine.TurnCrank();

            Console.WriteLine(gumballMachine.ToString());

            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            gumballMachine.EjectQuarter();

            Console.WriteLine(gumballMachine.ToString());

            gumballMachine.InsertQuarter();
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();
            gumballMachine.InsertQuarter();
            gumballMachine.TurnCrank();

            Console.WriteLine(gumballMachine.ToString());
        }
    }
}
