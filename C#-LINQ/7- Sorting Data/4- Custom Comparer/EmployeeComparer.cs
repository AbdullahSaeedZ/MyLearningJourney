using System;
using System.Collections.Generic;
using DataSorting.Shared;

namespace _4__Custom_Comparer
{
    // Custom comparer that encapsulates domain-specific sorting rules for Employee instances.
    // Implements IComparer<Employee> so LINQ's OrderBy can delegate pairwise element comparisons to it.
    
    public class EmployeeComparer : IComparer<Employee>
    {
        // Compares two Employee objects based on the structured segments of their EmployeeNo.
        // Expected EmployeeNo format: "YYYY-DEPT-SEQ" (e.g., "2017-FI-1343").
        
        // using the comapareTo method to compare two ints and returns an int representing:
        // A signed integer indicating relative order:
        // Less than 0    : e1 precedes e2 (e1 is smaller).
        // Zero (0)       : e1 equals e2 (relative order preserved).
        // Greater than 0 : e2 precedes e1 (e1 is greater).
        
        // implementing the interface by declaring the Compare method with needed logic:
        public int Compare(Employee e1, Employee e2)
        {
            // "2017-FI-1343" => "2017", "FI", "1343"   <- we want to ignore the department and rely on year and sequence in sorting
            var e1Year = Convert.ToInt32(e1.EmployeeNo.Split('-')[0]);
            var e2Year = Convert.ToInt32(e2.EmployeeNo.Split('-')[0]);
            var e1Seq = Convert.ToInt32(e1.EmployeeNo.Split('-')[2]);
            var e2Seq = Convert.ToInt32(e2.EmployeeNo.Split('-')[2]);

            
            // Primary Sort: Compare Years
            // If the hiring years are identical (a tie), proceed to secondary tie-breaking.
            if (e1Year == e2Year)
            {
                // Secondary Sort: Break the tie using the sequence ID (e1Seq vs e2Seq).
                // Returns -1 if e1Seq < e2Seq, 0 if equal, +1 if e1Seq > e2Seq.
                return e1Seq.CompareTo(e2Seq);
            }
            else
            {
                // Resolve ordering strictly by year (earlier year comes first in ascending sort).
                return e1Year.CompareTo(e2Year);
            }
        }
    }
}