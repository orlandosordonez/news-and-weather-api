using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTodo.DTO;
using WebApplicationTodo.Servicies;

namespace WebApplicationTodo.Controllers
{
    [Route("weather-and-news/api/[controller]")]
    [ApiController]
    public class CheckHistoryController : ControllerBase
    {
        [HttpGet]
        public HistoryDTO Get()
        {
            DataTable d = new DataTable();
            SQLConnection sql = new SQLConnection();
            List<CityDTO> allCity = new List<CityDTO>();
            HistoryDTO historyDTO = new HistoryDTO();

            d = sql.MostrarDatos();

            foreach (DataRow z in d.Rows)
            {
                CityDTO cityDTO = new CityDTO();
                cityDTO.city = (string)z["country"];
                cityDTO.info = (string)z["inf"];
                allCity.Add(cityDTO);
            }

            historyDTO.history = allCity;

            return historyDTO;

        }
    }
}
