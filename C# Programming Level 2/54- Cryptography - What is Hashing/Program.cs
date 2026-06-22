/* ==============================================================================
  CRYPTOGRAPHIC HASHING & SHA-256 IN .NET
  ==============================================================================
  Hashing is the process of transforming variable-size input data into a 
  fixed-length string of characters (a hash value or digital fingerprint). 
  By design, cryptographic hash functions are strictly:
  - one-way: cannot be reversed
  - deterministic: same input always returns same result

  They are engineered for data integrity verification and authenticity checking, 
  not for data encryption or retrieval, as the original input cannot be 
  mathematically reversed from the output hash.
  Meaning is that we use hashing to compare results of hashing prcocess regardless
  of the original data encrypted.
  

  ==============================================================================
  THE CORE PRINCIPLE OF HASH COMPARISON
  ==============================================================================
  Exact Intent:
  In system architecture, we never decrypt or look at the original sensitive 
  data to verify it. Instead, we run the hashing process on the new input and 
  compare the newly generated hash directly against the previously stored hash.
 
  Operational Flow:
  1. The original plaintext data is permanently obscured during the initial hash.
  2. When verification is needed, the system hashes the incoming payload.
  3. The system compares Output_Hash_A with Output_Hash_B.
  4. If the hashes match, mathematical determinism guarantees the inputs match,
  allowing authentication or integrity verification without ever exposing 
  the actual underlying data.
  ============================================================================== 

  ==============================================================================
  SHA-256 (Secure Hash Algorithm 256-bit) - QUICK SUMMARY
  ==============================================================================
  •SHA-256 (Secure Hash Algorithm 256-bit) is a cryptographic hash function that 
   belongs to the SHA-2 family of hash functions.
  • Fixed Output Size: Always produces a 256-bit (32-byte) execution block.
  • Text Representation: Represented as a 64-character hexadecimal string,  since
    one hexa is 4-bit so 256-bit / 4-bit = 64 charachter.
  • Consistent Length: The output is always exactly 64 characters long, 
  regardless of whether the input is a single word or an entire book.
  • Avalanche Effect: Changing just a single character in the original input 
  completely and unpredictably changes the entire 64-character output.
  ============================================================================== 

  ==============================================================================
  CORE PRODUCTION USE CASES & EXAMPLES
  ==============================================================================
  * 1. Data Integrity (Checking for Changes)
  • Concept: Making sure a file or message wasn't corrupted or changed by a hacker.
  • Example: You download a 5GB game. The website says the hash should be 'A1B2'. 
  Your PC hashes the downloaded file. If it matches 'A1B2', the file is safe.

  * 2. Digital Signatures (Proving Ownership)
  • Concept: Signing a digital document so people know it legally came from you.
  • Example: You send a digital contract. The system hashes the contract and locks 
  it with your private key. The client verifies it to prove you actually signed it.

  * 3. Blockchain Technology (Securing Ledgers)
  • Concept: Linking blocks of transactions together so old data cannot be altered.
  • Example: In Bitcoin, Block #50 contains a hash of Block #49. If a hacker tries 
  to change a transaction in Block #49, the chain breaks immediately.

  * 4. Password Protection (Safe Storage)
  • Concept: Storing passwords in a database without actually knowing what they are.
  • Example: Your password is 'MySecret123'. The database only saves '7f83b2...'. 
  If a hacker steals the database, they only get useless hashes, not your password.
  ============================================================================== 
*/