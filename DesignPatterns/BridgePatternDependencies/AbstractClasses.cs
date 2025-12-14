using static BridgePatternDependencies.Interfaces;

namespace BridgePatternDependencies
{
    public class AbstractClasses
    {
        public abstract class RemoteControl(ITV device)
        {
            protected readonly ITV implementor = device;

            public virtual void On() => implementor.On();

            public virtual void Off() => implementor.Off();

            public virtual void SetChannel(int channel) => implementor.TuneChannel(channel);
        }
    }
}
