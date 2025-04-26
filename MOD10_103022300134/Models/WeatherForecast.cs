using System;

namespace MOD10_103022300134.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; } // <<< HARUS Date, bukan TanggalLahir
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string? Summary { get; set; }
    }
}
