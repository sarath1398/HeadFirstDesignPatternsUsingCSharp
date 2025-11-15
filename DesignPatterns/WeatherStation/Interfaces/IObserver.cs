namespace WeatherStationDependencies.Interfaces
{
    public interface IObserver
    {
        void Update(double temperature, double pressure, double humidity);
    }
}
