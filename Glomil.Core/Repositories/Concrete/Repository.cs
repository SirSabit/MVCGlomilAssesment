using Glomil.Core.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.Core.Repositories.Concrete
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
       where TEntity : class, IEntity
       where TContext : DbContext
    {

        private TContext context;
        public Repository(TContext context)
        {
            this.context = context;
        }
        public int Add(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
            return context.SaveChanges();
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return expression == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(expression).ToList();
        }
    }
}
