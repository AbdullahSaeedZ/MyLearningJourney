using Serializer.Attributes;

namespace Serializer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Abdullah Alzahrani", 20_000, null);
            Serializer.Serialize(employee, "employee.json");




            Employee employee1 = new Employee("Ali", 40_000, "Manager");
            Employee employee2 = new Employee("Mohammed", 14_500, "Developer");
            Employee employee3 = new Employee("Fahad", 10_030, "Designer");
            Employee employee4 = new Employee("Yasser", 18_334, "Tester");

            Employee[] employeeArray = { employee1, employee2, employee3, employee4 };
            //Serializer.Serialize(employeeArray, "employee.json");
        }


        [JsonInclude]
        [JsonIgnore]
        public class Employee
        {
            // default: private fields and properties are not serialized, public fields and properties are serialized

            public Address EmployeeAddress { get; set; }

            private string CarType = "Elantra";
            public string StreetName = "st 64";


            public string Name { get; set; }

            [JsonPropertyName("Money")]
            public int Salary { get; set; }

            public string Position { get; set; }

            public bool IsManager { get; set; }


            private bool IsActive { get; set; }

            public Employee(string name, int salary, string position)
            {
                Name = name;
                Salary = salary;
                Position = position;
                EmployeeAddress = new Address("Riyadh", "st 64", 12345);
            }


            public void Promote(string newPosition)
            {
                
            }
        }

        public class Address
        {
            public string City { get; set; }
            public string Street { get; set; }
            public int ZipCode { get; set; }
            public Address(string city, string street, int zipCode)
            {
                City = city;
                Street = street;
                ZipCode = zipCode;
            }
        }
    }
}
