using Glomil.Entities.Entities;
using System.Collections.Generic;

namespace Glomil.BLL.Abstract
{
    public interface IQuestionAnswerBLL
    {
        public List<QuestionAnswer> GetAllQuestions();
        public void AddQuestion(QuestionAnswer question);
    }
}
