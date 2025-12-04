using static StatePatternDependencies.StatePatternClasses;

namespace GumballMachineTestDrive
{
    public class GumballMachineTestDrive
    {
        public static void Main(string[] args)
        {
            // Implementation without state pattern

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

            // Implementation with State Pattern

            GumballMachineWithStatePatternImplementation gumballMachineWithState = new(5);

            Console.WriteLine(gumballMachineWithState.ToString());

            gumballMachineWithState.InsertQuarter();
            gumballMachineWithState.TurnCrank();

            Console.WriteLine(gumballMachineWithState.ToString());

            gumballMachineWithState.InsertQuarter();
            gumballMachineWithState.EjectQuarter();
            gumballMachineWithState.TurnCrank();

            Console.WriteLine(gumballMachineWithState.ToString());

            gumballMachineWithState.InsertQuarter();
            gumballMachineWithState.TurnCrank();
            gumballMachineWithState.InsertQuarter();
            gumballMachineWithState.TurnCrank();
            gumballMachineWithState.EjectQuarter();

            Console.WriteLine(gumballMachineWithState.ToString());

            gumballMachineWithState.InsertQuarter();
            gumballMachineWithState.InsertQuarter();
            gumballMachineWithState.TurnCrank();
            gumballMachineWithState.InsertQuarter();
            gumballMachineWithState.TurnCrank();
            gumballMachineWithState.InsertQuarter();
            gumballMachineWithState.TurnCrank();

            Console.WriteLine(gumballMachineWithState.ToString());
        }
    }
}
