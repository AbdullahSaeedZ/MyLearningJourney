using System.IO;
using System.Text;

namespace _8__Streams
{


    /*
      ==================================================================================
       WHAT IS A STREAM? (The Ultimate Explanation)
      ==================================================================================
      ** CONCEPT:
      A "Stream" is a conceptual pipe or conveyor belt used to transfer bytes of data 
      sequentially from a Source (e.g., a file, memory, network) to a Destination.
      
      ** WHY DO WE NEED STREAMS? (The Memory Problem)
      Imagine you have a huge 10 GB video file, and your computer only has 8 GB of RAM. 
      If you try to load the whole file into RAM at once, your program will crash with 
      an "OutOfMemoryException".

      ** THE SOLUTION:
      Instead of loading the entire file, a Stream opens a small connection (pipe) to 
      the file and reads it piece by piece (e.g., 4 KB at a time) into a small buffer. 
      Once processed, it moves to the next piece. This keeps memory usage incredibly low.

      * ----------------------------------------------------------------------------------
       THE RELATION WITH UNMANAGED RESOURCES & IDisposable
      ----------------------------------------------------------------------------------
      Streams are the ultimate example of why we need IDisposable:
      *1. To open a file or network stream, .NET must ask the Operating System (OS) for a 
      "File Handle" or "Network Socket". These are UNMANAGED resources.

      *2. If you don't close/dispose the stream, the file remains LOCKED by the OS. 
      Other programs (or even your own program, same happened in DVLD with profile pics) won't be able to open or delete it.

      *3. Therefore, Streams ALWAYS implement IDisposable.
     */

    /*
     * ==================================================================================
     *  Summary Table: Streams Explained
     * ==================================================================================
     * * 🔷 Term           | 🔍 Explanation
     * ------------------|--------------------------------------------------------------
     * Stream            | An abstract pipe used to transfer data sequentially as bytes
     * | 
     * Core Benefit      | Processes huge data source piece-by-piece without freezing RAM
     * | 
     * Backing Stores    | Can connect to Files (FileStream), RAM (MemoryStream), or Networks (NetworkStream)
     * | 
     * Stream Operations | Can Read (source -> app), Write (app -> dest), or Seek (move cursor)
     * | 
     * Unmanaged Link    | Relies on OS file handles or sockets that MUST be released
     * | 
     * Best Practice     | ALWAYS wrap Streams in a "using" block to guarantee OS handles 
     * | are unlocked immediately via Dispose()
     * * ==================================================================================
     */

    /*
     * ----------------------------------------------------------------------------------
     * CODE EXAMPLE: Reading a File using Streams the Modern Way (.NET 10)
     * ----------------------------------------------------------------------------------
     */

    public class StreamExample
    {
        public static void ReadFileExample()
        {
            string filePath = "large_data.txt";

            // 'using var' guarantees the OS file handle is unlocked the moment this method ends
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            // StreamReader is a helper stream wrapper that converts raw bytes into readable text characters
            using var reader = new StreamReader(fileStream, Encoding.UTF8);

            string? line; // ? -> nullable reference explanation in next lessons

            // Reading line by line sequentially without filling up the RAM
            while (( line = reader.ReadLine() ) != null)
            {
                // Process the line here
            }
        }
        // <--- Both 'reader' and 'fileStream' are Disposed here automatically in reverse order.
        //      The OS file handle is released and the file is completely unlocked.
    }

    /*
    FileStream does NOT store the file's data inside the object.

    It acts as a connection(channel) between the program and the file,
    keeping track of information such as:

    - The opened file
    - The current position in the file
    - The file handle provided by the OS
    - Read / Write mode


    Data is transferred through the stream only when requested.

    Example:
        data.txt
            |
            v
        FileStream
            |
            v
        byte[] buffer
            |
            v
        Your Code

    When Read() is called, a small portion of the file is copied into
    a buffer, processed by the program, then the next portion is read.

    This allows large files to be handled efficiently without loading
    the entire file into memory at once.

    Stream = a channel for moving data, not a container holding all data.
    */
}
