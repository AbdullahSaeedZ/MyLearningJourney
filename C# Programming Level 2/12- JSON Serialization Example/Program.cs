using System.IO;
using System.Runtime.Serialization.Json; // this is the old way using this lib

// for Json Serialization to work, the class must have a parameterless constructor (either explicitly defined or provided by default) to let the serializer class create an object when deserialization,
// and all properties to be serialized must be public, or privat and marked with attribute.


// attributes we can use with this lib:
/*
 
[DataMember(Name = "full_name")]
public string Name { get; set; }   // Serialized with a custom JSON property name

[IgnoreDataMember]
public int Age { get; set; }       // Ignored during serialization

This will result in:

{
    "full_name": "Abdullah"
}

*/

// ======== modern .NET uses System.Text.Json lib, and it has different attributes ========

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}


class Program
{
    static void Main()
    {
        Person person = new Person { Name = "Abdullah", Age = 2 };

        // serialaizer object
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));

        // JSON serialization
        using (FileStream stream = new FileStream("person.json", FileMode.Create))
        {
            serializer.WriteObject(stream, person);
        }


        // deserialization
        using (FileStream stream = new FileStream("person.json", FileMode.Open))
        {
            Person deserializedPerson = (Person)serializer.ReadObject(stream);
            Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
        }


        // same data was serialized in xml file and JSON, we can check both files sizes and see that JSON is less in size
        // cuz it has less text, which makes it faster and preferable 
    }
}