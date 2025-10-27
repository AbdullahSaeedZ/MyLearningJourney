using Newtonsoft.Json;
using System;
using System.IO;

namespace Ajr
{
    public class AppSettings
    {
        public bool isNotifyOn { get; set; }
        public bool isNotifySoundOn { get; set; }
        public bool isRunOnStartupOn { get; set; }
        public int timerIntervalIndex { get; set; }
        public int balloonShowTime { get; set; }
        public int selectedCategoryIndex { get; set; }

        // static path to settings file
        private static string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Ajr");
        private static string filePath = Path.Combine(folderPath, "settings.json");

        public static AppSettings getDefaultSettings()
        {
            return new AppSettings
            {
                isNotifyOn = true,
                isNotifySoundOn = true,
                isRunOnStartupOn = false,
                timerIntervalIndex = 1,
                balloonShowTime = 10,
                selectedCategoryIndex = 1
            };
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


        public void saveToJson()
        {
            Directory.CreateDirectory(folderPath);
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }



      
    }
}
