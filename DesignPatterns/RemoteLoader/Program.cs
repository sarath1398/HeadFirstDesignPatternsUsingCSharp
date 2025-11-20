using static RemoteControlDependencies.RemoteControlClasses;

namespace RemoteLoader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RemoteControl remoteControl = new();

            CeilingFan ceilingFan = new("Living Room");
            CeilingFanMediumCommand ceilingFanMedium = new(ceilingFan);
            CeilingFanHighCommand ceilingFanHigh = new(ceilingFan);
            CeilingFanOffCommand ceilingFanOff = new(ceilingFan);

            remoteControl.SetCommand(0, ceilingFanMedium, ceilingFanOff);
            remoteControl.SetCommand(1, ceilingFanHigh, ceilingFanOff);

            remoteControl.OnButtonWasPushed(0);
            remoteControl.OffButtonWasPushed(0);
            Console.WriteLine(remoteControl.ToString());
            remoteControl.UndoButtonWasPushed();
            
            Stereo livingRoomStereo = new("Living Room");
            ICommand stereoOnCd = new StereoOnWithCdCommand(livingRoomStereo);
            ICommand stereoOff = new StereoOffCommand(livingRoomStereo);
            remoteControl.SetCommand(0, stereoOnCd, stereoOff);

            GarageDoor garageDoor = new("Main House");
            ICommand doorUp = new GarageDoorUpCommand(garageDoor);
            ICommand doorDown = new GarageDoorDownCommand(garageDoor);
            remoteControl.SetCommand(1, doorUp, doorDown);

            CeilingFan ceilingFanBedRoom = new("Bedroom");
            ICommand fanHigh = new CeilingFanHighCommand(ceilingFanBedRoom);
            ICommand fanOff = new CeilingFanOffCommand(ceilingFanBedRoom);
            remoteControl.SetCommand(2, fanHigh, fanOff);

            remoteControl.OnButtonWasPushed(0);
            remoteControl.UndoButtonWasPushed();

            remoteControl.OnButtonWasPushed(1);
            remoteControl.UndoButtonWasPushed();

            remoteControl.OnButtonWasPushed(2);
            remoteControl.UndoButtonWasPushed();

            Console.WriteLine(remoteControl.ToString());
        }
    }
}
