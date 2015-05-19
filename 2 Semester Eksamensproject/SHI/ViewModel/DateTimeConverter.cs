using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHI.ViewModel
{
    class DateTimeConverter
    {
        public static DateTime DateTimeOffsetAndTimeSetToDateTime(DateTimeOffset date, TimeSpan time)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, 0);
        }
    }
}
