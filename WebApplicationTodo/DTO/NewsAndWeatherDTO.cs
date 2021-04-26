using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTodo.DTO
{
    public class NewsAndWeatherDTO
    {
        public List<NewsDTO> news { get; set; }
        public WeatherDTO current_weather { get; set; }
    }
}
