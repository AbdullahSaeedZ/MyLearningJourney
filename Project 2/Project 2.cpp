#include <iostream>
#include <cstdlib>    
#include <ctime>
#include <string>
using namespace std;

enum enLevel {Easy = 1, Med = 2, Hard = 3, MixLevel = 4};

enum enOperation {Add = 1, Sub = 2, Mult = 3, Div = 4, MixOp = 5};

struct GameResults
{
    short NumberOfQuestions = 0;
    short CorrectAnswers = 0;
    short WrongAnswers = 0;
    enLevel Level;
    enOperation Operation;
};

struct QuestionNums
{
    short Num1 = 0;
    short Num2 = 0;
    short Result = 0;
    enOperation Type;
};

string Tabs(short N)
{
    string t = "\t";

    for (short Counter = 1; Counter <= N; Counter++)
    {
        t += "\t";
    }
    return t;
}

int ReadPositiveNumber(string Message)
{
    int Number = 0;
    do
    {
        cout << Message;
        cin >> Number;
    } while (Number <= 0);

    return Number;
}

short RandomNumber(short From, short To)
{
    short randNum = rand() % (To - From + 1) + From;
    return randNum;
}

QuestionNums AddQuestion(enLevel Level)
{
    short Num1 = 0, Num2 = 0, Result = 0;
    short Random = RandomNumber(0, 2);
    

    if (Level == enLevel::MixLevel)
    {
        switch (Random)
        {
        case 0: Level = enLevel::Easy; break;
        case 1: Level = enLevel::Med; break;
        case 2: Level = enLevel::Hard; break;
        }
    }

    if (Level == enLevel::Easy)
    {
        Num1 = RandomNumber(1, 10);
        Num2 = RandomNumber(1, 10);
        Result = Num1 + Num2;

            return { Num1, Num2, Result , enOperation::Add };
    }
    else if (Level == enLevel::Med)
    {
        Num1 = RandomNumber(1, 50);
        Num2 = RandomNumber(1, 50);
        Result = Num1 + Num2;

        return { Num1, Num2, Result , enOperation::Add };
    }
    else if (Level == enLevel::Hard)
    {
        Num1 = RandomNumber(50, 100);
        Num2 = RandomNumber(50, 100);
        Result = Num1 + Num2;

        return { Num1, Num2, Result , enOperation::Add };
    }
}

QuestionNums SubQuestion(enLevel Level)
{
    short Num1 = 0, Num2 = 0, Result = 0;
    short Random = RandomNumber(0, 2);

    if (Level == enLevel::MixLevel)
    {
        switch (Random)
        {
        case 0: Level = enLevel::Easy; break;
        case 1: Level = enLevel::Med; break;
        case 2: Level = enLevel::Hard; break;
        }
    }

    if (Level == enLevel::Easy)
    {
        Num1 = RandomNumber(1, 10);
        Num2 = RandomNumber(1, 10);
        Result = Num1 - Num2;

        return { Num1, Num2, Result , enOperation::Sub };
    }
    else if (Level == enLevel::Med)
    {
        Num1 = RandomNumber(1, 50);
        Num2 = RandomNumber(1, 50);
        Result = Num1 - Num2;

        return { Num1, Num2, Result , enOperation::Sub };
    }
    else if (Level == enLevel::Hard)
    {
        Num1 = RandomNumber(50, 100);
        Num2 = RandomNumber(50, 100);
        Result = Num1 - Num2;

        return { Num1, Num2, Result , enOperation::Sub };
    }
}

QuestionNums MultQuestion(enLevel Level)
{
    short Num1 = 0, Num2 = 0, Result = 0;
    short Random = RandomNumber(0, 2);

    if (Level == enLevel::MixLevel)
    {
        switch (Random)
        {
        case 0: Level = enLevel::Easy; break;
        case 1: Level = enLevel::Med; break;
        case 2: Level = enLevel::Hard; break;
        }
    }

    if (Level == enLevel::Easy)
    {
        Num1 = RandomNumber(1, 10);
        Num2 = RandomNumber(1, 10);
        Result = Num1 * Num2;

        return { Num1, Num2, Result , enOperation::Mult };
    }
    else if (Level == enLevel::Med)
    {
        Num1 = RandomNumber(1, 50);
        Num2 = RandomNumber(1, 50);
        Result = Num1 * Num2;

        return { Num1, Num2, Result , enOperation::Mult };
    }
    else if (Level == enLevel::Hard)
    {
        Num1 = RandomNumber(50, 100);
        Num2 = RandomNumber(50, 100);
        Result = Num1 * Num2;

        return { Num1, Num2, Result , enOperation::Mult };
    }
}

QuestionNums DivQuestion(enLevel Level)
{
    short Num1 = 0, Num2 = 0, Result = 0;

    short Random = RandomNumber(0, 2);

    if (Level == enLevel::MixLevel)
    {
        switch (Random)
        {
        case 0: Level = enLevel::Easy; break;
        case 1: Level = enLevel::Med; break;
        case 2: Level = enLevel::Hard; break;
        }
    }

    if (Level == enLevel::Easy)
    {
        Num1 = RandomNumber(1, 10);
        Num2 = RandomNumber(1, 10);
        Result = Num1 / Num2;

        return { Num1, Num2, Result , enOperation::Div};
    }
    else if (Level == enLevel::Med)
    {
        Num1 = RandomNumber(1, 50);
        Num2 = RandomNumber(1, 50);
        Result = Num1 / Num2;

        return { Num1, Num2, Result , enOperation::Div };
    }
    else if (Level == enLevel::Hard)
    {
        Num1 = RandomNumber(50, 100);
        Num2 = RandomNumber(50, 100);
        Result = Num1 / Num2;

        return { Num1, Num2, Result , enOperation::Div };
    }
}

QuestionNums GenerateQuestion(enLevel Level, enOperation Operation)
{
    short Random = RandomNumber(1, 4);


    if (Operation == enOperation::MixOp)
    {
        switch (Random)
        {
        case 1: Operation = enOperation::Add; break;
        case 2: Operation = enOperation::Sub; break;
        case 3: Operation = enOperation::Mult; break;
        case 4: Operation = enOperation::Div; break;
        }
    }

    if (Operation == enOperation::Add)
    {
        return AddQuestion(Level);
    }
    else if (Operation == enOperation::Sub)
    {
        return SubQuestion(Level);
    }
    else if (Operation == enOperation::Mult)
    {
        return MultQuestion(Level);
    }
    else
        return DivQuestion(Level);
}

char OperationChar(enOperation Type)
{
    char arrOperation[5] = { '+', '-', '*', '/' , 'M'};
    return arrOperation[Type - 1];
}

void ShowQuestion(QuestionNums Question)
{
    cout << endl;
    cout << Question.Num1 << endl;
    cout << Question.Num2 << " " << OperationChar(Question.Type) << endl;
    cout << "________________" << endl;
}

bool ShowAnswer(QuestionNums Question)
{
    int UserAnswer = ReadPositiveNumber("Your Answer?  ");

    if (Question.Result == UserAnswer)
    {
        system("color 2F");
        cout << "Correct Answer!\n" << endl;
        return true;
    }
    else
    {
        cout << '\a';
        system("color 4F");
        cout << "Wrong Answer!\n" << endl;
        return false;
    }
}

short ReadLevel()
{
    short Number = 0;

    cout << "Enter Question Level [1]Easy, [2]Med, [3]Hard, [4]Mix : ";
    cin >> Number;

        return Number;
}

short ReadOT()
{
    short Number = 0;
    
    cout << "Enter Operation type [1]Add, [2]Sub, [3]Mult, [4]Div, [5]Mix : ";
    cin >> Number;

    return Number;
}

GameResults PlayGame(short HowManyQuestions)
{
    
    enLevel Level;
    enOperation OT;
    QuestionNums Question;

    Level = (enLevel)ReadLevel();
    OT = (enOperation)ReadOT();

    short CorrectAnswers = 0, WrongAnswers = 0;

    for (short QuestionNumber = 1; QuestionNumber <= HowManyQuestions; QuestionNumber++)
    {
        cout << "Question [" << QuestionNumber << "/" << HowManyQuestions << "]" << endl;
       
        Question = GenerateQuestion(Level, OT);

        ShowQuestion(Question);
        
        if (ShowAnswer(Question))
            CorrectAnswers++;
        else
            WrongAnswers++;
    }

    

    return { HowManyQuestions, CorrectAnswers, WrongAnswers, Level, OT };
}

void ShowFinalResults(GameResults GameResult)
{
    cout << Tabs(3) << "____________________________________________" << endl;

    if (GameResult.CorrectAnswers > GameResult.WrongAnswers)
    {
        system("color 2F");
        cout << Tabs(3) << "You Passed the test!" << endl;
    }
    else if (GameResult.CorrectAnswers < GameResult.WrongAnswers)
    {
        cout << '\a';
        system("color 4F");
        cout << Tabs(3) << "You Failed the test!" << endl;
    }
    else
    {
        system("color 6F");
        cout << "Draw!" << endl;
    }
    cout << Tabs(3) << "____________________________________________" << endl;
    cout << Tabs(3) << "Number of Question       : " << GameResult.NumberOfQuestions << endl;
    cout << Tabs(3) << "Questions Level          : " << GameResult.Level << endl;
    cout << Tabs(3) << "OpType                   : " << OperationChar(GameResult.Operation) << endl;
    cout << Tabs(3) << "Number of correct answers: " << GameResult.CorrectAnswers << endl;
    cout << Tabs(3) << "Number of wrong answers  : " << GameResult.WrongAnswers << endl;
    cout << Tabs(3) << "____________________________________________" << endl;

}

string ReadPlayAgain(string Message)
{
    string Answer = "";
    do
    {
        cout << Message;
        cin >> Answer;
    } while ((Answer != "Y" && Answer != "y") && (Answer != "N" && Answer != "n"));

    return Answer;
}

void StartGame()
{
    string PlayAgain = "Y";

    do
    {
        system("cls");
        system("color 0F");

        GameResults GameResults = PlayGame(ReadPositiveNumber("How many questions do you want to answer? : "));

        ShowFinalResults(GameResults);

        PlayAgain = ReadPlayAgain("\t\t\t\tDo you want ro play again? Y/N?  ");

    } while (PlayAgain == "Y" || PlayAgain == "y");

}



int main()
{
    srand((unsigned)time(NULL));
    
    StartGame();

    return 0;
}

