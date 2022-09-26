using System.Collections.Generic;

namespace RestaurantApi
{
    public interface IWeatherForecastServices
    {
        IEnumerable<WeatherForecast> Get();
    }
}