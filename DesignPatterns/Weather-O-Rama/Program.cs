using WeatherStationDependencies.Classes;
using WeatherStationDependencies.Classes.WeatherDisplays;
using WeatherStationDependencies.Interfaces;

namespace Weather_O_Rama
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WeatherData data = new();
            IObserver forecast = new ForecastDisplay(data);
            IObserver statistics = new StatisticsDisplay(data);
            IObserver currentConditions = new CurrentConditionsDisplay(data);
            

            data.MeasurementsChanged(40, 25, 30);
            data.RemoveObserver(forecast);
            data.MeasurementsChanged(35, 40, 90);
            data.AddObserver(forecast);
            data.RemoveObserver(currentConditions);
            data.MeasurementsChanged(37,64,55);
        }
    }
}
