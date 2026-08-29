using Billiards_Club_Management_System.SessionsHistory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

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
        private const long _maxFileSizeBytes = 5 * 1024 * 1024;



        public static void LogEvent(LogType entryType, string message, string stackTrace = "")
        {
            try
            {
                LogToFile(entryType, message, stackTrace);
    }
            catch (Exception ex)
            {
                // we can handle the logging exception in multiple ways, just for demo
            }

            try
            {
                LogToEventViewer(entryType, message, stackTrace);
    }
            catch (Exception ex)
            {
            }
        }

        private static void LogToFile(LogType entryType, string message, string stackTrace = "")
        {
            string formattedMessage = "";
            if (entryType == LogType.Error)
                formattedMessage = FormattedErrorMessage(entryType, message, stackTrace);
            else
                formattedMessage = FormattedInfoMessage(entryType, message);

            if (File.Exists(_logFilePath))
            {
                FileInfo fileInfo = new FileInfo(_logFilePath);
                if (fileInfo.Length >= _maxFileSizeBytes)
                {
                    File.WriteAllText(_logFilePath, formattedMessage + Environment.NewLine);
                    return;
                }
            }

            File.AppendAllText(_logFilePath, formattedMessage + Environment.NewLine);
        }

        private static void LogToEventViewer(LogType entryType, string message, string stackTrace = "")
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

        private static string FormattedErrorMessage(LogType entryType, string message, string stackTrace = "")
        {
            return $"[{DateTime.Now}][{entryType}][{message}][Trace: {stackTrace}]";
        }

        private static string FormattedInfoMessage(LogType entryType, string message)
        {
            string entryTypeString = entryType == LogType.TablesPayment ? "Tables Payment" : entryType == LogType.FoodPayment ? "Food Payment" : entryType.ToString();
            return $"[{DateTime.Now}][{entryTypeString}][{message}]";
        }

        public static async Task<string[]> GetLogsAsync()
        {
            if (!File.Exists(_logFilePath)) return null;

            try
            {
                List<string> lines = new List<string>();
                using (StreamReader reader = new StreamReader(_logFilePath))
                {
                    string line;
                    while (( line = await reader.ReadLineAsync() ) != null)
                    {
                        lines.Add(line);
                    }
                }

                return lines.ToArray();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to read from logs file.", ex);
            }
        }
    }
}
