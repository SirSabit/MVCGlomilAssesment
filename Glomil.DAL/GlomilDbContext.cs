using Microsoft.EntityFrameworkCore;

namespace Glomil.DAL
{
    public class GlomilDbContext : DbContext
    {
        public GlomilDbContext(DbContextOptions<GlomilDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GlomilDbContext).Assembly);
        }



    }
}
