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
        public static string CopyImageToServer(string newPicPath, string oldPicPath) 
        {
            try
            {
                // scenario 1: user removed image to nothing
                if (string.IsNullOrEmpty(newPicPath))
                {
                    DeleteFileIfExists(oldPicPath);
                    return ""; // empty path to be sent to object then to DB
                }

                // setting up the directory
                if (!Directory.Exists(_ServerPicturesFolder))
                    Directory.CreateDirectory(_ServerPicturesFolder);


                // perform Copy
                // scenario 2: no old pic,then new pic added
                // scenario 3: remove old pic,then new pic added
                string destinationPath = Path.Combine(_ServerPicturesFolder, Guid.NewGuid() + Path.GetExtension(newPicPath));

                if (File.Exists(newPicPath))
                {
                    File.Copy(newPicPath, destinationPath, true);
                    DeleteFileIfExists(oldPicPath); // Clean up old after success
                    return destinationPath;
                }
            }
            catch (IOException i)
            {
                // logs
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
                throw;
            }
        }

        public static bool IsEmailFormatValid(string Email)
        {
            return Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]+$", RegexOptions.IgnoreCase); //RegularExpressions same as Java
        }
    }
}
