//add this class through NuGet packages:  System.Diagnostics.EventLog
using System.Diagnostics; 

namespace _44__Logging___Logging_Example
{
    // i will store my app event logs in the system event viewr (the centralized database) so i can track processes or errors.

    internal class Program
    {
        static void Main(string[] args)
        {
            // 1- we preapre the event log info:
            string sourceName = "testApp"; // specify the source, the name of the app
            string logName = "Application"; //specify which folder(Application, Security..)

            // needs to be run as adminstrator or add the manifest file
            try
            {
                //2- create the event source if not created
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, logName);
                    Console.WriteLine($"source name {sourceName} is created in {logName} log");
                }


                // for example: those can be used in try-catch blocks in my DVLD project to track errors,
                // or to have any logs like when adding new people in the system or whatever process we need to track

                // log an event of Information type
                EventLog.WriteEntry(sourceName, "this is an information event: user logged in", EventLogEntryType.Information);

                // log an event of Warning type
                EventLog.WriteEntry(sourceName, "this is a warning event: user was blocked due to 3 failed log in attempts", EventLogEntryType.Warning);

                // log an event of Error type
                EventLog.WriteEntry(sourceName, "this is an Error event: (exception message) Database connection failed due to..", EventLogEntryType.Error);


                Console.WriteLine("events logged successfully ");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
        }
    }
}
