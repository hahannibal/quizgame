using System;
using System.IO;
using System.Text;
using System.Linq;

namespace quizgame
{
    class Program
    {
        static void Main(string[] args)
        {
            int userScore = 0;

            Database.FileExist();

            UI.WelcomeMessage();
            UI.CurrentQuestions(Database.QuestionCount());
            bool wantToAdd = UI.AddQuestionRequest();
            while (wantToAdd)
            {
                Database.AddToDataBase(UI.AddQuestion());
                wantToAdd = UI.AddQuestionRequest();
            }
            if (Database.QuestionCount() == 0)
            {
                UI.ZeroQuestion();
                Environment.Exit(0);
            }
            bool wantToPlay = UI.GameLoop();
            while (wantToPlay)
            {
                Random number = new Random();
                bool gameRound = UI.DisplayQuestion(Database.ReadFromDataBase());
                if (gameRound)
                {
                    userScore++;
                    UI.UserWonARound(userScore);
                }
                else
                {
                    userScore--;
                    UI.UserLostARound(userScore);
                }
                
                wantToPlay = UI.GameLoop();
            }
            Database.ReadFromDataBase();
            
            
        }



    }
}