using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTodo.DTO;
using WebApplicationTodo.Servicies;

namespace WebApplicationTodo.Controllers
{
    [Route("weather-and-news/api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        ApiPublic dbApi = new ApiPublic();
        WebServices webService = new WebServices();

        [HttpGet("{cities}")]
        public NewsAndWeatherDTO Get(string cities)
        {
            //Se inicializa todo
            NewsAndWeatherDTO newsAndweatherDTO = new NewsAndWeatherDTO();
            List<NewsDTO> newsAll = new List<NewsDTO>();
            WeatherDTO weatherDTO = new WeatherDTO();
            SQLConnection sql = new SQLConnection();

            //Se consumen las Apis publicas
            newsAll= webService.newsApi(cities);
            weatherDTO = webService.weatherApi(cities);

            //Se concatena todo
            newsAndweatherDTO.news = newsAll;
            newsAndweatherDTO.current_weather = weatherDTO;

            //Se inserta en la DB la cuidad consultada
            sql.Insertar(cities, "info");

            //Se retorna el JSON pedido
            return newsAndweatherDTO;
        }
    }
}
