#pragma once

#include <iostream>
#include <vector>
using namespace std;

class clsString
{
private:

	string _strValue;

public:

    clsString()
    {
        _strValue = "";
    }

    clsString(string str)
    {
        _strValue = str;
    }

    void setStrValue(string str)
    {
        _strValue = str;
    }

    string getStrValue()
    {
        return _strValue;
    }


    __declspec(property(get = getStrValue, put = setStrValue)) string Value;


    static void Print1stLettersOfWords(string str)
    {
        bool IsFirstLetter = true;

        for (int i = 0; i < str.size(); i++)
        {

            if (str[i] != ' ' && IsFirstLetter) // will run only if the it is first letter and it is a letter.
                cout << str[i] << endl;

            IsFirstLetter = (str[i] != ' ') ? false : true; // it will be false for all indexes till a new space comes then it will be true.

        }

    }

    void Print1stLettersOfWords()
    {
        Print1stLettersOfWords(_strValue);
    }


   static void UppercaseFirstLetters(string& str)
    {
        bool IsFirstLetter = true;

        for (int i = 0; i < str.size(); i++)
        {

            if (str[i] != ' ' && IsFirstLetter)
                str[i] = toupper(str[i]);

            IsFirstLetter = (str[i] != ' ') ? false : true;

        }

    }

   void UppercaseFirstLetters()
   {
       UppercaseFirstLetters(_strValue);
   }


    static void LowercaseFirstLetters(string& str)
    {
        bool IsFirstLetter = true;

        for (int i = 0; i < str.size(); i++)
        {

            if (str[i] != ' ' && IsFirstLetter)
                str[i] = tolower(str[i]);

            IsFirstLetter = (str[i] != ' ') ? false : true;

        }

    }

    void LowercaseFirstLetters()
    {
        LowercaseFirstLetters(_strValue);
    }


    static string UppercaseAllString(string str)
    {
        for (int i = 0; i < str.length(); i++)
        {
            str[i] = toupper(str[i]);
        }

        return str;
    }

    string UppercaseAllString()
    {
        return UppercaseAllString(_strValue);
    }


    static string LowercaseAllString(string str)
    {
        for (int i = 0; i < str.length(); i++)
        {
            str[i] = tolower(str[i]);
        }

        return str;
    }

    string LowercaseAllString()
    {
        return LowercaseAllString(_strValue);
    }


    static char InvertLetterCase(char c)
    {
        return (isupper(c)) ? tolower(c) : toupper(c);
    }


    static string InvertAllLettersCase(string str)
    {
        for (int i = 0; i < str.length(); i++)
        {
            str[i] = InvertLetterCase(str[i]);
        }

        return str;
    }

    string InvertAllLettersCase()
   {
       return InvertAllLettersCase(_strValue);
   }


    static short CountCapitalLetters(string str)
    {
        short Count = 0;

        for (short i = 0; i < str.length(); i++)
        {
            if (isupper(str[i]))
                Count++;
        }

        return Count;
    }

    short CountCapitalLetters()
   {
       return CountCapitalLetters(_strValue);
   }


    static short CountSmallLetters(string str)
    {
        short Count = 0;

        for (short i = 0; i < str.length(); i++)
        {
            if (islower(str[i]))
                Count++;
        }

        return Count;
    }

    short CountSmallLetters()
    {
        return CountSmallLetters(_strValue);
    }


    static short CountLetterInString(string str, char Letter, bool MatchCase = true)
    {
        short Count = 0;

        for (short i = 0; i < str.length(); i++)
        {
            if (MatchCase)
            {
                if (str[i] == Letter)
                    Count++;

            }
            else
            {
                if (tolower(str[i]) == tolower(Letter))
                    Count++;
            }
        }

        return Count;
    }

    short CountLetterInString(char Letter, bool MatchCase = true)
    {
        CountLetterInString(_strValue, Letter, MatchCase);
    }
    

    static bool IsVowel(char letter)
    {
        char v = tolower(letter);
        return ((v == 'a') || (v == 'e') || (v == 'i') || (v == 'o') || (v == 'u'));
    }


    static short CountVowelInString(string str)
    {
        short count = 0;

        for (short i = 0; i < str.length(); i++)
        {
            if (IsVowel(str[i]))
                count++;
        }

        return count;
    }

    short CountVowelInString()
    {
        return CountVowelInString(_strValue);
    }


    static void PrintVowelsInString(string str)
    {
        for (int i = 0; i < str.length(); i++)
        {
            if (IsVowel(str[i]))
                cout << str[i] << "   ";
        }
    }

    void PrintVowelsInString()
    {
        PrintVowelsInString(_strValue);
    }


    static vector<string> SplitStringToVector(string str, string delim = " ")
    {
        vector<string> vWords;

        short pos = 0;
        string sWord;

        while ((pos = str.find(delim)) != string::npos)
        {
            sWord = str.substr(0, pos);

            if (sWord != "")
                vWords.push_back(sWord);

            str.erase(0, pos + delim.length());
        }

        if (str != "")
            vWords.push_back(str);

        return vWords;
    }

    vector<string> SplitStringToVector(string delim = " ")
    {
        return SplitStringToVector(_strValue, delim);
    }


    static string JoinToString(const vector<string>& vWords, string delim)
    {
        string str = "";

        for (const string& word : vWords)
        {
            str = str + word + delim;
        }

        return str.substr(0, str.length() - delim.length());
    }


    static string JoinToString(string array[], short length, string delim)
    {
        string str = "";

        for (short i = 0; i < length; i++)
        {
            str = str + array[i] + delim;
        }

        return str.substr(0, str.length() - delim.length());
    }


    static string ReverseString(string str)
    {
        vector<string> Vector = SplitStringToVector(str, " ");
        string Reversed = "";

        vector<string>::iterator itr = Vector.end();

        while (itr != Vector.begin())
        {
            itr--;

            Reversed += *itr + " ";
        }



        return Reversed.substr(0, Reversed.length() - 1);

    }

    string ReverseString()
    {
        return ReverseString(_strValue);
    }


    static string ReplaceExactWord(string str, string OldWord, string NewWord)
    {
        short pos = 0;
        while ((pos = str.find(OldWord)) != string::npos)
        {

            str = str.replace(pos, OldWord.length(), NewWord);

        }

        return str;
    }

    string ReplaceExactWord(string OldWord, string NewWord)
    {
        return ReplaceExactWord(_strValue, OldWord, NewWord);
    }


    static string ReplaceWord(string str, string OldWord, string NewWord, bool MatchCase = false)
    {
        vector<string> vWords = SplitStringToVector(str, " ");

        for (string& word : vWords)
        {
            if (MatchCase)
            {
                if (word == OldWord)
                    word = NewWord;
            }
            else
            {
                if (LowercaseAllString(word) == LowercaseAllString(OldWord))
                    word = NewWord;
            }
        }

        str = JoinToString(vWords, " ");

        return str;
    }

    string ReplaceWord(string OldWord, string NewWord, bool MatchCase = false)
    {
        return ReplaceWord(_strValue, OldWord, NewWord, MatchCase);
    }



    static string RemoveAllPunctInString(string str)
    {
        string New = "";

        for (short i = 0; i < str.length(); i++)
        {
            if (!ispunct(str[i]))
                New += str[i];

        }

        return New;
    }

    string RemoveAllPunctInString()
    {
        return RemoveAllPunctInString(_strValue);
    }


};

