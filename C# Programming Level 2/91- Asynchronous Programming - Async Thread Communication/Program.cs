using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace RealProgressExample
{
    class Program
    {
        /* ==============================================================================================
          TOPIC: PROGRESS REPORTING IN ASYNCHRONOUS TASKS (.NET)
          
          1. THE PROBLEM:
             Long-running background operations (like file downloads or data processing) are isolated. 
             Without a communication channel, the main/UI thread has no visibility into the task's 
             current status, causing frozen screens or uninformative UIs.
          
          2. THE MECHANISM (THE "HOW"):
             We achieve this decoupling using a CALLBACK mechanism. The worker method accepts a 
             functional placeholder (Delegate) passed by the caller. As the background thread works, 
             it invokes this delegate to send live metrics back, without knowing or caring how the 
             caller displays them.
          
             CROSS-THREAD COMMUNICATION:
             In a broader sense, this is a foundational pattern for passing information between threads.
             Because background threads shouldn't directly touch or manipulate data owned by other 
             threads (especially the UI thread), they pass safe, immutable snapshots of data via 
             delegates, message queues, or specialized context-aware channels.
          
          3. THE PROFESSIONAL .NET WAY:
             While raw delegates (like 'Action<T>') work in basic apps, they can crash GUI applications 
             (WPF, WinForms, MAUI) due to cross-thread UI violations. 
             
             To solve this professionally, .NET provides:
             - 'IProgress<T>' : The abstraction interface passed into the worker method.
             - 'Progress<T>'  : The class instantiated by the caller which automatically captures the 
                                original thread context, ensuring safe UI synchronization.
         * ============================================================================================== */

        static async Task Main(string[] args)
        {
            // using the interface that .NET provides:

            //Progress<double> progress = new Progress<double>(percent =>
            //{
            //    // This code runs back on the main thread to update the user
            //    Console.Clear();
            //    Console.WriteLine($"Downloading file: {percent:F2}% complete");
            //});

            Action<double> progress1 =(percent =>
            {
                // This code runs back on the main thread to update the user
                Console.Clear();
                Console.WriteLine($"Downloading file: {percent:F2}% complete");
            });

            Console.WriteLine("Starting download...");

            await FakeDownloadFileAsync1(progress1);

            Console.WriteLine("\nDownload finished successfully!");
        }

        // Simulating a real stream download
        static Task FakeDownloadFileAsync1(Action<double> progress)
        {
            return Task.Run(async () =>
            {
                long totalBytes = 1_000_000; // Imagine a 1MB file
                long bytesDownloaded = 0;
                int chunkSize = 4096;        // Reading 4KB at a time

                while (bytesDownloaded < totalBytes)
                {
                    // 1. Simulate reading a chunk of data from the network stream
                    await Task.Delay(5);
                    bytesDownloaded += chunkSize;

                    // 2. Calculate the real percentage mathematically
                    double percentage = ( (double)bytesDownloaded / totalBytes ) * 100;

                    // 3. Fire-and-forget the progress metric back to the UI
                    progress?.Invoke(percentage);
                }
            });
        }

        // using the interface that .NET provides
        static Task FakeDownloadFileAsync(IProgress<double> progress)
        {
            return Task.Run(async () =>
            {
                long totalBytes = 1_000_000; // Imagine a 1MB file
                long bytesDownloaded = 0;
                int chunkSize = 4096;        // Reading 4KB at a time

                while (bytesDownloaded < totalBytes)
                {
                    // 1. Simulate reading a chunk of data from the network stream
                    await Task.Delay(5);
                    bytesDownloaded += chunkSize;

                    // 2. Calculate the real percentage mathematically
                    double percentage = ( (double)bytesDownloaded / totalBytes ) * 100;

                    // 3. Fire-and-forget the progress metric back to the UI
                    progress?.Report(percentage);
                }
            });
        }
    }
}