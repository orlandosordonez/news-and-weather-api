using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplicationTodo.Servicies
{
    public class SQLConnection
    {
        private SqlConnection connection = new SqlConnection("Data Source = DESKTOP-7STF7HA; Initial Catalog = city_weather_api; Integrated Security = true");
        private DataSet ds;

        public DataTable MostrarDatos()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from consultation_history", connection);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            connection.Close();
            return ds.Tables["tabla"];
        }

        public bool Insertar(string country, string inf)
        {

            connection.Open();
            //string city = Regex.Replace(country, @"\s", "_");
            SqlCommand cmd = new SqlCommand(string.Format("insert into consultation_history values ('{0}','{1}') ", new string[] { country, inf }), connection);
            int rowsaffected = cmd.ExecuteNonQuery();
            connection.Close();
            if (rowsaffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
