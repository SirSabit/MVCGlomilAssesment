using Glomil.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
