using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.ViewModels.Common.DateTimeFormats
{
    public class TimeFormats
    {
        /// <summary>
        /// Formats the Time from TimeSpan to string
        /// </summary>
        /// <param name="regularId">regularId</param>
        /// <returns>string time as hour:minute AM/PM</returns>
        public string convertTime(TimeSpan time)
        {
            //Converts the TimeSpan time into DateTime
            DateTime dt = new DateTime(time.Ticks);

            //Returns a date formatted string
            return dt.ToString("hh:mm tt");


        }

        /// <summary>
        /// Separate the time from a DateTIme
        /// </summary>
        /// <param name="wholeDate"></param>
        /// <returns></returns>
        public TimeSpan separateTime(DateTime wholeDate)
        {
            TimeSpan time = wholeDate.TimeOfDay;
            return time;
        }
    }
}
