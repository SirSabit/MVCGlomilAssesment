using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.Core.Repositories.Abstract
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        int Add(TEntity entity);

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> expression);

        public List<TEntity> GetAll();

        public TEntity GetBy(Expression<Func<TEntity, bool>> expression);
    }
}
