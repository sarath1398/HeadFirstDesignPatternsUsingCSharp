using static HouseOfTheFutureDependencies.Interfaces;
using static HouseOfTheFutureDependencies.Enums;

namespace HouseOfTheFutureDependencies
{
    public class Classes
    {
        public class Device(IMediator mediator = null) : IDevice
        {
            private IMediator _mediator = mediator;

            public void SetMediator(IMediator mediator) => _mediator = mediator;

            public void SendEvent(string eventArgs) => _mediator.OnEvent(this, eventArgs);
        }

        public class Alarm : Device
        {
            public Alarm() { }
            public Alarm(IMediator mediator) : base(mediator) { }

            public void CheckAlarm() => Console.WriteLine($"Alarm currently set at 6.00 AM on {DateTime.Now.AddDays(1):d}");

            public void ResetAlarm() => Console.WriteLine("Cleared all the existing alarms.");

            public void DoAlarm() => Console.WriteLine($"Alarm set at 6.00 AM on {DateTime.Now.AddDays(1):d}");

            public void RaiseAlarm() => Console.WriteLine("Beep Beep Beep...Wake up Sleepyhead!");
        }

        public class CoffeePot : Device
        {
            public CoffeePot() { }

            public CoffeePot(IMediator mediator) : base(mediator) { }

            public void DoCoffee() => Console.WriteLine("Coffee timer set 10 minutes from the time of alarm");

            public void StartCoffee() => Console.WriteLine("Whizz Whizz Whizz...Here's your Coffee!");
        }

        public class Calendar : Device
        {
            public Calendar() { }

            public Calendar(IMediator mediator) : base(mediator) { }

            public bool CheckDayOfWeek() => 
                (DateTime.Today.DayOfWeek == DayOfWeek.Sunday) || (DateTime.Today.DayOfWeek == DayOfWeek.Saturday);

            public void CheckCalendar() => Console.WriteLine($"Today is {DateTime.Now}");
        }

        public class Sprinkler : Device
        {
            public Sprinkler() { }

            public Sprinkler(IMediator mediator) : base(mediator) { }

            public void DoSprinkler() => Console.WriteLine("Sprinkler timer set 15 minutes from the time of alarm");

            public void CheckShower() => Console.WriteLine("Sprinkler timer currently set 15 minutes from the time of alarm");

            public void OnShower() => Console.WriteLine("Whoosh...!");

            public void OffSprinkler() => Console.WriteLine("Turned off timer for Sprinkler");
        }

        public class Mediator : IMediator
        {
            private Alarm _alarm;
            private CoffeePot _coffeePot;
            private Calendar _calendar;
            private Sprinkler _sprinkler;

            public Mediator()
            {
                _alarm = new Alarm();
                _coffeePot = new CoffeePot();
                _calendar = new Calendar();
                _sprinkler = new Sprinkler();
            }

            public void SetDevices(Alarm alarm, CoffeePot coffeePot, Calendar calendar, Sprinkler sprinkler)
            {
                _alarm = alarm;
                _coffeePot = coffeePot;
                _calendar = calendar;
                _sprinkler = sprinkler;
            }

            public void OnEvent(IDevice device, string eventArgs)
            {
                if (eventArgs == EventType.Alarm.ToString())
                {
                    Console.WriteLine("\nMediator handles the Alarm event -");

                    bool isWeekend = _calendar.CheckDayOfWeek();

                    if (!isWeekend)
                    {
                        _calendar.CheckCalendar();
                        _sprinkler.DoSprinkler();
                        _coffeePot.StartCoffee();
                    }
                    else
                    {
                        Console.WriteLine("\nMediator switched to weekend -");

                        OnEvent(device, EventType.Weekend.ToString());
                    }
                }
                else if (eventArgs == EventType.TrashDay.ToString())
                {
                    Console.WriteLine("\nMediator handles the Trashday event -");

                    _alarm.ResetAlarm();

                }
                else if (eventArgs == EventType.Weekend.ToString())
                {
                    Console.WriteLine("\nMediator handles the Weekend event -");

                    _calendar.CheckCalendar();
                    _coffeePot.DoCoffee();
                    _sprinkler.OffSprinkler();
                }
            }
        }
    }
}
