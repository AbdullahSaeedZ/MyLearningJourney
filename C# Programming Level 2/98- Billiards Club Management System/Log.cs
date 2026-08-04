using Billiards_Club_Management_System.SessionsHistory;
using System;
using System.Diagnostics;
using System.IO;

namespace Billiards_Club_Management_System
{
    internal class Log
    {
        public enum LogType
        {
            General,
            Error,
            Session,
            FoodPayment,
            TablesPayment
        }

        private static readonly string _sourceName = "Billiards Club";
        private static readonly string _logName = "Application";

        private static readonly string _logFilePath = "Logs.txt"; // in the debug folder

        public static void LogEvent(LogType entryType, string message, string stackTrace = "")
        {
            LogToFile(entryType, message, stackTrace);
            LogToEventViewer(entryType, message, stackTrace);
        }

        private static void LogToFile(LogType entryType, string message, string stackTrace = "")
        {
            try
            {
                string formattedMessage = "";
                if (entryType == LogType.Error)
                    formattedMessage = FormattedErrorMessage(entryType, message, stackTrace);
                else
                    formattedMessage = FormattedInfoMessage(entryType, message);

                if (File.Exists(_logFilePath))
                {
                    FileInfo fileInfo = new FileInfo(_logFilePath);

                    long bytes = fileInfo.Length;
                    double megabytes = bytes / ( 1024.0 * 1024.0 );

                    if (megabytes >= 5) // overrite the file if it exceeds 5 MB
                        File.WriteAllText(_logFilePath, formattedMessage + Environment.NewLine);
                    else
                        File.AppendAllText(_logFilePath, formattedMessage + Environment.NewLine);
                }

            }
            catch (Exception e)
            {
                throw new Exception($"Writing to Log File Error: {e.Message}");
            }
        }

        private static void LogToEventViewer(LogType entryType, string message, string stackTrace = "")
        {
            try
            {
                if (!EventLog.SourceExists(_sourceName))
                    EventLog.CreateEventSource(_sourceName, _logName);

                string formattedMessage = "";
                if (entryType == LogType.Error)
                    formattedMessage = FormattedErrorMessage(entryType, message, stackTrace);
                else
                    formattedMessage = FormattedInfoMessage(entryType, message);

                // added manifest file to ask for adminstrator permission
                EventLog.WriteEntry(_sourceName, formattedMessage, entryType == LogType.Error ? EventLogEntryType.Error : EventLogEntryType.Information);
            }
            catch (Exception e)
            {
                throw new Exception($"Writing to Event Viewer error: {e.Message}");
            }
        }

        private static string FormattedErrorMessage(LogType entryType, string message, string stackTrace = "")
        {
            return $"[{DateTime.Now}][{entryType}][{message}][Trace: {stackTrace}]";
        }

        private static string FormattedInfoMessage(LogType entryType, string message)
        {
            string entryTypeString = entryType == LogType.TablesPayment ? "Tables Payment" : entryType == LogType.FoodPayment ? "Food Payment" : entryType.ToString();
            return $"[{DateTime.Now}][{entryTypeString}][{message}]";
        }

        public static string[] GetLogs()
        {
            if (!File.Exists(_logFilePath)) return null;

            try
            {
                return File.ReadAllLines(_logFilePath);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to read from logs file: {ex.Message}");
            }
        }
    }
}
