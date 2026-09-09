/*
====================================================================
 LESSON: STRING DATA TYPES IN T-SQL (CHAR, VARCHAR, NCHAR, NVARCHAR)
====================================================================

1. THE BIG PICTURE
------------------
SQL Server classifies string data types across two fundamental decisions:

                 | Fixed-Length (Padded) | Variable-Length (Dynamic)
  ---------------+-----------------------+--------------------------
  Standard/ASCII | CHAR(n)               | VARCHAR(n)
  Unicode        | NCHAR(n)              | NVARCHAR(n)

* Fixed-length:   Always uses the exact defined memory, padding empty space.
* Variable-length: Uses only the memory needed for the actual characters.
* Standard:       Optimized for English/ASCII (1 byte per character typically).
* Unicode ('N'):  Supports all global alphabets (including Arabic) via UTF-16.


-------------------
* Padding:
  It adds filler blanks to reach the full size.
  Example: Storing 'SA' in CHAR(5) results in 'SA   '.

* Offset Pointer (2 Bytes):
  A tiny 2-byte marker SQL Server attaches to every variable-length value. 
  Because lengths change row-by-row, this pointer marks the exact byte 
  where your text ends so the engine knows where the next column begins.



2. THE FOUR TYPES EXPLAINED
---------------------------
* CHAR(n)
  - Fixed-length, non-Unicode string.
  - Takes exactly `n` bytes on disk, even if your string is shorter.
  - Pads unused space with trailing blank spaces.
  - Ideal for: Values guaranteed to have an exact, predictable length 
    (e.g., country codes 'SA', 'US', currency codes 'SAR', 'USD').

* VARCHAR(n)
  - Variable-length, non-Unicode string.
  - Takes only the actual bytes of the text plus a 2-byte row offset pointer.
  - Ideal for: Variable-length text containing only Latin/English characters 
    (e.g., email addresses, URLs, system logs, UUID/GUID strings).

* NCHAR(n)
  - Fixed-length, Unicode string (UTF-16).
  - Takes `2 * n` bytes on disk, padding empty space with blanks.
  - Ideal for: Fixed-length values containing non-Latin characters.

* NVARCHAR(n)
  - Variable-length, Unicode string (UTF-16).
  - Takes `(2 * actual characters) + 2 bytes` of row offset overhead.
  - Ideal for: Multilingual text, Arabic names, user-submitted content, 
    and notes where text length varies and character sets differ.


3. THE CRITICAL MISCONCEPTION: WHAT DOES (n) ACTUALLY MEAN?
-----------------------------------------------------------
* Think of (n) as a WEIGHT LIMIT (in bytes), NOT an ITEM COUNT (characters)!

* The Common Trap:
  Many assume VARCHAR(10) means "store up to 10 letters."
  In reality, VARCHAR(10) means "you have a bucket of 10 BYTES of space."

* Why developers get confused:
  - In standard English/ASCII, every letter takes exactly 1 byte.
  - 10 English letters = 10 bytes, so it fits cleanly into VARCHAR(10).
  - This leads people to falsely believe (n) counts characters.

* How it breaks:
  - Letters from non-Latin alphabets or multi-byte encodings require 
    2 to 4 bytes per character.
  - If a character takes 2 bytes, a VARCHAR(10) bucket can only hold 
    5 characters before it runs out of space and truncates your data!

* The Core Rule:
  - (n) defines the maximum BYTES allocated for that column or variable.
  - The actual number of characters that fit inside depends entirely on 
    how many bytes each individual character consumes.


4. WHY NOT USE NVARCHAR EVERYWHERE? (THE PERFORMANCE COST)
----------------------------------------------------------
While NVARCHAR prevents character corruption, it should not be applied 
blindly to every column in high-scale systems:

* Doubles Disk and Network Usage:
  Storing 50 million UUIDs in NVARCHAR costs ~5 GB instead of ~2.5 GB.
* Reduces RAM Cache (Buffer Pool) Efficiency:
  SQL Server reads data in 8 KB pages. VARCHAR fits roughly twice as many 
  rows per 8 KB page, allowing SQL Server to keep more index pages in RAM 
  and perform faster index scans.
* Rule of Thumb:
  - Use NVARCHAR for user-facing text, localized data, and Arabic content.
  - Use VARCHAR/CHAR for system data, codes, tokens, and technical identifiers.


5. THE UNICODE LITERAL PREFIX (N'...')
--------------------------------------
Whenever assigning Unicode or Arabic text to an NVARCHAR variable or column, 
you must prefix the string literal with a capital `N`:
  - Correct:   SET @Name = N'محمد';
  - Incorrect: SET @Name = 'محمد';  -- Converts to VARCHAR first; causes '????'
====================================================================
*/

-- =================================================================
-- PRACTICAL DEMO: Fixed vs Variable & ASCII vs Unicode
-- =================================================================

-- 1. Space Padding: CHAR vs VARCHAR
DECLARE @FixedCode CHAR(5) = 'SA';         -- Holds 'SA   ' (pads with 3 spaces)
DECLARE @VariableCode VARCHAR(5) = 'SA';   -- Holds 'SA' (no padding, 2 bytes + pointer)

PRINT 'Fixed length padding:   [' + @FixedCode + ']';
PRINT 'Variable-length output:  [' + @VariableCode + ']';

-- 2. Character Loss vs Unicode Preservation
DECLARE @CorruptedText VARCHAR(20) = 'مرحبا';  -- Missing Unicode support
DECLARE @SafeText NVARCHAR(20) = N'مرحبا';     -- Preserved via NVARCHAR + N prefix

PRINT 'VARCHAR Output (Data Loss): ' + @CorruptedText;
PRINT 'NVARCHAR Output (Preserved): ' + @SafeText;

-- 3. Measuring Actual Storage (Bytes vs Characters)
-- LEN() measures the number of characters
-- DATALENGTH() measures the actual bytes consumed in memory
PRINT 'Characters in SafeText: ' + CAST(LEN(@SafeText) AS VARCHAR);
PRINT 'Bytes used by SafeText: ' + CAST(DATALENGTH(@SafeText) AS VARCHAR);