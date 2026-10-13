namespace _2__Procedural_Approach;

class Program
{
    // the issue here is that for each purpose we have a dedicated method,
    // lots of methods for filtering then returning the needed employee collection
    
    static void Main(string[] args)
    {
        RunProceduralApproach();
    }
    
    private static void RunProceduralApproach()
    {
        var q1 = ProceduralOperations.GetEmployeesWithFirstNameStartsWith("ma");
        ProceduralOperations.Print(q1, "Employees with first name starts with 'ma'");

        var q2 = ProceduralOperations.GetEmployeesWithLastNameStartsWith("ju");
        ProceduralOperations.Print(q2, "Employees with last name starts with 'ju'");

        var q3 = ProceduralOperations.GetEmployeesWithDepartmentEqualsTo("hr");
        ProceduralOperations.Print(q3, "Employees in 'HR' department");

        var q4 = ProceduralOperations.GetEmployeesByGender("female");
        ProceduralOperations.Print(q4, "Female employees");

        var q5 = ProceduralOperations.GetEmployeesHiredInYear(2018);
        ProceduralOperations.Print(q5, "Employees hired in '2018'");

        var q6 = ProceduralOperations.GetEmployeesWithPensionPlanValueEqualsTo(true);
        ProceduralOperations.Print(q6, "Employees with Pension Plan");

        var q7 = ProceduralOperations.GetEmployeesWithHealthInsuranceValueEqualsTo(false);
        ProceduralOperations.Print(q7, "Employees without Health insurance");

        var q8 = ProceduralOperations.GetEmployeesWithSalaryEqualsTo(103200);
        ProceduralOperations.Print(q8, "Employees with Salary = $103200");

        var q9 = ProceduralOperations.GetEmployeesWithSalaryGreaterThan(107000);
        ProceduralOperations.Print(q9, "Employees with Salary > $107000");

        var q10 = ProceduralOperations.GetEmployeesWithSalaryLessThan(107000);
        ProceduralOperations.Print(q10, "Employees with Salary < $107000");

    }

    
}