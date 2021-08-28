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
            int lineCount = File.ReadLines("C:\\Users\\Tamas Kiss\\source\\repos\\quizgame\\Database.txt").Count();
            StreamWriter sw = new StreamWriter("C:\\Users\\Tamas Kiss\\source\\repos\\quizgame\\Database.txt", true, Encoding.ASCII);
            UI.WelcomeMessage();
            UI.CurrentQuestions(lineCount);
            bool wantToAdd = UI.AddQuestionRequest();
            while (wantToAdd)
            {
                var question = UI.AddQuestion();
                sw.WriteLine(question.Question + ", " + question.CorrectAnswer + ", " + question.IncorrectAnswer1 + ", " + question.IncorrectAnswer2 + ", " + question.IncorrectAnswer3);
                wantToAdd = UI.AddQuestionRequest();
            }
            sw.Close();
        }

    }
}