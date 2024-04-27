﻿
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Config
{
    internal class CoporateConfiguration : IEntityTypeConfiguration<Corporate>
    {
        public void Configure(EntityTypeBuilder<Corporate> builder)
        {
            builder.ToTable("Coporates");
        }
    }
}
