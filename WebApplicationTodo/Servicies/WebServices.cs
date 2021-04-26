using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTodo.DTO;

namespace WebApplicationTodo.Servicies
{
    public class WebServices
    {
        ApiPublic dbApi = new ApiPublic();
        public List<NewsDTO> newsApi(string cities)
        {
            List<NewsDTO> newsAll = new List<NewsDTO>();
            
            try
            {
                dynamic respuesta = dbApi.Get($"https://newsapi.org/v2/everything?q={cities}&apiKey=295b9318f4a74478aa1f13cedbd3356f");
                for (int i = 0; i < 3; i++)
                {
                    NewsDTO newsDTO = new NewsDTO();
                    newsDTO.author = respuesta.articles[i].author.ToString();
                    newsDTO.title = respuesta.articles[i].title.ToString();
                    newsDTO.description = respuesta.articles[i].description.ToString();
                    newsDTO.url = respuesta.articles[i].url.ToString();
                    newsDTO.urlImage = respuesta.articles[i].urlToImage.ToString();
                    newsDTO.publishedAt = respuesta.articles[i].publishedAt.ToString();
                    newsDTO.content = respuesta.articles[i].content.ToString();
                    newsAll.Add(newsDTO);
                }
                //resul = respuesta;

            }
            catch (Exception ex)
            {
                return null;
            }
            return newsAll;
        }

        public WeatherDTO weatherApi(string cities)
        {
            List<string> weatherDes = new List<string>();
            WeatherDTO weatherDTO = new WeatherDTO();
            string lat;
            string lon;

            try
            {
                dynamic respuesta = dbApi.Get($"https://api.openweathermap.org/data/2.5/weather?q={cities}&appid=5ffca2fa2bffcc549242d4ceefd579c5");
                string weatherDescrip;
                weatherDTO.observation_time = respuesta.dt.ToString();
                weatherDTO.temperature = respuesta.main.temp.ToString();
                weatherDescrip = respuesta.weather[0].description.ToString();
                weatherDes.Add(weatherDescrip);
                weatherDTO.weather_description = weatherDes;
                weatherDTO.wind_speed = respuesta.wind.speed.ToString();
                weatherDTO.wind_degree = respuesta.wind.deg.ToString();
                //TO DO: Investigate an API that can find the values for wind_dir and precip
                weatherDTO.wind_dir = "n/a";
                weatherDTO.pressure = respuesta.main.pressure.ToString();
                weatherDTO.humidity = respuesta.main.humidity.ToString();
                weatherDTO.feelslike = respuesta.main.feels_like.ToString();
                weatherDTO.precip = "0";
                //Get it a lat and lon for the next API
                lat = respuesta.coord.lat.ToString();
                lon = respuesta.coord.lon.ToString();


            }
            catch (Exception ex)
            {
                return null;
            }
            try
            {
                dynamic respuesta = dbApi.Get($"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&exclude=hourly,daily&appid=5ffca2fa2bffcc549242d4ceefd579c5");
                weatherDTO.cloudcover = respuesta.current.clouds.ToString();
                weatherDTO.uv_index = respuesta.current.uvi.ToString();
                weatherDTO.visibility = respuesta.current.visibility.ToString();

            }
            catch (Exception ex)
            {
                return null;
            }
            return weatherDTO;
        }
    }
}
