using Microsoft.Win32;

namespace _40__Windows_Registry___Reading_from_Registry
{
    class Program
    {
        static void Main(string[] args)
        {
            //string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\LessonTest";


            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\LessonTest";
            string valueName = "username"; // the valueName which we need to read its valueData


            try
            {
                string value = Registry.GetValue(keyPath, valueName, null) as string;


                if (value != null)
                {
                    Console.WriteLine($"The value of {valueName} is: {value}");
                }
                else
                {
                    Console.WriteLine($"Value {valueName} not found in the Registry.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
