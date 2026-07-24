using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billiards_Club_Management_System
{
    internal static class Utility
    {

        public static string GetCurrentDateTimeFormatted()
        {
            return $"{DateTime.Now.ToLongDateString()}  |  {DateTime.Now.ToShortTimeString()}";
        }

    }
}
