/*
  What is a Configuration file? 
  
  ====================================================================================================
  THE PROBLEM: HARDCODED STRINGS AND COMPILATION PAIN
  ====================================================================================================
  In the DVLD (Driving Licenses Management System) project, the application needs to connect to a SQL Server database.
  If a developer hardcodes the connection string directly inside the Data Access Layer (DAL) classes, like this:
  string connectionString = "Server=localhost;Database=DVLD;User Id=sa;Password=...";

  * This introduces major issues:
  1. Security Risk: Hardcoded credentials are saved in plain text within the source code.
  2. Maintenance Nightmare: If the database server name changes, or the system moves from development to production,
  the developer must open the source code, find the string, change it, and RECOMPILE the entire application.
  
  ====================================================================================================
  THE CORE IDEA: App.config
  ====================================================================================================
  To solve this, .NET provides 'App.config'. It is an external XML file that separates 
  application settings (like connection strings or system configuration) from the compiled C# code.
  * Instead of embedding values into the binary, the application pulls them dynamically at runtime from this file.
  If the database IP or database credentials change in the real DVLD system, an administrator only needs to edit this 
  text file on the client's machine without touching or rebuilding the C# executable.
  
  ====================================================================================================
  HOW IT WORKS INTERNALLY
  ====================================================================================================
  1. Development Phase: A file named 'App.config' is added to the project root.
  2. Compilation Phase: The compiler copies this file to the output directory (bin/Debug or bin/Release)
  and renames it to match the executable: '[AssemblyName].exe.config'.
  3. Runtime Phase: The C# code reads from this '[AssemblyName].exe.config' file using the 
  'System.Configuration.ConfigurationManager' class.
  
  ====================================================================================================
  CRITICAL SECURITY CONSIDERATIONS: THE LIMITATIONS OF APP.CONFIG
  ====================================================================================================
  While App.config solves the recompilation problem, it does NOT automatically solve the security problem.
  * It remains a plain-text file. Anyone with local access to the deployment directory can open it and read it.
  
  * Strict Rules for Production:
  1. No Raw Secrets: Never store production API keys, third-party tokens, or plain-text passwords inside App.config.
  2. Source Control Exposure: App.config is typically tracked by Git. Committing production secrets to a repository 
     exposes them to anyone with repository access.
     
  * How to handle sensitive data properly:
  1. Configuration Encryption: Encrypt sections of the config file (such as <connectionStrings>) using 
     Protected Configuration tools (e.g., aspnet_regiis or DPAPI) so the data is unreadable on the disk.
  2. Environment Variables / Secrets Managers: For highly sensitive keys, fetch them at runtime from the host 
     machine's Environment Variables or an external secure vault rather than keeping them in the config file.
  
  ====================================================================================================
  QUICK FIX: IF 'ConfigurationManager' IS NOT FOUND IN .NET FRAMEWORK
  ====================================================================================================
  Unlike core namespaces, System.Configuration is not always implicitly referenced. If errors occur:
  1. Right-click Project -> Add -> Reference -> Check 'System.Configuration'.
  2. Add 'using System.Configuration;' at the top of the C# file.
  3. Clean and Rebuild the solution.
 */