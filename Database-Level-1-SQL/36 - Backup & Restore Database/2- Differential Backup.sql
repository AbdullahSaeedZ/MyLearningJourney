-- this is Differential Backup, which means we already have a full back up file, but now we have extra data we want to back up
-- so instead of making another full back up file, we do Differential Backup, which will take the different or new data and save it on the file.
-- this will save time and make backing up much faster.

-- by mouse: Database -> right click -> tasks -> back up -> back up type -> choose differential.

-- script:
use DB1;

backup database DB1
to disk = 'D:\DB1.bak'
with Differential;
