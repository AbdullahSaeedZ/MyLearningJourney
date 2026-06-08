namespace _15__Attributes___Serialization_Attributes
{
    /*
     These attributes help customize the serialization and deserialization process to meet specific requirements, 
     such as excluding certain fields, renaming elements, or controlling the order of serialization.
     Depending on the serialization framework or library used (e.g., XML serialization, JSON serialization, binary serialization), different attributes might be employed.

     there are more advance attributes for serialization

     
     
     
     
     Binary/Soap formatters → need [Serializable]
     XML & JSON serializers → don’t need it
     */


    [Serializable] // everything inside the class will be serialized except the ones tagged with non or ignore attributes
    internal class Program
    {



        // Will be serialized
        public int SerializedField;


        // Will not be serialized
        [NonSerialized]
        public int NonSerializedField;

        // [NonSerialized] Attribute works only with fields not properties
        // Instead you can use [XmlIgnore] or [JsonIgnore] that works with properties & fields

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
