/* ==============================================================================================
 * THEORETICAL FOUNDATION: OPERATING SYSTEM PROCESSES & SYSTEM.DIAGNOSTICS.PROCESS
 * ==============================================================================================
 *
 * 1. WHAT IS AN OS PROCESS?
 * ----------------------------------------------------------------------------------------------
 * An Operating System (OS) Process is an independent, executing instance of a computer program.
 * When an executable (.exe) is launched, the operating system assigns it:
 *   - Its own isolated virtual address space in RAM (it cannot directly access another app's memory).
 *   - A unique Process Identifier (PID).
 *   - Security tokens, permissions, and operating system resources.
 *   - At least one primary execution thread.
 *
 *
 * 2. THE THREE STANDARD I/O CHANNELS (Standard Streams)
 * ----------------------------------------------------------------------------------------------
 * Every console/CLI program created in Windows, Linux, and macOS is automatically attached by 
 * the operating system to three default communication data pipelines (File Descriptors / Handles):
 *
 *   1. Standard Input  (stdin  / StandardInput):
 *      - An incoming data stream where the process reads inputs (like typing commands in a terminal).
 *      - In C#, redirecting this lets you feed commands/keystrokes to the tool programmatically.
 *
 *   2. Standard Output (stdout / StandardOutput):
 *      - An outgoing data stream where the process writes its normal operational output, text, 
 *        logs, and real-time progress metrics.
 *
 *   3. Standard Error  (stderr / StandardError):
 *      - A separate outgoing stream dedicated exclusively to diagnostics, warnings, and errors.
 *      - Keeping stderr separate ensures that logging errors does not corrupt or interfere with
 *        the clean data being transmitted across stdout.
 *
 *
 * 3. WHAT IS THE SYSTEM.DIAGNOSTICS.PROCESS CLASS?
 * ----------------------------------------------------------------------------------------------
 * In .NET, `System.Diagnostics.Process` is a managed wrapper around the native Win32 Process APIs
 * (specifically functions like `CreateProcess`, `TerminateProcess`, and `WaitForSingleObject`).
 *
 * It bridges the gap between your C# application and the operating system:
 *   - It allows .NET code to spawn, monitor, interact with, and terminate external binaries.
 *   - It intercepts the 3 standard channels (stdin, stdout, stderr) via anonymous OS pipes, 
 *     letting your C# code read live console output line-by-line as managed C# events.
 *
 *
 * 4. KEY PROPERTIES & MECHANISMS (How It Works Under the Hood)
 * ----------------------------------------------------------------------------------------------
 *   - ProcessStartInfo:
 *     The configuration blueprint defining how the OS creates the process.
 *       • UseShellExecute = false: Crucial setting. Tells Windows NOT to run the binary through
 *         the graphical Windows Shell (explorer.exe), which enables direct redirection of the
 *         stdin/stdout/stderr pipes into managed .NET streams.
 *       • CreateNoWindow = true: Instructs the OS not to allocate a visible black CMD window.
 *       • RedirectStandardOutput / RedirectStandardError = true: Hooks into stdout/stderr pipes.
 *
 *   - BeginOutputReadLine() & BeginErrorReadLine():
 *     Launches internal background listener threads managed by the OS/runtime that actively 
 *     read chunks from the stdout/stderr pipe buffers and raise `OutputDataReceived` / 
 *     `ErrorDataReceived` events on the .NET ThreadPool.
 *
 *   - WaitForExit():
 *     Calls the underlying OS synchronization kernel object (`WaitForSingleObject`). It blocks 
 *     the caller until the process terminates. Wrapping this in `Task.Run()` keeps the UI thread free.
 *
 *   - ExitCode:
 *     A numeric integer returned by the external binary upon termination (Convention: 0 means Success; 
 *     any non-zero integer represents a specific application error).
 *
 *
 * 5. PROCESS TREE TERMINATION & CANCELLATION
 * ----------------------------------------------------------------------------------------------
 *   - The Child Process Trap:
 *     Many CLI utilities act as orchestrators that launch child processes (e.g., tool A spawns tool B).
 *     Calling a simple single-process termination kills tool A, leaving tool B running as an "orphan"
 *     holding open file handles.
 *   - Solution:
 *     Terminating the full Process Tree (e.g., via `taskkill /F /T` or modern `.Kill(true)`) ensures
 *     the OS traverses all parent-child links and forcefully kills every spawned sub-process.
 * ============================================================================================== */


/* ==============================================================================================
 * PRACTICAL IMPLEMENTATION: System.Diagnostics.Process Lifecycle & Stream Management
 * ==============================================================================================
 * 
 * Demonstrates:
 *   1. Initializing ProcessStartInfo without Shell Execution (UseShellExecute = false).
 *   2. Attaching to stdout & stderr channels via asynchronous line readers.
 *   3. Non-blocking OS wait via Task.Run() to prevent UI freezing.
 *   4. Safe cancellation wiring and complete process-tree termination.
 *   5. Proper handling of ExitCode and process disposal.
 * ============================================================================================== */

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class NativeProcessExecutor
{
    public async Task ExecuteProcessAsync(
        string executablePath,
        string arguments,
        Action<string> onOutputReceived,
        Action<string> onErrorReceived,
        CancellationToken cancellationToken)
    {
        // 1. Guard check: Ensure binary exists before attempting native execution
        if (!File.Exists(executablePath))
        {
            throw new FileNotFoundException("Executable binary not found.", executablePath);
        }

        // 2. Blueprint configuration: Intercepting the 3 OS channels
        var startInfo = new ProcessStartInfo
        {
            FileName = executablePath,
            Arguments = arguments,

            // Required: Bypasses Windows Shell to enable direct OS pipe redirection
            UseShellExecute = false,

            // Redirect outgoing channels (stdout & stderr)
            RedirectStandardOutput = true,
            RedirectStandardError = true,

            // Hide the default native console/command prompt window
            CreateNoWindow = true
        };

        // 3. Process wrapper initialization
        using (var process = new Process { StartInfo = startInfo })
        {
            // Attach event listener for the Standard Output stream (Channel 2)
            process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    onOutputReceived?.Invoke(e.Data);
                }
            };

            // Attach event listener for the Standard Error stream (Channel 3)
            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    onErrorReceived?.Invoke(e.Data);
                }
            };

            // 4. Wire CancellationToken to forcefully terminate the process tree if requested
            using (cancellationToken.Register(() => TerminateProcessTree(process)))
            {
                try
                {
                    // Start the native OS process
                    process.Start();

                    // Start asynchronous background listener threads on the stdout/stderr pipe handles
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();

                    // Non-blocking wait: Offloads the blocking Win32 handle wait to a worker thread
                    await Task.Run(() => process.WaitForExit(), cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    // Triggered ONLY if cancellation occurred before Task.Run was scheduled
                    return;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failed to start or execute process: {ex.Message}");
                    throw;
                }

                // 5. Evaluate execution result
                // Note: If killed mid-execution, WaitForExit() returns normally, so check the token state:
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                // 0 indicates success in native CLI conventions; non-zero indicates an error code
                if (process.ExitCode != 0)
                {
                    throw new InvalidOperationException($"Process terminated with error ExitCode: {process.ExitCode}");
                }
            }
        }
    }

    /// <summary>
    /// Kills the target process along with all descendant child processes (Process Tree)
    /// to avoid orphan background processes holding file locks.
    /// </summary>
    private void TerminateProcessTree(Process process)
    {
        try
        {
            if (process != null && !process.HasExited)
            {
                // In .NET Core / .NET 5+: process.Kill(entireProcessTree: true);
                // In classic .NET Framework 4.7.2/4.8: Use taskkill /T to kill the full subtree
                Process.Start(new ProcessStartInfo
                {
                    FileName = "taskkill",
                    Arguments = $"/F /T /PID {process.Id}",
                    CreateNoWindow = true,
                    UseShellExecute = false
                })?.WaitForExit();
            }
        }
        catch
        {
            // Process might have exited between check and termination call
        }
    }
}