using WeatherStationDependencies.Interfaces;

namespace WeatherStationDependencies.Classes.WeatherDisplays
{
    public class CurrentConditionsDisplay : IDisplay, IObserver
    {
        private double _temperature;
        private double _humidity;
        private double _pressure;
        private WeatherData _weatherData;

        public CurrentConditionsDisplay(WeatherData weatherData)
        {
            _weatherData = weatherData;
            _weatherData.AddObserver(this);
        }

        public void Update(double temperature, double humidity, double pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;

            DisplayDetails();
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Current Temperature: {_temperature}\tCurrent Humidity: {_humidity}\tCurrent Pressure: {_pressure}");
        }
    }
}
