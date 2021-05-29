﻿using Glomil.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glomil.DAL.Configurations
{
    public class QuestionAnswerConfiguration : IEntityTypeConfiguration<QuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<QuestionAnswer> builder)
        {
            builder.Property(x => x.Question).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Answer).IsRequired();
            builder.Property(x => x.UserId).IsRequired();
        }
    }
}
