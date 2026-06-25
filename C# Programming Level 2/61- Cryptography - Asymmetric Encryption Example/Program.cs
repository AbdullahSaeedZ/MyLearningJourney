using System;
using System.Security.Cryptography;
using System.Text;

/*
  =====================================================================================================
  Old & New Approach
  =====================================================================================================
  * 1. THE PROBLEM (Legacy Cryptography Issues):
  - Platform Lock-in: Traditional .NET implementations relied heavily on legacy Windows-specific 
  Cryptographic Service Providers (CAPI) and exported asymmetric keys as XML structures. 
  This architecture introduces immediate failure points on modern .NET workloads running cross-platform, 
  throwing 'PlatformNotSupportedException' on Linux or macOS environments.

  - Insecure Defaults: Legacy methods typically defaulted to PKCS #1 v1.5 padding schemes. This standard 
  is now considered obsolete by modern engineering standards due to its critical vulnerability to 
  chosen-ciphertext attacks (such as padding oracle exploits).


  * 2. THE NEW APPROACH (Why it is viable and secure):
  - Abstract Factory ('RSA.Create()'): Automatically delegates cryptographic tasks to the host operating 
  system's native engine (CNG on Windows, OpenSSL on Linux/macOS). This provides seamless cross-platform 
  execution and optimal performance.

  - Strong Padding (OAEP SHA256): Replaces the broken PKCS #1 v1.5 scheme with Optimal Asymmetric 
  Encryption Padding (OAEP). OAEP processes plaintext through a asymmetric mathematical trapdoor paired 
  with a SHA256-based mask generation function, eliminating padding oracle vectors.

  - Industry Standard Serialization (PEM): Uses RFC 7468 compliant formatting, enabling smooth 
  data interchange with systems built on Linux, Node.js, Python, or Go.


  * 3. WHAT IS PEM?
  - PEM (Privacy-Enhanced Mail) is the industry-standard container format for cryptographic keys, 
  certificates, and parameters. 

  - Internally, a PEM structure is just a binary cryptographic key (serialized using DER encoding) 
  that has been Base64 encoded. This raw string payload is wrapped inside distinct, readable boundaries: 
  "-----BEGIN RSA PUBLIC KEY-----" and "-----END RSA PUBLIC KEY-----".

  - This format allows keys to be safely transmitted as plain text over APIs, stored in environment 
  variables, or committed to configuration vaults without corruption from system-specific line endings.
  =====================================================================================================
 */

class AsymmetricEncryptionExample
{
    static void Main()
    {
        // RSA cannot encrypt data larger than its key size (minus padding overhead).
        // For a 2048-bit key using OAEP SHA256, the maximum plaintext limit is 190 bytes.
        // If you need to encrypt large payloads, use Hybrid Encryption:
        // generate a random AES key, encrypt the file with AES, and encrypt the small AES key with RSA.
        try
        {
            // Generate a secure cross-platform RSA key pair (defaults to a safe 2048-bit key size)
            using (RSA rsa = RSA.Create())
            {
                // Export public and private keys using standard, cross-platform PEM formatting
                string publicKeyPem = rsa.ExportRSAPublicKeyPem();
                string privateKeyPem = rsa.ExportRSAPrivateKeyPem();

                string originalMessage = "Hello, this is a secret message!";

                // Encrypt using the public key PEM
                string encryptedMessage = Encrypt(originalMessage, publicKeyPem);

                // Decrypt using the private key PEM
                string decryptedMessage = Decrypt(encryptedMessage, privateKeyPem);

                // Output results
                Console.WriteLine("--- CRYPTOGRAPHIC KEYS ---");
                Console.WriteLine($"\nPublic Key (PEM):\n\n{publicKeyPem}");
                Console.WriteLine("\n\n--------------------------\n");
                Console.WriteLine($"Original Message:  \n{originalMessage}");
                Console.WriteLine($"\nEncrypted (Base64 Encoded):   \n{encryptedMessage}");
                Console.WriteLine($"\nDecrypted Message: \n{decryptedMessage}");
            }
        }
        catch (CryptographicException ex)
        {
            Console.WriteLine($"[CRITICAL] Cryptographic Failure: {ex.Message}");
        }
    }

    static string Encrypt(string plainText, string publicKeyPem)
    {
        using (RSA rsa = RSA.Create())
        {
            // Parses the structural text headers and decodes the internal Base64 key payload automatically
            rsa.ImportFromPem(publicKeyPem);

            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(plainText);

            // Enforce secure OAEP padding with SHA256 hashing
            byte[] encryptedData = rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.OaepSHA256);

            return Convert.ToBase64String(encryptedData);
        }
    }

    // Decrypts a base64 encoded ciphertext using a standard RSA Private Key PEM.
    static string Decrypt(string cipherText, string privateKeyPem)
    {
        using (RSA rsa = RSA.Create())
        {
            // Parses and imports the private key structure from PEM text
            rsa.ImportFromPem(privateKeyPem);

            byte[] encryptedData = Convert.FromBase64String(cipherText);

            // Mirror the padding and hashing configuration used during encryption
            byte[] decryptedData = rsa.Decrypt(encryptedData, RSAEncryptionPadding.OaepSHA256);

            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}