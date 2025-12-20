namespace HouseOfTheFutureDependencies
{
    public class Interfaces
    {
        public interface IDevice
        {
            public void SendEvent(string eventArgs);
        }
        public interface IMediator
        {
            public void OnEvent(IDevice device, string eventArgs);
        }
    }
}
