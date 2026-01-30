/*


open pdf first


DO.NET has two main components that are used for accessing and manipulating data. They are as follows:

1- Data Provider:
Following are the core object of Data Providers:

A-Connection Object: It is used to establish a connection to a specific data source.
ex: it defines and establishes the connection to database, as in which base to connect to? university database? or which one? 
is it local or over the internet, and so on.


B-Command Object: It is used to execute queries to perform database operations, 
meaning this object will deal with queries and queries commands such as Insert, select and so on.



C-DataReader Object: It is used to read data from data source. The DbDataReader is a base class for all DataReader objects.
it brings back a result set for reading ONLY and forward ONLY (if we read a row in a loop, we cant go back to read previous row) 
it is fastest way to fetch data to read, no update or manipulation.
remains connection with database when fetching data, unlike DataSets





D-DataAdapter Object: Acts as a bridge between database and DataSet. It populates a DataSet and resolves updates with the data source.
The base class for all DataAdapter objects is the DbDataAdapter class.






2- DataSet:
Represents an in-memory cache of data that can store multiple
tables, relationships between tables, and constraints. It provides a
disconnected representation of the data retrieved from a data source.

brings data sets (tables and records) from a database to an XML file then disconnects from the database, 
we work offline, we can do updating and manipulation 
then once we want to reflect updates, it will connect to the database then data will be reflected.
it is slower than data reader

what makes the connection and reflects data from XML to the database ? IT IS THE DATA ADAPTER OBJECT



- best practice to not use dataSet, it has problems, but sometimes needed. better to use data readers.

-----------------------------------------------------------------------------------------------------------------

.NET Framework Data Provider for SQL Server
Data provider for SQL Server is a lightweight component. It provides better performance because it directly access SQL Server without any middle connectivity layer. In early versions, it interacts with ODBC layer before connecting to the SQL Server that created performance issues.

The .NET Framework Data Provider for SQL Server classes is located in the System.Data.SqlClient namespace. We can include this namespace in our C# application by using the following syntax.

using System.Data.SqlClient;    

This namespace contains the following important classes.

SqlConnection: It is used to create SQL Server connection. This class cannot be inherited.
SqlCommand: It is used to execute database queries. This class cannot be inherited.
SqlDataAdapter: It represents a set of data commands and a database connection that are used to fill the DataSet. This class cannot be inherited.
SqlDataReader: It is used to read rows from a SQL Server database. This class cannot be inherited.
SqlException: This class is used to throw SQL exceptions. It throws an exception when an error is occurred. This class cannot be inherited.