using System;


// Observer pattern is one of the design patterns.

// it is embedded in the c# architecture with delegates

// idea is that there is a subject/publisher and subscribers/Observers
// publisher makes something , all subscribers get notified then they handle this notification with an action

// below example will be a Youtube channel that has subscribers,
// once channel uploads a video, all subscriber will be notified and they will handle the notification by watching the vid.
namespace _7__Observer_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1- creating the objects
            YouTubeChannel channel1 = new YouTubeChannel();

            Subscriber subscriber1 = new Subscriber();
            Subscriber subscriber2 = new Subscriber();
            Subscriber subscriber3 = new Subscriber();
            // -----------------------------------------------------------

            //2- now subscribing to the channel, which takes the event handler and adds it to the delegate invocation list
            subscriber1.Subscribe(channel1);
            subscriber2.Subscribe(channel1);
            subscriber3.Subscribe(channel1);

            channel1.UploadVideo("C# Advanced");
            channel1.UploadVideo("C# Roadmap");
            channel1.UploadVideo("C# Coding");

        }
    }


    // 1- define the delegate
    delegate void VideoUpload(string Title);

    class YouTubeChannel
    {
        // 2- create the delegate instance:
        public VideoUpload delUploaded;


        // 5-
        public void UploadVideo(string Title)
        {
            Console.WriteLine($"\nVideo with title: {Title} , has been uploaded and all subscribers will be notified");

            // invoke , and notify all subscribers (delegate chains,  run all methods in the invocation list)
            delUploaded(Title);
        }

    }

    class Subscriber
    {
        // 4-
        public void Subscribe(YouTubeChannel Channel)
        {
            // adding the event handler method to the invocation list to be notified once publisher uploads a new vid and invoke the delegate
            Channel.delUploaded += WatchVideo;
        }

        // 3-
        private void WatchVideo(string title) // event-handler, meaning once publisher notifies me, i will use this method to handle and take action
        {
            Console.WriteLine($"event-handler is invoked, user is Watching the new Video: {title}");
        }
    }

}
