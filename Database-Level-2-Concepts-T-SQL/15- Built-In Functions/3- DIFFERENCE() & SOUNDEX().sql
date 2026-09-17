/*
====================================================================
DEEP DIVE: DIFFERENCE() & SOUNDEX()
====================================================================

1. THE PROBLEM (Why it exists)
--------------------------------------------------------------------
Human names and search inputs frequently contain typos, dialect phonetic 
differences, or transliteration variances (e.g., 'Stephen' vs 'Steven', 
or 'Smyth' vs 'Smith'). 

Standard SQL equality (`=`) and pattern matches (`LIKE '%...%'`) check 
strict character bytes. If a user misspells a name by one consonant, 
the query returns 0 rows.


2. CORE IDEA
--------------------------------------------------------------------
The DIFFERENCE() function measures how similar two strings sound when spoken, 
using an algorithm called SOUNDEX.

It outputs an integer from 0 to 4:
* 4 = Highest phonetic similarity (sounds virtually identical).
* 3 = Strong similarity.
* 0 - 2 = Weak or no phonetic resemblance.


3. HOW IT WORKS INTERNALLY
--------------------------------------------------------------------
1. Evaluates String A using an algorithm called SOUNDEX.
2. Evaluates String B using the same algorithm.
3. Compares the resulting phonetic representations.
4. Returns a score from 0 to 4 based on how closely the two sounds match.


4. COMPLETE T-SQL DEMONSTRATION
--------------------------------------------------------------------
*/

-- Setup simulated user table
DROP TABLE IF EXISTS #Customers;
CREATE TABLE #Customers (
    CustomerID INT IDENTITY(1,1),
    FullName   VARCHAR(50)
);

INSERT INTO #Customers (FullName)
VALUES 
    ('Stephen Miller'),
    ('Steven Millar'),
    ('Jonathon Davis'),
    ('Robert Johnson');

-- Real-World Search Simulation:
-- Caller typed 'Steven Miller' into an application search input.
DECLARE @SearchInput VARCHAR(50) = 'Steven Miller';

SELECT 
    CustomerID,
    FullName,
    DIFFERENCE(FullName, @SearchInput) AS MatchScore
FROM #Customers
WHERE DIFFERENCE(FullName, @SearchInput) >= 3
ORDER BY MatchScore DESC;

/*
Query Output:
CustomerID | FullName         | MatchScore
-----------+------------------+-----------
1          | Stephen Miller   | 4
2          | Steven Millar    | 4

(Note: Both variations match despite 'ph' vs 'v' and 'ar' vs 'er')
*/

DROP TABLE #Customers;


/*
5. PRODUCTION CAVEAT (Performance)
--------------------------------------------------------------------
`DIFFERENCE(Column, @Input)` is NOT SARGable. Applying it inside a WHERE 
clause forces SQL Server to perform a full table scan and compute the 
function for millions of rows.

Production Fix: 
Compute and store `SOUNDEX(FullName)` into a dedicated, indexed column. 
Then filter on the indexed column instead of evaluating on the fly.


6. REAL-WORLD END GOAL (Application Use Case)
--------------------------------------------------------------------
Backend APIs query this score to populate real-time UI components:
* Autocomplete & Suggestion Dropdowns: When a user types a name in a search 
  box, return records scoring 4 (or >= 3) as "Did you mean...?" suggestions.
* Call Center Screens: Agents typing phonetically what a caller says over 
  the phone can locate records without needing exact spelling.
* Duplicate Detection: Flagging potential duplicate customer accounts 
  during registration when MatchScore = 4.
*/