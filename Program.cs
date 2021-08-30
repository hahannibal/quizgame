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
            string dataBase = Database.DataBaseName();
            Database.FileExist();

            UI.WelcomeMessage();
            UI.CurrentQuestions(Database.QuestionCounter());
            bool wantToAdd = UI.AddQuestionRequest();
            while (wantToAdd)
            {
                Database.UpdateDatabase(dataBase);
                wantToAdd = UI.AddQuestionRequest();
            }
            bool wantToPlay = UI.GameLoop();
            while (wantToPlay)
            {
                Random number = new Random();
                bool gameRound = UI.DisplayQuestion(dataBase, number.Next(0,10));
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
            
            
        }



    }
}