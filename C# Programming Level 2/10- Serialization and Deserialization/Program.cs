/*
 
 SERIALIZATION
 ------------------------------------------------------------
 Serialization is the process of converting an object and its
 current state (data stored inside it) into a format that can
 be stored or transmitted.
 
 Think of it as taking a snapshot of an object and converting
 that snapshot into text or bytes that can be saved or sent.
 
 Example:
 
      Person person = new Person()
      {
          Name = "Abdullah",
          Age = 25
      };
 
 After serialization to JSON:
 
      {
          "Name":"Abdullah",
          "Age":25
      }
 
 The object itself no longer exists in this format; only its
 data representation exists.
 
 ------------------------------------------------------------
 DESERIALIZATION
 ------------------------------------------------------------
 Deserialization is the opposite process.
 
 It takes the serialized data (JSON, XML, Binary, etc.) and
 reconstructs a new object with the same state and values.
 
 Example:
 
      JSON Data
            |
            V
      Deserialization
            |
            V
      Person Object
 
 The reconstructed object contains the same data that was
 originally serialized.
 
 ------------------------------------------------------------
 WHY SERIALIZATION EXISTS
 ------------------------------------------------------------
 Objects live in memory (RAM) while the application is running.
 
 When the application closes, objects are destroyed and their
 data is lost unless the data is stored somewhere.
 
 Serialization allows us to preserve object data outside memory
 so it can be used later.
 
 ------------------------------------------------------------
 COMMON USE CASES
 ------------------------------------------------------------
 
 1) Saving Data
    Store application settings, user preferences, game progress,
    configuration files, or any object data in files or databases.
 
 2) Network Communication
    Send objects between a client and a server.
 
    Example:
    Browser -> JSON -> Web API
    Web API -> JSON -> Browser
 
 3) Web APIs
    Most modern APIs serialize objects into JSON before sending
    them across the internet.
 
 4) Caching
    Store the result of expensive operations so they can be
    reused later instead of recalculating them.
 
 5) Deep Copying Objects
    Serialize an object and deserialize it again to create a
    completely separate copy with the same data.
 
 6) Distributed Systems
    Exchange data between multiple applications, services,
    servers, or microservices.
 
 7) Cross-Language Communication
    Different programming languages can understand common
    formats like JSON and XML.
 
    Example:
    C# Application <-> JSON <-> Python Application
 
 ------------------------------------------------------------
 COMMON SERIALIZATION FORMATS
 ------------------------------------------------------------
 
 JSON (JavaScript Object Notation)
 - Lightweight.
 - Human-readable.
 - Most common format today.
 - Widely used in Web APIs.
 
 XML (eXtensible Markup Language)
 - Human-readable.
 - More verbose than JSON.
 - Often used for configuration and integration systems.
 
 Binary
 - Stored as raw bytes.
 - Very compact and efficient.
 - Not human-readable.
 - Usually intended for applications running on the same platform.
 
 ------------------------------------------------------------
 SERIALIZATION FLOW
 ------------------------------------------------------------
 
      Object in Memory
              |
              V
        Serialization
              |
              V
     JSON / XML / Binary Data
              |
      Save or Transmit
              |
              V
      Deserialization
              |
              V
       New Object Created
 
 ------------------------------------------------------------
 IMPORTANT IDEA
 ------------------------------------------------------------
 Serialization does NOT save the object itself.
 
 It saves the object's DATA (state).
 
 When deserializing, a new object is created and populated
 with the saved values so it behaves as if it were the original
 object.



 * Note:
 * Serialization stores only an object's data (state), not its methods (behavior). During deserialization, a new object is created using the existing class definition, and its data members are restored from the serialized data.
*/