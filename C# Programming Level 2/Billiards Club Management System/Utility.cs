using System;


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
