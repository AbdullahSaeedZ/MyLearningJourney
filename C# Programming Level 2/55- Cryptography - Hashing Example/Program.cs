using System.Security.Cryptography;
using System.Text;

namespace _55__Cryptography___Hashing_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawPassword = "123456";
            string hashedPassword = ComputeHash(rawPassword);

            Console.WriteLine("===================== Try To Match The Hash =====================\n");
            Console.WriteLine($"Main Password before hashing: {rawPassword}");
            Console.WriteLine($"Main Password after hashing: {hashedPassword}");

            Console.Write("\nEnter a password to be hashed and compared with the Main password:");
            string userInput = Console.ReadLine();
            string userInputHashed = ComputeHash(userInput);
            Console.WriteLine($"\nEntered Password before hashing: {userInput}");
            Console.WriteLine($"Entered Password after hashing: {userInputHashed}");

            string result = ( hashedPassword == userInputHashed ) ? "MATCH" : "NO MATCH";
            Console.WriteLine($"\nMain password and Entered Password compared using hashes: {result}");

            Console.ReadKey();
        }

        public static string ComputeHash(string input)
        {
            // we convert the string into bytes using utf8 encoding
            byte[] inputInBytes = Encoding.UTF8.GetBytes(input);

            // take the input text in bytes as parameter to the method that will return result in bytes
            byte[] hashResult = SHA256.HashData(inputInBytes);

            // since result is in bytes, we need it in a readable string wo we use the bit converter class:
            return BitConverter.ToString(hashResult).Replace("-", "").ToLower();
        }
    }
}
