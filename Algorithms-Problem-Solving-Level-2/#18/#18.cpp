#include <iostream>
#include <string>
using namespace std;

string ReadName(string Message)
{
    string Name;
    
        cout << Message << endl;
        cin.ignore(0, '\n');
        getline(cin, Name);

        return Name;
}

int ReadKey(string Message)
{
    int Key;

    cout << Message << endl;
    cin >> Key;

    return Key;
}

string Encryption(string Name, int EncryptionKey)
{
    

    for (int Counter = 0; Counter < Name.length(); Counter++)
    {
        Name[Counter] = char((int)Name[Counter] + EncryptionKey);
    }

    return Name;
}

string Decryption(string Name, int EncryptionKey)
{
    

    for (int Counter = 0; Counter < Name.length(); Counter++)
    {
        Name[Counter] = char((int)Name[Counter] - EncryptionKey);
    }

    return Name;

}

void PrintEncryption(string Name, int Key)
{
    cout << "string before encryption: " << Name << endl;
    cout << "string after encryption: " << Encryption(Name, Key) << endl;
    cout << "string after decryption: " << Decryption(Encryption(Name, Key), Key) << endl;   //here we have to give him the name already encrypted otherwise he will take NAME from the parameter unencrypted.
}


int main()
{
    string Name = ReadName("Enter a string to encrypt:");
    int Key = ReadKey("Enter a key for encryption: ");

    PrintEncryption(Name, Key);

    return 0;
}

