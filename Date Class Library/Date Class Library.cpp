#include <iostream>
#include "clsDate.h"
using namespace std;



int main()
{
	clsDate D1(10, 12, 2022);


	clsDate D2;

	cout << D1.IsDateBeforeDate2(D2) << endl;
	
	return 0;
}
