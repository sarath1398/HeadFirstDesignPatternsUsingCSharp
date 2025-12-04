namespace StatePatternDependencies
{
    public class StatePatternClasses
    {

        #region enum

        public enum State
        {
            SOLD_OUT = 1,
            NO_QUARTER,
            HAS_QUARTER,
            SOLD
        }

        #endregion

        #region Interfaces

        public interface IState
        {
            public void InsertQuarter();

            public void EjectQuarter();

            public void TurnCrank();

            public void Dispense();
        }

        #endregion

        #region classes

        // Default GumballMachine without implementing State Pattern
        public class GumballMachine
        {
            private int _state = (int)State.SOLD_OUT;
            private int _count = 0;

            public GumballMachine(int count)
            {
                _count = count;
                if (count > 0)
                {
                    _state = (int)State.NO_QUARTER;
                }
            }

            public void InsertQuarter()
            {
                if (_state == (int)State.HAS_QUARTER)
                {
                    Console.WriteLine("You can't insert another quarter");
                }
                else if (_state == (int)State.NO_QUARTER)
                {
                    _state = (int)State.HAS_QUARTER;
                    Console.WriteLine("You inserted a quarter");
                }
                else if (_state == (int)State.SOLD_OUT)
                {
                    Console.WriteLine("You can't insert a quarter, the machine is sold out");
                }
                else if (_state == (int)State.SOLD)
                {
                    Console.WriteLine("Please wait, we're already giving you a gumball");
                }
            }

            public void EjectQuarter()
            {
                if (_state == (int)State.HAS_QUARTER)
                {
                    Console.WriteLine("Quarter returned");
                    _state = (int)State.NO_QUARTER;
                }
                else if (_state == (int)State.NO_QUARTER)
                {
                    Console.WriteLine("You haven't inserted a quarter");
                }
                else if (_state == (int)State.SOLD)
                {
                    Console.WriteLine("Sorry, you already turned the crank");
                }
                else if (_state == (int)State.SOLD_OUT)
                {
                    Console.WriteLine("You can't eject, you haven't inserted a quarter yet");
                }
            }

            public void TurnCrank()
            {
                if (_state == (int)State.SOLD)
                {
                    Console.WriteLine("Turning twice doesn't get you another gumball!");
                }
                else if (_state == (int)State.NO_QUARTER)
                {
                    Console.WriteLine("You turned but there's no quarter");
                }
                else if (_state == (int)State.SOLD_OUT)
                {
                    Console.WriteLine("You turned, but there are no gumballs");
                }
                else if (_state == (int)State.HAS_QUARTER)
                {
                    Console.WriteLine("You turned...");
                    _state = (int)State.SOLD;
                    Dispense();
                }
            }

            public void Dispense()
            {
                if (_state == (int)State.SOLD)
                {
                    Console.WriteLine("A gumball comes rolling out the slot");
                    _count = _count - 1;
                    if (_count == 0)
                    {
                        Console.WriteLine("Oops, out of gumballs!");
                        _state = (int)State.SOLD_OUT;
                    }
                    else
                    {
                        _state = (int)State.NO_QUARTER;
                    }
                }
                else if (_state == (int)State.NO_QUARTER)
                {
                    Console.WriteLine("You need to pay first");
                }
                else if (_state == (int)State.SOLD_OUT)
                {
                    Console.WriteLine("No gumball dispensed");
                }
                else if (_state == (int)State.HAS_QUARTER)
                {
                    Console.WriteLine("You need to turn the crank");
                }
            }

            public override string ToString()
            {
                var gumballInfoString = $"\nMighty Gumball, Inc.\nC# enabled Standing Gumball Model #2004\nInventory: {_count} gumballs\n";
                gumballInfoString += (_count <= 0) ? "Machine is sold out\n" : "Machine is waiting for a quarter\n";
                return gumballInfoString;
            }

        }

        // The below code implements State pattern

        public class SoldOutState(GumballMachineWithStatePatternImplementation gumballMachineWithState) : IState
        {
            private GumballMachineWithStatePatternImplementation _gumballMachineWithState = gumballMachineWithState;
            public void InsertQuarter() => Console.WriteLine("You can't insert a quarter, the machine is sold out");
            
            public void EjectQuarter() => Console.WriteLine("You can't eject, you haven't inserted a quarter yet");

            public void TurnCrank() => Console.WriteLine("You turned, but there are no gumballs");

            public void Dispense() => Console.WriteLine("No gumball dispensed");
        }

        public class NoQuarterState(GumballMachineWithStatePatternImplementation gumballMachineWithState) : IState
        {
            private readonly GumballMachineWithStatePatternImplementation _gumballMachine = gumballMachineWithState;

            public void InsertQuarter()
            {
                _gumballMachine.SetState(new HasQuarterState(_gumballMachine));
                Console.WriteLine("You inserted a quarter");
            }

            public void EjectQuarter() => Console.WriteLine("You haven't inserted a quarter");

            public void TurnCrank() => Console.WriteLine("You turned but there's no quarter");

            public void Dispense() => Console.WriteLine("You need to pay first");
        }

        public class HasQuarterState(GumballMachineWithStatePatternImplementation gumballMachineWithState) : IState
        {
            private readonly GumballMachineWithStatePatternImplementation _gumballMachine = gumballMachineWithState;

            public void InsertQuarter() => Console.WriteLine("You can't insert another quarter");
            
            public void EjectQuarter()
            {
                _gumballMachine.SetState(new NoQuarterState(_gumballMachine));
                Console.WriteLine("Quarter returned");
            }

            public void TurnCrank()
            {
                Console.WriteLine("You turned...");
                _gumballMachine.SetState(new SoldState(_gumballMachine));
                _gumballMachine.Dispense();
            }

            public void Dispense() => Console.WriteLine("You need to turn the crank");
        }

        public class SoldState(GumballMachineWithStatePatternImplementation gumballMachineWithState) : IState
        {
            private GumballMachineWithStatePatternImplementation _gumballMachine = gumballMachineWithState;

            public void InsertQuarter() => Console.WriteLine("Please wait, we're already giving you a gumball");

            public void EjectQuarter() => Console.WriteLine("Sorry, you already turned the crank");
            
            public void TurnCrank() => Console.WriteLine("Turning twice doesn't get you another gumball!");

            public void Dispense()
            {
                Console.WriteLine("A gumball comes rolling out the slot");
                int gumballCount = _gumballMachine.GetCount();
                _gumballMachine.SetCount(gumballCount - 1);
                if (gumballCount - 1 == 0)
                {
                    Console.WriteLine("Oops, out of gumballs!");
                    _gumballMachine.SetState(new SoldOutState(_gumballMachine));
                }
                else
                {
                    _gumballMachine.SetState(new NoQuarterState(_gumballMachine));
                }
            }
        }

        public class GumballMachineWithStatePatternImplementation
        {
            private int _count = 0;
            private IState _gumballState;

            public GumballMachineWithStatePatternImplementation(int count)
            {
                _count = count;
                if (_count < 0)
                {
                    _gumballState = new SoldOutState(this);
                }
                else
                {
                    _gumballState = new NoQuarterState(this);
                }
            }

            public void InsertQuarter() => _gumballState.InsertQuarter();

            public void EjectQuarter() => _gumballState.EjectQuarter();

            public void TurnCrank() => _gumballState.TurnCrank();

            public void Dispense() => _gumballState.Dispense();

            public void SetState(IState state) => _gumballState = state;

            public void SetCount(int count) => _count = count;

            public int GetCount() => _count;

            public override string ToString()
            {
                var gumballInfoString = $"\nMighty Gumball, Inc.\nC# enabled Standing Gumball Model #2004\nInventory: {_count} gumballs\n";
                gumballInfoString += (_count <= 0) ? "Machine is sold out\n" : "Machine is waiting for a quarter\n";
                return gumballInfoString;
            }
        }

        #endregion
    }
}
