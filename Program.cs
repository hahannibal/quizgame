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
            string dataBase = ("C:\\Users\\Tamas Kiss\\source\\repos\\quizgame\\Database.txt");
            int lineCount = File.ReadLines(dataBase).Count();
            StreamWriter sw = new StreamWriter(dataBase, true, Encoding.ASCII);
            UI.WelcomeMessage();
            UI.CurrentQuestions(lineCount);
            bool wantToAdd = UI.AddQuestionRequest();
            while (wantToAdd)
            {
                var question = UI.AddQuestion();
                sw.WriteLine(question);
                wantToAdd = UI.AddQuestionRequest();
            }
            sw.Close();
        }

    }
}