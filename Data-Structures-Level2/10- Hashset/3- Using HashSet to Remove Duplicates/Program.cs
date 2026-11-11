namespace _3__Using_HashSet_to_Remove_Duplicates;

class Program
{
    static void Main(string[] args)
    {
        List<string> names = new List<string>()
        {
            "Ali", "Ali", "Abdullah", "Faisal", "Nasser", "Abdullah"
        };

        Console.WriteLine("Duplicate Names:");
        names.ForEach(name => Console.Write($"{name} "));
        
        // removing duplicates using HashSet:
        HashSet<string> distinctNames = new HashSet<string>(names);
        
        Console.WriteLine("\n\nUnique Names:");
        foreach (string name in distinctNames)
        {
            Console.Write($"{name} ");
        }
        
        // ------------------------ --------------------------------------------------
        List<Person> people = new List<Person>()
        {
            new Person(){ID = 1, Name = "Abdullah"},
            new Person(){ID = 1, Name = "Ahmed"},
            new Person(){ID = 2, Name = "Khalid"},
            new Person(){ID = 3, Name = "Nasser"}
        };

        Console.WriteLine("\n\n\n\nDuplicate people Ids:");
        people.ForEach(person => Console.WriteLine($"Person ID: {person.ID}, Person Name: {person.Name}"));
        
        // since those are of Person Type, Add will check uniqueness using Equals and GetHashCode,
        // since they are not overriden, will compare by reference and will add all objects even with duplicate IDs:
        HashSet<Person> notDistinctPeople = new HashSet<Person>(people);
        
        Console.WriteLine("\nFailed To Add Distinct People using HashSet:");
        foreach (Person person in notDistinctPeople)
        {
            Console.WriteLine($"Person ID: {person.ID}, Person Name: {person.Name}");
        }
        
        // ------------------------
        // Using overriden methods will make it work as we need:
        List<Employee> emps = new List<Employee>()
        {
            new Employee(){ID = 1, Name = "Abdullah"},
            new Employee(){ID = 1, Name = "Ahmed"},
            new Employee(){ID = 2, Name = "Khalid"},
            new Employee(){ID = 3, Name = "Nasser"}
        };

        Console.WriteLine("\n\n\n\nDuplicate Employees Ids:");
        emps.ForEach(emp => Console.WriteLine($"Employee ID: {emp.ID}, Employee Name: {emp.Name}"));
        
        // since those are of Employees Type, Add will check uniqueness using Equals and GetHashCode,
        // since they are overriden, will compare IDs and remove duplicates:
        HashSet<Employee> distinctEmps = new HashSet<Employee>(emps);
        
        Console.WriteLine("\nOnly Distinct Employees using HashSet:");
        foreach (Employee emp in distinctEmps)
        {
            Console.WriteLine($"Employee ID: {emp.ID}, Employee Name: {emp.Name}");
        }
        
    }
}

public class Person
{
    public int ID { get; set; }
    public string Name { get; set; }
}

public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }

    public override bool Equals(object? obj)
    {
        return  ReferenceEquals(this, obj) || obj is Employee other && other.ID == this.ID;
    }

    public override int GetHashCode()
    {
        return this.ID.GetHashCode();
    }
}