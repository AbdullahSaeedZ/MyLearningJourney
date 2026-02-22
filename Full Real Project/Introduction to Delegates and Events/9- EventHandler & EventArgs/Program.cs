using System;

// EventHandler is a built-in delegate in .NEt, see definition of it and will see
// instead of defining a delegate then declaring instance of it, just create an EvenHandler anywhere directly


namespace _9__EventHandler___EventArgs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            YouTubeChannel ElzeroChannel = new YouTubeChannel() { channelName = "Elzero"};
            YouTubeChannel HadhudChannel = new YouTubeChannel() { channelName = "Hadhud"};

            Subscriber Abdullah = new Subscriber();

            Abdullah.Subscribe(ElzeroChannel);
            Abdullah.Subscribe(HadhudChannel);
   

            ElzeroChannel.UploadVideoWithNoData("JS Basics");
            Console.WriteLine();

            ElzeroChannel.UploadVideoWithData("HTML 101");
            Console.WriteLine();

            HadhudChannel.UploadVideoWithFULLData("RoadMap");
            Console.WriteLine();

        }
    }

    // old way
    // delegate void Uploaded(string title);


    class YouTubeChannel
    {
        // old way
        // public event Uploaded delUploaded;


        // directly declaring the built-in delegate
        // signature inside the .Net:  public delegate void EventHandler(object sender, EventArgs e);

        // (object sender) is the object that makes the event
        // (EventArgs e ) is any data related to the event to be sent when invoked

        // so every event-handler method must match those parameters to be able to subscribe


        public event EventHandler eventNoData;            // delegate that just notifies with no event data
        public event EventHandler<string> eventWithData;  // delegate that notifies WITH event data, type of data is specified
        public event EventHandler<EventArgsVideo> eventWithFullData;  // delegate that notifies WITH FULL event data, type of data is a class we made

        public string channelName { get; set; } 

        public void UploadVideoWithNoData(string title)
        {
            Console.WriteLine($"Video : {title} has been uploaded, no data sent");
            eventNoData(this, EventArgs.Empty); //invoke, with empty eventArgs cuz this delegate type sends no data when invoking.
        }

        public void UploadVideoWithData(string title)
        {
            Console.WriteLine($"Video : {title} has been uploaded, only one data sent");
            eventWithData(this, title); //invoke, with only one data based on EventHandler delegate we declared
        }

        public void UploadVideoWithFULLData(string title)
        {

            Console.WriteLine($"Video : {title} has been uploaded, with full data");

            eventWithFullData(this, new EventArgsVideo() { Title = title, duration = 12, date = "2026", genre = "Comedy" }); 
        }

    }

    class Subscriber
    {

        public void Subscribe(YouTubeChannel Channel)
        {
            Channel.eventNoData += WatchVideoNoData;
            Channel.eventWithData += WatchVideoWithData;
            Channel.eventWithFullData += WatchVideoWithFULLData;
        }

        private void WatchVideoNoData(object sender,  EventArgs e) // must match the parameters of the EventHandler delegate
        {
            Console.WriteLine($"user is now watching the new Vid, No Data Received");
        }

        private void WatchVideoWithData(object sender,  string title) // must match the parameters of the EventHandler delegate of one data to send
        {
            Console.WriteLine($"user is now watching {title}, one data Received");
        }

        private void WatchVideoWithFULLData(object sender, EventArgsVideo e) // must match the parameters of the EventHandler delegate woth full data to send
        {
            Console.WriteLine($"user is now watching {e.Title} from {((YouTubeChannel)sender).channelName}, duration: {e.duration.ToString()}, genre: {e.genre}, dat: {e.date} ");
        }
    }



    // to send full data once invoking, we must contain them in a class, best practice is to inherit EventArgs base class, so it is clear for others that it is for event data
    class EventArgsVideo : EventArgs
    {
        public string Title { get; set; }
        public int duration { get; set; }
        public string genre { get; set; }
        public string date{ get; set; }
    }

}
