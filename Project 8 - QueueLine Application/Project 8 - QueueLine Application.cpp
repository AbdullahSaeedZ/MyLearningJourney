#include <iostream>
#include "clsQueueLine.h";
using namespace std;

int main()
{
    // tickets are printed as papers once issued , so printed tickets info wont be updated.
    // do menu with options later
    clsQueueLine PayBillsQueue("B0", 10);

    PayBillsQueue.IssueTicket();
    PayBillsQueue.IssueTicket();
    PayBillsQueue.IssueTicket();

    cout << "\nPay Bills Queue Info:" << endl;
    PayBillsQueue.PrintQueueInfo();

    cout << "\nTickets Info: " << endl;
    PayBillsQueue.PrintTickets();

    PayBillsQueue.PrintTicketsLineRTL();
    PayBillsQueue.PrintTicketsLineLTR();

    PayBillsQueue.ServeNextClient();
    cout << "\nPay Bills Queue Info after serving one client:" << endl;
    PayBillsQueue.PrintQueueInfo();

    cout << "\nNext Client Ticket ID: " << endl;
    cout << PayBillsQueue.WhoIsNext() << endl;

    PayBillsQueue.IssueTicket();
    PayBillsQueue.IssueTicket();
    cout << "\nPay Bills Queue Info after issuing more tickets:" << endl;
    PayBillsQueue.PrintQueueInfo();

    cout << "\nTickets Info: " << endl;
    PayBillsQueue.PrintTickets();

   


    return 0;
}

