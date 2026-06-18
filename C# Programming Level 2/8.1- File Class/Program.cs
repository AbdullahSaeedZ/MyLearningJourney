// ===================================================================================
// LESSON: THE 'File' CLASS IN .NET
// ===================================================================================
//
// WHAT IS IT?
// The 'File' class (System.IO) is a static utility class providing high-level, 
// convenient methods for creating, copying, deleting, moving, and opening files.
//
// THE PROBLEM IT SOLVES (Why it exists):
// Operating systems require low-level stream management (allocating file handles,
// locking files, managing byte buffers, and closing streams safely). Writing this 
// boilerplate code for every simple file operation leads to verbose code, resource 
// leaks, and bugs. The 'File' class exists to hide this complexity.
//
// CORE IDEA & INTERNALS:
// It acts as a Facade Pattern. When you call a method like 'File.WriteAllText()', 
// it internally creates a 'FileStream', writes the data, and wraps it in a 
// try-finally block to guarantee that the stream is closed and resources are freed.
// It handles the entire lifecycle of the file access in a single, atomic operation.
//
// PRAGMATIC RULES:
// 1. Use it for small to medium files (under a few megabytes).
// 2. Avoid manual "Check-then-Do" logic (e.g., File.Exists -> File.Create) because 
//    another process can modify the file between the check and the action. Instead,
//    rely on options that do both safely (like FileMode.Append or direct File methods).
// ===================================================================================

using System;
using System.IO;
using System.Text;

public static class FileHelper
{
    private static readonly string _filePath = "demo_log.txt";

    // Writes or overwrites a text file with a single operation.
    // Best used when replacing the entire contents of a configuration or state file.
    public static void OverwriteFile(string content)
    {
        try
        {
            // Internally opens a stream, writes the entire content, and closes it.
            File.WriteAllText(_filePath, content, Encoding.UTF8);
        }
        catch (IOException ex)
        {
            // Handle cases where the file is locked by another process
            Console.WriteLine($"I/O Error writing to file: {ex.Message}");
        }
    }

    // Appends text to a file. If the file does not exist, it creates it automatically.
    // This is the ideal, crash-safe approach for custom logging.
    public static void AppendLineToFile(string message)
    {
        try
        {
            string formattedMessage = $"[{DateTime.Now}] {message}{Environment.NewLine}";
            // Environment.NewLine will insert a new line, the usual \n might crash on some platforms

            // Will check, create (if needed), open, append, and close.
            File.AppendAllText(_filePath, formattedMessage, Encoding.UTF8);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O Error appending to file: {ex.Message}");
        }
    }



    // Reads the entire file content into memory as a single string.
    // Use ONLY for small files.
    public static string ReadEntireFile()
    {
        // If it doesn't exist, return a safe default instead of crashing.
        if (!File.Exists(_filePath))
            return string.Empty;

        try
        {
            // Internally opens a stream for reading, loads content to RAM, and closes it.
            return File.ReadAllText(_filePath, Encoding.UTF8);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"I/O Error reading file: {ex.Message}");
            return string.Empty;
        }
    }
}