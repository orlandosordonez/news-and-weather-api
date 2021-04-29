
using System;

namespace WebApplicationTodo.Servicies
{
    public class FormattingServicies
    {
        public string unixDatetoString(double UnixTime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(UnixTime).ToLocalTime();
            string dtDateTimeString = dtDateTime.ToString("MM/dd/yyyy h:mm tt");
            return dtDateTimeString;
        }

        public string windDegreeToDirection(double degrees)
        {
            string CardinalDir = "";
            //North
            if (degrees < 11.25 & degrees >= 348.75)
            {
                CardinalDir = "N";
            }
            if (degrees < 33.75 & degrees >= 11.25)
            {
                CardinalDir = "NNE";
            }
            if (degrees < 56.25 & degrees >= 33.75)
            {
                CardinalDir = "NE";
            }
            if (degrees < 78.75 & degrees >= 56.25)
            {
                CardinalDir = "ENE";
            }
            //East
            if (degrees < 101.25 & degrees >= 78.75)
            {
                CardinalDir = "E";
            }
            if (degrees < 123.75 & degrees >= 101.25)
            {
                CardinalDir = "ESE";
            }
            if (degrees < 146.25 & degrees >= 123.75)
            {
                CardinalDir = "SE";
            }
            if (degrees < 168.75 & degrees >= 146.25)
            {
                CardinalDir = "SSE";
            }
            //South
            if (degrees < 191.25 & degrees >= 168.75)
            {
                CardinalDir = "S";
            }
            if (degrees < 213.75 & degrees >= 191.25)
            {
                CardinalDir = "SSW";
            }
            if (degrees < 236.25 & degrees >= 213.75)
            {
                CardinalDir = "SW";
            }
            if (degrees < 258.75 & degrees >= 236.25)
            {
                CardinalDir = "WSW";
            }
            //West
            if (degrees < 281.25 & degrees >= 258.75)
            {
                CardinalDir = "W";
            }
            if (degrees < 303.75 & degrees >= 281.25)
            {
                CardinalDir = "WNW";
            }
            if (degrees < 326.25 & degrees >= 303.75)
            {
                CardinalDir = "NW";
            }
            if (degrees < 348.75 & degrees >= 326.25)
            {
                CardinalDir = "NNW";
            }
            return CardinalDir;
        }
    }
}
