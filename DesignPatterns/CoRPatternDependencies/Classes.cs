using static CoRPatternDependencies.AbstractClasses;

namespace CoRPatternDependencies
{
    public class Classes
    {
        public class Email(string type, string message)
        {
            public string Type { get; } = type;
            public string Message { get; } = message;
        }

        public class SpamHandler : Handler
        {
            public override void HandleRequest(Email email)
            {
                if (email.Type.Equals("SPAM", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Spam Handler - Deleting the spam email");
                }
                else if (successor != null)
                {
                    successor.HandleRequest(email);
                }
                else
                {
                    HandleFallback();
                }
            }
        }

        public class FanHandler : Handler
        {
            public override void HandleRequest(Email email)
            {
                if (email.Type.Equals("FAN", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Fan Handler - Forwarding fan mail to the CEO.");
                }
                else if (successor != null)
                {
                    successor.HandleRequest(email);
                }
                else
                {
                    HandleFallback();
                }
            }
        }

        public class ComplaintHandler : Handler
        {
            public override void HandleRequest(Email email)
            {
                if (email.Type.Equals("COMPLAINT", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Complaint Handler - Forwarding complaint to the Legal Department.");
                }
                else if (successor != null)
                {
                    successor.HandleRequest(email);
                }
                else
                {
                    HandleFallback();
                }
            }
        }

        public class NewLocHandler : Handler
        {
            public override void HandleRequest(Email email)
            {
                if (email.Type.Equals("NewLoc", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("New Location Handler - Forwarding new location requests" +
                        " to the business development team");
                }
                else if (successor != null)
                {
                    successor.HandleRequest(email);
                }
                else
                {
                    HandleFallback();
                }
            }
        }
    }
    
}
