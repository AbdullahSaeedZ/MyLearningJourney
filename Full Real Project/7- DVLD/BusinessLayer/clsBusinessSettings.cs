using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;



namespace BusinessLayer
{
    public static class clsBusinessSettings
    {
        public static clsUserBusiness CurrentUser;

        // all permissions
        [Flags]
        public enum enPermissions { eAll = -1, eNone = 0, eListUsers = 2, eAddUser = 4, eUpdateUser = 8, eDeleteUser = 16, eListPeople = 32, eAddPerson = 64, eUpdatePerson = 128, eDeletePerson = 256 };

        // Add/Edit person form
        public static  string  _ServerPicturesFolder = @"D:\UsersPictures\";
        public readonly static  string _defaultComboBoxCountry = "Saudi Arabia";
        public static DateTime _defaultMinAllowedAge = DateTime.Now.AddYears(-18);
        // User Login Info remember me
        public static string _RememberMeFile = @"D:\UserLogin.txt"; // later will be saved professionally


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


        // validations
        public static bool IsEmailFormatValid(string Email)
        {
            return Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]+$", RegexOptions.IgnoreCase); //RegularExpressions same as Java
        }

        public static bool IsPasswordFormatValid(string Password)
        {
            // at least one small, one capital, one number, one special character, min 8 max 20
            return Regex.IsMatch(Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#&*!._%+-]).{8,20}$"); 
        }


        public static bool IsValidInteger(string Number)
        {
            return int.TryParse(Number, out int test);
        }

        public static bool IsValidFloat(string Number)
        {
            return float.TryParse(Number, out float test);
        }

        public static bool IsValidNumber(string Number)
        {
            return double.TryParse(Number, out double test); // will return true if text is int or double
        }


        // login remember me methods
        public static void SaveLoginInfoToFile(string Username, string Password)
        {
            string del = "#//#";
            string str = Username + del + Password;
            try  
            {
                if (!File.Exists(_RememberMeFile))
                    File.Create(_RememberMeFile);

                if (Username == "" || Password == "")
                    str = "";

                File.WriteAllText(_RememberMeFile, str);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static bool LoadLoginInfoFromFile(ref string Username, ref string Password)
        {
            try
            {
                if (File.Exists(_RememberMeFile))
                {
                    string del = "#//#";
                    string Line = File.ReadAllText(_RememberMeFile);

                    if (string.IsNullOrEmpty(Line))
                        return false;

                    Username = Line.Substring(0, Line.IndexOf(del));
                    Line = Line.Remove(0, Username.Length + del.Length);

                    Password = Line;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                throw new Exception("Error while loading stored credentials");
            }
        }

    }
}
