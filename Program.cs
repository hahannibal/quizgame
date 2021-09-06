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
            int count = 0;
            while (wantToPlay)
            {
                if (count == Database.QuestionCount)
                {
                    Console.WriteLine("As I ran out of questions, we have to stop now!");
                    break;
                }
                bool gameRound = UI.DisplayQuestion(Database.QuestionsAndAnswers,count);
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
                count++;
                wantToPlay = UI.GameLoop();
            }
                  
        }



    }
}