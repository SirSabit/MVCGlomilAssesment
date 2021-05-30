using Glomil.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.BLL.Abstract
{
    public interface IQuestionAnswerBLL
    {
        public List<QuestionAnswer> GetAllQuestions();
        public void AddQuestion(QuestionAnswer question);
    }
}
