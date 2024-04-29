using _01.DBTransactions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DBTransactions.Data.Config
{
    public class GLTransactionConfiguration : IEntityTypeConfiguration<GLTransaction>
    {
        public void Configure(EntityTypeBuilder<GLTransaction> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Notes)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.Amount)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(t => t.CreatedAt).IsRequired();

            builder.ToTable("GLTransactions");
        }
    }
}
