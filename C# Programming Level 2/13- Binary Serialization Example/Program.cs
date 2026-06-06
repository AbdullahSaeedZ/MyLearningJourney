using System.Runtime.Serialization.Formatters.Binary; // old lib


public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}


class Program
{
    static void Main()
    {
        Person person = new Person { Name = "Abdullah", Age = 3 };
        /*
        ========== this is an old way, using an old library that is obsolete and shouldnt be used due to security issues:
        - Binary serialization
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream("person.bin", FileMode.Create))
        {
            formatter.Serialize(stream, person);
        }


        - Deserialize the object back
        using (FileStream stream = new FileStream("person.bin", FileMode.Open))
        {
            Person deserializedPerson = (Person)formatter.Deserialize(stream);
            Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
        }
        */

        // --- Serialize manually ---
        using (BinaryWriter writer = new BinaryWriter(File.Open("person.bin",FileMode.Create)))
        {
            writer.Write(person.Name);
            writer.Write(person.Age);
        }


            
        // --- Deserialize manually ---
        using (BinaryReader reader = new BinaryReader(File.Open("person.bin", FileMode.Open)))
        {
            string name = reader.ReadString();
            int age = reader.ReadInt32();
            Person deserializedPerson = new Person { Name = name, Age = age };

            Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
        }

    }
}
