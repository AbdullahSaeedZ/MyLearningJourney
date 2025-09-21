#include <iostream>
using namespace std;

short FindNumberAlgorhim1(short arr1[10], short Number)

{
    int n = 10;
    short pos = -1;

    for (int i = 0; i <= n; i++)
    {
        if (arr1[i] == Number)
        {
            pos = i;
        }
    }

    return pos;

}

short FindNumberAlgorhim2(short arr1[10], short Number)

{
    int n = 10;

    for (int i = 0; i <= n; i++)
    {
        if (arr1[i] == Number)
        {
            return i;
        }
    }

    return -1;

}


// even though both algorithms are O(n), but that doesnt mean they have the same speed in seconds, they will have same speed if looking for the last item in the array(with both having same number of items), but to look for
// an item somewhere in between, the second one will be faster cuz it will return once item is found



int main()
{
    short arr1[10] = { 10,20,30,40,50,60,70,80,90,100 };

    cout << FindNumberAlgorhim1(arr1, 100) << "\n";
    cout << FindNumberAlgorhim2(arr1, 100) << "\n";

    system("pause>0");
    return 0;
}