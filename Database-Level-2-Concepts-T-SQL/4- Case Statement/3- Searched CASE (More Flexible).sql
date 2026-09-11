/*


Searched CASE (Boolean predicates):
     CASE
         WHEN condition1 THEN res1
         WHEN condition2 THEN res2
         ELSE default_result
     END


*/


-- evaluating a set of boolean expressions

select SaleID, SaleAmount,
    case 
        when SaleAmount <= 100 then 'Weak'
        when SaleAmount between 101 and 200 then 'Good'
        when SaleAmount between 201 and 300 then 'Very Good'
        when SaleAmount > 300 then 'Excellent'
        else 'Not Specified'
    end as SaleLevel
from Sales;