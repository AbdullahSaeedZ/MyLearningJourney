// download System.Configuration.ConfigurationManager from nuget
using System.Configuration;


namespace TestProject
{
    internal class Program
    {
        // we add a new item in the project as a configuration file, we add it in the Persentation layer, cuz thats where the exe will be and the exe will be using the config file
        // but accessing the config file will be in DAL
        // add needed app settings, see the file
        // then we access it this way:
        static void Main(string[] args)
        {
            // get the key values from the config file
            Console.WriteLine("accessing the appSettings tag:");
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"]; // <- key name as parameter
            string LogLevel = ConfigurationManager.AppSettings["LogLevel"]; // <- key name as parameter
            string koko = ConfigurationManager.AppSettings["koko"]; // <- key name as parameter


            Console.WriteLine($"Key: connectionString, key value: {connectionString}");
            Console.WriteLine($"Key: LogLevel, key value: {LogLevel}");
            Console.WriteLine($"Key: koko,  key value: {koko}");


            // reading the other <connectionStrings> tag:
            Console.WriteLine("\n\naccessing the connectionString tag");
            string connectionStringTag = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString; // <- name attribute as parameter
            Console.WriteLine($"tag: <connectionStrings>, attribute name: MyDbConnection, connectionString attribute: {connectionString}");
        }

        // NOTE: after app is compiled, and we deploy the app to the client, any further updates on the config file will be on the one in bin folder not the one we created here,
        // cuz thats the place where the exe file will be looking for a config file at runtime

    }
}
