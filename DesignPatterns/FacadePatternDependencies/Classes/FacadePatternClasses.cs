using System.Numerics;

namespace FacadePatternDependencies.Classes
{
    public static class FacadePatternClasses
    {
        // TODO: Update all the Console Writes as per the book

        #region Classes
        public class Amplifier
        {
            private Tuner? _tuner;
            private StreamingPlayer? _player;

            public Amplifier() {}

            public Amplifier(Tuner tuner, StreamingPlayer player)
            {
                this._tuner = tuner;
                this._player = player;
            }

            public void On() => Console.WriteLine("Amplifier on");

            public void Off() => Console.WriteLine("Amplifier off");

            public void SetStreamingPlayer(StreamingPlayer player)
            {
                this._player = player;
                Console.WriteLine($"Amplifier setting Streaming Player to {player.GetType()}");
            } 

            public void SetStereoSound() => Console.WriteLine("Stereo mode set!");

            public void SetSurroundSound() => Console.WriteLine("Amplifier surround sound on (5 speakers, 1 subwoofer)");

            public void SetTuner(Tuner tuner) => this._tuner = tuner;

            public void SetVolume(int volume) => Console.WriteLine("Amplifier setting volume to " + volume.ToString());

            public override string ToString() => "Amplifier Works";
        }

        public class StreamingPlayer
        {
            private readonly Amplifier? _amplifier;
            private string _movie = String.Empty;

            public StreamingPlayer() { }

            public StreamingPlayer(Amplifier amplifier) => this._amplifier = amplifier;

            public void On() => Console.WriteLine("Streaming Player on");

            public void Off() => Console.WriteLine("Streaming Player off");

            public void Pause() => Console.WriteLine("Streaming Player paused");

            public void Play(string movie)
            {
                _movie = movie;
                Console.WriteLine($"Streaming Player playing {_movie}");
            } 

            public void SetSurroundAudio() => _amplifier?.SetSurroundSound();

            public void SetTwoChannelAudio() => _amplifier?.SetStereoSound();

            public void Stop() => Console.WriteLine($"Streaming Player playing {_movie}");

            public override string ToString() => "Streaming Player works!";
        }

        public class Tuner
        {
            private readonly Amplifier? _amplifier;

            public Tuner() { }

            public Tuner(Amplifier amplifier) => _amplifier = amplifier;

            public void On() => Console.WriteLine("Tuner turned on");

            public void Off() => Console.WriteLine("Tuner tuned off");

            public void SetAm() => Console.WriteLine("Frequency set to AM");

            public void SetFm() => Console.WriteLine("Frequency set to FM");

            public void SetFrequency(int frequency) => Console.WriteLine($"Frequency set as {frequency}");

            public override string ToString() => "Tuner works";
        }

        public class Projector
        {
            private readonly StreamingPlayer? _player;

            public Projector() { }

            public Projector(StreamingPlayer player) => _player = player;

            public void On() => Console.WriteLine("Projector on");

            public void Off() => Console.WriteLine("Projector off");

            public void TVMode() => Console.WriteLine("Mode set to TV");

            public void WideScreenMode() => Console.WriteLine("Projector in widescreen mode (16x9 aspect ratio)");

            public override string ToString() => "Projector works!";
        }

        public class Screen
        {
            public void Up() => Console.WriteLine("Theater Screen going up");

            public void Down() => Console.WriteLine("Theater Screen going down");

            public override string ToString() => "Screen works!";
        }

        public class PopcornPopper
        {
            public void On() => Console.WriteLine("Popcorn Popper on");

            public void Off() => Console.WriteLine("Popcorn Popper off");

            public void Pop() => Console.WriteLine("Popcorn Popper popping popcorn!");

            public override string ToString() => "Popcorn popper works!";
        }

        public class TheaterLights
        {
            public void On() => Console.WriteLine("Theater Ceiling lights on");

            public void Off() => Console.WriteLine("Theater Ceiling lights off");

            public void Dim(int percentage) => Console.WriteLine($"Theater Ceiling Lights dimming to {percentage}%");

            public override string ToString() => "Theater Lights works!";
        }

        public class HomeTheaterFacade(Amplifier? amplifier,StreamingPlayer? play,Tuner? tuner,Projector? projector,
                                        Screen? screen,PopcornPopper? popper, TheaterLights? lights)
        {
            private readonly Amplifier? _amplifier = amplifier;
            private readonly StreamingPlayer? _player = play;
            private readonly Tuner? _tuner = tuner;
            private readonly Projector? _projector = projector;
            private readonly Screen? _screen = screen;
            private readonly PopcornPopper? _popper = popper;
            private readonly TheaterLights? _theaterLights = lights;
        
            public void WatchMovie(string movie)
            {
                Console.WriteLine("Get ready to watch a movie...");
                _popper?.On();
                _popper?.Pop();
                _theaterLights?.Dim(10);
                _screen?.Down();
                _projector?.On();
                _projector?.WideScreenMode();
                _amplifier?.On();
                _amplifier?.SetStreamingPlayer(_player ?? new StreamingPlayer());
                _amplifier?.SetSurroundSound();
                _amplifier?.SetVolume(5);
                _player?.On();
                _player?.Play(movie);
            }

            public void EndMovie()
            {
                Console.WriteLine("Shutting movie theater down...");
                _popper?.Off();
                _theaterLights?.On();
                _screen?.Up();
                _projector?.Off();
                _amplifier?.Off();
                _player?.Stop();
                _player?.Off();
            }
        }

        #endregion
    }
}
