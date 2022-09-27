using System.Collections.Generic;

namespace RestaurantApi
{
    public interface IWeatherForecastServices
    {
        IEnumerable<WeatherForecast> Get();
        IEnumerable<WeatherForecast> Get(int minTemperature, int maxTemperature, int maxResult);
    }
}