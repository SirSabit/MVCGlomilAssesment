using Glomil.BLL.Abstract;
using Glomil.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.BLL.Concrete
{
  public  class QuestionAnswerBLL:IQuestionAnswerBLL
    {
        private IQuestionAnswerDal answerDal;

        public QuestionAnswerBLL(IQuestionAnswerDal answerDal)
        {
            this.answerDal = answerDal;
        }

    }
}
