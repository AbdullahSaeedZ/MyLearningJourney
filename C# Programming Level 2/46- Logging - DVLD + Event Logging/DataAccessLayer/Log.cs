using System;
using System.Diagnostics;
using System.IO;


namespace DataAccessLayer
{
    public static class Log
    {
        private static readonly string _sourceName = "DVLD";
        private static readonly string _logName = "Application";

        private static readonly string _logFilePath = "Log.txt"; // in the debug folder


        
        public static void LogEvent(EventLogEntryType entryType, string message, string stackTrace = "")
        {
            LogToFile(entryType, message, stackTrace);
            LogToEventViewer(entryType, message, stackTrace);
        }

        public static string GetLogHistory()
        {
            if (!File.Exists(_logFilePath)) return $"No File Found at: {_logFilePath}";

            try
            {
                // large file sizes are not handled, this is just for demo
                return File.ReadAllText(_logFilePath);
            }
            catch (Exception)
            {
                return "Error while reading log history";
            }
        }

        private static void LogToFile(EventLogEntryType entryType, string message, string stackTrace = "")
        {
            try
            {
                string formattedMessage = "";
                if (entryType == EventLogEntryType.Error)
                    formattedMessage = $"[{DateTime.Now}][{entryType}][Exception: {message}][Trace: {stackTrace}]";
                else
                    formattedMessage = $"[{DateTime.Now}][{entryType}][Message: {message}]";

                File.AppendAllText(_logFilePath, formattedMessage + Environment.NewLine);
            }
            catch (Exception e)
            {
                throw new Exception($"Writing to Log File Error: {e.Message}");
            }
        }

        private static void LogToEventViewer(EventLogEntryType entryType, string message, string stackTrace = "")
        {
            try
            {
                if (!EventLog.SourceExists(_sourceName))
                    EventLog.CreateEventSource(_sourceName, _logName);

                string formattedMessage = "";
                if (entryType == EventLogEntryType.Error)
                    formattedMessage = $"[{DateTime.Now}][{entryType}][Exception: {message}][Trace: {stackTrace}]";
                else
                    formattedMessage = $"[{DateTime.Now}][{entryType}][Message: {message}]";

                // added manifest file to ask for adminstrator permission
                EventLog.WriteEntry(_sourceName, formattedMessage, entryType);
            }
            catch (Exception e)
            {
                throw new Exception($"Writing to Event Viewer error: {e.Message}");
            }
        }
    }
}
