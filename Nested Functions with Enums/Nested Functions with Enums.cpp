#include <iostream>
using namespace std;

enum enWeekDays {Sunday=1, Monday=2 ,Tuesday=3 , Wednesday=4, Thursday=5 , Friday=6, Saturday=7};

void ShowMenu()               //procedure for only showing menu
{
    cout << "*************" << endl;
    cout << "  Week Days" << endl;
    cout << "*************" << endl;
    cout << "1: Sunday" << endl;
    cout << "2: Monday" << endl;
    cout << "3: Tuesday" << endl;
    cout << "4: Wednesday" << endl;
    cout << "5: Thursday" << endl;
    cout << "6: Friday" << endl;
    cout << "7: Saturday" << endl;
    cout << "*************" << endl;
    cout << "choose a day: " << endl;
}

enWeekDays ReadDay()        //this function is only to read input the save (return) the result in the function as a numerator.
{
    short int Input;
    cin >> Input;
    return (enWeekDays)Input;  // the function returned the iputted value as a numerator
}

string PrintDay(enWeekDays Input)    //i will put the erlier function with saved numerator here then this function will read the saved numerator then the switch will check it.
{
    
    switch (Input)
    {
        case enWeekDays::Sunday:   //since this is a function so there must be a returned value and in our case it will return in string if condition is met.
            return "Sunday";
            break;
        case enWeekDays::Monday:
            return "Monday";
            break;
        case enWeekDays::Tuesday:
            return "Tuesday";
            break;
        case enWeekDays::Wednesday:
            return "Wednesday";
            break;
        case enWeekDays::Thursday:
            return "Thursday";
            break;
        case enWeekDays::Friday:
            return "Friday";
            break;
        case enWeekDays::Saturday:
            return "Saturday";
            break;
        default: return "Wrong Number, Try Again!";

    }
}



int main()
{
    ShowMenu(); // only showing menu
    cout << "the chosen day is " << PrintDay(ReadDay()) << endl; // print function will run read function first, then will take its value and run the swich and return will string.

    return 0;
}

