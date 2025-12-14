using static BridgePatternDependencies.Interfaces;
using static BridgePatternDependencies.AbstractClasses;

namespace BridgePatternDependencies
{
    public class Classes
    {
        public class ConcreteRemote(ITV device) : RemoteControl(device)
        {
            private int _currentChannel; 
            public override void Off() => implementor.Off();

            public override void On() => implementor.On();

            public override void SetChannel(int channel)
            {
                _currentChannel = channel;
                implementor.TuneChannel(channel);
            }

            public void NextChannel() => SetChannel(_currentChannel + 1);

            public void PreviousChannel() => SetChannel(_currentChannel - 1);
        }

        public class Sony : ITV
        {
            public void On() => Console.WriteLine("Sony TV turned ON");
            
            public void Off() => Console.WriteLine("Sony TV turned OFF");

            public void TuneChannel(int channel) => Console.WriteLine($"Sony TV switched to channel {channel}");
        }

        public class RCA : ITV
        {
            public void On() => Console.WriteLine("RCA TV turned ON");

            public void Off() => Console.WriteLine("RCA TV turned OFF");

            public void TuneChannel(int channel) => Console.WriteLine($"RCA TV switched to channel {channel}");
        }
    }
}
