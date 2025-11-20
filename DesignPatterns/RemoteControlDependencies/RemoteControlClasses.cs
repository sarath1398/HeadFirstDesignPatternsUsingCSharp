using System;

namespace RemoteControlDependencies
{
    public class RemoteControlClasses
    {
        #region Interfaces

        public interface ICommand
        {
            public void Execute();

            public void Undo();
        }

        #endregion

        #region Classes

        public class Light(string type)
        {
            public string lightType = type;

            public void On() => Console.WriteLine($"{lightType} light is now ON");

            public void Off() => Console.WriteLine($"{lightType} light is now OFF");
        }

        public class LightOnCommand(Light light) : ICommand
        {
            private readonly Light _light = light;

            public void Execute() => _light.On();

            public void Undo() => _light.Off();
        }

        public class LightOffCommand(Light light) : ICommand
        {
            private readonly Light _light = light;

            public void Execute() => _light.Off();

            public void Undo() => _light.On();
        }

        public class CeilingFan(string type)
        {
            public const int HIGH = 3;
            public const int MEDIUM = 2;
            public const int LOW = 1;
            public const int OFF = 0;
            public string location = type;
            public int speed;

            public void High()
            {
                speed = HIGH;
                Console.WriteLine($"{location} fan is now running at HIGH speed");
            }

            public void Medium()
            {
                speed = MEDIUM;
                Console.WriteLine($"{location} fan is now running at MEDIUM speed");
            }

            public void Low()
            {
                speed = LOW;
                Console.WriteLine($"{location} fan is now running at LOW speed");
            }

            public void Off()
            {
                speed = OFF;
                Console.WriteLine($"{location} fan is now OFF");
            }

            public int GetSpeed() => speed;
        }

        public class CeilingFanHighCommand(CeilingFan fan) : ICommand
        {
            private readonly CeilingFan _fan = fan;
            private int prevSpeed;

            public void Execute()
            {
                prevSpeed = _fan.GetSpeed();
                _fan.High();
            } 

            public void Undo()
            {
                switch (prevSpeed)
                {
                    case CeilingFan.HIGH:
                        _fan.High();
                        break;
                    case CeilingFan.MEDIUM:
                        _fan.Medium();
                        break;
                    case CeilingFan.LOW:
                        _fan.Low();
                        break;
                    default:
                        _fan.Off();
                        break;
                }

            }
        }

        public class CeilingFanMediumCommand(CeilingFan fan) : ICommand
        {
            private readonly CeilingFan _fan = fan;
            private int prevSpeed;

            public void Execute()
            {
                prevSpeed = _fan.GetSpeed();
                _fan.Medium();
            }

            public void Undo()
            {
                switch (prevSpeed)
                {
                    case CeilingFan.HIGH:
                        _fan.High();
                        break;
                    case CeilingFan.MEDIUM:
                        _fan.Medium();
                        break;
                    case CeilingFan.LOW:
                        _fan.Low();
                        break;
                    default:
                        _fan.Off();
                        break;
                }

            }
        }

        public class CeilingFanLowCommand(CeilingFan fan) : ICommand
        {
            private readonly CeilingFan _fan = fan;
            private int prevSpeed;

            public void Execute()
            {
                prevSpeed = _fan.GetSpeed();
                _fan.Low();
            }

            public void Undo()
            {
                switch (prevSpeed)
                {
                    case CeilingFan.HIGH:
                        _fan.High();
                        break;
                    case CeilingFan.MEDIUM:
                        _fan.Medium();
                        break;
                    case CeilingFan.LOW:
                        _fan.Low();
                        break;
                    default:
                        _fan.Off();
                        break;
                }

            }
        }

        public class CeilingFanOffCommand(CeilingFan fan) : ICommand
        {
            private readonly CeilingFan _fan = fan;
            private int prevSpeed;

            public void Execute()
            {
                prevSpeed = _fan.GetSpeed();
                _fan.Off();
            }

            public void Undo()
            {
                switch (prevSpeed)
                {
                    case CeilingFan.HIGH:
                        _fan.High();
                        break;
                    case CeilingFan.MEDIUM:
                        _fan.Medium();
                        break;
                    case CeilingFan.LOW:
                        _fan.Low();
                        break;
                    default:
                        _fan.Off();
                        break;
                }

            }
        }

        public class GarageDoor(string location)
        {
            private readonly string _location = location;

            public void Up() => Console.WriteLine($"{_location} garage door is OPEN");
            public void Down() => Console.WriteLine($"{_location} garage door is CLOSED");
            public void Stop() => Console.WriteLine($"{_location} garage door is STOPPED");
            public void LightOn() => Console.WriteLine($"{_location} garage light is ON");
            public void LightOff() => Console.WriteLine($"{_location} garage light is OFF");
        }

        public class GarageDoorUpCommand(GarageDoor garageDoor) : ICommand
        {
            public void Execute()
            {
                garageDoor.Up();
            }

            public void Undo()
            {
                garageDoor.Down();
            }
        }

        public class GarageDoorDownCommand(GarageDoor garageDoor) : ICommand
        {
            public void Execute()
            {
                garageDoor.Down();
            }

            public void Undo()
            {
                garageDoor.Up();
            }
        }

        public class GarageDoorLightOnCommand(GarageDoor garageDoor) : ICommand
        {
            private readonly GarageDoor _garageDoor = garageDoor;

            public void Execute()
            {
                _garageDoor.LightOn();
            }

            public void Undo()
            {
                _garageDoor.LightOff();
            }
        }

        public class GarageDoorLightOffCommand(GarageDoor garageDoor) : ICommand
        {
            public void Execute()
            {
                garageDoor.LightOff();
            }

            public void Undo()
            {
                garageDoor.LightOn();
            }
        }

        public class Stereo(string location)
        {
            public void On() => Console.WriteLine($"{location} stereo is ON");
            
            public void Off() => Console.WriteLine($"{location} stereo is OFF");
            
            public void SetCd() => Console.WriteLine($"{location} stereo is set to CD input");
            
            public void SetDvd() => Console.WriteLine($"{location} stereo is set to DVD input");
            
            public void SetRadio() => Console.WriteLine($"{location} stereo is set to Radio");
            
            public void SetVolume(int level) => Console.WriteLine($"{location} stereo volume set to {level}");
        }

        public class StereoOnCommand(Stereo stereo) : ICommand
        {
            public void Execute() => stereo.On();
            
            public void Undo() => stereo.Off();
        }

        public class StereoOffCommand(Stereo stereo) : ICommand
        {
            public void Execute() => stereo.Off();
            
            public void Undo() => stereo.On();
        }

        public class StereoOnWithCdCommand(Stereo stereo) : ICommand
        {
            public void Execute()
            {
                stereo.On();
                stereo.SetCd();
                stereo.SetVolume(11);
            }

            public void Undo() => stereo.Off();
        }

        public class StereoOnWithRadioCommand(Stereo stereo) : ICommand
        {
            public void Execute()
            {
                stereo.On();
                stereo.SetRadio();
                stereo.SetVolume(5);
            }

            public void Undo() => stereo.Off();
        }

        public class NoCommand : ICommand
        {
            public void Execute()
            {

            }

            public void Undo()
            {
                
            }
        }

        public class MacroCommand(List<ICommand> commands) : ICommand
        {
            private readonly List<ICommand> _macroCommands = commands;

            public void Execute() 
            {
                for (int i = 0; i < _macroCommands.Count; i++)
                {
                    _macroCommands[i].Execute();
                }
            }

            public void Undo()
            {
                for (int i = 0; i < _macroCommands.Count; i++)
                {
                    _macroCommands[i].Undo();
                }
            }
        }

        public class RemoteControl
        {
            private readonly List<ICommand> _onCommands;
            private readonly List<ICommand> _offCommands;
            private ICommand _lastCommand;

            public RemoteControl()
            {
                const int slots = 7;
                _onCommands = new List<ICommand>(slots);
                _offCommands = new List<ICommand>(slots);
                ICommand noCommand = new NoCommand();

                for (int i = 0; i < slots; i++)
                {
                    _onCommands.Add(noCommand);
                    _offCommands.Add(noCommand);
                }

                _lastCommand = noCommand;
            }

            public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
            {
                _onCommands[slot] = onCommand;
                _offCommands[slot] = offCommand;
            }

            public void OnButtonWasPushed(int slot)
            {
                _onCommands[slot].Execute();
                _lastCommand = _onCommands[slot];
            }

            public void OffButtonWasPushed(int slot)
            {
                _offCommands[slot].Execute();
                _lastCommand = _offCommands[slot];
            }

            public void UndoButtonWasPushed()
            {
                Console.WriteLine("Undoing last command...");
                _lastCommand.Undo();
            }

            public override string ToString()
            {
                var stringBuff = new System.Text.StringBuilder();
                stringBuff.AppendLine("\n------ Remote Control -------");
                for (int i = 0; i < _onCommands.Count; i++)
                {
                    stringBuff.AppendLine($"[slot {i}] {_onCommands[i].GetType().Name}    {_offCommands[i].GetType().Name}");
                }
                return stringBuff.ToString();
            }
        }

        #endregion
    }

}
