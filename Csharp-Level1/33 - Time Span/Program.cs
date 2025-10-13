using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // -----------------------------------------------------------
        // TimeSpan represents a time interval (duration)
        // It can be used to store hours, minutes, seconds, or even days.
        // -----------------------------------------------------------

        TimeSpan t1 = new TimeSpan(1, 30, 0); // 1 hour, 30 minutes, 0 seconds
        Console.WriteLine(t1); // 01:30:00

        // Another way to create a TimeSpan is by using static methods:
        TimeSpan t2 = TimeSpan.FromHours(1.5); // same as 1 hour 30 minutes
        Console.WriteLine(t2); // 01:30:00

        // TimeSpan can also be created using days, hours, minutes, seconds
        TimeSpan t3 = new TimeSpan(2, 14, 18, 45); // 2 days, 14 hours, 18 minutes, 45 seconds
        Console.WriteLine(t3);

        // -----------------------------------------------------------
        // Properties
        // -----------------------------------------------------------
        Console.WriteLine("\n\nDays: " + t3.Days);
        Console.WriteLine("Hours: " + t3.Hours);
        Console.WriteLine("Minutes: " + t3.Minutes);
        Console.WriteLine("Seconds: " + t3.Seconds);
        Console.WriteLine("Milliseconds: " + t3.Milliseconds);

        // Total properties (include full interval in floating point)
        Console.WriteLine("\n\nTotal Days: " + t3.TotalDays);
        Console.WriteLine("Total Hours: " + t3.TotalHours);
        Console.WriteLine("Total Minutes: " + t3.TotalMinutes);
        Console.WriteLine("Total Seconds: " + t3.TotalSeconds);

        // -----------------------------------------------------------
        // Arithmetic operations by methods or just use operators
        // -----------------------------------------------------------
        TimeSpan add = t1.Add(t2); // add two TimeSpans
        Console.WriteLine("\n\nAdd: " + add);

        TimeSpan sub = t3.Subtract(t1); // subtract
        Console.WriteLine("Subtract: " + sub);

        TimeSpan neg = t1.Negate(); // negative duration
        Console.WriteLine("Negate: " + neg);

        // -----------------------------------------------------------
        // Comparison
        // -----------------------------------------------------------
        Console.WriteLine(t1 == t2); // True
        Console.WriteLine(t1 < t3);  // True
        Console.WriteLine(t3 > t2);  // True

        // -----------------------------------------------------------
        // Static fields
        // -----------------------------------------------------------
        Console.WriteLine(TimeSpan.Zero);      // 00:00:00
        Console.WriteLine(TimeSpan.MaxValue);  // 10675199.02:48:05.4775807
        Console.WriteLine(TimeSpan.MinValue);  // -10675199.02:48:05.4775808

        // -----------------------------------------------------------
        // Example of pause using TimeSpan
        // -----------------------------------------------------------
        TimeSpan delay = TimeSpan.FromSeconds(2);
        Console.WriteLine("\n\nWaiting for 2 seconds...");
        Thread.Sleep(delay);
        Console.WriteLine("Done.");

        // -----------------------------------------------------------
        // Example: difference between two DateTimes
        // -----------------------------------------------------------
        DateTime start = new DateTime(2023, 2, 20, 12, 0, 0);
        DateTime end = new DateTime(2023, 2, 22, 14, 30, 0);
        TimeSpan diff = end - start;

        Console.WriteLine("\n\nDifference: " + diff); // 2.02:30:00
        Console.WriteLine("Total Hours: " + diff.TotalHours); // 50.5

        // -----------------------------------------------------------
        // Formatting TimeSpan
        // -----------------------------------------------------------
        Console.WriteLine(diff.ToString(@"d\.hh\:mm\:ss")); // 2.02:30:00

        // -----------------------------------------------------------
        // Create a specific DateTime and add a TimeSpan to it
        // -----------------------------------------------------------
        DateTime dt = new DateTime(2023, 2, 21);

        // Hours, Minutes, Seconds
        TimeSpan ts = new TimeSpan(49, 25, 34);

        Console.WriteLine(ts);
        Console.WriteLine(ts.Days);
        Console.WriteLine(ts.Hours);
        Console.WriteLine(ts.Minutes);
        Console.WriteLine(ts.Seconds);

        // This will add the time span to the date // we cant add date to date, we can add time span to date
        DateTime newDate = dt.Add(ts);
        Console.WriteLine(newDate);


        DateTime MyBirth = new DateTime(1997, 6, 4);
        TimeSpan Age = DateTime.Now.Subtract(MyBirth);
        Console.WriteLine("\n\nMy age is " + (Age.TotalDays / 365));

    }
}
