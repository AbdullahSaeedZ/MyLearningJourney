/*

Data Providers : 
مجموعة كلاسات مسؤولة عن التواصل مع قواعد البيانات
خاص بها Data Provider كل قاعدة بيانات لديها 
فيه 4 أدوات أساسية Data provider وكل 
(Connection, Command, DataReader, DataAdapter)

ADO.NET (ActiveX Data Objects for .NET) is a data access technology provided by Microsoft as part of the .NET Framework.
It includes a set of data providers that enable developers to connect to and interact with different types of databases and data sources.
Here are some commonly used data providers in ADO.NET:

Data provider is used to connect to the database, execute commands and retrieve the record. 
It is lightweight component with better performance. It also allows us to place the data into DataSet to use it further in our application.

The .NET Framework provides the following data providers that we can use in our application:

 -  System.Data.SqlClient (SQL Server):
    This data provider is specifically designed for Microsoft SQL Server databases.
    It provides classes like SqlConnection, SqlCommand, SqlDataAdapter, and SqlDataReader to establish
    connections, execute commands, and retrieve data from SQL Server databases.

-   System.Data.OracleClient (Oracle):
    This data provider allows connectivity to Oracle databases.
    It provides classes such as OracleConnection, OracleCommand, OracleDataAdapter, and OracleDataReader to work with Oracle databases.
 
-   System.Data.MySql(MySql):
    This data provider allows connectivity to MySql databases.


the following data providers are generic, if a database has no specific provider then those are used:
-   System.Data.OleDb (OLE DB) windows only :
    OleDB (Object Linking and Embedding Database)
    This data provider allows access to various databases through the OLE DB technology.
    OLEDB is a Microsoft technology and is primarily used on Windows platforms.
    It supports a wide range of databases, including Microsoft Access, Oracle, MySQL, and more.
    It provides classes like OleDbConnection, OleDbCommand, OleDbDataAdapter, and OleDbDataReader for interacting with OLE DB data sources.

-   System.Data.Odbc (ODBC) cross-platform :
    ODBC (Open Database Connectivity) .
    This data provider enables connectivity through the ODBC (Open Database Connectivity) standard.
    ODBC is a widely adopted standard for accessing databases and is supported on various platforms, including Windows, macOS, and Linux.
    It supports databases that comply with the ODBC standard, such as Microsoft SQL Server, Oracle, MySQL, and others.
    It provides classes like OdbcConnection, OdbcCommand, OdbcDataAdapter, and OdbcDataReader for working with ODBC data sources.



Entity Framework (EF):
Entity Framework is an ORM (Object-Relational Mapping) framework provided by Microsoft as part of ADO.NET.
It allows developers to work with databases using a high-level object-oriented API.
Entity Framework supports multiple database providers, including SQL Server, Oracle, MySQL, and more, through the 
use of provider-specific DbContext and DbSet classes.


These are some of the data providers available in ADO.NET. The choice of data provider depends on the specific
database system you are working with and the requirements of your application. ADO.NET provides a consistent programming model 
for accessing and manipulating data from various data sources.



see pdf