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

            Database.CheckOrCreateDatabase();
            Database.ReadFromFile();
            
            

            UI.WelcomeMessage();
            UI.CurrentQuestions(Database.QuestionCount);
            bool wantToAdd = UI.AddQuestionRequest();
            while (wantToAdd)
            {
                Database.AddQuestionToList(UI.AddQuestion());
                wantToAdd = UI.AddQuestionRequest();
            }
            Database.AddToFile();
            if (Database.QuestionCount == 0)
            {
                UI.ZeroQuestion();
                Environment.Exit(0);
            }
            bool wantToPlay = UI.GameLoop();
            while (wantToPlay)
            {
                Random number = new Random();
                bool gameRound = UI.DisplayQuestion(Database.QuestionsAndAnswers);
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