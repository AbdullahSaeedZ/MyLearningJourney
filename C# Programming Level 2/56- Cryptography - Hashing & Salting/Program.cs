using System.Security.Cryptography;
using System.Text;

namespace _56__Cryptography___Hashing_With_Salting_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawPassword = "123456";

            // 1. Simplest way to generate a secure 16-byte salt
            // 
            // WHY RandomNumberGenerator OVER Random?
            // - System.Random: Unsafe for security. It uses a predictable mathematical formula (Pseudo-Random).
            //   If an attacker guesses the seed (or server start time), they can predict all future salts.
            // - RandomNumberGenerator (CSPRNG): Cryptographically secure. It harvests true randomness 
            //   from OS entropy sources (hardware, system events). Completely unpredictable and mandatory for security.
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            // 2. Hash the password with the salt
            string hashedPassword = ComputeHashWithSalt(rawPassword, salt);

            Console.WriteLine("===================== Registering User =====================");
            Console.WriteLine($"Raw Password: {rawPassword}");
            Console.WriteLine($"Generated Salt (Hex): {BitConverter.ToString(salt).Replace("-", "")}");
            Console.WriteLine($"Stored Hash: {hashedPassword}\n");

            Console.WriteLine("===================== Login Attempt =====================");
            Console.Write("Enter your password to login: ");
            string userInput = Console.ReadLine();


            // 3. To verify, we MUST use the same salt generated during registration
            string userInputHashed = ComputeHashWithSalt(userInput, salt);
            Console.WriteLine($"\nEntered password: {userInput}");
            Console.WriteLine($"Entered password after hashing with stored salt: {userInputHashed}");

            if (hashedPassword == userInputHashed)
                Console.WriteLine("\n[SUCCESS] Login successful! Hashes match.");
            else
                Console.WriteLine("\n[FAILED] Invalid password! Hashes do not match.");

            Console.ReadKey();
        }

        // The cleanest and most straightforward way to combine and hash
        public static string ComputeHashWithSalt(string input, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(input);

            // Combine arrays easily using LINQ Concat
            byte[] combinedBytes = passwordBytes.Concat(salt).ToArray();

            // Compute SHA256 in one single clean step
            byte[] hashResult = SHA256.HashData(combinedBytes);

            // Modern and fastest way to convert bytes to Hex string (Returns uppercase by default)
            return Convert.ToHexString(hashResult).ToLower();
        }
    }
}
