using Glomil.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.DAL.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(40).IsRequired();
            builder.Property(x => x.NickName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(50).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired();
        }
    }
}
