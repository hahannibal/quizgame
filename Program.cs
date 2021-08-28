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
            string dataBase = Path.Combine(Directory.GetCurrentDirectory(), "Database.txt");
            if ((File.Exists(dataBase)) == false)
            {
                using (File.Create(dataBase)); // without "using" the code fails at linecount. why?
            }
            int lineCount = File.ReadLines(dataBase).Count();
            UI.WelcomeMessage();
            UI.CurrentQuestions(lineCount);
            bool wantToAdd = UI.AddQuestionRequest();
            while (wantToAdd)
            {
                UpdateDatabase(dataBase);
                lineCount++;
                wantToAdd = UI.AddQuestionRequest();
            }
            bool wantToPlay = UI.GameLoop();
            while (wantToPlay)
            {
                Random number = new Random();
                bool gameRound = UI.DisplayQuestion(dataBase, number.Next(0,lineCount));
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

        /// <summary>
        /// Adding questions to the database
        /// </summary>
        /// <param name="path">path of the database</param>
        public static void UpdateDatabase(string path)
        {
            StreamWriter sw = new StreamWriter(path, true, Encoding.ASCII);
            var question = UI.AddQuestion();
            sw.WriteLine(question);
            sw.Close();
        }

    }
}