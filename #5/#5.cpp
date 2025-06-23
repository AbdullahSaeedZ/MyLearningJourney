#include <iostream>
#include<string>
using namespace std;

string ReadString(string Message) {

    string Number;

    cout << Message << endl;
    cin >> Number;

    return Number;

}


void ReversedNumberInOrder(string Number) {


    for (int i = Number.length() - 1 ; i >= 0; i--)

        cout << Number[i] << endl;

}


int main()
{
    ReversedNumberInOrder(ReadString("Please Enter A Positive Number :\n"));
}