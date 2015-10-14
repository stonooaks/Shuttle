using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.ViewModels.Common.DateTimeFormats
{
    public class DateFormats
    {
        /// <summary>
        /// Combine Date and Time into DateTime
        /// </summary>
        /// <param name="originalDate">oringinal date in DateTime</param>
        /// <param name="originalTime">original time in DateTime</param>
        /// <returns></returns>
        public DateTime combineDateTime(DateTime originalDate, TimeSpan originalTime)
        {
            DateTime comDateTime = originalDate.Add(originalTime);
            return comDateTime;
        }

        public DateTime separateDate(DateTime wholeDate)
        {
            DateTime day = wholeDate.Date;
            return day;
        }
    }
}
