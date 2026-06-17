/*
 
 -The Windows Registry is a hierarchical database (not relational)
 that stores configuration settings and options
 on Microsoft Windows operating systems
 

-It's used to store information about the system,
applications, and user preferences


-In C#, you can interact with the Windows
Registry using the Microsoft.Win32 namespace



-Hierarchy: 
The Registry is organized into:
keys (folders)
subkeys (subfolders)
values  (actual data or configuration settings)


-Centralized Configuration:
The Registry consolidates system
and application settings, making it a centralized location
for configuration information. This centralized approach
helps ensure consistency and allows for easy retrieval and
modification of settings

-System and User Settings: 
The Registry stores both:
1- system-wide settings (applicable to all users) are stored in various other root keys like "HKEY_LOCAL_MACHINE.
2- user-specific settings are stored in "HKEY_CURRENT_USER"


-Start-up Configuration: 
The Registry is used to
store information about programs and services that
start automatically when the system boots. This
includes settings related to startup programs and
services.
“HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run”


-Hardware Configuration: 
Information about
installed hardware components, device drivers, and
their configurations is stored in the Registry. This
includes details about connected devices, hardware
settings, and driver configurations

-Be Careful:
Modifying the Windows Registry can have
significant consequences, so it's crucial to be
careful and ensure that you have the necessary 
permissions. Always back up the Registry before
making any changes

 */



namespace _38__Windows_Registry___What__Why
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
