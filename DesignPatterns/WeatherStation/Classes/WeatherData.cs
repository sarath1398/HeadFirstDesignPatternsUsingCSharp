using WeatherStationDependencies.Interfaces;

namespace WeatherStationDependencies.Classes
{
    public class WeatherData : ISubject
    {

        private double _temperature;
        private double _humidity;
        private double _pressure;
        private readonly List<IObserver> _observers = [];

        public WeatherData()
        {
            
        }

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_temperature,_humidity,_pressure);
            }
        }

        public void SetMeasurements(double temperature, double humidity, double pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
        }

        public void MeasurementsChanged(double temperature, double humidity, double pressure)
        {
            SetMeasurements(temperature, humidity, pressure);
            NotifyObservers();
        }

        public double GetTemperature()
        {
            return _temperature;
        }

        public double GetHumidity()
        {
            return _humidity;
        }

        public double GetPressure()
        {
            return _pressure;
        }
    }
}
