using System.IO;
using System.Xml.Serialization; // we use this lib

namespace _11__XML_Serialization_Example
{

    // for XML Serialization to work, the class must have a parameterless constructor (either explicitly defined or provided by default) so that the serializer class can create an object when deserialization,
    // and all data members to be serialized must be public.
    // XmlSerializer serializes only public members by default.
    // Private fields and private properties are ignored.

    // the class or its members can be annotated with attributes (explained in Attributes lessons) to control the serialization process, like:
    /*
     [XmlAttribute]
     public int ID{ get; set; } : Serialized as an XML attribute

     [XmlElement("FullName")]
     public string Name { get; set; } : Serialized as an XML element

     [XmlIgnore]
     public int Age { get; set; } : This property is ignored (not serialized)

     This will result in: 
     <Person ID="1">
       <FullName>Hanae</FullName>
        </Person>
     */

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            // to be serialized into xml file
            Person person1 = new Person() { Name = "Abdullah", Age = 1 };

            // this serializer object will be used to serialize and deserialize 
            XmlSerializer serializer = new XmlSerializer(typeof(Person));

            // serialization
            using (TextWriter writer = new StreamWriter("Person.xml")) // using statement to dispose resources of StreamWriter
            {
                serializer.Serialize(writer, person1);
            }


            // deserialization
            using (TextReader reader = new StreamReader("Person.xml"))
            {
                Person deserializedPerson = (Person)serializer.Deserialize(reader);
                Console.WriteLine($"Name: {deserializedPerson.Name}, Age: {deserializedPerson.Age}");
            }

        }
    }
}
