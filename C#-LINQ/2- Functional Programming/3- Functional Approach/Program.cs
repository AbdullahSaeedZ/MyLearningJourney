namespace _3__Functional_Approach;

class Program
{ 
// now we use the Functional paradigm approach, we try to:
// eliminate external dependencies
// being declarative rather than imperative, eliminating instructions (procedural) as much as possible
// moving to purity as much as possible, not creating side effects
    
    static void Main(string[] args)
    {
        //RunProceduralOperations();
        //RunFunctionalOperations();
        RunEnhancedFunctionalOperations();
    }
    
    private static void RunProceduralOperations()
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

    
    private static void RunFunctionalOperations()
    {
        var list = Repository.LoadEmployees();

        // now this is a functional approach, where we pass inputs, and get outputs
        // passing employees collections and the needed filtering, acting as pure functional method 
        var q1 = FunctionalOperations.Filter(list, e => e.FirstName.ToLowerInvariant() == "ma");
        FunctionalOperations.Print(q1, "Employees with first name starts with 'ma'");

        var q2 = FunctionalOperations.Filter(list, e => e.LastName.ToLowerInvariant() == "ju");
        FunctionalOperations.Print(q2, "Employees with last name starts with 'ju'");

        var q3 = FunctionalOperations.Filter(list, e => e.Department.ToLowerInvariant() == "hr");
        FunctionalOperations.Print(q3, "Employees in 'HR' department");

        var q4 = FunctionalOperations.Filter(list, e => e.Gender.ToLowerInvariant() == "female");
        FunctionalOperations.Print(q4, "Female employees");

        var q5 = FunctionalOperations.Filter(list, e => e.HireDate.Year == 2018);
        FunctionalOperations.Print(q5, "Employees hired in '2018'");

        var q6 = FunctionalOperations.Filter(list, e => e.HasPensionPlan);
        FunctionalOperations.Print(q6, "Employees with Pension Plan");

        var q7 = FunctionalOperations.Filter(list, e => !e.HasHealthInsurance);
        FunctionalOperations.Print(q7, "Employees without Health insurance");

        var q8 = FunctionalOperations.Filter(list, e => e.Salary == 107000);
        FunctionalOperations.Print(q8, "Employees with Salary = $107000");

        var q9 = FunctionalOperations.Filter(list, e => e.Salary > 107000);
        FunctionalOperations.Print(q9, "Employees with Salary > $107000");

        var q10 = FunctionalOperations.Filter(list, e => e.Salary < 107000);
        FunctionalOperations.Print(q10, "Employees with Salary < $107000");

        var q11 = FunctionalOperations.Filter(list, e => e.Salary < 107000 && e.Gender == "female");
        FunctionalOperations.Print(q11, "Employees with Salary < $107000 and female");

    }
    
    private static void RunEnhancedFunctionalOperations()
    {
        var list = Repository.LoadEmployees();

        // this is enhanced by using extension methods on the functional operations we prepared
        list.Filter(e => e.FirstName.ToLowerInvariant() == "ma").Print("Employees with first name starts with 'ma'");
        list.Filter(e => e.LastName.ToLowerInvariant() == "ju").Print("Employees with last name starts with 'ju'");
        list.Filter(e => e.Department.ToLowerInvariant() == "hr").Print("Employees in 'HR' department");
        list.Filter(e => e.Gender.ToLowerInvariant() == "female").Print("Female employees");
        list.Filter(e => e.HireDate.Year == 2018).Print("Employees hired in '2018'");
        list.Filter(e => e.HasPensionPlan).Print("Employees with Pension Plan");
        list.Filter(e => !e.HasHealthInsurance).Print("Employees without Health insurance");
        list.Filter(e => e.Salary == 107000).Print("Employees with Salary = $107000");
        list.Filter(e => e.Salary > 107000).Print("Employees with Salary > $107000");
        list.Filter(e => e.Salary < 107000).Print("Employees with Salary < $107000");
        list.Filter(e => e.Salary < 107000 && e.Gender == "female").Print("Employees with Salary < $107000 and female");
    }
    
}