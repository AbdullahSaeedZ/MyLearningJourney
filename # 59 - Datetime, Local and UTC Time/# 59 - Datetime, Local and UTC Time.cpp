#pragma warning(disable : 4996)
#include <iostream>
#include <ctime>

// using pointers here cuz the library is from language C , there was no strings and that is why we use pointers to print chars as a string.

using namespace std;

int main() {

    // time_t is a special data type for storing time values.
    // time(0) returns the current time as the number of seconds since January 1, 1970 (the Epoch).
    // So 'currentTime' now holds a large integer value representing "seconds since 1970".

    time_t currentTime = time(0);

    // now that big number is useless, cant say now the time is 12138173897 seconds !!
    // so we need to convert it into a useful form.
    // ctime() takes address of the numbers from time_t and convert them into an array of char (string) in an ordered time form.
    // now the pointer of char array is ready, by printing the pointer localTimeStr , in normal cases it will print address, but with char pointers (programmed this way) it will print the full array of char.

    char* localTimeStr = ctime(&currentTime);
    cout << "Local date and time is: " << localTimeStr << endl;


    // now the function gmtime() will take address of time_t which is seconds till now, then returns it to a structure that has members like hours, days..etc, but in the UTC (universal time)
    // so now we have gmtTimestruct filled will detailed UTC time as a structure.

    tm* gmtTimeStruct = gmtime(&currentTime);

    // asctime() will take the structure and return a char array to store in the char pointer utcTimeStr, then print the pointer which will print a string instead of address.
    // char pointer points to address of first char in the array, then as it is programmed it will print the full array elements(just with char pointers). 

    char* utcTimeStr = asctime(gmtTimeStruct);
    cout << "UTC date and time is: " << utcTimeStr << endl;

    return 0;
}