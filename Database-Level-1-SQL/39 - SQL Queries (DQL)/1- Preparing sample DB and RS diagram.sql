-- restore the sample database 
use master;

restore database HR_Database
from disk = 'D:\HR_Database.bak';


-- use this command to give permissions to create diagrams
use HR_Database;
EXEC sp_changedbowner 'sa';

-- now in explorer, under HR_Database, right click on the Database diagrams and choose the tables then save, this is a relational schema we can see anytime
