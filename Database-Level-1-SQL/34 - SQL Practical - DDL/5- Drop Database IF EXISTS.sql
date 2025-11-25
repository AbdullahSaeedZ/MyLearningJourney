-- Drop Database IF EXISTS

if exists (select * from sys.databases where name = 'db2')
begin
	drop database db2;
end
else
begin
	print('cant find database');
end