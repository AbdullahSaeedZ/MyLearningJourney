/*
  ====================================================================================================
  THE CROSS-PLATFORM REPLACEMENT: FROM APP.CONFIG TO APPSETTINGS.JSON
  ====================================================================================================
  
  ====================================================================================================
  1. THE PROBLEM: WHY APP.CONFIG HAD TO DIE
  ====================================================================================================
  The legacy 'App.config' system (System.Configuration) was engineered in the early 2000s specifically 
  for the Windows ecosystem. As .NET evolved into a modern, cross-platform framework running on Linux, 
  macOS, and cloud Docker containers, App.config became a liability for three primary reasons:
  
  1. Windows Dependency: It relied on underlying Windows-specific registry behaviors and APIs.
  2. Verbose XML Format: XML is heavy, difficult to read, and computationally expensive to parse.
  3. Static Monolithic Design: ConfigurationManager was a global static class that assumed your 
     configuration lived in exactly one file on the local machine disk. Modern cloud apps require 
     dynamic configurations aggregated from multiple external sources simultaneously.
  
  ====================================================================================================
  2. THE CORE IDEA: EXTENSIBLE CONFIGURATION PROVIDERS
  ====================================================================================================
  To support cross-platform architectures, modern .NET introduced 'appsettings.json' powered by the 
  'Microsoft.Extensions.Configuration' ecosystem. 
  
  Instead of viewing configuration as a single static file, modern .NET treats configuration as a unified, 
  flattened stream of key-value pairs fed by an arbitrary chain of "Configuration Providers".
  
  You can stack providers on top of each other. A typical pipeline looks like this:
  [appsettings.json] ---> [Environment Variables] ---> [Command Line Arguments]
  
  Each layer overrides the previous one. This means you can ship safe default developer settings inside 
  the JSON file, but securely override the database connection string or API keys at runtime using host 
  machine Environment Variables in production without changing a single line of code or configuration files.
  
  ====================================================================================================
  3. HOW IT WORKS INTERNALLY
  ====================================================================================================
  1. Initialization: At application startup, a 'ConfigurationBuilder' instance is initialized.
  2. Registration: File providers, environment providers, or secret manager providers are registered to the builder.
  3. Compilation: The builder compiles these disparate sources into a single internal, read-only dictionary 
     called an 'IConfiguration' root.
  4. Binding (The Options Pattern): Instead of parsing strings everywhere manually, .NET extracts specific 
     JSON sections and maps (binds) them directly into standard, strongly-typed C# classes (POCOs). 
     These objects are then distributed across the system via Dependency Injection.
  
  ====================================================================================================
  4. WHEN NOT TO USE IT & COMMON OVER-ENGINEERING MISTAKES
  ====================================================================================================
  * The "Service Locator" Anti-Pattern: Never pass the entire 'IConfiguration' instance into your Data Access 
    Layer (DAL) or Business Logic Layer (BLL). Doing so violates separation of concerns by coupling your core logic 
    to the configuration subsystem. Pass only the strongly-typed settings objects they actually need.
  * Storing Plaintext Production Secrets: Like App.config, 'appsettings.json' is plain text. Never write production 
    passwords here. Use .NET's "User Secrets" manager ('dotnet user-secrets') during local development, 
    and environment variables or cloud vaults (like Azure Key Vault) during production deployments.
*/