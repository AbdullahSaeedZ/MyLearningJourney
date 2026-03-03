using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;



namespace BusinessLayer
{
    public static class clsBusinessSettings
    {
        public static  string  _ServerPicturesFolder = @"D:\UsersPictures\";
        public readonly static  string _defaultComboBoxCountry = "Saudi Arabia";
        public static DateTime _defaultMinAllowedAge = DateTime.Now.AddYears(-18);


        // must be in DataAccess ?
        // this is copying files from users computers to our server, so need business and data layers, not helper class in UI.

        /// <summary>
        /// if OldPicPath is empty and first time to upload a picture, it is handled.
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="OldPicPath"></param>
        /// <returns></returns>
        public static string CopyImageToServer(string sourcePath, string oldPicPath)
        {
            try
            {
                // 1. If user removed image or source is empty
                if (string.IsNullOrEmpty(sourcePath))
                {
                    DeleteFileIfExists(oldPicPath);
                    return "";
                }

                // 2. If no change happened
                if (sourcePath == oldPicPath) return oldPicPath;

                // 3. Setup Directory
                if (!Directory.Exists(_ServerPicturesFolder))
                    Directory.CreateDirectory(_ServerPicturesFolder);

                // 4. Perform Copy
                string destinationPath = Path.Combine(_ServerPicturesFolder, Guid.NewGuid() + Path.GetExtension(sourcePath));

                if (File.Exists(sourcePath))
                {
                    File.Copy(sourcePath, destinationPath, true);
                    DeleteFileIfExists(oldPicPath); // Clean up old after success
                    return destinationPath;
                }
            }
            catch (IOException i)
            {
                // Log your error here: clsLogger.Log(ex.Message);
                return "";
            }

            return "";
        }

        private static void DeleteFileIfExists(string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                    File.Delete(path);
            }
            catch (IOException i)
            {
                /* Log deletion error */
            }
        }

        public static bool IsEmailFormatValid(string Email)
        {
            return Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]+$", RegexOptions.IgnoreCase); //RegularExpressions same as Java
        }


     
    }
}
