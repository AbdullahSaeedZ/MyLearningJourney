-- Second Normal Form (2NF)
-- used to fix issues of composite PK, which is not a best practice to have!!

-- 2NF builds on 1NF. A table must already be in 1NF.
-- Rule: No partial dependency.
-- Meaning: Every non-key column must depend on the whole primary key (if the PK is composite),
-- not just part of it.

-- 2NF matters ONLY when the primary key consists of multiple columns.
-- If the table has a single-column primary key, it's automatically in 2NF.


--  see pdf