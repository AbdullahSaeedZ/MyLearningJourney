#include <iostream>
#include <cstdlib>    
#include <ctime>
#include <string>
using namespace std;

struct stGameResult
{
    short GameRounds = 0, PlayerWonTimes = 0, ComputerWonTimes = 0, DrawTimes = 0;
    string FinalWinner = "";
};

enum enTool {Stone = 1, Paper = 2, Scissors = 3};

short ReadPositiveInRangeNumber(string Message, short From, short To)
{
    int Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;

        if (cin.fail())
        {
            // if other than numbers entered system will fail.
            cin.clear();                // to clear the failure
            cin.ignore(10000, '\n');    // to ignore what was entered before, to clean the buffer
            cout << "Invalid input! Please enter a number." << endl;
            continue;
        }

    } while (Number < From || Number > To);

    return Number;
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

short RandomNumber(int From, int To)
{
    int randNum = rand() % (To - From + 1) + From;
    return randNum;
}

short ComputerChoiceFromMenu()
{
    return RandomNumber(1, 3);
}

string ToolToString(short Tool)
{
    switch (Tool)
    {
    case enTool::Paper: return "Paper";
    case enTool::Scissors: return "Scissors";
    case enTool::Stone: return "Stone";
    default: return "Unknown";
    }
}

string CalculateWinner(short UserChoice, short ComputerChoice)
{

    if (UserChoice == enTool::Paper && ComputerChoice == enTool::Stone)
    {
        system("color 2F");
        return "Player";
    }
    else if (UserChoice == enTool::Paper && ComputerChoice == enTool::Scissors)
    {
        cout << '\a';
            system("color 4F");
            return "Computer";
    }
    else if (UserChoice == enTool::Stone && ComputerChoice == enTool::Paper)
    {
        cout << '\a';
        system("color 4F");
        return "Computer";
    }
    else if (UserChoice == enTool::Stone && ComputerChoice == enTool::Scissors)
    {
        system("color 2F");
        return "Player";
    }
    else if (UserChoice == enTool::Scissors && ComputerChoice == enTool::Paper)
    {
        system("color 2F");
        return "Player";
    }
    else if (UserChoice == ComputerChoice)
    {
        system("color 6F");
        return "No Winner!!";
    }
    else
    {
        cout << '\a';
        system("color 4F");
        return "Computer";
    }
        
}

void ShowRoundResult(short RoundCount, short UserChoice, short ComputerChoice, stGameResult &FinalResult)
{
    string Winner = CalculateWinner(UserChoice, ComputerChoice);
    
    cout << "__________________Round [" << RoundCount << "] __________________" << endl;
    cout << "\nPlayer Choice: " << ToolToString(UserChoice) << endl;
    cout << "Computer Choice: " << ToolToString(ComputerChoice) << endl;
    cout << "Round Winner: " << Winner << endl;
    cout << "\n______________________________________________" << endl;

    if (Winner == "Player")
        FinalResult.PlayerWonTimes++;
    else if (Winner == "Computer")
        FinalResult.ComputerWonTimes++;
    else
        FinalResult.DrawTimes++;
}

stGameResult GamePart()
{
    short RoundWanted = ReadPositiveInRangeNumber("How many rounds to play? 1 to 10:", 1, 10);
    short UserChoice = 0;
    short ComputerChoice = 0;

    stGameResult FinalResult;
    FinalResult.GameRounds = RoundWanted;

    for (int Counter = 1; Counter <= RoundWanted; Counter++)
    {
        cout << "\nRound [" << Counter << "] begins:\n" << endl;
        UserChoice = ReadPositiveInRangeNumber("Choose from the menu: [1]:Stone , [2]:Paper , [3]:Scissors", 1, 3);
        ComputerChoice = ComputerChoiceFromMenu();

        ShowRoundResult(Counter, UserChoice, ComputerChoice, FinalResult);

        
    }

    if (FinalResult.PlayerWonTimes > FinalResult.ComputerWonTimes)
        FinalResult.FinalWinner = "Player";
    else if (FinalResult.PlayerWonTimes < FinalResult.ComputerWonTimes)
        FinalResult.FinalWinner = "Computer";
    else
        FinalResult.FinalWinner = "No Winner";

    return FinalResult;
}

void ShowFinalResult(stGameResult FinalResult)
{
    cout << "\n\t\t\t--------------------------------------------------\n" << endl;
    cout << "\t\t\t\t\t+++ G a m e  O v e r +++" << endl;
    cout << "\t\t\t--------------------------------------------------\n" << endl;
    cout << "\t\t\t______________________[Game Results]____________________\n" << endl;
    cout << "\n\t\t\tGame Rounds\t\t:" << FinalResult.GameRounds << endl;
    cout << "\n\t\t\tPlayer Won Times\t:" << FinalResult.PlayerWonTimes << endl;
    cout << "\n\t\t\tComputer Won Times\t:" << FinalResult.ComputerWonTimes << endl;
    cout << "\n\t\t\tDraw Times\t\t:" << FinalResult.DrawTimes << endl;
    cout << "\n\t\t\tFinal Winner\t\t:" << FinalResult.FinalWinner << endl;
    cout << "\n\t\t\t--------------------------------------------------\n" << endl;

    if (FinalResult.FinalWinner == "Player")
        system("color 2F");
    else if (FinalResult.FinalWinner == "Computer")
    {
        cout << '\a';
        system("color 4F");
    }
    else 
        system("color 6F");

}

void StartGame()
{
    string PlayAgain = "";

    do
    {
        system("cls");
        system("color 0F");

        ShowFinalResult(GamePart());


        PlayAgain = ReadPlayAgain("\t\t\tDo you want ro play again? Y/N?  ");

    } while (PlayAgain == "Y" || PlayAgain == "y");


}

int main()
{
    srand((unsigned)time(NULL));
   
    StartGame();

    return 0;
}
