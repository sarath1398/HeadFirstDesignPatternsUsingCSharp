namespace StatePatternDependencies
{
    public class StatePatternClasses
    {

        public enum State
        {
            SOLD_OUT = 1,
            NO_QUARTER,
            HAS_QUARTER,
            SOLD
        }

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
    }
}
