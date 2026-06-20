// REQUIRED NUGET PACKAGES FOR THIS LESSON:
// 1. Microsoft.Extensions.Configuration
// 2. Microsoft.Extensions.Configuration.Json
using Microsoft.Extensions.Configuration;

namespace TestProject
{
    internal class Program
    {
        /*
          ====================================================================================================
          LESSON: MODERN CROSS-PLATFORM CONFIGURATION IN .NET
          ====================================================================================================
          
          WORKFLOW RULE:
          We add the 'appsettings.json' file directly inside the Presentation Layer project folder.
          Why? Because that is where the compiled executable (.exe) will live. 
          
          CRITICAL STEP IN VISUAL STUDIO:
          Right-click 'appsettings.json' -> Select Properties -> Set "Copy to Output Directory" to "Copy if newer".
          This ensures that whenever the app compiles, the file is moved to the 'bin/Debug' or 'bin/Release' folder
          alongside the executable, which is where the app actually looks for it at runtime.
          
          ====================================================================================================
          UNDERSTANDING THE SYNTAX & ARCHITECTURE
          ====================================================================================================
          1. WHY USE THE 'IConfiguration' INTERFACE?
             In legacy App.config, we used a static Windows-only class called 'ConfigurationManager'. 
             In modern .NET, we read configurations via the 'IConfiguration' interface. By programming to 
             an interface instead of a hardcoded file reader, your code is decoupled from the file system. 
             Today, 'IConfiguration' reads from local JSON. Tomorrow, without changing your Data Access Layer (DAL),
             the exact same interface can read configuration values from Environment Variables or Cloud Key Vaults.
             
          2. BEST PRACTICE: WHERE DO CONNECTION STRINGS GO?
             While you can technically make up any custom tags inside a JSON file, the industry standard and 
             best practice is to use the dedicated, root-level "ConnectionStrings" section. 
             .NET provides specialized built-in extension methods (like .GetConnectionString()) specifically
             engineered to target this exact section safely.
        */

        static void Main(string[] args)
        {
            // ============================================================================================
            // STEP-BY-STEP CONFIGURATION BUILD (Without Method Chaining / Fluent API)
            // ============================================================================================

            // Step A: Create the raw engine responsible for assembling configuration sources.
            ConfigurationBuilder builder = new ConfigurationBuilder();

            // Step B: Point the builder to the active directory where the executable is running (the bin folder).
            builder.SetBasePath(Directory.GetCurrentDirectory());

            // Step C: Register our specific JSON file into the configuration source pipeline.
            // 'optional: false' means the app will crash safely if the file is missing (good for critical DB paths).
            // 'reloadOnChange: true' allows the app to read updated values without restarting the application execution.
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // Step D: Run the compilation process to parse the JSON data into a clean, read-only key-value map.
            IConfiguration config = builder.Build();


            // ============================================================================================
            // ACCESSING VALUES FROM APPSETTINGS.JSON
            // ============================================================================================

            Console.WriteLine("=== READING TRADITIONAL APPSETTINGS ===");

            // To access nested keys inside JSON, we use a Colon (:) to drill down into the object hierarchy.
            string logLevel = config["AppSettings:LogLevel"];
            string sampleCustomKey = config["AppSettings:koko"];

            Console.WriteLine($"Log Level Value: {logLevel}");
            Console.WriteLine($"Custom Key Value: {sampleCustomKey}");


            Console.WriteLine("\n=== READING CONNECTION STRINGS (INDUSTRY BEST PRACTICE) ===");




            // BAD PRACTICE: Accessing connection strings via generic AppSettings strings.
            // string badApproach = config["AppSettings:ConnectionString"]; 

            // BEST PRACTICE: Using the native .NET shortcut helper. 
            // .GetConnectionString("Name") automatically looks inside the top-level "ConnectionStrings" section.
            string productionConnectionString = config.GetConnectionString("DVLDConnection");

            Console.WriteLine($"Database Target String: {productionConnectionString}");

            Console.ReadLine();
        }
    }
}