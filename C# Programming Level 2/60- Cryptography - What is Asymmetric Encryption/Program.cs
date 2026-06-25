/* =========================================================================================================
  ASYMMETRIC ENCRYPTION
  ========================================================================================================= 

** 1. THE PROBLEM: THE KEY EXCHANGE CATCH-22
  ---------------------------------------------------------------------------------------------------------
  Before asymmetric encryption, systems relied entirely on symmetric encryption (like AES). 
  In a symmetric system, the exact same secret key is used to both encrypt and decrypt data. 
  * The fatal architectural flaw is the distribution problem: If Alice wants to send encrypted data 
  to Bob, they both need the same key. How does Alice send that key to Bob securely over an insecure 
  internet? If an eavesdropper intercepts the key during transit, the encryption becomes entirely 
  useless. You essentially needed a secure channel just to establish a secure channel.
 

/* * 2. THE CORE IDEA: THE PUBLIC AND PRIVATE KEY RELATIONSHIP
 * ---------------------------------------------------------------------------------------------------------
 * Asymmetric encryption eliminates the key distribution problem by giving a single party (Party B) 
 * two distinct, mathematically linked keys.
 
 - i have 2 keys (private and public), anyone who wants to send me an encrypted message then the process is:
 - he takes my public key (used only to encrypt) and uses it to encrypt the message, cannot use this public key
 to decrypt, so any other pary possesing this public key is useless.

 - then encrypted message is transefered through the insecure internet, and recieved by me.

 - now i got the message in place, i can decrypt it using my prvivate key that has never gone out or exposed to
 anyone.
 
 * * Because the public key can only lock data and never unlock it, the message remains completely secure 
 * during transit. Even if an attacker intercepts both the public key and the encrypted ciphertext, 
 * they cannot read the message because they lack the private key.
 


3. HOW IT WORKS INTERNALLY
  ---------------------------------------------------------------------------------------------------------
  The foundational mathematics rely on "trapdoor functions"—operations that are computationally 
  trivial to perform in one direction, but functionally impossible to reverse unless you possess 
  a specific piece of extra knowledge (the "trapdoor" or private key).
 
  * - RSA (Rivest-Shamir-Adleman): Relies on prime factorization. Multiplying two massive prime numbers 
  together to get a product takes a CPU microseconds. Reversing that process—finding the original 
  prime factors from a massive product—takes modern supercomputers thousands of years.
 
  * - ECC (Elliptic Curve Cryptography): Relies on the algebraic structure of elliptic curves over 
  finite fields. It offers the exact same cryptographic strength as RSA but uses drastically 
  smaller key sizes, resulting in faster processing speeds and lower memory consumption.
 

  4. WHEN NOT TO USE IT & COMMON OVER-ENGINEERING MISTAKES
  ---------------------------------------------------------------------------------------------------------
  Asymmetric encryption is computationally expensive. It is roughly 100 to 1,000 times slower 
  than symmetric algorithms like AES.
 
  * - The Big Mistake: Attempting to encrypt large files, large database columns, or continuous 
  network payloads directly with RSA. If you attempt to encrypt a large payload with RSA, 
  your CPU usage will spike excessively, and the operation will throw an exception because 
  RSA can only encrypt data chunks smaller than its actual key size.
 
  * - The Pragmatic Architecture (Hybrid Encryption): Production systems (like HTTPS/TLS) use a 
  hybrid approach. They leverage asymmetric encryption *only* during the initial handshake 
  to safely exchange a temporary, short-lived symmetric key. Once both parties safely possess 
  that shared symmetric key, they switch entirely to AES for high-speed payload encryption.
 

 

 =========================================================================================================
 ARCHITECTURAL SUMMARY: ENCRYPTION VS. DIGITAL SIGNATURES
 ========================================================================================================= 

 * 1. THE IMPERSONATION FLAWS WITH ENCRYPTION ALONE
 ---------------------------------------------------------------------------------------------------------
 Standard asymmetric encryption ONLY guarantees privacy; it does NOT prove the sender's identity.
 * The Vulnerability:
 Since Bob's Public Key is exposed to the entire world, anyone (including an attacker) can encrypt 
 a malicious message using Bob's Public Key, send it to Bob, and falsely claim to be Alice. 
 Bob can decrypt it with his private key, but he has no mathematical way to verify who actually sent it.


 * 2. THE REMEDY: DIGITAL SIGNATURES (HOW TO PROVE IDENTITY)
 ---------------------------------------------------------------------------------------------------------
 Scenario: You want to send a document to a company, and you want to prove to them that it actually 
 came from you, and that no one altered it on the way.
 
 * * THE WORKFLOW:
 - You Sign It: You take the document and use your Private Key (Key B) to lock a small stamp onto 
 the document. Because only you have Key B, only you could have attached this specific lock.

 * - They Verify It: The company receives the document. They take your freely available Public Key (Key A) 
 and try to use it on the stamp.

 * - The Proof: Because Key A is mathematically linked to your Key B, it will successfully open that stamp.


 * 3. WHAT THE DIGITAL SIGNATURE PROVES INSTANTLY
 ---------------------------------------------------------------------------------------------------------
 - Identity: It came from you, because only your private key could create a lock (digital signature) that your public 
 key can open.

 * - Integrity: The document wasn't changed. If a hacker changed even one letter in the document 
 during transit, the lock would break and the public key wouldn't open it.


 * 4. WHY THIS IS IMPOSSIBLE WITH A 1-KEY (SYMMETRIC) SYSTEM
 ---------------------------------------------------------------------------------------------------------
 If you and the company shared the exact same standard padlock key (Symmetric):
 1. You send them a locked document.
 2. They open it.

 * But wait—since they also have a copy of that exact same key, they could have easily locked a fake 
 document themselves and claimed it came from you. 

 * Conclusion: With one shared key, you can never prove WHO actually locked the box. You absolutely 
 need the two different keys of Asymmetric cryptography to prove identity.


 see this vid:
 https://www.youtube.com/watch?v=WlKj-UnX-s4

 ========================================================================================================= */