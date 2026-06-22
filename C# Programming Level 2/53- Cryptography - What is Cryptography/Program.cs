/* ==============================================================================
  CRYPTOGRAPHY IN .NET (System.Security.Cryptography)
  ==============================================================================
  Cryptography is the practice and study of techniques for secure communication 
  in the presence of third parties. In computer science, it relies on mathematical 
  concepts and deterministic, rule-based algorithms (following strict rules) to transform messages in ways 
  that are highly difficult to decipher.
 
  Core Cryptographic Pillars in C#:
 
  1. Hashing:
  A one-way encryption, deterministic cryptographic function that converts arbitrary data 
  into a fixed-length numerical fingerprint (e.g., SHA-256). It is impossible 
  to reverse, making it ideal for verifying data integrity and storing 
  passwords safely without saving the actual plaintext.
 
  2. Symmetric Encryption:
  A two-way encryption, cryptographic operation that utilizes a single, shared secret key 
  for both encryption and decryption (e.g., AES). It is computationally highly 
  efficient and designed for securely processing large amounts of data, provided 
  the secret key can be safely shared between parties.
 
  3. Asymmetric Encryption (Public Key Cryptography):
  A two-way encryption, cryptographic system that solves the key distribution problem by 
  utilizing mathematically linked key pairs (e.g., RSA). Anyone can use the 
  freely distributed Public Key to encrypt data, but only the holder of the 
  strictly protected Private Key can decrypt it. Often used for secure key 
  exchange and digital signing due to its higher computational overhead.
  ============================================================================== 
*/