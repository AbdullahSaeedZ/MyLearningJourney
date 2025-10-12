#include <iostream>
#include <map>
using namespace std;

int main() 
{
    // Declare a map with string keys and int values
    // we can do :
    // map<string, unsigned short> studentsGrades = { {"Ahmad", 90}, {"Salem", 80}, {"Mona", 97}, {"Sara", 100} };

    //or :

    map<string, int> studentGrades;
    // Inserting grades for three students
    studentGrades["Ali"] = 77;     // Assigning a grade of 77 to the student "Ali"
    studentGrades["Ahmed"] = 85;   // Assigning a grade of 85 to the student "Ahmed"
    studentGrades["Fadi"] = 95;    // Assigning a grade of 95 to the student "Fadi"


    // Printing all map values
    cout << "\nPrinting all map values..\n\n";

    // Iterating over the map, the pair will be prnited based on their key ascending oeder. not which was first added!
    // Note that sorting is case-sensitive which means that upper - case letters comes before lower - case letters, because of their positions in the ASCII Table.

    for (const auto& pair : studentGrades) // we can write: for (const pair<string, float>& pair : studentGrades) but auto does th same.
    {
        cout << "Student: " << pair.first << ", Grade: " << pair.second << endl;
    }                              //key                       //value


    // Finding the grade for a specific student
    string studentName = "Fadi";
    if (studentGrades.find(studentName) != studentGrades.end()) 
    {
        cout << studentName << "'s grade: " << studentGrades[studentName] << endl;
    }
    else 
    {
        cout << "Grade not found for " << studentName << endl;
    }


    return 0;
}


/*
What is map ?
In C++, a std::map is a container in the Standard Template Library(STL) that represents an associative array.
It is a sorted associative container that contains key - value pairs, where each key must be unique.
The elements are ordered based on the keys, which are sorted in ascending order by default.
This sorting allows for efficient search, insertion, and deletion of elements.

Here are some key characteristics and features of std::map :

-Associative Container :
std::map is an associative container, meaning it associates a key with a value.

-Sorted Order :
The elements are sorted based on the keys.By default, sorting is done using the < operator.

-Unique Keys :
Each key in a std::map must be unique.If you attempt to insert a key that already exists, the associated value will be updated.

-Balanced Binary Search Tree :
Internally, std::map is usually implemented as a balanced binary search tree, such as a red - black tree.This ensures efficient search, insertion, and deletion operations.

-Efficient Lookups :
Searching for an element based on its key has a time complexity of O(log n), making it efficient for large datasets.

-Dynamic Sizing :
std::map dynamically adjusts its size as elements are inserted or removed.

-Key - Value Pairs :
Each element in the map is a key - value pair, where the key and value can be of any data type.

-Iterator Support :
It provides iterators that allow you to traverse the elements in sorted order.

In many programming languages, the concept of a map is similar to that of a dictionary.
Both represent an associative container that stores key - value pairs, allowing efficient retrieval, insertion, and deletion of elements based on their keys.
*/