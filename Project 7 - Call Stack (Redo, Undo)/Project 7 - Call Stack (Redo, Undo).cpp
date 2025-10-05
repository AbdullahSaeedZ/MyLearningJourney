#include <iostream>
#include "clsMyString.h"
using namespace std;

int main()
{
    
    clsMyString S1;

    S1.Value = " ";
    cout << "S1 Value = " << S1.Value << endl;

    S1.Value = "A1";
    cout << "S1 Value = " << S1.Value << endl;

    S1.Value = "A2";
    cout << "S1 Value = " << S1.Value << endl;

    S1.Value = "A3";
    cout << "S1 Value = " << S1.Value << endl;



    cout << "\nUndo : " << endl;
    S1.Undo();
    cout << "S1 after undo = " << S1.Value << endl;
    
    S1.Undo();
    cout << "S1 after undo = " << S1.Value << endl;

    S1.Undo();
    cout << "S1 after undo = " << S1.Value << endl;


    cout << "\nRedo : " << endl;
    S1.Redo();
    cout << "S1 after Redo = " << S1.Value << endl;

    S1.Redo();
    cout << "S1 after Redo = " << S1.Value << endl;

    S1.Redo();
    cout << "S1 after Redo = " << S1.Value << endl;


    return 0;
}

 