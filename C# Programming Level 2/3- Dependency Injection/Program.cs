namespace _3__Dependency_Injection
{

    /*

    ============================================================
                        What is a Dependency?
    ============================================================

    A dependency is any object, service, or resource that a class
    needs in order to perform its work.

    Example:

        UserService needs a Database object.

        Logger needs a logging implementation. (like in logger example inside delegates lessons)

        OrderService may need an EmailService.

    If a class cannot perform its task without another object,
    that object is considered a dependency.


    ============================================================
                    Dependency Injection (DI)
    ============================================================

    What is Dependency Injection?
    -----------------------------

    Dependency Injection (DI) is a design technique where a class
    receives the objects or services it depends on from the outside
    instead of creating them itself.

    In simple terms:

    "Don't let a class create its own dependencies.
     Give those dependencies to the class from the outside."

    This makes code more flexible, easier to maintain,
    and easier to test.


    ============================================================
                The Problem Without Dependency Injection
    ============================================================

    Example:

        public class UserService
        {
            private Database _database;

            public UserService()
            {
                _database = new Database();
            }
        }

    Here, UserService creates its own Database object.

    This creates several problems:

    1. Tight coupling
       UserService is directly tied to Database.

    2. Difficult to replace implementations
       Switching to SqlDatabase, OracleDatabase, or MockDatabase
       requires modifying UserService.

    3. Difficult to test
       Tests may require a real database.

    4. Reduced flexibility
       The dependency is hardcoded inside the class.


    Relationship:

        UserService
              |
              v
          Database


    ============================================================
                    Dependency Injection Solution
    ============================================================

    Instead of creating the dependency inside the class,
    provide it from the outside.

    Example:

        public class UserService
        {
            private Database _database;

            public UserService(Database database)
            {
                _database = database;
            }
        }

    Usage:

        Database databaseToBeInjected = new Database();

        UserService userService = new UserService(databaseToBeInjected);

    Relationship:

        Database
            |
            v
        UserService

    The class now receives the dependency rather than
    creating it itself.


    ============================================================
                      Constructor Injection
    ============================================================

    Constructor Injection is the most common form of
    Dependency Injection.

    Dependencies are passed through the constructor.

    Example:

        public class UserService
        {
            private readonly Database _database;

            public UserService(Database database)
            {
                _database = database;
            }
        }

    Advantages:

    - Dependencies are required.
    - Objects are fully initialized when created.
    - Dependencies are visible and explicit.
    - Preferred approach in most applications.

    ----------------- another example of Constructor Injection from winForms ----

                                        MainForm
                                           |
                                           |  (passes Person object or info)
                                           v
                                        EditPersonForm

        This is Dependency Injection (Constructor Injection).
        The Person object is the dependency.
        It is created outside EditPersonForm and injected through the constructor,
        instead of the form creating or locating it internally.


  ============================================================
              Dependency Injection with Interfaces
   ============================================================

   This is Constructor Injection combined with polymorphism.

   The dependency being injected is NOT a concrete class,
   but an abstraction (interface).

   This is achieved through upcasting:
   a concrete implementation is treated as its interface type.

   ------------------------------------------------------------

   Example:

       public interface ILogger
       {
           void Log(string message);
       }

       public class FileLogger : ILogger
       {
           public void Log(string message)
           {
               // Save to file
           }
       }

       public class ScreenLogger : ILogger
       {
           public void Log(string message)
           {
               Console.WriteLine(message);
           }
       }

   ------------------------------------------------------------

   Injection point (Constructor Injection):

       public class UserService
       {
           private readonly ILogger _logger;  --> Holds a reference to the injected object, typically upcasted to ILogger

           public UserService(ILogger logger)
           {
               _logger = logger;
           }
       }

   ------------------------------------------------------------

   Usage (Upcasting + DI):

       ILogger logger = new FileLogger();    // FileLogger is upcasted to ILogger

       UserService service = new UserService(logger);

   ------------------------------------------------------------

   What is actually happening?

   - FileLogger is the concrete implementation.
   - ILogger is the abstraction (contract).
   - UserService depends only on the abstraction ILogger, not on any concrete implementation, then at runtime, the actual implementation (FileLogger) is executed through polymorphism
   - The real implementation is decided outside the class.

   ------------------------------------------------------------

   Result:

       UserService is independent of logging implementation -> loosely coupled
       Any ILogger implementation can be injected without
       modifying UserService.


    ============================================================
                Dependency Injection Using Delegates
    ============================================================

    Dependency Injection is not limited to classes
    and interfaces.

    A dependency can also be injected using delegates.

    Example:

        public class Logger
        {
            private readonly Action<string> _logStrategy;

            public Logger(Action<string> logStrategy)
            {
                _logStrategy = logStrategy;
            }

            public void Log(string message)
            {
                _logStrategy(message);
            }
        }

    Usage:

        Logger screenLogger = new Logger(LogToScreen);

        Logger fileLogger = new Logger(LogToFile);

    The Logger class does not know how logging is performed.
    It only executes the implementation that was provided from the outside.
    This is also a simplified example of the Strategy Design Pattern.


    ============================================================
                    Benefits of Dependency Injection
    ============================================================

    1. Loose Coupling

       Classes become less dependent on specific
       implementations.

       Before:

           UserService --> FileLogger

       After:

           UserService --> ILogger


    2. Easier Maintenance

       Implementations can be replaced without
       modifying the consuming class.


    3. Better Testability

       Fake or mock dependencies can be injected
       during testing.


    4. Improved Flexibility

       Different implementations can be supplied
       at runtime.


    ============================================================
                Types of Dependency Injection
    ============================================================

    1. Constructor Injection

        public UserService(ILogger logger)
        {
            _logger = logger;
        }

    Most common and recommended.


    2. Property Injection

        public ILogger Logger { get; set; }

    Dependency is assigned through a property.


    3. Method Injection

        public void Process(ILogger logger)
        {
        }

    Dependency is supplied through a method parameter.


    ============================================================
                            Summary
    ============================================================

    Dependency Injection (DI) is a technique where a class
    receives its dependencies from the outside instead of
    creating them internally.

    Main goals:

    - Reduce coupling.
    - Increase flexibility.
    - Improve maintainability.
    - Simplify testing.

    A good rule to remember:

    "A class should focus on using its dependencies,
     not creating them."

    see this : https://www.youtube.com/watch?v=ttza41X-O6k
*/

}
