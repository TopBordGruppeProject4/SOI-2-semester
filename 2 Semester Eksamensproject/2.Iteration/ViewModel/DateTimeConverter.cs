using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Iteration.ViewModel
{
    class DateTimeConverter
    {
        public static string DateTimeToString(DateTimeOffset date)
        {
            return Convert.ToString(date);
        }
    }
}
