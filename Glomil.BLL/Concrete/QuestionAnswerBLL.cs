using Glomil.BLL.Abstract;
using Glomil.DAL.Repositories.Abstract;
using Glomil.Entities.Entities;
using System.Collections.Generic;

namespace Glomil.BLL.Concrete
{
    public class QuestionAnswerBLL : IQuestionAnswerBLL
    {
        private IQuestionAnswerDal answerDal;

        public QuestionAnswerBLL(IQuestionAnswerDal answerDal)
        {
            this.answerDal = answerDal;
        }

        public List<QuestionAnswer> GetAllQuestions()
        {
            return answerDal.GetAll();
        }

        public void AddQuestion(QuestionAnswer question)
        {
            answerDal.Add(question);
        }
    }
}
