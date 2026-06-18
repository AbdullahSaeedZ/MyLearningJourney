// ===================================================================================
// LESSON: STACK TRACING IN LOGGING
// ===================================================================================
//
// WHAT IS IT?
// A Stack Trace is an ordered report of the active stack frames (method calls) at 
// a specific point in time during a program's execution. It shows the exact chain 
// of methods that were called leading up to the log or exception.
//
// THE PROBLEM IT SOLVES (Why it exists):
// When an application fails in production, just knowing the error message (e.g., 
// "Object reference not set to an instance of an object") is rarely enough. You 
// need to know WHERE the error happened and HOW the code got there. Without a 
// Stack Trace, debugging production issues is like solving a mystery with no clues.
//
// CORE IDEA:
// The .NET Runtime (CLR) keeps track of every method call in a structure called 
// the "Call Stack". When an exception is thrown, or when you explicitly ask for it, 
// .NET captures this stack snapshot, including method names, file names, and line 
// numbers (if .pdb debugging files are available), and formats it into a readable string.
//
// INTERNAL MECHANICS:
// Each time a method is called, a "Stack Frame" is pushed onto the Call Stack. 
// When the method returns, its frame is popped off. The Stack Trace simply reads 
// this stack from the top (current failing method) down to the bottom (Main method).
//
// PRAGMATIC WARNINGS (When NOT to over-use it):
// 1. Performance Cost: Generating a Stack Trace requires walking the CPU/CLR stack, 
//    which is a relatively expensive operation.
//     -The Problem: An Information log string is usually tiny:
//      "Order #4592 processed successfully." (approx. 40 bytes)
//    - A Stack Trace string can easily be 2KB to 10KB depending on how deep your 
//      architecture is (Controllers -> Services -> Repositories -> Database).
//    - Impact: If you log a Stack Trace for every standard event, your log files 
//      will grow exponentially by 100x to 1000x. You will run out of server disk 
//      space in days, or pay massive, unnecessary cloud storage bills (AWS/Azure).

// 2. Security Risk: Stack traces expose internal method names, namespaces, and 
//    sometimes file paths. Log them into secure server files, NEVER expose them 
//    directly to the end-user in the UI.
// ===================================================================================

using System;
using System.Diagnostics;
using System.IO;
using System.Text;

public static class PragmaticLogger
{
    private static readonly string _logFilePath = "app_errors.log";

    // APPROACH 1: The Standard Pragmatic Way (Logging caught exceptions)
    // This captures the exact stack trace where the actual crash occurred.
    public static void LogException(Exception ex, string customMessage)
    {
        try
        {
            string message = $"[{DateTime.Now}][{customMessage}][Exception: {ex.GetType().Name} - {ex.Message}][Trace: {ex.StackTrace}]{Environment.NewLine}";
            File.AppendAllText(_logFilePath, message, Encoding.UTF8);
        }
        catch (IOException)
        {
            // Fail-safe: Avoid crashing the app because logging failed
        }
    }

    // APPROACH 2: The Explicit Way (Capturing stack trace on-demand)
    // Used when you want to log a warning or diagnostic message and see how the 
    // code reached this specific helper method, without a real exception being thrown.
    public static void LogDiagnosticWarning(string warningMessage)
    {
        try
        {
            // Capture current stack context. 
            // We skip 1 frame so the current 'LogDiagnosticWarning' method itself isn't at the top.
            StackTrace stackTrace = new StackTrace(1, true);
            string message = $"[{DateTime.Now}][WARN: {warningMessage}][CALL STACK ORIGIN: {stackTrace.ToString()}]{Environment.NewLine}";
            File.AppendAllText(_logFilePath, message, Encoding.UTF8);
        }
        catch (IOException) { }
    }
}

// ===================================================================================
// COMPARISON: APPROACH 1 vs. APPROACH 2 (Internal Mechanics)
// ===================================================================================
//
// APPROACH 1: ex.StackTrace (The Post-Mortem Capture)
// - Efficiency: HIGH. It doesn't generate anything new at runtime when you call it; 
//   the Stack Trace was ALREADY captured and populated by the CLR the exact moment 
//   the exception was thrown ('throw'). You are just reading a stored string property.
// - Best Use: Standard catch blocks where an actual failure occurred.
//
// APPROACH 2: new StackTrace(1, true) (The On-Demand Snapshot)
// - Efficiency: LOW. It actively forces the CLR to pause the thread, inspect the 
//   current CPU registers/managed stack, and build a new trace structure frame-by-frame 
//   right at that moment. Passing 'true' forces it to look for .pdb files to resolve 
//   exact line numbers, adding disk I/O overhead.
// - Best Use: Diagnostic/Warning tools used sparingly. The '1' parameter is pragmatic 
//   as it skips the logging method itself, making the log start directly from the 
//   caller method that triggered the warning.
// ===================================================================================