using System;

// check previous lesson first
// THEN REMOVE EVENT KEYWORD TO UNDERSTAND THE ISSUES

// event is a solution for two problems in delegates
// 1- direct invoking.
// 2- ability to reference to null, hence deleting invocation list.

// so event is a protection layer for delegate, a wrapper on top the delegate

namespace _7__Observer_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            YouTubeChannel channel1 = new YouTubeChannel();

            Subscriber subscriber1 = new Subscriber();
            Subscriber subscriber2 = new Subscriber();
            Subscriber subscriber3 = new Subscriber();

            subscriber1.Subscribe(channel1);
            subscriber2.Subscribe(channel1);
            subscriber3.Subscribe(channel1);

            channel1.UploadVideo("C# Advanced");
            channel1.UploadVideo("C# Roadmap");
            channel1.UploadVideo("C# Coding");
            Console.WriteLine();

            //----------------------------------------------------------------------------
            // Problem 1,  direct invoking:

            // 2- since the delegate instance is public, we can access it here and SKIP and violate the encapsulations concept
            // also logic in the UploadVideo will be skipped also
            channel1.delUploaded("direct invoking");


            // Problem 2,  point to null and delete invocation list:
            channel1.delUploaded = null;

            // now we upload a vid then notify, Exception will be thrown cuz delegate will call methods in the list, but there is none!!
            // we can do validation in uploading method to not invoke if null, but then we will upload a video without invoking which means no one will watch it!
            channel1.UploadVideo("After pointing to null");

        }
    }


    delegate void VideoUpload(string Title);

    class YouTubeChannel
    {
        // 1- this must be public so we can subscribe to it from other objects

        //SOLUTION TO ISSUES: to add event keyword to a delegate, then the two problems are gone
        // hover on the errors in main to see the message: can only use assignment operator inside the delegate target (where it is created), and outside can only add or remove to chain ( += and -= )
        public event VideoUpload delUploaded;  


        public void UploadVideo(string Title)
        {
            Console.WriteLine($"\nVideo with title: {Title} , has been uploaded and all subscribers will be notified");
            // logic to be executed, like who can see the vid, is it Kids-content and so on
            // ......
            // ......


            // the direct invoking will skip this whole logic code
            delUploaded(Title);
        }

    }

    class Subscriber
    {
        public void Subscribe(YouTubeChannel Channel)
        {
            Channel.delUploaded += WatchVideo;
        }

        private void WatchVideo(string title) 
        {
            Console.WriteLine($"event-handler is invoked, user is Watching the new Video: {title}");
        }
    }

}
