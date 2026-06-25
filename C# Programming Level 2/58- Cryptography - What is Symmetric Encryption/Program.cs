/*
  =========================================================================
  INTRODUCTION TO SYMMETRIC ENCRYPTION
  =========================================================================
  
  * 1. THE PROBLEM (Why it exists)
  -------------------------------------------------------------------------
  When two systems need to exchange sensitive data over an untrusted network 
  like the internet, sending it in plain text is a massive security risk. 
  Anyone sniffing network packets can read it. We needed a fast, secure 
  way to scramble this data so that only authorized parties can read it.

  * 2. THE CORE IDEA (What "Symmetric" means)
  -------------------------------------------------------------------------
  "Symmetric" means balanced or mirrored. In cryptography, it means that 
  the EXACT SAME SECRET KEY is used for both encryption and decryption.
  
  
  
  * 3. BRIEF TYPES OF SYMMETRIC ENCRYPTION
  -------------------------------------------------------------------------
  Symmetric algorithms generally operate in one of two ways:

  1- Block Ciphers: Breaks data into fixed-size chunks (blocks) and encrypts 
  each block. 
  Examples: DES, 3DES, and AES.

  2- Stream Ciphers: Encrypts data continuously, byte-by-byte or bit-by-bit. 
  Example: RC4.
  
  
  * 4. THE MODERN STANDARD: FOCUS ON AES
  -------------------------------------------------------------------------
  Advanced Encryption Standard (AES) is the industry gold standard for 
  symmetric block ciphers. It don't rely on keeping the algorithm itself 
  a secret; the math is public knowledge. Instead, security relies entirely 
  on keeping the key secret. 

  * The algorithm takes your data, breaks it into 128-bit blocks, and mixes 
  it with the key through multiple mathematical rounds of substitution 
  (swapping values) and permutation (shuffling positions) until the output 
  looks completely like random noise.
  
  
  * 5. AES KEY SIZES: PROS & CONS
  -------------------------------------------------------------------------
  AES supports three key lengths: 128-bit, 192-bit, and 256-bit. 

  The key size determines the number of mathematical rounds executed internally.

  - 128-bit Key (10 Rounds):
  -> Pros: Fastest performance, lowest CPU overhead, highly optimized. 
  Mathematically unbreakable via brute-force today.
  -> Cons: Less theoretical margin against future quantum computing.

  - 192-bit Key (12 Rounds):
  -> Pros: Slightly higher security baseline than 128-bit.
  -> Cons: Rarely used in modern software architectures.

  - 256-bit Key (14 Rounds):
  -> Pros: Maximum security depth, deemed quantum-resistant.
  -> Cons: Slower throughput and higher processing cost due to extra rounds.
  
  **** it is a trade-off, higher key size > higher security > higher cost
  
  * 6. WHAT DOES A "128-BIT KEY" MEAN?
  -------------------------------------------------------------------------
  - It represents the length of the secret cryptographic key (128 zeros/ones).
  - It consists of 16 characters, 128-bit / 8 (8-bit: a byte representing a char) = 16 char key
  - This gives you 2^128 possible key combinations.
  - To put this into perspective: A brute-force attack trying to guess this 
  key would take modern supercomputers billions of years—longer than the 
  age of the universe—making it cryptographically unbreakable today.
  
  
  * 7. WHEN NOT TO USE IT & COMMON OVER-ENGINEERING MISTAKES
  -------------------------------------------------------------------------
  - The Key Distribution Dilemma: Do not use symmetric encryption if you 
  don't have a secure way to share the key first. If you send the symmetric 
  key over an unencrypted email, your security is entirely broken. 

  * - Choosing AES-256 Blindly: A common mistake is always forcing AES-256 
  because "bigger is better." AES-256 requires more mathematical rounds 
  internally, which drains more CPU cycles and slows down throughput. 
  Unless you are protecting top-secret government data or complying with 
  strict military standards, AES-128 offers absolute security with 
  significantly better performance.
  
  
  * -------------------------------------------------------------------------
  *NOTE:
  To solve the Key Distribution Dilemma mentioned in Section 7, we rely on 
  "Asymmetric Encryption" (using a Public/Private key pair). 
  How Asymmetric encryption works, and how it collaborates with Symmetric 
  encryption in production, will be explained in next lessons.
  =========================================================================
 */