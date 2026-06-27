using System;
using System.Net;
using System.Threading;

namespace _71__Multithreading___Downloading_3_Web_Pages_using_WebClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread task1 = new Thread(() => DownloadAndPrintWithWebClient("https://www.abdullahsz.com"));
            Console.WriteLine("Thread 1 started");
            Thread task2 = new Thread(() => DownloadAndPrintWithWebClient("https://www.programmingadvices.com"));
            Console.WriteLine("Thread 2 started");
            Thread task3 = new Thread(() => DownloadAndPrintWithWebClient("https://learn.microsoft.com"));
            Console.WriteLine("Thread 3 started");

            task1.Start();
            task2.Start();
            task3.Start();

            task1.Join();
            task2.Join();
            task3.Join();

            Console.WriteLine("All tasks executed!");
        }

        public static void DownloadAndPrintWithWebClient(string url)
        {
            try
            {
                // using, to clean up network resources
                using WebClient webClient = new WebClient(); // <- this is an obsolete class, there are modern classes to use, but just for the sake of explaining

                // this line tells the web server we are a browser, avoiding the forbidden error i used to get
                webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                string webPage = webClient.DownloadString(url);
                Console.WriteLine($"url: {url}, {webPage.Length} characters downloaded");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading {url}: {ex.Message}");
            }
        }
    }
}