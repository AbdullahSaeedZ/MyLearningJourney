namespace JoinOperations.Shared;

public class EmployeeDepartmentDto
{
    public string FullName { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{FullName} [{DepartmentName}]";
    }
}