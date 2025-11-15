using WeatherStationDependencies.Classes;
using WeatherStationDependencies.Classes.WeatherDisplays;
using WeatherStationDependencies.Interfaces;

namespace Weather_O_Rama
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IObserver forecast = new ForecastDisplay();
            IObserver statistics = new StatisticsDisplay();
            IObserver currentConditions = new CurrentConditionsDisplay();
            WeatherData data = new();

            data.AddObserver(forecast);
            data.AddObserver(statistics);
            data.AddObserver(currentConditions);

            data.MeasurementsChanged(40, 25, 30);
            data.RemoveObserver(forecast);
            data.MeasurementsChanged(35, 40, 90);
        }
    }
}
