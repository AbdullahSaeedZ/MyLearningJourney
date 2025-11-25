-- to back up a database, full back up (every thing in the data base), we can right click on the Database->Tasks-> back up -> add back up path (where to save)
-- better to save the back up file with .bak extension, it will work if didnt type it.
-- better to save it on another drive or another device or place, in case current drive gets damaged, we will have the other drive.


-- by script:

use DB1;

backup database DB1
to disk = 'D:\DB1.bak';

-- if authenticated user (the one we logged in in SQL server) has no adminstration access then it wont allow to save on C drive, we have to get admin access.
-- we get access from going to the c drive folder -> right click any where -> security -> check full control for authenticated users.
