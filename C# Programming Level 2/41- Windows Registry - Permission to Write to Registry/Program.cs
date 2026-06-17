using Microsoft.Win32;

namespace _41__Windows_Registry___Permission_to_Write_to_Registry
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Local Machine
            string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\LessonTest";  // permission needed
            string valueName = "username";
            string valueData = "Abdullah";


            // getting a permission is done through:
            // first method: run VS as adminstrator
            // second method: adding a manifest file cintaining xml script inside the project to allow the app to ask the user for an adminstrator permission

            // name of file must be: app.manifest
            // script inside the file:
            /*
             
             <?xml version="1.0" encoding="utf-8"?>
                <assembly manifestVersion="1.0" xmlns="urn:schemas-microsoft-com:asm.v1">
	                <assemblyIdentity version="1.0.0.0" processorArchitecture="X86" name="YourAppName" type="win32" />
	                <trustInfo xmlns="urn:schemas-microsoft-com:asm.v2">
		                <security>
			                <requestedPrivileges>
				                <requestedExecutionLevel level="requireAdministrator" uiAccess="false" />
			                </requestedPrivileges>
		                </security>
	                </trustInfo>
                </assembly>

             */


            // after adding it to the project, go to project settings > Application > Manifest drop menu then choose the app.manifest file


            try
            {
              
                Registry.SetValue(keyPath, valueName, valueData);
                Console.WriteLine($"value: {valueData}, with name: {valueName}\nhas been added to the key: {keyPath}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"couldnt write to registry, {e.Message}");
            }

            // Redirection to "WOW6432Node" is not necessary for user-specific registry settings
            //
            // NOTE: The redirection to "WOW6432Node" ONLY happens if this C# app is compiled as a 32-bit (x86) process running on a 64-bit OS.
            // If compiled as 64-bit (x64) or 'Any CPU' on a 64-bit OS, it writes directly to the standard path without redirection.
            // 
            // WHAT IS WOW6432Node?
            // It stands for "Windows on Windows 64-bit". It's a compatibility layer and a Registry key used to isolate 32-bit applications 
            // from 64-bit applications on a 64-bit OS.
            // - 32-bit App on 64-bit OS -> Redirected to: SOFTWARE\WOW6432Node\<Key>
            // - 64-bit App on 64-bit OS -> Goes directly to: SOFTWARE\<Key>
        }
    }
}
