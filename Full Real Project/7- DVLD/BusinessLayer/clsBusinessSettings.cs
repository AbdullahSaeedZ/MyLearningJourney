using System;
using System.IO;
using System.Text.RegularExpressions;



namespace BusinessLayer
{
    public static class clsBusinessSettings
    {
        // Add/Edit person form
        public static  string  _ServerPicturesFolder = @"D:\UsersPictures\";
        public readonly static  string _defaultComboBoxCountry = "Saudi Arabia";
        public static DateTime _defaultMinAllowedAge = DateTime.Now.AddYears(-18);
        // User Login Info remember me
        public static string _RememberMeFile = @"D:\UserLogin.txt";


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


        public static void SaveLoginInfoToFile(string Username, string Password, bool isRememberMeChecked, string del = "#//#")
        {
            string str = Username + del + Password + del + isRememberMeChecked.ToString();
            try
            {
                File.WriteAllText(_RememberMeFile, str);
            }
            catch (IOException e)
            {
                throw;
            }
        }

        public static void LoadLoginInfoFromFile(ref string Username, ref string Password, ref bool isRememberMeChecked, string del = "#//#")
        {
            try
            {
                string Line = File.ReadAllText(_RememberMeFile);

                Username = Line.Substring(0, Line.IndexOf(del));
                Line = Line.Remove(0, Username.Length + del.Length);

                Password = Line.Substring(0, Line.IndexOf(del));
                Line = Line.Remove(0, Password.Length + del.Length);

                isRememberMeChecked = Convert.ToBoolean(Line);
            }
            catch (IOException e)
            {
                throw;
            }
        }

    }
}
