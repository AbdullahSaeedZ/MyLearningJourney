namespace JoinOperations.Shared;

public class EmployeeGroup
{
    public string DepartmentName { get; set; } = string.Empty;
    public IEnumerable<Employee> Employees { get; set; } = new List<Employee>();
}