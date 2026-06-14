namespace _31__Special_Comments_In_C_
{
    /*
     In C#, method descriptions are typically added using XML comments, 
     which are special comments that provide information about the code and can be used to generate documentation.
     */


    /// <summary>
    /// This class represents a simple calculator.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Adds two numbers and returns the result.
        /// </summary>
        /// <param name="a">The first number to be added.</param>
        /// <param name="b">The second number to be added.</param>
        /// <returns>The sum of the two numbers.</returns>
        public int Add(int a, int b)
        {
            return a + b;
        }


        // ==========  below are used to add notes to a list that can be viewed in : go to View > Task List
        // they are called Task Identifiers
        // they can be used in a more advanced way, like making git pervent any commit if there is a specific task like TODO

        // TODO: implement validation
        public int MyProperty { get; set; }

        // HACK: Hardcoded connection string here just for testing, move to appsettings.json later
        string connectionString = "Server=myServerAddress;Database=myDataBase;";

        private void SaveToDatabase(string user)
        {
            // UNDONE: Need to finish the SQL mapping
        }

      
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // hover on the elements to see the comments
            Calculator myCalculator = new Calculator();
            int sum = myCalculator.Add(1, 2);
        }
    }
}
