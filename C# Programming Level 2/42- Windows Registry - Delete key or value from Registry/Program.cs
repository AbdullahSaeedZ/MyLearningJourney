using Microsoft.Win32;

namespace _42__Windows_Registry___Delete_key_or_value_from_Registry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // the key path and value name to be deleted
            string keyPath = @"SOFTWARE\LessonTest";
            string valueName = "username";


            try
            {
                // Open the registry key in read/write mode with explicit registry view
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(keyPath, true))
                    {
                        if (key != null)
                        {
                            // we can use this method to delete the subkey : key.DeleteSubKey(keyPath);
                            // this will delete the value, but keeps the subkey
                            key.DeleteValue(valueName);
                            Console.WriteLine($"Successfully deleted value '{valueName}' from registry key '{keyPath}'");
                        }
                        else
                        {
                            Console.WriteLine($"Registry key '{keyPath}' not found");
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("UnauthorizedAccessException: Run the program with administrative privileges.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }


        }
    }
}
