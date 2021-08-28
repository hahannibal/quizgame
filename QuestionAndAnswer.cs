namespace quizgame
{
    public class QuestionAndAnswer
    {
        public string Question;
        public string CorrectAnswer;
        public string IncorrectAnswer1;
        public string IncorrectAnswer2;
        public string IncorrectAnswer3;

        public override string ToString()
        {
            return $"{Question}, {CorrectAnswer}, {IncorrectAnswer1}, {IncorrectAnswer2}, {IncorrectAnswer3}";
        }
    }
}