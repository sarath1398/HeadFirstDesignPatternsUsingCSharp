using static FacadePatternDependencies.Classes.FacadePatternClasses;

namespace HomeTheaterTestDrive
{
    public class Client
    {
        public static void Main(string[] args)
        {
            Amplifier amplifier = new();
            StreamingPlayer play = new();
            Tuner tuner = new();
            Projector projector = new();
            Screen screen = new();
            PopcornPopper popper = new();
            TheaterLights lights = new();
            HomeTheaterFacade homeTheaterFacade = new(amplifier,play,tuner,projector,screen,popper,lights);
            homeTheaterFacade.WatchMovie("Raiders of the Lost Ark");
            homeTheaterFacade.EndMovie();
        }
    }
}
