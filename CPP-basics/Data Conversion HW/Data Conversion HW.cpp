#include <iostream>
#include <string>
using namespace std;

int main()
{
    string Str1 = "43.22";
    int Int1;
    float Flo1;
    double Doub1;

    Int1 = stoi(Str1);
    cout << Int1 << endl;

    Flo1 = stof(Str1);
    cout << Flo1 << endl;

    Doub1 = stod(Str1);
    cout << Doub1 << endl;

    cout << "================" << endl;

    int N1 = 20;
    int N2 = 33.5;
    float N3 = 55.23;

    string N1String;
    string N2String;
    string N3String;
    int N3Int;

    N1String = to_string(N1);
    cout << N1String << endl;

    N2String = to_string(N2);
    cout << N2String << endl;

    N3String = to_string(N3);
    cout << N3String << endl;

    N3Int = int(N3);
    cout << N3Int << endl;




    return 0;
}

