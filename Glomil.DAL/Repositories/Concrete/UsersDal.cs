using Glomil.Core.Repositories.Concrete;
using Glomil.DAL.Repositories.Abstract;
using Glomil.Entities.Entities;

namespace Glomil.DAL.Repositories.Concrete
{
    public class UsersDal : Repository<Users, GlomilDbContext>, IUsersDal
    {
        private GlomilDbContext context;
        public UsersDal(GlomilDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
