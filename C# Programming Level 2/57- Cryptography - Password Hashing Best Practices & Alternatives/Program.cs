// =====================================================================================
// ARCHITECTURAL DOCUMENTATION: PASSWORDS VS. GENERAL-PURPOSE HASHING
// =====================================================================================
//
// 1. THE PROBLEM: WHY GENERAL-PURPOSE HASHING (SHA-256) FAILS FOR PASSWORDS
//    - SHA-256 (Secure Hash Algorithm) is fundamentally a FAST cryptographic primitive. 
//      It was engineered to hash massive chunks of data (Files, Checksums) instantly.

//    - If used for passwords, this speed becomes a catastrophic vulnerability. A modern 
//      GPU setup can calculate billions of SHA-256 hashes per second.

//    - Adding a manual Salt solves Rainbow Tables (pre-computed dictionary attacks), but 
//      it DOES NOT mitigate GPU-driven brute-force attacks. If the database leaks, 
//      weak/medium user passwords will be cracked in seconds.
//


// 2. THE SOLUTION: DEDICATED PASSWORD HASHING ALGORITHMS
//    - Dedicated password hashers (BCrypt, Argon2id, PBKDF2) solve the speed issue via 
//      "Key Stretching" using an adjustable "Cost / Work Factor".

//    - They deliberately slow down execution (~100ms - 300ms per attempt). While 
//      imperceptible to a single logging-in human user, it paralyzes hacking rigs 
//      by reducing their cracking attempts from billions to just thousands per second.

//    - Self-Contained: They eliminate human error by generating unique Salts 
//      and embedding them directly inside the final output string.
//



// 3. UNDER THE HOOD: DO THE ALTERNATIVES USE SHA-256?
//    - No. They are entirely different mathematical structures built from scratch:
//
//    * SHA-256: 
//      Bitwise operations executed exactly once. Designed for pure speed.
//
//    * BCrypt: 
//      Based on the Blowfish symmetric cipher. Uses an 'Eksblowfish' setup phase 
//      that forces the CPU through thousands of iterative loops ($2^{Cost}$).
//
//    * PBKDF2: 
//      Can use SHA-256 as its internal core engine (HMAC-SHA256), but forces it 
//      to cycle consecutively over hundreds of thousands of loops (iterations).
//
//    * Argon2id: 
//      The modern global standard. A "Memory-Hard" algorithm designed to aggressively 
//      fill up RAM cache, successfully neutralizing parallel hardware acceleration (GPUs).
//



// 4. WHERE TO FIND THEM IN .NET (.NET 6 / 8 / 9)
//    - Option A (Native API): 'Microsoft.AspNetCore.Identity.PasswordHasher<TUser>'
//      Best if you are embedded inside the standard ASP.NET Core Identity ecosystem. 
//      Zero extra dependencies; uses PBKDF2/Argon2id under the hood.
//
//    - Option B (External Library): NuGet Package 'BCrypt.Net-Next'
//      Best for decoupled backend architectures (Clean Architecture / Domain-Driven Design) 
//      where you want your Core Domain to remain agnostic of ASP.NET web frameworks.
//



// 5. THE PRAGMATIC BRUTAL TRUTH (WHEN TO USE WHAT)
//    - USE BCrypt / Native Identity Hasher ONLY FOR: Human-generated account passwords.

//    - USE SHA-256 ONLY FOR: API Keys, Session Tokens, Password Reset Tokens, and File Integrity. 
//      (Because these machine-generated strings possess high entropy/randomness naturally, 
//       making brute-force impossible; fast computation here is an asset).
//
// =====================================================================================