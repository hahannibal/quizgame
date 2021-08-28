﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        /// <summary>
        /// displaying the question and answers
        /// </summary>
        /// <param name="path">path of the database</param>
        /// <param name="i">the number of the selected line</param>
        /// <returns></returns>
        public static bool DisplayQuestion(string path, int i)
        {

            //reading the database, selecting 1 line and splitting it to parts (question and answers)
            string[] allLines = File.ReadAllLines(path);
            string selectedLine = allLines[i];
            string[] parts = selectedLine.Split(',');
            
            //storing the correct Answer
            string correctAnswer = parts[1];

            //shuffling the answers
            Random number = new Random();
            var sequence = Enumerable.Range(1, 4).OrderBy(x => number.Next()).ToArray();
            string first = parts[sequence[0]];
            string second = parts[sequence[1]];
            string third = parts[sequence[2]];
            string fourth = parts[sequence[3]];


            Console.WriteLine(parts[0]); //display of the question
            Console.WriteLine($"1: {first} ; 2: {second} ; 3: {third} ; 4: {fourth}"); //display of answers in a random sequence
            string answer = (Console.ReadLine());
            switch (answer)
            {
                case "1":
                    return CorrectOrIncorrect(first, correctAnswer);
                case "2":
                    return CorrectOrIncorrect(second, correctAnswer);
                case "3":
                    return CorrectOrIncorrect(third, correctAnswer);
                case "4":
                    return CorrectOrIncorrect(fourth, correctAnswer);
                default:
                    Console.WriteLine("As you couldn't do a simple selection, you lose.");
                    Console.WriteLine($"The correct answer was: {correctAnswer}");
                    return false;
            }
            

        }
        /// <summary>
        /// Checking the selected answer with the correct one
        /// </summary>
        /// <param name="select">Selected answer</param>
        /// <param name="correct">Correct answer</param>
        /// <returns>If the 2 is the same = true, else = false</returns>
        public static bool CorrectOrIncorrect(string select, string correct)
        {
            if (select == correct)
            {
                Console.WriteLine("You are correct!");
                return true;
            }
            Console.WriteLine($"No bueno, the correct answer was: {correct}");
            return false;
        }

        /// <summary>
        /// asking the user if he wants to play/play again
        /// </summary>
        /// <returns>y = true , else = false</returns>
        public static bool StartTheGame()
        {
            Console.WriteLine("Should we play?(y/n)");
            string i = Console.ReadLine();
            if (i == "y")
            {
                return true;
            }
            return false;

        }
    }
}
