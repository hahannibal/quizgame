using System.Collections.Generic;
namespace quizgame
{
    public class QuestionAndAnswer
    {
        public string Question;
        public List<string> Answers = new List<string>();
        public bool isCorrect;
        public List<QAPair> NewAnswers = new List<QAPair>();
    }

    public class QAPair
    {
        public string Answer;
        public bool isCorrect;
    }
}