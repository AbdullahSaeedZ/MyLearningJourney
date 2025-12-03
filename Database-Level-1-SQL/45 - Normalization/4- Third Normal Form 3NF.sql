-- Third Normal Form 3NF

--Third Normal Form (3NF) is a higher level of database normalization that builds on the rules of First Normal Form (1NF) and Second Normal Form (2NF).
--It requires that each nonkey column in a table be dependent only on the primary key, and not on any other non-key columns.

--To satisfy the requirements of 3NF:
--1. Table must first be in 1NF and 2NF, and then have:
--2. No transitive dependencies: Each non-key column in the table must be dependent only on the primary key, and not on any other non-key columns.

-- see pdf