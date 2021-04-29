using System;
using System.Collections.Generic;
using WebApplicationTodo.DTO;

namespace WebApplicationTodo.Servicies
{
    public class WebServicies
    {
        ApiPublic apiRequest = new ApiPublic();
        public List<NewsDTO> newsApi(string cities)
        {
            List<NewsDTO> newsAll = new List<NewsDTO>();
            
            try
            {
                string urlApicPublicNewsWhithKey = $"https://newsapi.org/v2/everything?q={cities}&apiKey=295b9318f4a74478aa1f13cedbd3356f";
                dynamic response = apiRequest.Get(urlApicPublicNewsWhithKey);
                for (int i = 0; i < response.articles.Count; i++)
                {
                    NewsDTO newsDTO = new NewsDTO();
                    newsDTO.author = response.articles[i].author.ToString();
                    newsDTO.title = response.articles[i].title.ToString();
                    newsDTO.description = response.articles[i].description.ToString();
                    newsDTO.url = response.articles[i].url.ToString();
                    newsDTO.urlImage = response.articles[i].urlToImage.ToString();
                    newsDTO.publishedAt = response.articles[i].publishedAt.ToString();
                    newsDTO.content = response.articles[i].content.ToString();
                    newsAll.Add(newsDTO);
                }

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
            FormattingServicies formatting = new FormattingServicies();
            string lat;
            string lon;

            try
            {
                string urlApicPublicWeatherWhithKey1 = $"https://api.openweathermap.org/data/2.5/weather?q={cities}&appid=5ffca2fa2bffcc549242d4ceefd579c5";
                dynamic response = apiRequest.Get(urlApicPublicWeatherWhithKey1);
                string weatherDescrip;
                double UnixTime = response.dt;
                double windDegre = response.wind.deg;
                weatherDTO.observation_time = formatting.unixDatetoString(UnixTime);
                weatherDTO.temperature = response.main.temp.ToString();
                weatherDescrip = response.weather[0].description.ToString();
                weatherDes.Add(weatherDescrip);
                weatherDTO.weather_description = weatherDes;
                weatherDTO.wind_speed = response.wind.speed.ToString();
                weatherDTO.wind_degree = response.wind.deg.ToString();
                weatherDTO.wind_dir = formatting.windDegreeToDirection(windDegre);
                weatherDTO.pressure = response.main.pressure.ToString();
                weatherDTO.humidity = response.main.humidity.ToString();
                weatherDTO.feelslike = response.main.feels_like.ToString();
                //TO DO: Investigate an API that can find the values for precip
                weatherDTO.precip = "0";
                //Get it a lat and lon for the next API
                lat = response.coord.lat.ToString();
                lon = response.coord.lon.ToString();

            }
            catch (Exception ex)
            {
                return null;
            }
            try
            {
                string urlApicPublicWeatherWhithKey2 = $"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lon}&exclude=hourly,daily&appid=5ffca2fa2bffcc549242d4ceefd579c5";
                dynamic response = apiRequest.Get(urlApicPublicWeatherWhithKey2);
                weatherDTO.cloudcover = response.current.clouds.ToString();
                weatherDTO.uv_index = response.current.uvi.ToString();
                weatherDTO.visibility = response.current.visibility.ToString();

            }
            catch (Exception ex)
            {
                return null;
            }
            return weatherDTO;
        }
    }
}
