#include <iostream>
#include <string>
#include <cctype>
using namespace std;

// my solution

//void PrintStringWords(string str)
//{
//    for (int i = 0; i < str.length(); i++)
//    {
//        if (str[i] != ' ') 
//            cout << str[i];
//
//        else if (str[i + 1] != ' ')//in case there is more than 1 space 
//            cout << endl;
//    }
//}


// complex and slow solution, for practicing:

void PrintAllStringWords(string str)
{
    short pos = 0;          // position
    string sWord;           // to store a full word
    string delimeter = " ";         // A delimiter is just a character (or sequence of characters) used to separate pieces of data. in our string we chose a space to use in loop

    while ((pos = str.find(delimeter)) != string::npos)  // we assign the space index to pos variable to be a stop point, if there is no spaces in the string then loop is skipped
    {
        sWord = str.substr(0, pos);            // store the word from index 0 to the space index which is pos

        if (sWord != "")            // print the word as long as it is not empty, cuz if string has more than 1 space like (ali   faris) then the sWord will store nothing cuz of the pos variable
        cout << sWord << endl;

        str.erase(0, pos + delimeter.length());     // now erase the whole index from 0 to pos plus delimeter (cuz some times the delimeter is more thean 1 space), now ready to next round of loop
    }

    if (str != "") //when there is one word left, there will be no spaces, so the loop wont work and we still have to pring the last word, so we do it here.
        cout << str << endl;
}


int main()
{
    string str = "Abdullah    Saeed Alzahrani";
    cout << str << endl;

    cout << "\nString words are:" << endl;
    //PrintStringWords(str);
    PrintAllStringWords(str);


    return 0;
}

