using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace quizgame
{
    public class QuestionAndAnswer : ISerializable
    {
        public string Question;
        public List<QAPair> QAPairs = new List<QAPair>();

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Question", Question);
            info.AddValue("QAPairs", QAPairs);
        }

        public void QuestionReturn(SerializationInfo info, StreamingContext context)
        {
            Question = (string)info.GetValue("Question", typeof(string));
            QAPairs = (List<QAPair>)info.GetValue("QAPairs", typeof(List<QAPair>));
        }
    }
}