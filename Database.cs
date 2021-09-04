using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

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
            string x = "Database.xml";
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
            XmlDocument doc = new XmlDocument();
            doc.Load(DataBaseName());

            XmlElement root = doc.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName("Question");
            int i = elemList.Count;
            return i;
        }

        /// <summary>
        /// Adding questions and answers to the Database
        /// </summary>
        /// <param name="questionAndAnswers">Question and answers list</param>
        public static void AddToDataBase(QuestionAndAnswer questionAndAnswers)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(QuestionAndAnswer));
            using (TextWriter tw = new StreamWriter(DataBaseName())) 
            {
                serializer.Serialize(tw, questionAndAnswers);
            };
        }
        /// <summary>
        /// Reading the database and turning it back to objects
        /// </summary>
        /// <returns>Question and Answers object</returns>
        public static QuestionAndAnswer ReadFromDataBase()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(QuestionAndAnswer));
            TextReader reader = new StreamReader(DataBaseName());
            object obj = deserializer.Deserialize(reader);
            QuestionAndAnswer questionAndAnswer = (QuestionAndAnswer)obj;
            reader.Close();
            return questionAndAnswer;
        }


    }
}
