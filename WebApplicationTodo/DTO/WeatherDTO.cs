using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTodo.DTO
{
    public class WeatherDTO
    {
        public string observation_time { get; set; }
        public string temperature { get; set; }
        public List<string> weather_description { get; set; }
        public string wind_speed { get; set; }
        public string wind_degree { get; set; }
        public string wind_dir { get; set; }
        public string pressure { get; set; }
        public string precip { get; set; }
        public string humidity { get; set; }
        public string cloudcover { get; set; }
        public string feelslike { get; set; }
        public string uv_index { get; set; }
        public string visibility { get; set; }

    }
}
