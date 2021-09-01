using System.Collections.Generic;
namespace quizgame
{
    public class QuestionAndAnswer
    {
        public string Question;
        public List<QAPair> Answers = new List<QAPair>();
    }

    public class QAPair
    {
        public string Answer;
        public bool isCorrect;
    }
}