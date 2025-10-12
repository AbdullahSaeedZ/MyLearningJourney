#include <iostream>
using namespace std;

enum Teachers {Nafesah, Akkas, Wasq, Badr }; // inside are called enumerators and giving values by default starting from 0 and we can assign any value if desired
enum Semester {First , Second };
enum Degree {Bacholar , Master , Diploma };
enum Major {Ecommerce , CS , IT , Accounting };
// default values are 0, 1, 2, 3 

int main()
{
    
    Teachers FirstTeacher;
    Major FTmajor; 
    Degree FTdegree;
    Semester FTsemester;

    Teachers SecondTeacher;
    Major SCmajor;
    Degree SCdegree;
    Semester SCsemester;

    FirstTeacher = Teachers::Akkas; // Akkas is assigned a value of 1 , so this variable now contains the value of 1 not a string of Akkas
    FTdegree = Degree::Master;
    FTmajor = Major::Accounting;
    FTsemester = Semester::First;

    SecondTeacher = Teachers::Badr;
    SCdegree = Degree::Master;
    SCmajor = Major::Ecommerce;
    SCsemester = Semester::Second;

    // the variables now will be printed in numbers as they were assigned, not string. this is just to understand how it works, later we will use it correctly.
    cout << "my teacher is " << FirstTeacher << " and has a " << FTdegree << " in " << FTmajor << endl;





    return 0;
}


