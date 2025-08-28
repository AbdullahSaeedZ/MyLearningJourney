
#include <iostream>
#include "clsDate.h"
#include "clsPeriod.h"
using namespace std;


int main()
{
   
	clsPeriod P1(clsDate(1, 1, 2025), clsDate(10, 1, 2025));
	clsPeriod P2(clsDate(10, 1, 2025), clsDate(15, 1, 2025));

	

	P1.setEndDate(2, 2, 2222);

	P1.Print();

}

