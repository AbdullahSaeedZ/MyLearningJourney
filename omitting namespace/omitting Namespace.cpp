/* Namespace is a sub segment inside a library like iostream, so we are using the library iostream and the namespace inside it which is std
then we use the things inside the spacename like cout or cin and so on.*/
// Omitting namespace is how to use the name space std and the things inside it without writing std:: everytime and write the code directly.

#include <iostream>
using namespace std; 
// this will replace the std:: allover the code

int main()

{
	cout << "I just used the namespace std which is a container that has variables, strings, functions and other  things!\n";

	return 0;

}

//newwwww