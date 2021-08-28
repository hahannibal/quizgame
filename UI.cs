using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizgame
{
    class UI
    {
        /// <summary>
        /// Simple welcome message
        /// </summary>
        public static void WelcomeMessage()
        {
            Console.WriteLine("Hello! This is a quiz game, let's do some smartening!");
        }

        /// <summary>
        /// Requesting a question and correct/incorrect answers from a user
        /// </summary>
        /// <returns>question and answers</returns>
        public static QuestionAndAnswer AddQuestion()
        {
            Console.WriteLine("Enter a question:");
            var questionAndAnswer = new QuestionAndAnswer();
            questionAndAnswer.Question = Console.ReadLine();
            Console.WriteLine("Enter the correct answer:");
            questionAndAnswer.CorrectAnswer = Console.ReadLine();
            Console.WriteLine("Enter an incorrect answer:");
            questionAndAnswer.IncorrectAnswer1 = Console.ReadLine();
            Console.WriteLine("Enter a second incorrect answer:");
            questionAndAnswer.IncorrectAnswer2 = Console.ReadLine();
            Console.WriteLine("Enter a third incorrect answer:");
            questionAndAnswer.IncorrectAnswer3 = Console.ReadLine();
            Console.Clear();
            return questionAndAnswer;
        }

        /// <summary>
        /// Displaying the number of questions in the system
        /// </summary>
        /// <param name="count">number of questions</param>
        public static void CurrentQuestions(int count)
        {
            Console.WriteLine($"There is {count} questions in my database!");
        }
        /// <summary>
        /// Ask the user if he wants to add a new question to the database
        /// </summary>
        /// <returns>Bool; y = true, else = false</returns>
        public static bool AddQuestionRequest()
        {
            Console.WriteLine("Do you want to add a question to my database?(y/n)");
            string i = Console.ReadLine();
            if (i == "y")
            {
                return true;
            }
            return false;
        }
    }
}
