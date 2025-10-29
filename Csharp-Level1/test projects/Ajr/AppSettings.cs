using Newtonsoft.Json;
using System;
using System.IO;

namespace Ajr
{
    public class AppSettings
    {
        public bool isNotifyOn { get; set; }
        public bool isRunOnStartupOn { get; set; }
        public int timerIntervalIndex { get; set; }
        public int selectedCategoryIndex { get; set; }

        // static path to settings file
        private static string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Ajr");
        private static string filePath = Path.Combine(folderPath, "settings.json");

        // in case no json available
        public static AppSettings getDefaultSettings()
        {
            return new AppSettings
            {
                isNotifyOn = true,
                isRunOnStartupOn = false,
                timerIntervalIndex = 1,
                selectedCategoryIndex = 1
            };
        }

        // saving and loading
        public void saveToJson()
        {
            Directory.CreateDirectory(folderPath);
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static AppSettings loadFromJson()
        {
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(folderPath);
                AppSettings defaultSettings = getDefaultSettings();
                defaultSettings.saveToJson();

                return defaultSettings;
            }

            string json = File.ReadAllText(filePath);
            AppSettings Settings = JsonConvert.DeserializeObject<AppSettings>(json); // ?? getDefaultSettings();

            return Settings;
        }

    }
}
