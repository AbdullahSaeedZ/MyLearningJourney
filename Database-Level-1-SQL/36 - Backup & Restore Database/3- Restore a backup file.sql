-- restore a back up file.
-- by mouse: database -> right click -> tasks -> restore -> database -> choose the file.


--script:

-- do it on master
use master;
restore database DB1
from disk = 'D:\DB1.bak';