restore database ContactsDB
from disk = 'D:\\ContactsDB.bak';

ALTER AUTHORIZATION ON DATABASE::ContactsDB TO sa;


select * from Contacts;
