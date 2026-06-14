using System.Reflection;

namespace project
{
    // an very simple example of using custom attributes to provide extra info or metadata on properties with reflection for validation purposes
    // we can do validation by using setters or a didecated method without reflection and attributes, but just to explain another usage of the concept

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RangeAttribute : Attribute
    {
        public int Max { get; set; }
        public int Min { get; set; }
        public string ErrorMessage { get; set; }

        public RangeAttribute(int max, int min, string errorMessage)
        {
            Max = max;
            Min = min;
            ErrorMessage = errorMessage;
        }
    }

    public class Person
    {
        // tagged the needed properties with the range attribute
        // this means that we just gave extra info (metadata) then we deal with it any where

        public string Name { get; set; }

        [Range(18, 40, "Age is out of range, must be between 18 and 40")]
        public int Age { get; set; }

        [Range(10, 20, "Experience is out of range, must be between 10 and 20")]
        public int Experience { get; set; }

        [Range(1, 2, "CarsCount is out of range, must be between 1 and 2")]
        public int CarsCount { get; set; }

        public Person(string name, int age, int experience, int carsCount)
        {
            Name = name;
            Age = age;
            Experience = experience;
            CarsCount = carsCount;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Abdullah", 60, 40, 1);

            if (!IsPersonValide(person1))
                Console.WriteLine($"\nFinal Result: {person1.Name} is not valid due to above reasons");
            else
                Console.WriteLine($"\nFinal Result: {person1.Name} is valid");


        }

        public static bool IsPersonValide(Person person)
        {
            bool isValid = true;

            foreach (PropertyInfo prop in typeof(Person).GetProperties())
            {
                if (prop.IsDefined(typeof(RangeAttribute))) // is person property tagged with a range attribute?
                {
                    int personAttributeValue = (int)prop.GetValue(person)!;// get that tagged person property value
                    RangeAttribute rangeAttribute = (RangeAttribute)Attribute.GetCustomAttribute(prop, typeof(RangeAttribute))!; // get the related attribute

                    if (personAttributeValue < rangeAttribute.Min || personAttributeValue > rangeAttribute.Max)
                    {
                        isValid = false;
                        Console.WriteLine(rangeAttribute.ErrorMessage);
                    }    
                }
            }
            return isValid;
        }
    }
}
