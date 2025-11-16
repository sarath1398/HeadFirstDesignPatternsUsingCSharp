using WeatherStationDependencies.Interfaces;

namespace WeatherStationDependencies.Classes.WeatherDisplays
{
    public class StatisticsDisplay : IDisplay,IObserver
    {
        private double _temperature;
        private double _humidity;
        private double _pressure;
        private int _updateCount = 0;
        private WeatherData _weatherData;

        public StatisticsDisplay(WeatherData weatherData)
        {
            _weatherData = weatherData;
            _weatherData.AddObserver(this);
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            _temperature += temperature;
            _humidity += humidity;
            _pressure += pressure;
            _updateCount++;

            DisplayDetails();
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Average Temperature: {_temperature/_updateCount}\tAverage Humidity: {_humidity/_updateCount}\t" +
                $"Average Pressure: {_pressure/_updateCount}");
        }
    }
}
