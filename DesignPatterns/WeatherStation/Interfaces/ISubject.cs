namespace WeatherStationDependencies.Interfaces
{
    public interface ISubject
    {
        void AddObserver(IObserver observer);

        void RemoveObserver(IObserver observer);

        void NotifyObservers();
    }
}
