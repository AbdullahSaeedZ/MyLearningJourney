/* ===================================================================================
 * CONCEPT: REFLECTION IN C#
 * ===================================================================================
 * * 1. Problem (why it exists)
 * -----------------------------------------------------------------------------------
 * Normally, the compiler requires complete knowledge of types, methods, and properties 
 * at compile-time to enforce type safety and optimize execution. 
 * * However, when building generic frameworks—such as Serializers (e.g., JSON/XML), 
 * Dependency Injection containers, Unit Testing frameworks, or ORMs—you face a challenge:
 * You must write code today that can process and interact with classes written by 
 * other developers in the future. Since you cannot know their property names, types, 
 * or structures at compile-time, traditional static typing is insufficient.
 
 
 * -----------------------------------------------------------------------------------
 * * * 2. Core idea
 * -----------------------------------------------------------------------------------
 * 
 ******************* Reflection is the ability of a program to inspect, query, and interact with 
 * ***************** metadata and compiled code in the assembly at runtime. 
 * 
 * * It acts like an X-ray tool. By leveraging Upcasting and Polymorphism, 
 * you can accept any object into a generic parameter of type 'object' (the base class of 
 * everything in .NET). Once received, Reflection allows you to break open that object 
 * at runtime, dynamically scanning its fields, methods, and attributes without having 
 * any prior knowledge of its type during compilation.

 
 * -----------------------------------------------------------------------------------
 * * * 3. How it works internally
 * -----------------------------------------------------------------------------------
 * Step 1: Compilation Stage
 * When C# code is compiled into an Assembly (.dll or .exe), the compiler 
 * generates two components:
 * - IL (Intermediate Language): The actual executable instructions.
 * - Metadata: A highly organized internal database describing every type, 
 * method, property, field, parameter, and Attribute in the code.
 * 
 * * Step 2: Runtime Stage
 * When the application executes, the CLR (Common Language Runtime) loads the 
 * assembly. When you call 'obj.GetType()', the CLR queries this embedded 
 * Metadata database and exposes it through descriptive runtime objects 
 * (such as Type, FieldInfo, PropertyInfo, and MethodInfo).
 * 
 * * *Note on IDEs: This same metadata structure is what tools like IntelliSense use. 
 * When you type a dot (.) after an object, the IDE inspects the assembly's metadata 
 * at that exact moment to dynamically populate the dropdown menu with available members.
 
 * -----------------------------------------------------------------------------------
 * * * [Practical Real-World Analogy (Serialization & Attributes)]
 * -----------------------------------------------------------------------------------
 * Consider a custom serialization method that loops through a class to convert it. 
 * If a developer marks a specific field with an attribute like '[NonSerialized]' or 
 * a custom skip attribute, the serializer uses Reflection at runtime to inspect the 
 * metadata attached to that field. 
 * 
 * * It scans the structural "blueprint" of the object, identifies the presence of the 
 * attribute, and dynamically decides whether to serialize or skip that field. 
 * The serializer doesn't care what object you pass to it; it penetrates the container 
 * at runtime to extract exactly what it needs.
 
 * -----------------------------------------------------------------------------------
 * * * 5. When not to use it and common over-engineering mistakes
 * -----------------------------------------------------------------------------------
 * While powerful, Reflection introduces severe trade-offs and should be avoided in 
 * the following scenarios:
 * 
 * * - Performance-Critical Code: Reflection bypasses compiler optimizations, cuz the code
 * is handled in run-time and requires expensive metadata lookups.
 * Avoid using it inside high-frequency loops or performance-sensitive pathways.
 * 
 * * - Loss of Type Safety: Because operations happen dynamically, the compiler cannot 
 * catch typos (e.g., misspelling a method name). 
 * Errors that would normally break compilation will instead cause critical Runtime Crashes.
 * 
 * * - Misuse as an Alternative to Interfaces: A common design mistake is using Reflection 
 * to dynamically invoke methods on various classes just to avoid creating a proper 
 * Interface or abstract base class. If types are known at compile-time, always prefer 
 * explicit Polymorphism and strongly-typed architectures over dynamic Reflection.
 * =================================================================================== 
 
 
 * ===================================================================================
 * CORE SUMMARY OF REFLECTION
 * ===================================================================================
 * Reflection is fundamentally used to dynamically interact with external or unknown 
 * code at runtime without needing prior knowledge of its specific types, structures, 
 * or members at compile-time. 
 * * This entire capability is achieved by querying the self-describing 'Metadata' 
 * database embedded directly inside the compiled assembly (.dll or .exe) provided 
 * by the other developers.
 * ===================================================================================
 */