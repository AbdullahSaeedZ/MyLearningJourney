using Microsoft.Win32; // for accessing Windows Registry 

namespace _39__Windows_Registry___Writing_to_Registry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Local Machine
            //string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\LessonTest";  // <- will throw an exception, permission needed, explained in next lessons

            // current user
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\LessonTest"; // <- if doesnt exist, will be created

            string valueName = "username";
            string valueData = "Abdullah";


            // better use a try-catch, sometimes an exception will be thrown when a permission is needed
            try
            {
                Registry.SetValue(keyPath, valueName, valueData);
                Console.WriteLine($"value: {valueData}, with name: {valueName}\nhas been added to the key: {keyPath}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"couldnt write to registry, {e.Message}");
            }


        }
    }
}
