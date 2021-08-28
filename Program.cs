﻿using System;
using System.IO;
using System.Text;
using System.Linq;

namespace quizgame
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataBase = Path.Combine(Directory.GetCurrentDirectory(), "Database.txt");
            if ((File.Exists(dataBase)) == false)
            {
                using (File.Create(dataBase));
            }
            int lineCount = File.ReadLines(dataBase).Count();
            UI.WelcomeMessage();
            UI.CurrentQuestions(lineCount);
            bool wantToAdd = UI.AddQuestionRequest();
            while (wantToAdd)
            {
                UpdateDatabase(dataBase);               
                wantToAdd = UI.AddQuestionRequest();
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