using static BuilderPatternDependencies.Classes;

namespace BuilderPatternDependencies
{
    public class AbstractClasses
    {
        public abstract class AbstractBuilder
        {
            public abstract void BuildDay(DateTime date);

            // Removed date parameter since the build day is already passed
            // Also does not sit well with the other abstract method definitions
            public abstract void AddHotel(string hotelName);

            public abstract void AddReservation(string reservationName);

            public abstract void AddSpecialEvent(string eventName);

            // Changed the addTickets to number of tickets since the book points
            // to the event as per the scenario diagram but refers to the tickets in 
            // code snippet
            public abstract void AddTickets(int tickets);

            public abstract Vacation GetVacationPlanner();
        }

        // Fluent Builder Pattern

        public abstract class AbstractFluentBuilder
        {
            public abstract FluentVacationBuilder BuildDay(DateTime date);

            // Removed date parameter since the build day is already passed
            // Also does not sit well with the other abstract method definitions
            public abstract FluentVacationBuilder AddHotel(string hotelName);

            public abstract FluentVacationBuilder AddReservation(string reservationName);

            public abstract FluentVacationBuilder AddSpecialEvent(string eventName);

            // Changed the addTickets to number of tickets since the book points
            // to the event as per the scenario diagram but refers to the tickets in 
            // code snippet
            public abstract FluentVacationBuilder AddTickets(int tickets);

            public abstract Vacation GetVacationPlanner();
        }
    }
}
