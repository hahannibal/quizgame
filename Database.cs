using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizgame
{
    public static class Database
    {
        /// <summary>
        /// Contains the name of the Database for an easier handling
        /// </summary>
        /// <returns>The name of the database</returns>
        public static string DataBaseName()
        {
            string x = "Database.txt";
            return x;
        }
        /// <summary>
        /// Check if the Database file exists. If not, creates it.
        /// </summary>
        public static void FileExist()
        {
            if (File.Exists(DataBaseName()))
            {
                return;
            }
            var filestream = File.Create(DataBaseName());
            filestream.Close();
        }
        /// <summary>
        /// Counting the questions in the database by checking the number of lines
        /// </summary>
        /// <returns>number of questions</returns>
        public static int QuestionCount()
        {
            int i = File.ReadLines(DataBaseName()).Count();
            return i;
        }

        /// <summary>
        /// saves a line to the database
        /// </summary>
        /// <param name="x">QuestionAndAnswer object containing the new question and the answers</param>
        public static void UpdateDatabase(QuestionAndAnswer x)
        {
            StreamWriter sw = new StreamWriter(DataBaseName(), true, Encoding.ASCII);
            string answersToSave = string.Join(",", x.Answers);
            var question = x.Question + "," + answersToSave + "," + x.CorrectAnswerNumber;
            sw.WriteLine(question);
            sw.Close();
        }

       


    }
}
