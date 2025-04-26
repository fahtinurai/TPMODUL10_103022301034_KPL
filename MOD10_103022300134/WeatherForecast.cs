using System;

namespace MOD10_103022300134
{
    public class WeatherForecast
    {
        public DateTime TanggalLahir { get; set; }


        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
        public DateTime Date { get; internal set; }
    }
}
