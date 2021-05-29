using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.DAL
{
    public class GlomilDbContext:DbContext
    {
        public GlomilDbContext(DbContextOptions<GlomilDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GlomilDbContext).Assembly);
        }

       

    }
}
