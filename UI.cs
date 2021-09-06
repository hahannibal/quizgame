using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

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
            var questionAndAnswer = new QuestionAndAnswer();
            Console.WriteLine("Enter a question:");
            questionAndAnswer.Question = Console.ReadLine();
            bool wantToAdd = true;
            while (wantToAdd)
            {
                Console.Clear();
                QAPair x = new QAPair();
                Console.WriteLine("Enter an answer(right or wrong):");
                x.Answer = Console.ReadLine();
                Console.WriteLine("Is this the right answer?(y/n)");
                string isTheRightAnswer = Console.ReadLine();

                if (isTheRightAnswer == "y")
                {
                    x.isCorrect = true;
                }
                else
                {
                    x.isCorrect = false;
                }
                questionAndAnswer.QAPairs.Add(x);
                Console.WriteLine("Do you want to add more answers?(y/n)");
                string moreQuestion = Console.ReadLine();
                if(moreQuestion != "y")
                {
                    wantToAdd = false;
                }
                
                
            }
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
        public static bool OldDisplayQuestion(string path, int i)
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

        public static bool DisplayQuestion(List<QuestionAndAnswer> x)
        {
            Console.WriteLine(x[0]);
            return true;
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
        public static bool GameLoop()
        {
            Console.WriteLine("Push the SpaceBar to get a question!");
            ConsoleKeyInfo answer = Console.ReadKey();
            if (answer.Key == ConsoleKey.Spacebar)
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// Message when getting points
        /// </summary>
        /// <param name="userScore">the current score of the user</param>
        public static void UserWonARound(int userScore)
        {
            if (userScore > 10)
            {
                Console.WriteLine($"Wow! You have {userScore} points! NOOICE!");
            }
            Console.WriteLine($"Your score currently is {userScore}");
        }
        /// <summary>
        /// Message when losing a point
        /// </summary>
        /// <param name="userScore">the current score of the user</param>
        public static void UserLostARound(int userScore)
        {
            Console.WriteLine($"You lost a point and now have {userScore} points");
        }


        /// <summary>
        /// If there's no questions in the file, the game cannot be played
        /// </summary>
        public static void ZeroQuestion()
        {
            Console.WriteLine("You cannot play as I have no questions, sorry :(");
        }
    }
}
