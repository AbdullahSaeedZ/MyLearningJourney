-- insert into + select from
-- insert records from table1 into table2 

use DB1;

insert into Persons
values
(1, 'abdullah', 10),
(2, 'nawaf', 25),
(3, 'nora', 30)
;

select * from Persons;
select * from NewPersons;
delete from NewPersons;

-- insert all Persons recodrds into NewPersons table 
insert into NewPersons
select * from Persons;


-- copy records with conditions
insert into NewPersons
select * from Persons
where Age > 10;