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
            UI.CurrentQuestions();
            bool wantToAdd = UI.AddQuestionRequest();
            while (wantToAdd)
            {
                Database.UpdateDatabase();
                wantToAdd = UI.AddQuestionRequest();
            }
            bool wantToPlay = UI.GameLoop();
            while (wantToPlay)
            {
                Random number = new Random();
                bool gameRound = UI.DisplayQuestion(Database.DataBaseName(), number.Next(0,10));
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