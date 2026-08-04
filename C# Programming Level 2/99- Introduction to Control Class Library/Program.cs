/*
================================================================================
  CONTROL LIBRARIES IN .NET FRAMEWORK
================================================================================

1. THE PROBLEM (WHY IT EXISTS)
--------------------------------------------------------------------------------
Imagine you are building multiple Windows desktop applications. Every application 
needs a modern, rounded button with custom hover animations and a primary color 
theme. 

If you build that custom button inside Application A, its code lives directly 
inside Application A. When you start building Application B, you are forced to 
copy and paste the control's code and layout. 

This leads to major maintenance problems:
- Bug fixes in Application A's button must be manually copied to Application B.
- Teams end up reinventing the UI wheel for every single new project.
- UI consistency across different applications breaks down.


2. CORE IDEA
--------------------------------------------------------------------------------
A Control Library (or Windows Forms Control Library) is a specialized class 
library project in .NET that compiles into a reusable dynamic-link library (.dll) 
file instead of an executable (.exe). 

Instead of holding application logic, it houses UI components—such as UserControls 
and Custom Controls—so they can be built once, packaged, and reused across 
dozens of separate projects.


3. HOW GUNA UI RELATES TO THIS
--------------------------------------------------------------------------------
Guna UI (e.g., Guna.UI2.WinForms) is simply a commercially vendor-packaged 
Control Library. 

The developers of Guna created a Control Library project, built advanced custom 
controls (rounded buttons, toggle switches, custom charts with built-in animations), 
and compiled them into `.dll` files (or packaged them as NuGet packages). 

When you install Guna UI into your project, you are referencing an external 
Control Library. Your Visual Studio Toolbox scans that library's DLL and exposes 
Guna's components directly onto your drag-and-drop designer surface.


4. HOW IT WORKS INTERNALLY & MINIMAL C# EXAMPLE
--------------------------------------------------------------------------------
When you create a control library, your class inherits from `System.Windows.Forms.Control` 
or `System.Windows.Forms.UserControl`.



/*
5. HOW TO ADD AND USE IT IN SEPARATE PROJECTS
--------------------------------------------------------------------------------
There are three standard ways to consume a Control Library in separate projects:

METHOD A: Project Reference (When both live in the same Visual Studio Solution)
  1. Right-click your main App project -> 'Add' -> 'Reference...'.
  2. Select 'Projects' on the left menu.
  3. Check the box next to your Control Library project and click OK.

METHOD B: File Reference (.dll) (When shared across different Solutions)
  1. Build your Control Library project in 'Release' mode.
  2. Copy the resulting `.dll` file from the `bin/Release` folder.
  3. In your target project, right-click 'References' -> 'Add Reference...'.
  4. Click 'Browse', locate the `.dll` file, and add it.
  5. (Optional) To add it to the VS Toolbox: Open a Form designer, open the 
     Toolbox window, right-click an empty space, choose 'Choose Items...', 
     browse to the `.dll`, and select it.

METHOD C: Local / Private NuGet Package (Best practice for enterprise teams)
  1. Pack your Control Library into a `.nupkg` file using `dotnet pack` or 
     Visual Studio project properties.
  2. Host it on a private NuGet feed or local folder.
  3. Install it into target projects using the NuGet Package Manager (the exact 
     same way Guna UI is installed).


6. WHEN NOT TO USE IT & COMMON OVER-ENGINEERING MISTAKES
--------------------------------------------------------------------------------
- Don't build a Control Library for a control used in only one form or project. 
  Keep simple, single-use controls inside the main application project.
- Don't couple application business logic or database access inside your Control 
  Library. A Control Library should strictly handle UI presentation and layout.
- Don't create too many small control library projects. Group related UI 
  components into a single unified design system library (e.g., `Company.UI`).
*/