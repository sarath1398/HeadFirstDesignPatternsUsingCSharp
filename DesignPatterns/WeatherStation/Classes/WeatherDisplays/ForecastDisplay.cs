using System.Threading.Channels;
using WeatherStationDependencies.Interfaces;

namespace WeatherStationDependencies.Classes.WeatherDisplays
{
    public class ForecastDisplay : IDisplay,IObserver
    {
        private double _temperature;
        private double _humidity;
        private double _pressure;
        private WeatherData _weatherData;

        public ForecastDisplay(WeatherData weatherData)
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
            if (_humidity > 80)
            {
                Console.WriteLine("High chances of fog. Drive carefully.");
            }
            else if (_pressure > 50)
            {
                Console.WriteLine("High chances of rainfall. Carry an umbrella.");
            }
            else if (_temperature > 40)
            {
                Console.WriteLine("Weather is hot. Hydrate yourself.");
            }
            else 
            {
                Console.WriteLine("Moderate Weather. No need to panic.");
            }
            
        }
    }
}
