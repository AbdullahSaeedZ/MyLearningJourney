using Serializer.Attributes;

namespace Serializer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Abdullah Alzahrani", 20_000, null);
            Serializer.SerializeObject(employee, "employee.json");
        }


        [JsonInclude]
        [JsonIgnore]
        public class Employee
        {
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
            }


            public void Promote(string newPosition)
            {
                
            }
        }
    }
}
