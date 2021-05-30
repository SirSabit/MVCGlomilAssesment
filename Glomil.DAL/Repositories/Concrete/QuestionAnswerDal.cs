using Glomil.Core.Repositories.Concrete;
using Glomil.DAL.Repositories.Abstract;
using Glomil.Entities.Entities;

namespace Glomil.DAL.Repositories.Concrete
{
    public class QuestionAnswerDal : Repository<QuestionAnswer, GlomilDbContext>, IQuestionAnswerDal
    {
        private GlomilDbContext context;
        public QuestionAnswerDal(GlomilDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
