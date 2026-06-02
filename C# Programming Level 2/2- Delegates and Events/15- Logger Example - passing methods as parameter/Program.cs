namespace _15__Logger_Example___passing_methods_as_parameter
{
    /*
        this is an example of passing methods as parameters:
        the Logger class uses delegates to receive and execute different logging implementations

        this is similar to using switch statements with enums to choose which code block to execute, but it is more flexible and easier to extend

        this demonstrates the Strategy Design Pattern in a simplified way, where the main idea is:

        the Logger class does not know how logging is actually performed, instead, the logging implementation is provided from the outside through dependency injection

        in real applications, the Strategy Pattern is usually
        implemented using interfaces and separate strategy classes, but here we used delegates only to demonstrate the core idea with less code

        ============ see next lesson to clarify Dependency Injection concepts ===========
    */
    public class Logger
    {
        private event Action<string> _errorOccurred;

        public Logger(Action<string> handler)
        {
            this._errorOccurred = handler;
        }

        public void Log(string message)
        {
            _errorOccurred?.Invoke(message);
        }
    }


    internal class Program
    {
        public static void LogToScreen(string message)
        {
            Console.WriteLine(message);
        }

        public static void LogToFile(string message) // or to database or whatever
        {
            string filePath = "test.txt"; // default path will be the project folder > bin > debug > .net10
            
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(message);
            }
        }

        static void Main(string[] args)
        {
            Logger screenLogger = new Logger(LogToScreen);
            Logger fileLogger = new Logger(LogToFile);

            screenLogger.Log("error is logged and printed on screen");
            fileLogger.Log("error is logged and saved in file");
        }
    }
}
