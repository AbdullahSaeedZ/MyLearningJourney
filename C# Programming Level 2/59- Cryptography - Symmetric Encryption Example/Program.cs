using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

/* ====================================================================================
  1. WHAT IS BASE64?

  * The Problem:
  Encryption outputs raw binary bytes. If you try to transmit these bytes over the internet 
  (like in JSON or HTTP headers) or save them into a standard text file, the system might 
  misinterpret certain bytes as control characters (like a line break or end-of-file). 
  This corrupts the data.

  * The Solution:
  Base64 is a binary-to-text encoding scheme. It takes any raw binary data and translates 
  it into a safe, human-readable string consisting only of 64 characters: A-Z, a-z, 0-9, +, 
  and / (with = used for padding).
  * Important: Base64 is NOT encryption. It provides zero security. It is simply a way to 
  format binary data safely as text.
  ==================================================================================== 

  2. WHAT IS AN IV (INITIALIZATION VECTOR)?

  * The Problem:
  If you encrypt the word "PasstreamWriterord123" today, and encrypt it again tomorrow using the 
  exact same key, a deterministic cipher will produce the exact same encrypted string. 
  If a hacker intercepts your database, they will immediately see which users have the 
  same passtreamWriterord just by looking at the identical encrypted strings.

  * The Solution:
  The IV (Initialization Vector) is a block of completely random data mixed with your 
  first block of plaintext before encryption starts. Because the IV is random every single 
  time, encrypting the exact same text with the exact same key will produce completely 
  different, unpredictable ciphertexts.
  * Rule: The IV doesn't need to be kept secret. That's why in our code, we write it raw 
  at the very beginning of the encrypted message so the decryption method can read it.
  ==================================================================================== 

  3. WHY DO WE USE STREAmemoryStream?

  * The Problem:
  What if you need to encrypt a 4GB video file? If you try to read the entire file into a 
  byte[] array in RAM, encrypt it all at once, and return a new byte[] array, your 
  application will crash out of memory.

  * The Solution:
  StreamemoryStream are pipelines that process data sequentially, chunk by chunk, instead of loading 
  everything into memory simultaneously.

  - MemoryStream: Acts as the temporary buffer holding our bytes as they flow.
  - CryptoStream: The "transformer" in the middle of the pipeline. As bytes pass through it, 
    it applies the AES mathematical operations.
  - StreamWriter / StreamReader: Translates our C# string characters into raw bytes 
    (StreamWriter) or back into characters (StreamReader) so they can feed into the pipeline.
  */
namespace CryptographyExample
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
            string originalData = "Sensitive information";

            // 128-bit key (16 bytes) encoded in Base64
            string base64Key = GenerateKey();

            string encryptedData = Encrypt(originalData, base64Key);
            string decryptedData = Decrypt(encryptedData, base64Key);

            Console.WriteLine($"Original data: {originalData}");
            Console.WriteLine($"Key: {base64Key}");
            Console.WriteLine($"Encrypted using the key: {encryptedData}");
            Console.WriteLine($"Decrypted using the key: {decryptedData}");
        }

        static string Encrypt(string plainText, string base64Key)
        {
            // Convert your text-based safe key back into raw 16 bytes for AES.
            byte[] key = Convert.FromBase64String(base64Key);

            // create the algorithm object to perform symmetric cryptography operations
            using (Aes aes = Aes.Create()) // <- will generate IV, but it is a one-time use
            {
                aes.Key = key;
                // Generate a random 128-bit IV for every new encryption proess using same aes object
                aes.GenerateIV();
                // 3. Create the cryptographic engine engine (the transformer).
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                // 4. Open our stream pipeline.
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // 5. CRITICAL: We write the raw IV (16 bytes) at the very front of our stream.
                    // Anyone who decrypts this will know the first 16 bytes is the IV.
                    memoryStream.Write(aes.IV, 0, aes.IV.Length);

                    // 6. Chain the CryptoStream to the MemoryStream. 
                    // Anything written to 'cryptoStream' gets encrypted and pushed into 'memoryStream'.
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))


                    // 7. Chain the StreamWriter to the CryptoStream so we can write plain text.
                    using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    } // Closing these flushes all remaining bytes out into 'memoryStream'

                    // 8. Convert the final merged package (IV + Encrypted Bytes) into a safe Base64 text string.
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        static string Decrypt(string cipherText, string base64Key)
        {
            byte[] fullCipher = Convert.FromBase64String(cipherText);
            byte[] key = Convert.FromBase64String(base64Key);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;

                // from the full encrypted texr, extract the 16-byte IV instantly
                // using C# range slicing [start..end] instead of crearing a temp array to copy needed elements
                aes.IV = fullCipher[0..16];

                // Why do we use this MemoryStream constructor?
                // Instead of allocating a new array and copying the encrypted text, we pass the full array 
                // but offset the stream to start reading at index 16 (skipping the 16-byte IV) until the end.
                using (var memoryStream = new MemoryStream(fullCipher, 16, fullCipher.Length - 16))
                using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (var streamReader = new StreamReader(cryptoStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}

/*
 
 [ Your Plaintext String ]  (e.g., "Sensitive information")
           │
           ▼
 ┌───────────────────┐
 │   StreamWriter    │  Step 1: Translates C# string characters into raw UTF-8 bytes.
 └───────────────────┘
           │  (Raw Unencrypted Bytes)
           ▼
 ┌───────────────────┐
 │   CryptoStream    │  Step 2: Acts as the "transformer". It intercept the bytes,
 └───────────────────┘          applies the AES math algorithm using your Key and IV, 
           │                    and outputs scrambled, encrypted bytes.
           ▼  (Scrambled Encrypted Bytes)
 ┌───────────────────┐
 │   MemoryStream    │  Step 3: The destination buffer. It catches the encrypted bytes
 └───────────────────┘          and applies them directly behind the 16-byte IV 
                                that you manually wrote at the very beginning.
           │
           ▼
 [ memoryStream.ToArray() ]  -> Contains: [ 16-byte IV ] + [ Encrypted Ciphertext Bytes ]
           │
           ▼
 [ Convert.ToBase64String ]  -> Converts that entire raw byte array into a safe 
                                printable text string.
 
 */