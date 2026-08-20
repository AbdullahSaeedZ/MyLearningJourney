using Serializer.Attributes;
using System.Reflection.Emit;

namespace Serializer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --------------- serialization ----------------
            Employee employee = new Employee("Abdullah Alzahrani", 20_000.43f, null);
            //Serializer.Serialize(employee, "employee.json");


            Employee employee1 = new Employee("Ali", 40_000.50f, "Manager");
            Employee employee2 = new Employee("Mohammed", 14_500.75f, "Developer");
            Employee employee3 = new Employee("Fahad", 10_030.25f, "Designer");
            Employee employee4 = null;

            Employee[] employeeArray = { employee1, employee2, employee3, employee4 };
            //Serializer.Serialize(employeeArray, "employee.json");


            // --------------- deserialization ----------------

            //Employee? employee5 = Serializer.Deserialize<Employee>("employee.json");
            //Console.WriteLine(employee5);

            List<Employee> employeeArray2 = Serializer.DeserializeList<Employee>("employee.json");
            foreach (var emp in employeeArray2)
            {
                Console.WriteLine(emp + "\n\n---------------------\n\n");

            }
        }

    }

    //[JsonInclude]
    //[JsonIgnore]
    public class Employee
    {
        // default: private fields and properties are not serialized, public fields and properties are serialized

        public Address EmployeeAddress { get; set; }

        private string CarType = "Elantra";
        public string StreetName = "st 64";


        public string Name { get; set; }

        [JsonPropertyName("Money")]
        public float Salary { get; set; }

        public string Position { get; set; }

        public bool IsManager { get; set; }

        private bool IsActive { get; set; }

        public Employee(string name, float salary, string position)
        {
            Name = name;
            Salary = salary;
            Position = position;
            EmployeeAddress = new Address("Riyadh", "st 64", 12345);
        }


        public void Promote(string newPosition)
        {

        }

        //public override string ToString()
        //{
        //    return $"Name: {Name}\nSalary: {Salary}\nPosition: {Position}\nIsActive: {IsActive}\nIsManager: {IsManager}\nStreetName: {StreetName}\nCarType: {CarType}\n";
        //}

        public override string ToString()
        {
            return $"Name: {Name}\nSalary: {Salary}\nPosition: {Position}\nIsActive: {IsActive}\nIsManager: {IsManager}\nStreetName: {StreetName}\nCarType: {CarType}\n" +
                $"\nEmployee Address:{EmployeeAddress}" +
                $"\n\nCity:\n{EmployeeAddress.CityInfo}";
        }
    }

    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }

        public City CityInfo { get; set; }
        public Address(string city, string street, int zipCode)
        {
            City = city;
            Street = street;
            ZipCode = zipCode;
            CityInfo = new City();
        }

        public override string ToString()
        {
            return $"\nCity: {City}\nStreet: {Street}\nZipCode: {ZipCode}";
        }
    }


    public class City
    {
        public string Name { get; set; }

        public City()
        {
            Name = "Riyadh";
        }
        public override string ToString()
        {
            return $"Name: {Name}";
        }
    }


}