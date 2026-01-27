-- Problem 30: Get all Vehicle_Display_Name, NumDoors and add extra column to describe number of doors by words, and if door is null display 'Not Set'

select distinct NumDoors from VehicleDetails;

select Vehicle_Display_Name, NumDoors, DoorDescription =
case
	when NumDoors is null then 'Not Set'
	when NumDoors = 0 then 'zero Doors'   -- maybe a bike
	when NumDoors = 1 then 'One Door'
	when NumDoors = 2 then 'Two Doors'
	when NumDoors = 3 then 'three Doors'
	when NumDoors = 4 then 'Four Doors'
	when NumDoors = 5 then 'Five Doors'
	when NumDoors = 6 then 'Six  Doors'
	when NumDoors = 7 then 'Seven Doors'
	when NumDoors = 8 then 'Eight Doors'
	else 'Unknown'
end
from VehicleDetails;