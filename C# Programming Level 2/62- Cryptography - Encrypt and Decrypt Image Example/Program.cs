using System.Security.Cryptography;

namespace _62__Cryptography___Encrypt_and_Decrypt_Image_Example
{
    internal class Program
    {
        public static string GenerateKey()
        {
            // Generate a secure 128-bit key, 128bit is 16 byte (16 character)
            // using the RandomNumberGenerator which is a Cryptographically Secure Pseudo-Random Number Generator
            byte[] keyBytes = RandomNumberGenerator.GetBytes(16);
            return Convert.ToBase64String(keyBytes);
        }

        static void Main(string[] args)
        {
            string inputFile = @"D:\test.png";
            string encryptedOutputPath = @"D:\encrypted.png";
            string decryptedOutputPath = @"D:\decrypted.jpg";

            string key = GenerateKey();

            // IV will be attached into the file in the Encrypt method
            // and Decrypt will read it out of the file.
            Encrypt(inputFile, encryptedOutputPath, key);
            Decrypt(encryptedOutputPath, decryptedOutputPath, key);

            Console.WriteLine("Encryption and decryption completed successfully.");
            Console.WriteLine("go to D:\\ to see the results");
        }

        static void Encrypt(string inputFile, string outputFile, string base64Key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(base64Key);
                // IV is created by default

                using(FileStream fsOutput = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                {
                    // write the IV raw to the beginning of the new file to be created first
                    fsOutput.Write(aes.IV, 0, aes.IV.Length);

                    // now initialize the CryptoStream (encrypting engine) OVER the current position of fsOutput
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                    using (CryptoStream cryptoStream = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
                    using (FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                    {
                        fsInput.CopyTo(cryptoStream);
                    }
                }
            }
        }


        static void Decrypt(string inputFile, string outputFile, string base64Key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(base64Key);
                byte[] iv = new byte[16]; // prepare the IV buffer to extract the IV used in the encrypted file and store it for the decryption

                using (FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read)) // <- encrypted file is accessed now
                {
                    // we read the IV directly from the start of the encrypted file
                    int bytesRead = fsInput.Read(iv, 0, iv.Length);

                    // then just to duoble check
                    if (bytesRead != iv.Length)
                    {
                        throw new CryptographicException("Invalid IV header length.");
                    }

                    aes.IV = iv;

                    // now we initialize the CryptoStream to process the rest of the file
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (CryptoStream cryptoStream = new CryptoStream(fsInput, decryptor, CryptoStreamMode.Read))
                    using (FileStream fsOutput = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                    {
                        // Note: CryptoStreamMode is Read here, so we copy FROM cryptoStream TO fsOutput
                        cryptoStream.CopyTo(fsOutput);
                    }
                }
            }
        }
    }
}
