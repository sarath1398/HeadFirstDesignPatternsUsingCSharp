using static HouseOfTheFutureDependencies.Classes;
using static HouseOfTheFutureDependencies.Interfaces;
using static HouseOfTheFutureDependencies.Enums;

namespace HouseOfTheFuture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Mediator mediator = new();

            Alarm alarm = new(mediator);
            Calendar calendar = new(mediator);
            CoffeePot coffeePot = new(mediator);
            Sprinkler sprinkler = new(mediator);

            mediator.SetDevices(alarm, coffeePot, calendar, sprinkler);

            // Raise event from respective devices
            alarm.SendEvent(EventType.Alarm.ToString());
            calendar.SendEvent(EventType.TrashDay.ToString());
        }
    }
}
