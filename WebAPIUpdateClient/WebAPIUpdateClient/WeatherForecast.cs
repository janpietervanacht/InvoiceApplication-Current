using System;

namespace WebApiPeterOrigineel
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class WeatherForecast
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
