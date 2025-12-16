using static BuilderPatternDependencies.Interfaces;
using static BuilderPatternDependencies.AbstractClasses;

namespace BuilderPatternDependencies
{
    public class Classes
    {
        public class Vacation : IPlanner
        {
            private readonly List<string> _itineary = [];

            public void AddPlan(string plan) => _itineary.Add(plan);

            public override string ToString()
            {
                return string.Join('\n', _itineary);
            }
        }

        public class VacationBuilder : AbstractBuilder
        {
            private readonly Vacation _vacation = new();
            public override void AddHotel(string hotelName) => _vacation.AddPlan($"{hotelName} Booked");

            public override void AddReservation(string reservationName) => _vacation.AddPlan($"Hotel reserved" +
                $" in the name of {reservationName}");

            public override void AddSpecialEvent(string eventName) => _vacation.AddPlan("Arranged special event" +
                $" - {eventName}");

            public override void AddTickets(int tickets) => _vacation.AddPlan("Number of park tickets booked - " + tickets);

            public override void BuildDay(DateTime date) => _vacation.AddPlan($"Vacation planned on " + date.ToShortDateString());

            public override Vacation GetVacationPlanner() => _vacation;
        }

        public class FluentVacationBuilder : AbstractFluentBuilder
        {
            private readonly Vacation _vacation = new();

            public override FluentVacationBuilder AddHotel(string hotelName)
            {
                _vacation.AddPlan($"{hotelName} Booked");
                return this;
            }

            public override FluentVacationBuilder AddReservation(string reservationName)
            {
                _vacation.AddPlan($"Hotel reserved in the name of {reservationName}");
                return this;
            }

            public override FluentVacationBuilder AddSpecialEvent(string eventName)
            {
                _vacation.AddPlan($"Arranged special event - {eventName}");
                return this;
            }

            public override FluentVacationBuilder AddTickets(int tickets)
            {
                _vacation.AddPlan($"Number of park tickets booked - {tickets}");
                return this;
            }

            public override FluentVacationBuilder BuildDay(DateTime date)
            {
                _vacation.AddPlan($"Vacation planned on {date.ToShortDateString()}");
                return this;
            }

            public override Vacation GetVacationPlanner() => _vacation;
        }


        public class Client
        {
            public static void ConstructPlanner(AbstractBuilder builder)
            {
                builder.BuildDay(DateTime.Today);
                builder.AddHotel("Grand Facadian");
                builder.AddSpecialEvent("Patterns on Ice");
                builder.AddTickets(4);

                Console.WriteLine();

                builder.BuildDay(DateTime.Today.AddDays(1));
                builder.AddReservation("Objectville Diner");
                builder.AddSpecialEvent("Cirque Du Patterns");
                builder.AddTickets(4);
            }

            // Fluent Builder pattern allows method chaining and better readability
            public static void ConstructFluentPlanner(AbstractFluentBuilder builder)
            {
                builder
                    .BuildDay(DateTime.Today)
                    .AddHotel("Grand Facadian")
                    .AddSpecialEvent("Patterns on Ice")
                    .AddTickets(4);

                Console.WriteLine();

                builder
                    .BuildDay(DateTime.Today.AddDays(1))
                    .AddReservation("Objectville Diner")
                    .AddSpecialEvent("Cirque Du Patterns")
                    .AddTickets(4);
            }
        }
    }
}
