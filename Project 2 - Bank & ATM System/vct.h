#pragma once

#include <iostream>
#include <iomanip>
#include "str.h"
#include "in.h"
#include "rnd.h"
#include "num.h"



namespace vct
{

    void AddElementInVector(vector <int>& vNumbers)
    {
        int Number = 0;
        string Again = " ";
        do
        {
            Number = in::ReadPositiveNumber("Enter a positive number: ");
            vNumbers.push_back(Number);

            Again = in::AskY_N("Do you want keep adding? Y/N:");

        } while (Again == "Y" || Again == "y");
    }

    void PrintVectorElements(vector <int>& vNumbers)
    {

        cout << "\nvector Numbers are: " << endl;

        for (int& item : vNumbers)
        {

            printf("%04d  \n", item);
        }
    }


}