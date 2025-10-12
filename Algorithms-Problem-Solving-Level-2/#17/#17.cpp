#include <iostream>
using namespace std;


string ReadPassword(string Message)
{
    string Password = " ";
    
    
        cout << Message << endl;
        cin >> Password;
    
    return Password;
}

void CheckPassword(string Password)
{
    string Word = "";

    int Trial = 0;

    for (int L1 = 65; L1 <= 90; L1++)
    {
        for (int L2 = 65; L2 <= 90; L2++)
        {
            for (int L3 = 65; L3 <= 90; L3++)
            {
                
                Word.append(1, char(L1));
                Word.append(1, char(L2));
                Word.append(1, char(L3));

                Trial++;

                cout << "Trial [" << Trial << "] : " << Word << endl;

                if (Password == Word)
                {
                    cout << "Password is " << Word << endl;
                    cout << "Found after " << Trial << " trials" << endl;
                    return;
                }
                
                Word = "";  

                

                
            }
        }
    }

    
}



int main()
{

    CheckPassword(ReadPassword("Enter a password in 3 letters (Uppercase):"));

	return 0;
}
